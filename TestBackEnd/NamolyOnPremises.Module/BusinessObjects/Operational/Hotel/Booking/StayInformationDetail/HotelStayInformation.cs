using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.StayInformationDetail
{
    [DefaultClassOptions]
    [ImageName("Action_AboutInfo")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class HotelStayInformation : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public HotelStayInformation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        #region Properties

        // Fields...
        private HotelBooking _HotelBooking;
        private string _Notes;
        private decimal _Amount;
        private decimal _Price;
        private int _Quantity;
        private HotelRateTypeExtraCharge _ExtraCharge;

        public HotelRateTypeExtraCharge ExtraCharge
        {
            get
            {
                return _ExtraCharge;
            }
            set
            {
                SetPropertyValue("ExtraCharge", ref _ExtraCharge, value);
            }
        }


        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                SetPropertyValue("Quantity", ref _Quantity, value);
            }
        }
        [XafDisplayName("Price (Ð)")]
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                SetPropertyValue("Price", ref _Price, value);
            }
        }

        [XafDisplayName("Amount (Ð)")]
        public decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                SetPropertyValue("Amount", ref _Amount, value);
            }
        }


        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                SetPropertyValue("Notes", ref _Notes, value);
            }
        }



        #endregion

        #region Association

        [Association("HotelBooking-HotelStayInformation"),Browsable(false)]
        public HotelBooking HotelBooking
        {
            get
            {
                return _HotelBooking;
            }
            set
            {
                SetPropertyValue("HotelBooking", ref _HotelBooking, value);
            }
        }
        #endregion

        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
        //    this.PersistentProperty = "Paid";
        //}
    }
}
