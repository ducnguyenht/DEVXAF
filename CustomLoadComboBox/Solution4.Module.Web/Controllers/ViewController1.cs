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
using DevExpress.ExpressApp.Web.Editors;
using Solution4.Module.Web.Editors;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace Solution4.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ViewController1 : ViewController
    {
        private void InitNullText(ASPxPropertyEditor propertyEditor)
        {
            if (propertyEditor.ViewEditMode == DevExpress.ExpressApp.Editors.ViewEditMode.Edit)
            {
                var t = (CustomStringEditor)propertyEditor.CurrentObject;
            }
        }
        private void propertyEditor_ControlCreated(object sender, EventArgs e)
        {
            InitNullText((CustomStringEditor)sender);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            CustomStringEditor propertyEditor = ((DetailView)View).FindItem("Anniversary") as CustomStringEditor;
            if (propertyEditor != null)
            {
                if (propertyEditor.Control != null)
                {
                    InitNullText(propertyEditor);
                }
                else
                {
                    propertyEditor.ControlCreated += new EventHandler<EventArgs>(propertyEditor_ControlCreated);
                }
            }
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ViewItem propertyEditor = ((DetailView)View).FindItem("Anniversary");
            if (propertyEditor != null)
            {
                propertyEditor.ControlCreated -= new EventHandler<EventArgs>(propertyEditor_ControlCreated);
            }
        }
        public ViewController1()
        {
            InitializeComponent();
            RegisterActions(components);
        }
    }
}
