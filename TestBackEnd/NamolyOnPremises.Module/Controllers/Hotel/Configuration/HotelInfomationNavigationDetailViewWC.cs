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
using DevExpress.ExpressApp.Model;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration;

namespace NamolyOnPremises.Module.Controllers.Hotel.Configuration
{
    public partial class HotelInfomationNavigationDetailViewWC : WindowController
    {
        public HotelInfomationNavigationDetailViewWC()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Windows (via the TargetXXX properties) and create their Actions.
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target Window.
            try
            {
                Frame.GetController<ShowNavigationItemController>().CustomShowNavigationItem += HotelInfomationNavigationDetailViewWC_CustomShowNavigationItem;
            }
            catch { }
        }

        void HotelInfomationNavigationDetailViewWC_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
        {
            IModelDetailView model = ((IModelNavigationItem)e.ActionArguments.SelectedChoiceActionItem.Model).View as IModelDetailView;
            if (model != null)
                if (model.Id == "HotelInfomation_DetailView")
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace();
                    HotelInfomation hotelInfomation = objectSpace.FindObject<HotelInfomation>(null);
                    if (hotelInfomation == null)
                    {
                        hotelInfomation = objectSpace.CreateObject<HotelInfomation>();
                        try { objectSpace.CommitChanges(); }
                        catch { }
                    }
                    DetailView detailView = Application.CreateDetailView(objectSpace, model, true, hotelInfomation);
                    detailView.ViewEditMode = ViewEditMode.Edit;
                    e.ActionArguments.ShowViewParameters.CreatedView = detailView;
                    e.ActionArguments.ShowViewParameters.TargetWindow = TargetWindow.Current;
                    e.Handled = true;
                }
        }


        protected override void OnDeactivated()
        {
            Frame.GetController<ShowNavigationItemController>().CustomShowNavigationItem -= HotelInfomationNavigationDetailViewWC_CustomShowNavigationItem;
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
