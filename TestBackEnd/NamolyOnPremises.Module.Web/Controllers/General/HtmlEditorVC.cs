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
using NamolyOnPremises.Module.Interfaces;
using DevExpress.ExpressApp.HtmlPropertyEditor.Web;

namespace NamolyOnPremises.Module.Web.Controllers.General
{
    public partial class HtmlEditorVC : ViewController<DetailView>
    {
        ASPxHtmlPropertyEditor _HtmlEditor;

        public HtmlEditorVC()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(IHtmlEditorDisableTabView);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            _HtmlEditor = null;

            if (View.Id == "HotelInfomation_DetailView")
                ApplyToViewHotelInfomation();
            else if (View.Id == "EmailTemplate_DetailView")
                ApplyToViewEmailTemplate();
        }

        void htmlEditor_ControlCreated(object sender, EventArgs e)
        {
            ASPxHtmlPropertyEditor htmlEditor = sender as ASPxHtmlPropertyEditor;
            if (htmlEditor.Editor != null)
                if (htmlEditor.Editor.Settings != null)
                {
                    htmlEditor.Editor.Settings.AllowHtmlView = false;
                    htmlEditor.Editor.Settings.AllowPreview = false;
                }
        }

        void ApplyToViewHotelInfomation()
        {
            if (View.FindItem("Userful") != null)
            {
                _HtmlEditor = View.FindItem("Userful") as ASPxHtmlPropertyEditor;
                if (_HtmlEditor != null)
                    _HtmlEditor.ControlCreated += htmlEditor_ControlCreated;
            }
            if (View.FindItem("BookingPolicy") != null)
            {
                _HtmlEditor = View.FindItem("BookingPolicy") as ASPxHtmlPropertyEditor;
                if (_HtmlEditor != null)
                    _HtmlEditor.ControlCreated += htmlEditor_ControlCreated;
            }
            if (View.FindItem("CheckInPolicy") != null)
            {
                _HtmlEditor = View.FindItem("CheckInPolicy") as ASPxHtmlPropertyEditor;
                if (_HtmlEditor != null)
                    _HtmlEditor.ControlCreated += htmlEditor_ControlCreated;
            }
            if (View.FindItem("CheckOutPolicy") != null)
            {
                _HtmlEditor = View.FindItem("CheckOutPolicy") as ASPxHtmlPropertyEditor;
                if (_HtmlEditor != null)
                    _HtmlEditor.ControlCreated += htmlEditor_ControlCreated;
            }
            if (View.FindItem("CancelPolicy") != null)
            {
                _HtmlEditor = View.FindItem("CancelPolicy") as ASPxHtmlPropertyEditor;
                if (_HtmlEditor != null)
                    _HtmlEditor.ControlCreated += htmlEditor_ControlCreated;
            }
            if (View.FindItem("ChildAndExtraBedPolicy") != null)
            {
                _HtmlEditor = View.FindItem("ChildAndExtraBedPolicy") as ASPxHtmlPropertyEditor;
                if (_HtmlEditor != null)
                    _HtmlEditor.ControlCreated += htmlEditor_ControlCreated;
            }
        }

        void ApplyToViewEmailTemplate()
        {
            if (View.FindItem("Content") != null)
            {
                _HtmlEditor = View.FindItem("Content") as ASPxHtmlPropertyEditor;
                if (_HtmlEditor != null)
                    _HtmlEditor.ControlCreated += htmlEditor_ControlCreated;
            }
        }

        protected override void OnDeactivated()
        {
            if (_HtmlEditor != null)
                _HtmlEditor.ControlCreated -= htmlEditor_ControlCreated;
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
