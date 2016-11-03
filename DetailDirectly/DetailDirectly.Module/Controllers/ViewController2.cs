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
using DetailDirectly.Module.BusinessObjects.CMS;

namespace DetailDirectly.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class ViewController2 : WindowController
    {
        public ViewController2()
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
            if (e.ActionArguments.SelectedChoiceActionItem.Id == "SiteAVn")
            {
                try
                {
                    //SingleChoiceAction newObjectAction = GetNewObjectAction();
                    //if (newObjectAction != null) {
                    //    newObjectAction.DoExecute(new ChoiceActionItem() { Data = typeof(Issue) });
                    //}
                    //else {
                    IObjectSpace objectSpace = Application.CreateObjectSpace();
                    //Issue newIssue = objectSpace.CreateObject<Issue>();
                    Test newIssue = objectSpace.FindObject<Test>(new BinaryOperator("Code", "2"));

                    DetailView detailView = Application.CreateDetailView(objectSpace, newIssue);
                    //var t = objectSpace.GetObjects<IssueTest>();
                    detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.View;
                    e.ActionArguments.ShowViewParameters.CreatedView = detailView;
                    //}
                    e.Handled = true;
                }
                catch (Exception)
                {
                }

            }
        }
    }
}
