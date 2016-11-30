using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using CMSModule.Module.BusinessObjects.CMS.Galina;

namespace CMSModule.Module.Controllers.CMS.Galina
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ContactViewController : WindowController
    {
        public ContactViewController()
        {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ShowNavigationItemController showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
            showNavigationItemController.CustomShowNavigationItem += showNavigationItemController_CustomShowNavigationItem;
        }
        void showNavigationItemController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
        {
            try
            {
                if (e.ActionArguments.SelectedChoiceActionItem.Id == "Contact")
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace();
                    Contact obj = objectSpace.FindObject<Contact>(new BinaryOperator("Code", "Contact"));
                    DetailView detailView = Application.CreateDetailView(objectSpace, obj);
                    detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.View;
                    e.ActionArguments.ShowViewParameters.CreatedView = detailView;
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
