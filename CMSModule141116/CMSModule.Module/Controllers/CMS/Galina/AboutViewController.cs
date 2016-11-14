using System;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using CMSModule.Module.BusinessObjects.CMS.Galina;

namespace CMSModule.Module.Controllers.CMS.Galina
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class AboutViewController : WindowController
    {
        public AboutViewController()
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
                if (e.ActionArguments.SelectedChoiceActionItem.Id == "About")
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace();
                    About obj = objectSpace.FindObject<About>(new BinaryOperator("Code", "About"));
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
