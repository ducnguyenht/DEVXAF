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

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.RateInformationDetail
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class HotelRateInformation : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public HotelRateInformation(Session session)
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
        private decimal _AmountAfterDiscount;
        private decimal _Discount1;
        private decimal _Discount;
        private string _Rate;
        private string _RateType;
        private DateTime _Date;

        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                SetPropertyValue("Date", ref _Date, value);
            }
        }

        [XafDisplayName("Rate Type")]
        public string RateType
        {
            get
            {
                return _RateType;
            }
            set
            {
                SetPropertyValue("RateType", ref _RateType, value);
            }
        }


        public string Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                SetPropertyValue("Rate", ref _Rate, value);
            }
        }

        [XafDisplayName("Discount (%)")]
        public decimal Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                SetPropertyValue("Discount", ref _Discount, value);
            }
        }

        [XafDisplayName("Discount (Ð)")]
        public decimal Discount1
        {
            get
            {
                return _Discount1;
            }
            set
            {
                SetPropertyValue("Discount1", ref _Discount1, value);
            }
        }
        [ModelDefault("EditMask", @"#,###,###,##0")]
        [ModelDefault("DisplayFormat", "{0:#,##0}")]
        [XafDisplayName("Amount After Discount")]
        public decimal AmountAfterDiscount
        {
            get
            {
                return _AmountAfterDiscount;
            }
            set
            {
                SetPropertyValue("AmountAfterDiscount", ref _AmountAfterDiscount, value);
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

        [Association("HotelBooking-HotelRateInformation"),Browsable(false)]
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
