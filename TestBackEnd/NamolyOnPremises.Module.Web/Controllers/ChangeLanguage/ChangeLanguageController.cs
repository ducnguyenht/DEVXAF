using System;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;
using System.Globalization;

namespace NamolyOnPremises.Module.Web.Controllers.ChangeLanguage
{
    public partial class ChangeLanguageController : WindowController
    {
        public ChangeLanguageController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Windows (via the TargetXXX properties) and create their Actions.
            TargetWindowType = WindowType.Main;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
        }

        private void ChangeLanguageController_Activated(object sender, EventArgs e)
        {
            GetDefaultCulture();
            ChooseLanguage.Items.Add(new ChoiceActionItem(string.Format("English (en)", defaultCulture), defaultCulture));
            ChooseLanguage.Items.Add(new ChoiceActionItem("Tiếng Việt (vi)", "vi"));
            try
            {
                string language = ((NamolyOnPremises.Module.Web.Controllers.ChangeLanguage.ChangeLanguageController)(sender)).defaultFormattingCulture;
                if (language == "en")
                    ChooseLanguage.SelectedIndex = 0;
                else if (language == "vi")
                    ChooseLanguage.SelectedIndex = 1;
                Application.SetLanguage(language);
                Application.SetFormattingCulture(language);
            }
            catch { }
        }

        private void ChooseLanguage_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            string language = e.SelectedChoiceActionItem.Data as string;

            Application.SetLanguage(language);
            string culture = defaultCulture;
            if (language.Equals("vi"))
            {
                culture = "vi";
            }

            Application.SetFormattingCulture(culture);
        }

        private string defaultCulture;
        private string defaultFormattingCulture;

        private void GetDefaultCulture()
        {
            defaultCulture = CultureInfo.InvariantCulture.TwoLetterISOLanguageName;
            defaultFormattingCulture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }


    }
}
