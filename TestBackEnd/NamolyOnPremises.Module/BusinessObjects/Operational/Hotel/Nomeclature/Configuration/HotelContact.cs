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

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [XafDisplayName("Contacts")]
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty("Info")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]

    [Indices("Info")]
    public class HotelContact : BaseObject
    {
        public HotelContact(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        // Fields...
        private HotelGuestSharing _HotelGuestSharing;
        private RoomOwner _RoomOwner;
        private BusinessSource _BusinessSource;
        private string _Note;
        private string _Info;
        private ContactTypeEnum _Type;
        private HotelInfomation _Hotel;




        #region Properties

        [Index(0)]
        public ContactTypeEnum Type
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

        [Index(1)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Info
        {
            get
            {
                return _Info;
            }
            set
            {
                SetPropertyValue("Info", ref _Info, value);
            }
        }

        [Index(2)]
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
        [Association("HotelInfomation-HotelContacts")]
        public HotelInfomation Hotel
        {
            get
            {
                return _Hotel;
            }
            set
            {
                SetPropertyValue("Hotel", ref _Hotel, value);
            }
        }

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("BusinessSource-HotelContacts")]
        public BusinessSource BusinessSource
        {
            get
            {
                return _BusinessSource;
            }
            set
            {
                SetPropertyValue("BusinessSource", ref _BusinessSource, value);
            }
        }

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("RoomOwner-HotelContacts")]
        public RoomOwner RoomOwner
        {
            get
            {
                return _RoomOwner;
            }
            set
            {
                SetPropertyValue("RoomOwner", ref _RoomOwner, value);
            }
        }


        [Association("HotelGuestSharing-HotelContact")]
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

        #endregion Association
    }


    public enum ContactTypeEnum
    {
        Phone = 0,
        Fax = 1,
        Email = 2
    }
}
