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
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.StayInformationDetail;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.RateInformationDetail;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.GuestSharingDetail;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking
{
    [DefaultClassOptions]
    [ImageName("BO_Appearance")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    [Appearance("HotelBooking_Hide_BalanceTransfer", AppearanceItemType = "LayoutItem", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0", TargetItems = "HotelBooking_BalanceTransfer", Visibility = ViewItemVisibility.Hide)]
    public class HotelBooking : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public HotelBooking(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            ExtraCharge = false;


            Cash = true;
            BillTo = false;
            FOC = false;
        }

        #region General Information
        //Guest Information
        // Fields...

        private bool _BalanceTransferCheckOut;
        private bool _Reserved;
        private bool _Inhouse;
        private string _Room;
        private string _Guest;
        private string _Folio;
        private string _FolioNotes;
        private decimal _FolioAmount;
        private HotelFolio _FolioList;
        private decimal _Balance;
        private int _Hour;
        private string _IBan;
        private string _SwiftCode;
        private string _BankNumber;
        private string _BankName;
        private DateTime _ExpiryDate;
        private string _CardNo;
        private HotelBookingCashTypeCardType _CardType;

        private MethodTypeEnum _MethodType;
        private DateTime _Date;
        private BillingInstructionEnum _BillingInstruction;
        private string _GuestName;
        private bool _ExtraCharge;
        private string _FOCNotes;
        private string _BillToNotes;
        private BillingInstructionEnum _Company;
        private string _CashNotes;
        private string _VoucherNo;
        private decimal _CashAmount;
        private HotelBookingCashType _Type;
        private string _DepartureTime;
        private string _ArrivalTime;
        private string _Notes;
        private string _Commission;
        private MarketSegment _MarketSegment;
        private BusinessSource _Source;
        private string _HouseKeeping;
        private string _Cancellation;
        private string _CheckOut;
        private string _CheckIn;
        private string _SpecialRequest;
        private string _NotesGuest;
        private bool _FOC;
        private bool _BillTo;
        private bool _Cash;
        private decimal _RequiredText;
        private decimal _Required;
        private DateTime _ReleaseDate;
        private string _RateText;
        private HotelRateType _RateType;
        private string _RoomText;
        private HotelRoomType _RoomType;
        private int _Children;
        private int _Adults;
        private int _Night;
        private DateTime _DepartureDate;
        private DateTime _ArrivalDate;
        private string _Email;
        private string _Phone;
        private string _FullName;

        [ImmediatePostData]
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

        ///Stay Information
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
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
        [ModelDefault("DisplayFormat", "{0:HH:mm tt}")]
        [ModelDefault("EditMask", "HH:mm tt")]
        public string ArrivalTime
        {
            get
            {
                return _ArrivalTime;
            }
            set
            {
                SetPropertyValue("ArrivalTime", ref _ArrivalTime, value);
            }
        }
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
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
        [ModelDefault("DisplayFormat", "{0:HH:mm tt}")]
        [ModelDefault("EditMask", "HH:mm tt")]
        public string DepartureTime
        {
            get
            {
                return _DepartureTime;
            }
            set
            {
                SetPropertyValue("DepartureTime", ref _DepartureTime, value);
            }
        }

        [ModelDefault("EditMask", @"#,###,###,##0")]
        [ModelDefault("DisplayFormat", "{0:#,##0}")]
        public decimal Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                SetPropertyValue("Balance", ref _Balance, value);
            }
        }


        [XafDisplayName("Night (s)")]
        [ImmediatePostData]
        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        [Appearance("", Criteria = "RateType != 'Night'", Visibility = ViewItemVisibility.Hide)]
        public int Night
        {
            get
            {
                return _Night;
            }
            set
            {
                SetPropertyValue("Night", ref _Night, value);
            }
        }
        [XafDisplayName("Hour (s)")]
        [ImmediatePostData]
        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        [Appearance("", Criteria = "RateType != 'Hour'", Visibility = ViewItemVisibility.Hide)]
        public int Hour
        {
            get
            {
                return _Hour;
            }
            set
            {
                SetPropertyValue("Hour", ref _Hour, value);
            }
        }

        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public int Adults
        {
            get
            {
                return _Adults;
            }
            set
            {
                SetPropertyValue("Adults", ref _Adults, value);
            }
        }
        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public int Children
        {
            get
            {
                return _Children;
            }
            set
            {
                SetPropertyValue("Children", ref _Children, value);
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
        [XafDisplayName("Room")]
        public string RoomText
        {
            get
            {
                return _RoomText;
            }
            set
            {
                SetPropertyValue("RoomText", ref _RoomText, value);
            }
        }

        [ImmediatePostData]
        public HotelRateType RateType
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
        [XafDisplayName("Rate")]
        public string RateText
        {
            get
            {
                return _RateText;
            }
            set
            {
                SetPropertyValue("RateText", ref _RateText, value);
            }
        }
        [ImmediatePostData]
        [XafDisplayName("Show Extra Charge")]
        public bool ExtraCharge
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


        //GUARANTEE INFORMATION
        [ImmediatePostData]
        public bool Cash
        {
            get
            {
                return _Cash;
            }
            set
            {
                SetPropertyValue("Cash", ref _Cash, value);
                if (!IsLoading && !IsSaving)
                {
                    if (_Cash)
                        CashCheck();
                    else
                    {
                        CashUncheck();
                    }
                }

            }
        }




        [Appearance("", Criteria = "Cash = False", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        public HotelBookingCashType Type
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

        [Appearance("", Criteria = "Type != 'BankCard'", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Card Type")]
        public HotelBookingCashTypeCardType CardType
        {
            get
            {
                return _CardType;
            }
            set
            {
                SetPropertyValue("CardType", ref _CardType, value);
            }
        }
        [Appearance("", Criteria = "Type != 'BankCard'", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Card No")]
        public string CardNo
        {
            get
            {
                return _CardNo;
            }
            set
            {
                SetPropertyValue("CardNo", ref _CardNo, value);
            }
        }
        [Appearance("", Criteria = "Type != 'BankCard'", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Expiry Date")]
        public DateTime ExpiryDate
        {
            get
            {
                return _ExpiryDate;
            }
            set
            {
                SetPropertyValue("ExpiryDate", ref _ExpiryDate, value);
            }
        }
        [Appearance("", Criteria = "Type != 'BankTransfer'", Visibility = ViewItemVisibility.Hide)]
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
        [Appearance("", Criteria = "Type != 'BankTransfer'", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Bank Number")]
        public string BankNumber
        {
            get
            {
                return _BankNumber;
            }
            set
            {
                SetPropertyValue("BankNumber", ref _BankNumber, value);
            }
        }
        [Appearance("", Criteria = "Type != 'BankTransfer'", Visibility = ViewItemVisibility.Hide)]
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

        [Appearance("", Criteria = "Type != 'BankTransfer'", Visibility = ViewItemVisibility.Hide)]
        public string IBan
        {
            get
            {
                return _IBan;
            }
            set
            {
                SetPropertyValue("IBan", ref _IBan, value);
            }
        }

        [Appearance("", Criteria = "Cash = False", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("EditMask", @"#,###,###,##0.")]
        [ModelDefault("DisplayFormat", "{0:#,##0.}")]
        [XafDisplayName("Amount (Ð)")]
        public decimal CashAmount
        {
            get
            {
                return _CashAmount;
            }
            set
            {
                SetPropertyValue("CashAmount", ref _CashAmount, value);
            }
        }

        [Appearance("", Criteria = "Cash = False", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName(" Voucher No.")]
        public string VoucherNo
        {
            get
            {
                return _VoucherNo;
            }
            set
            {
                SetPropertyValue("VoucherNo", ref _VoucherNo, value);
            }
        }

        [Appearance("", Criteria = "Cash = False", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Notes")]
        public string CashNotes
        {
            get
            {
                return _CashNotes;
            }
            set
            {
                SetPropertyValue("CashNotes", ref _CashNotes, value);
            }
        }
        [ImmediatePostData]

        public bool BillTo
        {
            get
            {
                return _BillTo;
            }
            set
            {
                SetPropertyValue("BillTo", ref _BillTo, value);
                if (!IsSaving && !IsLoading)
                {
                    if (_BillTo)
                        BillToCheck();
                    else
                    {
                        BilltoUnCheck();
                    }

                }
            }
        }


        [Appearance("", Criteria = "BillTo = False", Visibility = ViewItemVisibility.Hide)]
        public BillingInstructionEnum Company
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
        [Appearance("", Criteria = "BillTo = False", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Notes")]
        public string BillToNotes
        {
            get
            {
                return _BillToNotes;
            }
            set
            {
                SetPropertyValue("BillToNotes", ref _BillToNotes, value);
            }
        }

        [ImmediatePostData]
        public bool FOC
        {
            get
            {
                return _FOC;
            }
            set
            {
                SetPropertyValue("FOC", ref _FOC, value);
                if (!IsSaving && !IsLoading)
                {
                    if (_FOC)
                        FOCCheck();
                    else
                    {
                        FOCUnCheck();
                    }

                }
            }
        }



        [Appearance("", Criteria = "FOC= False", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Notes")]
        public string FOCNotes
        {
            get
            {
                return _FOCNotes;
            }
            set
            {
                SetPropertyValue("FOCNotes", ref _FOCNotes, value);
            }
        }

        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime ReleaseDate
        {
            get
            {
                return _ReleaseDate;
            }
            set
            {
                SetPropertyValue("ReleaseDate", ref _ReleaseDate, value);
            }
        }
        [ModelDefault("DisplayFormat", "{0:n0} %"), ModelDefault("EditMask", "n0")]
        [XafDisplayName("Percentage (%)")]
        public decimal Required
        {
            get
            {
                return _Required;
            }
            set
            {
                SetPropertyValue("Required", ref _Required, value);
            }
        }

        [XafDisplayName("Required (đ)")]
        public decimal RequiredText
        {
            get
            {
                return _RequiredText;
            }
            set
            {
                SetPropertyValue("RequiredText", ref _RequiredText, value);
            }
        }



        //Notes tabs

        public string NotesGuest
        {
            get
            {
                return _NotesGuest;
            }
            set
            {
                SetPropertyValue("NotesGuest", ref _NotesGuest, value);
            }
        }

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

        public string CheckIn
        {
            get
            {
                return _CheckIn;
            }
            set
            {
                SetPropertyValue("CheckIn", ref _CheckIn, value);
            }
        }

        public string CheckOut
        {
            get
            {
                return _CheckOut;
            }
            set
            {
                SetPropertyValue("CheckOut", ref _CheckOut, value);
            }
        }

        public string Cancellation
        {
            get
            {
                return _Cancellation;
            }
            set
            {
                SetPropertyValue("Cancellation", ref _Cancellation, value);
            }
        }
        [XafDisplayName("House Keeping")]
        public string HouseKeeping
        {
            get
            {
                return _HouseKeeping;
            }
            set
            {
                SetPropertyValue("HouseKeeping", ref _HouseKeeping, value);
            }
        }
        //BUSINESS SOURCE 

        public BusinessSource Source
        {
            get
            {
                return _Source;
            }
            set
            {
                SetPropertyValue("Source", ref _Source, value);
            }
        }
        [XafDisplayName("Market Segment")]
        public MarketSegment MarketSegment
        {
            get
            {
                return _MarketSegment;
            }
            set
            {
                SetPropertyValue("MarketSegment", ref _MarketSegment, value);
            }
        }
        [XafDisplayName("Commission (Ð)")]
        public string Commission
        {
            get
            {
                return _Commission;
            }
            set
            {
                SetPropertyValue("Commission", ref _Commission, value);
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



        // FOLIO
        /// <summary>
        /// Khi HotelBooking được lưu lại thì value = null
        /// Sử dụng để tương tác khi chọn Folios
        /// </summary>    
        [ImmediatePostData]
        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Appearance("", Criteria = "FolioList = null", Visibility = ViewItemVisibility.Hide)]
        public string GuestName
        {
            get
            {
                return _GuestName;
            }
            set
            {
                SetPropertyValue("GuestName", ref _GuestName, value);
            }
        }

        /// <summary>
        /// Khi HotelBooking được lưu lại thì value = null
        /// Sử dụng để tương tác khi chọn Folios
        /// </summary>
        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Appearance("", Criteria = "FolioList = null", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        public BillingInstructionEnum BillingInstruction
        {
            get
            {
                return _BillingInstruction;
            }
            set
            {
                SetPropertyValue("BillingInstruction", ref _BillingInstruction, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
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

        [XafDisplayName("Type")]
        [ImmediatePostData]
        [VisibleInListView(false), VisibleInLookupListView(false)]
        public MethodTypeEnum MethodType
        {
            get
            {
                return _MethodType;
            }
            set
            {
                SetPropertyValue("MethodType", ref _MethodType, value);
            }
        }

        [ModelDefault("EditMask", @"#,###,###,##0.")]
        [ModelDefault("DisplayFormat", "{0:#,##0.}")]
        [ImmediatePostData]
        [XafDisplayName("Amount (Ð)")]
        public decimal FolioAmount
        {
            get
            {
                return _FolioAmount;
            }
            set
            {
                SetPropertyValue("FolioAmount", ref _FolioAmount, value);
            }
        }

        [XafDisplayName("Notes")]
        public string FolioNotes
        {
            get
            {
                return _FolioNotes;
            }
            set
            {
                SetPropertyValue("FolioNotes", ref _FolioNotes, value);
            }
        }

        [ToolTip("List auto create from Guest Sharing")]
        [NonPersistent]
        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [ImmediatePostData]
        [DataSourceProperty("FoliosDataSource")]
        public HotelFolio FolioList
        {
            get
            {
                return _FolioList;
            }
            set
            {
                SetPropertyValue("FolioList", ref _FolioList, value);
                if (!IsLoading && !IsSaving)
                {
                    if (_FolioList != null)
                        GuestName = _FolioList.GuestName;
                    else
                        GuestName = "";
                    OnChanged("GuestName");
                }
            }
        }

        #region Balance Transfer
        // [Appearance("", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        public string Folio
        {
            get
            {
                return _Folio;
            }
            set
            {
                SetPropertyValue("Folio", ref _Folio, value);
            }
        }

        //[Appearance("", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0 ", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
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
        //[Appearance("", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
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
        //[Appearance("", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        public bool Inhouse
        {
            get
            {
                return _Inhouse;
            }
            set
            {
                SetPropertyValue("Inhouse", ref _Inhouse, value);
            }
        }
        //[Appearance("", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        public bool Reserved
        {
            get
            {
                return _Reserved;
            }
            set
            {
                SetPropertyValue("Reserved", ref _Reserved, value);
            }
        }
        //[Appearance("", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [XafDisplayName("Check Out")]
        public bool BalanceTransferCheckOut
        {
            get
            {
                return _BalanceTransferCheckOut;
            }
            set
            {
                SetPropertyValue("BalanceTransferCheckOut", ref _BalanceTransferCheckOut, value);
            }
        }



        //[Appearance("", Criteria = "MethodType !='BalanceTransfer' or FolioAmount = 0", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [Association("HotelBooking-HotelBalanceTransferList")]
        public XPCollection<HotelBalanceTransferList> HotelBalanceTransferList
        {
            get
            {
                return GetCollection<HotelBalanceTransferList>("HotelBalanceTransferList");
            }
        }


        #endregion


        #endregion

        #region Association

        #region Guest Sharing
        [Association("HotelBooking-HotelGuestSharing")]
        public XPCollection<HotelGuestSharing> HotelGuestSharing
        {
            get
            {
                return GetCollection<HotelGuestSharing>("HotelGuestSharing");
            }
        }
        #endregion

        #region Stay Information Detail

        [ImmediatePostData]
        [Appearance("", Criteria = "ExtraCharge=False", Visibility = ViewItemVisibility.Hide)]
        [Association("HotelBooking-HotelStayInformation")]
        public XPCollection<HotelStayInformation> HotelStayInformation
        {
            get
            {
                return GetCollection<HotelStayInformation>("HotelStayInformation");
            }
        }
        #endregion

        #region Rate Information
        [Association("HotelBooking-HotelRateInformation")]
        public XPCollection<HotelRateInformation> HotelRateInformation
        {
            get
            {
                return GetCollection<HotelRateInformation>("HotelRateInformation");
            }
        }
        #endregion

        [XafDisplayName("Folio List")]
        [Association("HotelBooking-HotelFolios"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelFolio> Folios
        {
            get
            {
                return GetCollection<HotelFolio>("Folios");
            }
        }



        /// <summary>
        /// Quy tắc thanh toán
        /// </summary>
        [Appearance("", Criteria = "FolioList = null or ChargeRules.Count = 0", Visibility = ViewItemVisibility.Hide)]
        [Association("HotelBooking-HotelFolioDetailChargeRules"), DevExpress.Xpo.Aggregated]
        [ImmediatePostData]
        public XPCollection<HotelFolioDetailChargeRule> ChargeRules
        {
            get
            {
                return GetCollection<HotelFolioDetailChargeRule>("ChargeRules");
            }
        }

        [Association("HotelBooking-HotelFolioRoomCharges"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelFolioRoomCharge> RoomCharges
        {
            get
            {
                return GetCollection<HotelFolioRoomCharge>("RoomCharges");
            }
        }

        #region Posting
        [Association("HotelBooking-Posting")]
        public XPCollection<Postings.Posting> Posting
        {
            get
            {
                return GetCollection<Postings.Posting>("Posting");
            }
        }
        #endregion

        #endregion

        #region Logic
        private void CashCheck()
        {
            //throw new NotImplementedException();

            BillTo = false;
            OnChanged("BillTo");
            FOC = false;
            OnChanged("FOC");
        }
        private void CashUncheck()
        {
            //throw new NotImplementedException();
            Type = default(HotelBookingCashType);
            OnChanged("Type");

            CashAmount = default(decimal);
            OnChanged("Amount");
            VoucherNo = default(string);
            OnChanged("VoucherNo");
            CashNotes = default(string);
            OnChanged("CashNotes");
        }
        private void BilltoUnCheck()
        {
            //throw new NotImplementedException();
            Company = default(BillingInstructionEnum);
            OnChanged("Company");
            BillToNotes = default(string);
            OnChanged("BillToNotes");
        }

        private void BillToCheck()
        {
            //throw new NotImplementedException();
            Cash = false;
            OnChanged("Cash");
            FOC = false;
            OnChanged("Foc");
        }
        private void FOCUnCheck()
        {
            //throw new NotImplementedException();
            FOCNotes = default(string);
            OnChanged("FOCNotes");
        }

        private void FOCCheck()
        {
            // throw new NotImplementedException();

            Cash = false;
            OnChanged("Cash");
            BillTo = false;
            OnChanged("BillTo");
        }


        protected XPCollection<HotelFolio> FoliosDataSource
        {
            get
            {
                XPCollection<HotelFolio> hotelFolios = null;
                CriteriaOperator criteria = null;
                foreach (var guestSharing in HotelGuestSharing)
                {
                    criteria |= new BinaryOperator("HotelSharing.Oid", guestSharing.Oid);
                }
                hotelFolios = new XPCollection<HotelFolio>(Session, criteria);
                if (criteria == null)
                    hotelFolios = null;
                return hotelFolios;
            }
        }

        protected override void OnSaving()
        {
            //BillingInstruction = BillingInstructionEnum.NotAvaiable;

            //Date = default(DateTime);

            base.OnSaving();
        }




        #endregion

    }

    #region Enum
    public enum BillingInstructionEnum
    {
        Guest = 0,
        Company = 1,
        GroupOwner = 2,
        RoomAndTaxToCompany = 3,
        ExtraToGuest = 4,
        [XafDisplayName("N/A")]
        NotAvaiable = 10
    }

    public enum PostTypeEnum
    {
        CheckInAndCheckOut = 0,
        Everyday = 1,
        EverydayExceptCheckIn = 2,
        EverydayExceptCheckOut = 3,
        EverydayExceptCheckInAndCheckOut = 4,
        OnlyCheckIn = 5,
        OnlyCheckOut = 6
    }

    public enum MethodTypeEnum
    {
        Cash = 0,
        Adjustments = 1,
        Card = 2,
        BankTransfer = 3,
        CityLedger = 4,
        Discount = 5,
        ExtraCharges = 6,
        RoomCharges = 7,
        BalanceTransfer = 8
    }

    public enum HotelBookingCashType
    {
        [XafDisplayName("Cash")]
        Cash = 0,
        [XafDisplayName("Bank Card")]
        BankCard = 1,
        [XafDisplayName("Bank Transfer")]
        BankTransfer = 2
    }

    public enum HotelBookingCashTypeCardType
    {
        Visa = 0,
        Master = 1,
        Amex = 2,
    }
    #endregion



}
