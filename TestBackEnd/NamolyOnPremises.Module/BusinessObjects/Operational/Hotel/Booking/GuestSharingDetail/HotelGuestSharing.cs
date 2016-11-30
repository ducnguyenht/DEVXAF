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
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.HistoryTransactionDetail;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.GuestSharingDetail
{
    [DefaultClassOptions]
    [ImageName("BO_Person")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class HotelGuestSharing : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public HotelGuestSharing(Session session)
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
        private string _SpecialRequest;
        private string _DepartureTrans;
        private string _VisaNo;
        private bool _IsMainGuest;
        private HotelBooking _HotelBooking;
        //private string _Remark;
        //private string _Amerities;
        //private string _Diet;
        //private string _Fragrance;
        //private string _Flower;
        //private string _Newspaper;
        //private string _Magazine;
        //private int _ExQuilt;
        //private int _ExtraPillow;
        //private string _PillowType;
        //private string _Quilt;
        //private string _Mattress;
        //private string _BedSheet;
        //private string _SmokingRoom;
        private string _RoomNo;
        private HotelRoomType _RoomType;
        private HotelFloor _RoomFloor;
        private string _Iban;
        private string _SwiftCode;
        private string _Website;
        private string _BackAccount;
        private string _BankName;
        private string _TaxCode;
        private string _Address;
        private string _Company;
        private string _JobTitle;
        private bool _IsEmployedInCountry;
        private DateTime _ToDate;
        private string _ArrivalTrans;
        private DateTime _ArrivalDate;
        private string _Purpose;
        private string _Duration;
        private string _ValidUntil;
        private DateTime _ValidFrom;
        private string _IssueBy;
        private DateTime _IssueDate;
        private string _VisaType;
        private string _SerialNo;
        private string _ID;
        private GuestSharingIDType _IDType;
        private DateTime _DepartureDate;
        private DateTime _FromDate;
        private string _Nationnality;
        private string _Language;
        private DateTime _DoB;
        private string _Email;
        private string _Phone;
        private string _FullName;
        private GuestSharingSalutation _Salutation;

        #region Information
        public GuestSharingSalutation Salutation
        {
            get
            {
                return _Salutation;
            }
            set
            {
                SetPropertyValue("Salutation", ref _Salutation, value);
            }
        }

        [XafDisplayName("Full Name")]
        public string FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                SetPropertyValue("FullName", ref _FullName, value);
            }
        }


        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        }


        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        }


        public DateTime DoB
        {
            get
            {
                return _DoB;
            }
            set
            {
                SetPropertyValue("DoB", ref _DoB, value);
            }
        }


        public string Language
        {
            get
            {
                return _Language;
            }
            set
            {
                SetPropertyValue("Language", ref _Language, value);
            }
        }


        public string Nationnality
        {
            get
            {
                return _Nationnality;
            }
            set
            {
                SetPropertyValue("Nationnality", ref _Nationnality, value);
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

        [XafDisplayName("ID Type")]
        public GuestSharingIDType IDType
        {
            get
            {
                return _IDType;
            }
            set
            {
                SetPropertyValue("IDType", ref _IDType, value);
            }
        }

        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                SetPropertyValue("ID", ref _ID, value);
            }
        }

        [XafDisplayName("Is Main Guest")]
        public bool IsMainGuest
        {
            get
            {
                return _IsMainGuest;
            }
            set
            {
                SetPropertyValue("IsMainGuest", ref _IsMainGuest, value);
            }
        }
        #endregion

        #region BUSINESS INFO

        #region Information
        [XafDisplayName("Job Title")]
        public string JobTitle
        {
            get
            {
                return _JobTitle;
            }
            set
            {
                SetPropertyValue("JobTitle", ref _JobTitle, value);
            }
        }

        public string Company
        {
            get
            {
                return _Company;
            }
            set
            {
                SetPropertyValue("Company", ref _Company, value);
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
            }
        }

        [XafDisplayName("Tax Code")]
        public string TaxCode
        {
            get
            {
                return _TaxCode;
            }
            set
            {
                SetPropertyValue("TaxCode", ref _TaxCode, value);
            }
        }

        [XafDisplayName("Bank Name")]
        public string BankName
        {
            get
            {
                return _BankName;
            }
            set
            {
                SetPropertyValue("BankName", ref _BankName, value);
            }
        }

        [XafDisplayName("Bank Account")]
        public string BackAccount
        {
            get
            {
                return _BackAccount;
            }
            set
            {
                SetPropertyValue("BackAccount", ref _BackAccount, value);
            }
        }

        public string Website
        {
            get
            {
                return _Website;
            }
            set
            {
                SetPropertyValue("Website", ref _Website, value);
            }
        }
        [XafDisplayName("Swift Code")]
        public string SwiftCode
        {
            get
            {
                return _SwiftCode;
            }
            set
            {
                SetPropertyValue("SwiftCode", ref _SwiftCode, value);
            }
        }

        public string Iban
        {
            get
            {
                return _Iban;
            }
            set
            {
                SetPropertyValue("Iban", ref _Iban, value);
            }
        }
        #endregion


        #endregion

        #region VISA INFORMATION

        [XafDisplayName("Serial No")]
        public string SerialNo
        {
            get
            {
                return _SerialNo;
            }
            set
            {
                SetPropertyValue("SerialNo", ref _SerialNo, value);
            }
        }

        public string VisaNo
        {
            get
            {
                return _VisaNo;
            }
            set
            {
                SetPropertyValue("VisaNo", ref _VisaNo, value);
            }
        }

        [XafDisplayName("Visa Type")]
        public string VisaType
        {
            get
            {
                return _VisaType;
            }
            set
            {
                SetPropertyValue("VisaType", ref _VisaType, value);
            }
        }

        [XafDisplayName("Issue Date")]
        public DateTime IssueDate
        {
            get
            {
                return _IssueDate;
            }
            set
            {
                SetPropertyValue("IssueDate", ref _IssueDate, value);
            }
        }
        [XafDisplayName("Issue By")]
        public string IssueBy
        {
            get
            {
                return _IssueBy;
            }
            set
            {
                SetPropertyValue("IssueBy", ref _IssueBy, value);
            }
        }

        [XafDisplayName("Valid From")]
        public DateTime ValidFrom
        {
            get
            {
                return _ValidFrom;
            }
            set
            {
                SetPropertyValue("ValidFrom", ref _ValidFrom, value);
            }
        }

        [XafDisplayName("Valid Until")]
        public string ValidUntil
        {
            get
            {
                return _ValidUntil;
            }
            set
            {
                SetPropertyValue("ValidUntil", ref _ValidUntil, value);
            }
        }

        public string Duration
        {
            get
            {
                return _Duration;
            }
            set
            {
                SetPropertyValue("Duration", ref _Duration, value);
            }
        }

        public string Purpose
        {
            get
            {
                return _Purpose;
            }
            set
            {
                SetPropertyValue("Purpose", ref _Purpose, value);
            }
        }

        [XafDisplayName("Arrival Date")]
        public DateTime FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                SetPropertyValue("FromDate", ref _FromDate, value);
            }
        }
        [XafDisplayName("Arrival Trans.")]
        public string ArrivalTrans
        {
            get
            {
                return _ArrivalTrans;
            }
            set
            {
                SetPropertyValue("ArrivalTrans", ref _ArrivalTrans, value);
            }
        }

        [XafDisplayName("Departure Date")]
        public DateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                SetPropertyValue("ToDate", ref _ToDate, value);
            }
        }
        [XafDisplayName("Departure Trans.")]
        public string DepartureTrans
        {
            get
            {
                return _DepartureTrans;
            }
            set
            {
                SetPropertyValue("DepartureTrans", ref _DepartureTrans, value);
            }
        }

        [XafDisplayName("Is Employed In Country")]
        public bool IsEmployedInCountry
        {
            get
            {
                return _IsEmployedInCountry;
            }
            set
            {
                SetPropertyValue("IsEmployedInCountry", ref _IsEmployedInCountry, value);
            }
        }
        #endregion


        #region PREFERENCES

        #region ROOM PREFERENCES
        [XafDisplayName("Room Floor")]
        public HotelFloor RoomFloor
        {
            get
            {
                return _RoomFloor;
            }
            set
            {
                SetPropertyValue("RoomFloor", ref _RoomFloor, value);
            }
        }

        [XafDisplayName("Room Type")]
        public HotelRoomType RoomType
        {
            get
            {
                return _RoomType;
            }
            set
            {
                SetPropertyValue("RoomType", ref _RoomType, value);
            }
        }

        [XafDisplayName("Room No")]
        public string RoomNo
        {
            get
            {
                return _RoomNo;
            }
            set
            {
                SetPropertyValue("RoomNo", ref _RoomNo, value);
            }
        }

        [XafDisplayName("Special Request")]
        [ModelDefault("PropertyEditorType", "SpecialRequestPropertyEditor")]
        public string SpecialRequest
        {
            get
            {
                return _SpecialRequest;
            }
            set
            {
                SetPropertyValue("SpecialRequest", ref _SpecialRequest, value);
            }
        }
        //[XafDisplayName("Smoking Room")]
        //public string SmokingRoom
        //{
        //    get
        //    {
        //        return _SmokingRoom;
        //    }
        //    set
        //    {
        //        SetPropertyValue("SmokingRoom", ref _SmokingRoom, value);
        //    }
        //}

        #endregion

        #region ROOM AMENNITY PREFERENCES

        //[XafDisplayName("Bed Sheet")]
        //public string BedSheet
        //{
        //    get
        //    {
        //        return _BedSheet;
        //    }
        //    set
        //    {
        //        SetPropertyValue("BedSheet", ref _BedSheet, value);
        //    }
        //}

        //public string Mattress
        //{
        //    get
        //    {
        //        return _Mattress;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Mattress", ref _Mattress, value);
        //    }
        //}

        //public string Quilt
        //{
        //    get
        //    {
        //        return _Quilt;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Quilt", ref _Quilt, value);
        //    }
        //}
        //[XafDisplayName("Pillow Type")]
        //public string PillowType
        //{
        //    get
        //    {
        //        return _PillowType;
        //    }
        //    set
        //    {
        //        SetPropertyValue("PillowType", ref _PillowType, value);
        //    }
        //}
        //[XafDisplayName("Extra Pillow")]
        //public int ExtraPillow
        //{
        //    get
        //    {
        //        return _ExtraPillow;
        //    }
        //    set
        //    {
        //        SetPropertyValue("ExtraPillow", ref _ExtraPillow, value);
        //    }
        //}

        //[XafDisplayName("Ex.Quilt")]
        //public int ExQuilt
        //{
        //    get
        //    {
        //        return _ExQuilt;
        //    }
        //    set
        //    {
        //        SetPropertyValue("ExQuilt", ref _ExQuilt, value);
        //    }
        //}
        #endregion

        #region OTHER PREFERENCES

        //public string Magazine
        //{
        //    get
        //    {
        //        return _Magazine;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Magazine", ref _Magazine, value);
        //    }
        //}

        //public string Newspaper
        //{
        //    get
        //    {
        //        return _Newspaper;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Newspaper", ref _Newspaper, value);
        //    }
        //}

        //public string Flower
        //{
        //    get
        //    {
        //        return _Flower;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Flower", ref _Flower, value);
        //    }
        //}

        //public string Fragrance
        //{
        //    get
        //    {
        //        return _Fragrance;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Fragrance", ref _Fragrance, value);
        //    }
        //}

        //public string Diet
        //{
        //    get
        //    {
        //        return _Diet;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Diet", ref _Diet, value);
        //    }
        //}

        //public string Amerities
        //{
        //    get
        //    {
        //        return _Amerities;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Amerities", ref _Amerities, value);
        //    }
        //}

        //public string Remark
        //{
        //    get
        //    {
        //        return _Remark;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Remark", ref _Remark, value);
        //    }
        //}
        #endregion

        #endregion

        #endregion

        #region Association
        //Contact Detail 
        [Association("HotelGuestSharing-HotelContact")]
        public XPCollection<HotelContact> HotelContact
        {
            get
            {
                return GetCollection<HotelContact>("HotelContact");
            }
        }

        [Association("HotelGuestSharing-HotelBussinessInformationContact")]
        public XPCollection<HotelBussinessInformationContact> HotelBussinessInformationContact
        {
            get
            {
                return GetCollection<HotelBussinessInformationContact>("HotelBussinessInformationContact");
            }
        }

        //History Transaction
        [Association("HotelGuestSharing-HotelHistoryTransaction")]
        public XPCollection<HotelHistoryTransaction> HotelHistoryTransaction
        {
            get
            {
                return GetCollection<HotelHistoryTransaction>("HotelHistoryTransaction");
            }
        }


        [Association("HotelBooking-HotelGuestSharing"), Browsable(false)]
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


        #region Logic

        protected override void OnSaving()
        {
            try
            {
                HotelFolio hotelFolio = HotelBooking.Folios.FirstOrDefault(f => f.HotelSharing == this);
                if (hotelFolio == null)
                {
                    hotelFolio = new HotelFolio(Session);
                    hotelFolio.HotelSharing = this;
                    hotelFolio.Booking = this.HotelBooking;
                    hotelFolio.GuestName = FullName;
                    hotelFolio.Name = "Folio";
                }
                else
                {
                    hotelFolio.GuestName = FullName;
                }
                hotelFolio.Save();
            }
            catch { }
            base.OnSaving();
        }

        protected override void OnDeleting()
        {
            try
            {
                HotelFolio hotelFolio = HotelBooking.Folios.FirstOrDefault(f => f.HotelSharing == this);
                Session.Delete(hotelFolio);
            }
            catch { }
            base.OnDeleting();
        }

        #endregion Logic
    }

    public enum GuestSharingSalutation
    {
        Mrs = 0,
        Mr = 1,
        Other = 2
    }

    public enum GuestSharingIDType
    {
        [XafDisplayName("Identify Card")]
        IdentifyCard = 0,
        [XafDisplayName("Driving Licence")]
        DrivingLicence = 1,
        [XafDisplayName("Passport")]
        Passport = 2,
    }

}
