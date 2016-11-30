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
using NamolyOnPremises.Module.BusinessObjects.Operational.General;
using NamolyOnPremises.Module.Interfaces;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [DefaultClassOptions]
    [ImageName("BO_Organization")]
    [DefaultProperty("DisplayName")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [Indices("Code", "Name")]
    public class HotelInfomation : BaseObject, IHtmlEditorDisableTabView
    {
        public HotelInfomation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private string _ChildAndExtraBedPolicy;
        private string _CancelPolicy;
        private string _CheckOutPolicy;
        private string _CheckInPolicy;
        private string _BookingPolicy;
        private string _Userful;
        private bool _Spa;
        private bool _PhotocopyService;
        private bool _InternetAccess;
        private bool _CurrencyExchangeService;
        private bool _BarLounge;
        private bool _RoomService;
        private bool _Parking;
        private bool _GuestLaundry;
        private bool _ChildrenFacilities;
        private bool _BBQFacilities;
        private bool _Porterage;
        private bool _LuggageStorage;
        private bool _DryCleaningFacilities;
        private bool _BusinessCentre;
        private bool _H24HrFrontDesk;
        private bool _Sauna;
        private bool _PetsAllowed;
        private bool _GymFitnessCentre;
        private bool _ConferenceFacilities;
        private bool _Babysitting;
        private bool _TourDesk;
        private bool _Restaurant;
        private bool _NonSmokingRoomFloors;
        private bool _FreeParking;
        private bool _CarParking;
        private bool _AirConditioning;
        private bool _TennisCourt;
        private bool _Pool;
        private bool _Lifts;
        private bool _DisabledFacilities;
        private bool _Breakfast;
        private bool _H24HourSecurity;
        private string _AddressInInvoice;
        private string _TaxCode;
        private string _CompanyName;
        private string _Iban;
        private string _SwiftCode;
        private string _BankAccount;
        private string _BankName;
        private string _BookingEmail;
        private string _BookingPhone;
        private string _LogoUrl;
        private string _Website;
        private string _ZipCode;
        private General.Country _Country;
        private City _City;
        private string _Address;
        private string _Name;
        private string _Code;





        #region Properties

        #region GENERAL
        [Size(32)]
        [RuleRequiredField(DefaultContexts.Save), RuleUniqueValue(DefaultContexts.Save)]
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

        [RuleRequiredField(DefaultContexts.Save)]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }

        [Size(250)]
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

        [DataSourceProperty("CityDataSource")]
        [ImmediatePostData]
        public City City
        {
            get
            {
                return _City;
            }
            set
            {
                SetPropertyValue("City", ref _City, value);
                if (!IsSaving && !IsLoading)
                {
                    if (_City != null)
                    {
                        Country = _City.Country;
                        OnChanged("Country");
                    }
                }
            }
        }

        [ImmediatePostData]
        public General.Country Country
        {
            get
            {
                return _Country;
            }
            set
            {
                var countryOld = _Country;
                SetPropertyValue("Country", ref _Country, value);
                if (!IsSaving && !IsLoading)
                    if (countryOld != _Country)
                    {
                        if (_Country == null)
                        {
                            City = null;
                            OnChanged("City");
                        }
                        else
                        {
                            if (City != null)
                                if (City.Country != _Country)
                                {
                                    City = null;
                                    OnChanged("City");
                                }
                        }
                    }
            }
        }

        [Size(20)]
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                SetPropertyValue("ZipCode", ref _ZipCode, value);
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
        [Size(250)]
        public string LogoUrl
        {
            get
            {
                return _LogoUrl;
            }
            set
            {
                SetPropertyValue("LogoUrl", ref _LogoUrl, value);
            }
        }

        [VisibleInListView(false), VisibleInDetailView(false)]
        public string DisplayName
        {
            get
            {
                return Code + "--" + Name;
            }
        }
        #endregion GENERAL

        #region CONTACT
        [VisibleInListView(false)]
        [Size(20)]
        public string BookingPhone
        {
            get
            {
                return _BookingPhone;
            }
            set
            {
                SetPropertyValue("BookingPhone", ref _BookingPhone, value);
            }
        }

        [VisibleInListView(false)]
        public string BookingEmail
        {
            get
            {
                return _BookingEmail;
            }
            set
            {
                SetPropertyValue("BookingEmail", ref _BookingEmail, value);
            }
        }
        #endregion CONTACT

        #region FEATURE

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [XafDisplayName("24 Hour Security")]
        public bool h24HourSecurity
        {
            get
            {
                return _H24HourSecurity;
            }
            set
            {
                SetPropertyValue("h24HourSecurity", ref _H24HourSecurity, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Breakfast
        {
            get
            {
                return _Breakfast;
            }
            set
            {
                SetPropertyValue("Breakfast", ref _Breakfast, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool DisabledFacilities
        {
            get
            {
                return _DisabledFacilities;
            }
            set
            {
                SetPropertyValue("DisabledFacilities", ref _DisabledFacilities, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Lifts
        {
            get
            {
                return _Lifts;
            }
            set
            {
                SetPropertyValue("Lifts", ref _Lifts, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Pool
        {
            get
            {
                return _Pool;
            }
            set
            {
                SetPropertyValue("Pool", ref _Pool, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool TennisCourt
        {
            get
            {
                return _TennisCourt;
            }
            set
            {
                SetPropertyValue("TennisCourt", ref _TennisCourt, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool AirConditioning
        {
            get
            {
                return _AirConditioning;
            }
            set
            {
                SetPropertyValue("AirConditioning", ref _AirConditioning, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [XafDisplayName("Car Parking (fees may apply)")]
        public bool CarParking
        {
            get
            {
                return _CarParking;
            }
            set
            {
                SetPropertyValue("CarParking", ref _CarParking, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool FreeParking
        {
            get
            {
                return _FreeParking;
            }
            set
            {
                SetPropertyValue("FreeParking", ref _FreeParking, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [XafDisplayName("Non-smoking Room / Floors")]
        public bool NonSmokingRoomFloors
        {
            get
            {
                return _NonSmokingRoomFloors;
            }
            set
            {
                SetPropertyValue("NonSmokingRoomFloors", ref _NonSmokingRoomFloors, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Restaurant
        {
            get
            {
                return _Restaurant;
            }
            set
            {
                SetPropertyValue("Restaurant", ref _Restaurant, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool TourDesk
        {
            get
            {
                return _TourDesk;
            }
            set
            {
                SetPropertyValue("TourDesk", ref _TourDesk, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Babysitting
        {
            get
            {
                return _Babysitting;
            }
            set
            {
                SetPropertyValue("Babysitting", ref _Babysitting, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool ConferenceFacilities
        {
            get
            {
                return _ConferenceFacilities;
            }
            set
            {
                SetPropertyValue("ConferenceFacilities", ref _ConferenceFacilities, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [XafDisplayName("Gym / Fitness Centre")]
        public bool GymFitnessCentre
        {
            get
            {
                return _GymFitnessCentre;
            }
            set
            {
                SetPropertyValue("GymFitnessCentre", ref _GymFitnessCentre, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool PetsAllowed
        {
            get
            {
                return _PetsAllowed;
            }
            set
            {
                SetPropertyValue("PetsAllowed", ref _PetsAllowed, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Sauna
        {
            get
            {
                return _Sauna;
            }
            set
            {
                SetPropertyValue("Sauna", ref _Sauna, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [XafDisplayName("24 Hr Front Desk")]
        public bool h24HrFrontDesk
        {
            get
            {
                return _H24HrFrontDesk;
            }
            set
            {
                SetPropertyValue("h24HrFrontDesk", ref _H24HrFrontDesk, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool BusinessCentre
        {
            get
            {
                return _BusinessCentre;
            }
            set
            {
                SetPropertyValue("BusinessCentre", ref _BusinessCentre, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool DryCleaningFacilities
        {
            get
            {
                return _DryCleaningFacilities;
            }
            set
            {
                SetPropertyValue("DryCleaningFacilities", ref _DryCleaningFacilities, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool LuggageStorage
        {
            get
            {
                return _LuggageStorage;
            }
            set
            {
                SetPropertyValue("LuggageStorage", ref _LuggageStorage, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Porterage
        {
            get
            {
                return _Porterage;
            }
            set
            {
                SetPropertyValue("Porterage", ref _Porterage, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [XafDisplayName("BBQ Facilities")]
        public bool BBQFacilities
        {
            get
            {
                return _BBQFacilities;
            }
            set
            {
                SetPropertyValue("BBQFacilities", ref _BBQFacilities, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool ChildrenFacilities
        {
            get
            {
                return _ChildrenFacilities;
            }
            set
            {
                SetPropertyValue("ChildrenFacilities", ref _ChildrenFacilities, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool GuestLaundry
        {
            get
            {
                return _GuestLaundry;
            }
            set
            {
                SetPropertyValue("GuestLaundry", ref _GuestLaundry, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Parking
        {
            get
            {
                return _Parking;
            }
            set
            {
                SetPropertyValue("Parking", ref _Parking, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool RoomService
        {
            get
            {
                return _RoomService;
            }
            set
            {
                SetPropertyValue("RoomService", ref _RoomService, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [XafDisplayName("Bar / Lounge")]
        public bool BarLounge
        {
            get
            {
                return _BarLounge;
            }
            set
            {
                SetPropertyValue("BarLounge", ref _BarLounge, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool CurrencyExchangeService
        {
            get
            {
                return _CurrencyExchangeService;
            }
            set
            {
                SetPropertyValue("CurrencyExchangeService", ref _CurrencyExchangeService, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool InternetAccess
        {
            get
            {
                return _InternetAccess;
            }
            set
            {
                SetPropertyValue("InternetAccess", ref _InternetAccess, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool PhotocopyService
        {
            get
            {
                return _PhotocopyService;
            }
            set
            {
                SetPropertyValue("PhotocopyService", ref _PhotocopyService, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        public bool Spa
        {
            get
            {
                return _Spa;
            }
            set
            {
                SetPropertyValue("Spa", ref _Spa, value);
            }
        }
        #endregion FEATURE

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string Userful
        {
            get
            {
                return _Userful;
            }
            set
            {
                SetPropertyValue("Userful", ref _Userful, value);
            }
        }

        #region Policy
        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string BookingPolicy
        {
            get
            {
                return _BookingPolicy;
            }
            set
            {
                SetPropertyValue("BookingPolicy", ref _BookingPolicy, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string CheckInPolicy
        {
            get
            {
                return _CheckInPolicy;
            }
            set
            {
                SetPropertyValue("CheckInPolicy", ref _CheckInPolicy, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string CheckOutPolicy
        {
            get
            {
                return _CheckOutPolicy;
            }
            set
            {
                SetPropertyValue("CheckOutPolicy", ref _CheckOutPolicy, value);
            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string CancelPolicy
        {
            get
            {
                return _CancelPolicy;
            }
            set
            {
                SetPropertyValue("CancelPolicy", ref _CancelPolicy, value);
            }
        }

        [XafDisplayName("Child & Extra Bed Policy")]
        [VisibleInListView(false), VisibleInLookupListView(false)]
        [Size(SizeAttribute.Unlimited)]
        public string ChildAndExtraBedPolicy
        {
            get
            {
                return _ChildAndExtraBedPolicy;
            }
            set
            {
                SetPropertyValue("ChildAndExtraBedPolicy", ref _ChildAndExtraBedPolicy, value);
            }
        }

        #endregion Policy

        #region BANKING TRANSACTION WITH NAMOLY

        [VisibleInListView(false)]
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

        [VisibleInListView(false)]
        [Size(30)]
        public string BankAccount
        {
            get
            {
                return _BankAccount;
            }
            set
            {
                SetPropertyValue("BankAccount", ref _BankAccount, value);
            }
        }

        [VisibleInListView(false)]
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

        [VisibleInListView(false)]
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

        #endregion BANKING TRANSACTION WITH NAMOLY

        #region FOR VAT INVOICE

        [VisibleInListView(false)]
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                SetPropertyValue("CompanyName", ref _CompanyName, value);
            }
        }

        [VisibleInListView(false)]
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

        [VisibleInListView(false)]
        public string AddressInInvoice
        {
            get
            {
                return _AddressInInvoice;
            }
            set
            {
                SetPropertyValue("AddressInInvoice", ref _AddressInInvoice, value);
            }
        }

        #endregion FOR VAT INVOICE

        #endregion Properties


        #region Association
        [XafDisplayName("Other Contact")]
        [Association("HotelInfomation-HotelContacts"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelContact> Contacts
        {
            get
            {
                return GetCollection<HotelContact>("Contacts");
            }
        }


        [Association("HotelInfomation-HotelFloors"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelFloor> Floors
        {
            get
            {
                return GetCollection<HotelFloor>("Floors");
            }
        }


        [Association("HotelInfomation-HotelViews"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelView> Views
        {
            get
            {
                return GetCollection<HotelView>("Views");
            }
        }


        [Association("HotelInfomation-HotelBeds"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelBed> Beds
        {
            get
            {
                return GetCollection<HotelBed>("Beds");
            }
        }


        [Association("HotelInfomation-HotelImages"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelImage> Images
        {
            get
            {
                return GetCollection<HotelImage>("Images");
            }
        }

        [XafDisplayName("Other Policies")]
        [Association("HotelInfomation-HotelPolicys"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelPolicy> Policies
        {
            get
            {
                return GetCollection<HotelPolicy>("Policies");
            }
        }


        [Association("HotelInfomation-HotelRoomTypes"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelRoomType> RoomTypes
        {
            get
            {
                return GetCollection<HotelRoomType>("RoomTypes");
            }
        }
        #endregion Association


        #region Logic

        protected XPCollection<City> CityDataSource
        {
            get
            {
                if (Country != null)
                    return new XPCollection<City>(Session, new BinaryOperator("Country", Country));
                else
                    return new XPCollection<City>(Session);
            }
        }

        #endregion Logic
    }
}
