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
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.GuestSharingDetail;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.HistoryTransactionDetail
{
    [DefaultClassOptions]
    [ImageName("BO_Audit_ChangeHistory")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class HotelHistoryTransaction : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public HotelHistoryTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        #region Properties
        private HotelGuestSharing _HotelGuestSharing;
        private string _Preferences;
        private string _Room;
        private string _DepartureDate;
        private DateTime _ArrivalDate;
        private string _NOR;

        [XafDisplayName("N.O.R")]
        public string NOR
        {
            get
            {
                return _NOR;
            }
            set
            {
                SetPropertyValue("NOR", ref _NOR, value);
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
        public string DepartureDate
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

        public string Preferences
        {
            get
            {
                return _Preferences;
            }
            set
            {
                SetPropertyValue("Preferences", ref _Preferences, value);
            }
        }
        #endregion

        #region Association

        [Association("HotelGuestSharing-HotelHistoryTransaction"),Browsable(false)]
        public HotelGuestSharing HotelGuestSharing
        {
            get
            {
                return _HotelGuestSharing;
            }
            set
            {
                SetPropertyValue("HotelGuestSharing", ref _HotelGuestSharing, value);
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
