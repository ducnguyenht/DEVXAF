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
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class HotelBalanceTransferList : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public HotelBalanceTransferList(Session session)
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
        private DateTime _DepartureDate;
        private DateTime _ArrivalDate;
        private string _Guest;
        private string _Room;
        private string _FolioNo;
        private string _Code;

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                SetPropertyValue("Code", ref _Code, value);
            }
        }

        public string FolioNo
        {
            get
            {
                return _FolioNo;
            }
            set
            {
                SetPropertyValue("FolioNo", ref _FolioNo, value);
            }
        }

        public string Room
        {
            get
            {
                return _Room;
            }
            set
            {
                SetPropertyValue("Room", ref _Room, value);
            }
        }

        public string Guest
        {
            get
            {
                return _Guest;
            }
            set
            {
                SetPropertyValue("Guest", ref _Guest, value);
            }
        }

        [XafDisplayName("Arrival Date")]
        public DateTime ArrivalDate
        {
            get
            {
                return _ArrivalDate;
            }
            set
            {
                SetPropertyValue("ArrivalDate", ref _ArrivalDate, value);
            }
        }

        [XafDisplayName("Departure Date")]
        public DateTime DepartureDate
        {
            get
            {
                return _DepartureDate;
            }
            set
            {
                SetPropertyValue("DepartureDate", ref _DepartureDate, value);
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

        [Association("HotelBooking-HotelBalanceTransferList")]
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
