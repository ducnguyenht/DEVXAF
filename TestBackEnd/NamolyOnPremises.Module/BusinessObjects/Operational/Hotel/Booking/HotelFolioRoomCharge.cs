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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [RuleCriteria("HotelFolioRoomCharge_Rule_Date", DefaultContexts.Save, "Date is not null", SkipNullOrEmptyValues = false)]

    [Appearance("HotelFolioRoomCharge_Action_Hidden", AppearanceItemType.Action, "1 = 1",
        TargetItems = "New", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    public class HotelFolioRoomCharge : BaseObject
    {
        public HotelFolioRoomCharge(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        // Fields...
        private HotelBooking _Booking;
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

        [ModelDefault("DisplayFormat", "{0: #,###,###,###.##}"), ModelDefault("EditMask", "#,###,###,###.##")]
        [RuleValueComparison(ValueComparisonType.GreaterThan, 0)]
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

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelBooking-HotelFolioRoomCharges")]
        public HotelBooking Booking
        {
            get
            {
                return _Booking;
            }
            set
            {
                SetPropertyValue("Booking", ref _Booking, value);
            }
        }

        #endregion Association
    }
}
