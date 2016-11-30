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

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.Postings
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Posting : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Posting(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        private HotelBooking _HotelBooking;
        private string _Note;
        private object _User;
        private decimal _Quantity;
        private HotelRateTypeExtraCharge _Service;
        private MethodTypeEnum _Type;
        private object _VoucherCode;
        private DateTime _Date;



        #region Properties

        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy}"), ModelDefault("EditMask", "dd/MM/yyyy")]
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

        public object VoucherCode
        {
            get
            {
                return _VoucherCode;
            }
            set
            {
                SetPropertyValue("VoucherCode", ref _VoucherCode, value);
            }
        }

        public MethodTypeEnum Type
        {
            get
            {
                return _Type;
            }
            set
            {
                SetPropertyValue("Type", ref _Type, value);
            }
        }

        public HotelRateTypeExtraCharge Service
        {
            get
            {
                return _Service;
            }
            set
            {
                SetPropertyValue("Service", ref _Service, value);
            }
        }

        //[ModelDefault("DisplayFormat", "{0: #,###,###,###.##}"), ModelDefault("EditMask", "#,###,###,###.##")]
        //[RuleValueComparison(ValueComparisonType.GreaterThan, 0)]
        public decimal Quantity
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

        [ModelDefault("DisplayFormat", "{0: #,###,###,###,###}"), ModelDefault("EditMask", "#,###,###,###")]
        public decimal Amount
        {
            get
            {
                if (Service == null)
                    return 0;
                else
                    return Service.Rate * Quantity;
            }
        }

        public object User
        {
            get
            {
                return _User;
            }
            set
            {
                SetPropertyValue("User", ref _User, value);
            }
        }

        [Size(250)]
        [VisibleInListView(true)]
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                SetPropertyValue("Note", ref _Note, value);
            }
        }
        #endregion Properties


        #region Association

        [Association("HotelBooking-Posting")]
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

        #endregion Association


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
