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
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking;

namespace NamolyOnPremises.Module.Controllers.Hotel.Booking
{
    public partial class HotelBookingVC : ViewController
    {
        public HotelBookingVC()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(HotelBooking);
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
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void HotelFolioPost_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

        }

        private void HotelFolioCancel_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

        }
    }
}
