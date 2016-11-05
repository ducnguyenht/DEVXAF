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
using CMSModule.BusinessObjects.CMS.WebStructure;
//using DetailDirectly.Module.BusinessObjects.CMS;

namespace DetailDirectly.Module.Controllers {
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class ViewController1 : WindowController {
        public ViewController1() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            ShowNavigationItemController showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
            showNavigationItemController.CustomShowNavigationItem += showNavigationItemController_CustomShowNavigationItem;
        }
        void showNavigationItemController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e) {
            try {
                if(e.ActionArguments.SelectedChoiceActionItem.Id == "SiteAEng") {
                    //SingleChoiceAction newObjectAction = GetNewObjectAction();
                    //if (newObjectAction != null) {
                    //    newObjectAction.DoExecute(new ChoiceActionItem() { Data = typeof(Issue) });
                    //}
                    //else {
                    IObjectSpace objectSpace = Application.CreateObjectSpace();
                    //Issue newIssue = objectSpace.CreateObject<Issue>();
                    var SiteA_Home_Banner = objectSpace.FindObject<PageComponent>(
                        CriteriaOperator.And(new BinaryOperator("Code", "SiteA_Home_Banner")
                    ));
                    if(SiteA_Home_Banner==null) {
                        SiteA_Home_Banner = objectSpace.CreateObject<PageComponent>();
                    }

                    var tt = ObjectSpace.CreateObject<PageComponent>();
                    tt.Code = "SiteA_Home_Banner";
                    tt.Name = "Banner";
                    tt.Page = Page.Home;
                    tt.WebSite = WebSite.SiteA;

                    //DetailView detailView = Application.CreateDetailView(objectSpace, newIssue);
                    ////var t = objectSpace.GetObjects<IssueTest>();
                    //detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.View;
                    //e.ActionArguments.ShowViewParameters.CreatedView = detailView;
                    ////}
                    //e.Handled = true;
                }
            }
            catch(Exception) {
            }

        }
    }

    //public partial class ViewController1 : WindowController
    //{
    //    public ViewController1()
    //    {
    //        TargetWindowType = WindowType.Main;
    //    }
    //    protected override void OnActivated()
    //    {
    //        base.OnActivated();
    //        ShowNavigationItemController showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
    //        showNavigationItemController.CustomShowNavigationItem += showNavigationItemController_CustomShowNavigationItem;
    //    }
    //    void showNavigationItemController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
    //    {
    //        if (e.ActionArguments.SelectedChoiceActionItem.Id == "AAA")
    //        {
    //            //SingleChoiceAction newObjectAction = GetNewObjectAction();
    //            //if (newObjectAction != null) {
    //            //    newObjectAction.DoExecute(new ChoiceActionItem() { Data = typeof(Issue) });
    //            //}
    //            //else {
    //            IObjectSpace objectSpace = Application.CreateObjectSpace();
    //            //Issue newIssue = objectSpace.CreateObject<Issue>();
    //            Issue newIssue = objectSpace.FindObject<Issue>(new BinaryOperator("Subject", "AAA"));

    //            DetailView detailView = Application.CreateDetailView(objectSpace, newIssue);
    //            var t = objectSpace.GetObjects<Issue>();
    //            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
    //            e.ActionArguments.ShowViewParameters.CreatedView = detailView;
    //            //}
    //            e.Handled = true;
    //        }
    //    }
    //    protected virtual SingleChoiceAction GetNewObjectAction()
    //    {
    //        return Frame.GetController<NewObjectViewController>().NewObjectAction;
    //    }
    //}
}
