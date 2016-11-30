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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [XafDisplayName("Rate Type")]
    [DefaultClassOptions]
    [ImageName("BO_Sale_Item")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [Indices("Code", "Name")]
    public class HotelRateType : BaseObject
    {
        public HotelRateType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsNight = true;
            IsHour = false;
            IsStandardRate = false;
        }




        // Fields...
        private decimal _MoneyValue;
        private bool _IncludeServiceCharge;
        private bool _Include10PercentageTaxVAT;
        private object _RateType;
        private HotelRoomType _RoomType;
        private DateTime _EffectiveTo;
        private DateTime _EffectiveFrom;
        private decimal _RateSixthHour;
        private decimal _RateFifthHour;
        private decimal _RateFourthHour;
        private decimal _RateThirdHour;
        private decimal _RateSecondHour;
        private decimal _RateFirstHour;
        private int _MinNightSun;
        private int _MinNightSat;
        private int _MinNightFri;
        private int _MinNightThu;
        private int _MinNightWed;
        private int _MinNightTue;
        private int _MinNightMon;
        private decimal _RateSun;
        private decimal _RateSat;
        private decimal _RateFri;
        private decimal _RateThu;
        private decimal _RateWed;
        private decimal _RateTue;
        private decimal _RateMon;
        private bool _CheckSun;
        private bool _CheckSat;
        private bool _CheckFri;
        private bool _CheckThu;
        private bool _CheckWed;
        private bool _CheckTue;
        private bool _CheckMon;
        private string _Description;
        private decimal _UpchargeExtraBed;
        private decimal _UpchargeExtraPerson;
        private bool _IsStandardRate;
        private bool _IsHour;
        private bool _IsNight;
        private string _Name;
        private string _Code;




        #region Properties
        [Index(0)]
        [XafDisplayName("Code(*)")]
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

        [Index(1)]
        [XafDisplayName("Name(*)")]
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

        public object RateType
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

        [ImmediatePostData]
        [VisibleInListView(false)]
        public bool IsNight
        {
            get
            {
                return _IsNight;
            }
            set
            {
                SetPropertyValue("IsNight", ref _IsNight, value);
                if (!IsSaving && !IsLoading)
                {
                    if (_IsNight)
                        IsNightChecked();
                    else
                        IsNightUnChecked();
                }
            }
        }

        [ImmediatePostData]
        [VisibleInListView(false)]
        public bool IsHour
        {
            get
            {
                return _IsHour;
            }
            set
            {
                SetPropertyValue("IsHour", ref _IsHour, value);
                if (!IsSaving && !IsLoading)
                {
                    if (_IsHour)
                        IsHoursChecked();
                    else
                        IsHoursUnChecked();
                }
            }
        }

        [ImmediatePostData]
        [VisibleInListView(false)]
        public bool IsStandardRate
        {
            get
            {
                return _IsStandardRate;
            }
            set
            {
                SetPropertyValue("IsStandardRate", ref _IsStandardRate, value);
                if (!IsSaving && !IsLoading)
                {
                    if (_IsStandardRate)
                        IsStandardRateChecked();
                }
            }
        }

        [Appearance("", Criteria = "IsStandardRate = true", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal UpchargeExtraPerson
        {
            get
            {
                return _UpchargeExtraPerson;
            }
            set
            {
                SetPropertyValue("UpchargeExtraPerson", ref _UpchargeExtraPerson, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal UpchargeExtraBed
        {
            get
            {
                return _UpchargeExtraBed;
            }
            set
            {
                SetPropertyValue("UpchargeExtraBed", ref _UpchargeExtraBed, value);
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                SetPropertyValue("Description", ref _Description, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        [XafDisplayName("Mon")]
        public bool CheckMon
        {
            get
            {
                return _CheckMon;
            }
            set
            {
                SetPropertyValue("CheckMon", ref _CheckMon, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        [XafDisplayName("Tue")]
        public bool CheckTue
        {
            get
            {
                return _CheckTue;
            }
            set
            {
                SetPropertyValue("CheckTue", ref _CheckTue, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        [XafDisplayName("Wed")]
        public bool CheckWed
        {
            get
            {
                return _CheckWed;
            }
            set
            {
                SetPropertyValue("CheckWed", ref _CheckWed, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        [XafDisplayName("Thu")]
        public bool CheckThu
        {
            get
            {
                return _CheckThu;
            }
            set
            {
                SetPropertyValue("CheckThu", ref _CheckThu, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        [XafDisplayName("Fri")]
        public bool CheckFri
        {
            get
            {
                return _CheckFri;
            }
            set
            {
                SetPropertyValue("CheckFri", ref _CheckFri, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        [XafDisplayName("Sat")]
        public bool CheckSat
        {
            get
            {
                return _CheckSat;
            }
            set
            {
                SetPropertyValue("CheckSat", ref _CheckSat, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        [XafDisplayName("Sun")]
        public bool CheckSun
        {
            get
            {
                return _CheckSun;
            }
            set
            {
                SetPropertyValue("CheckSun", ref _CheckSun, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [XafDisplayName("Rate")]
        [VisibleInListView(false)]
        public decimal RateMon
        {
            get
            {
                return _RateMon;
            }
            set
            {
                SetPropertyValue("RateMon", ref _RateMon, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateTue
        {
            get
            {
                return _RateTue;
            }
            set
            {
                SetPropertyValue("RateTue", ref _RateTue, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateWed
        {
            get
            {
                return _RateWed;
            }
            set
            {
                SetPropertyValue("RateWed", ref _RateWed, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateThu
        {
            get
            {
                return _RateThu;
            }
            set
            {
                SetPropertyValue("RateThu", ref _RateThu, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateFri
        {
            get
            {
                return _RateFri;
            }
            set
            {
                SetPropertyValue("RateFri", ref _RateFri, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateSat
        {
            get
            {
                return _RateSat;
            }
            set
            {
                SetPropertyValue("RateSat", ref _RateSat, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateSun
        {
            get
            {
                return _RateSun;
            }
            set
            {
                SetPropertyValue("RateSun", ref _RateSun, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Min Night")]
        [VisibleInListView(false)]
        public int MinNightMon
        {
            get
            {
                return _MinNightMon;
            }
            set
            {
                SetPropertyValue("MinNightMon", ref _MinNightMon, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        public int MinNightTue
        {
            get
            {
                return _MinNightTue;
            }
            set
            {
                SetPropertyValue("MinNightTue", ref _MinNightTue, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        public int MinNightWed
        {
            get
            {
                return _MinNightWed;
            }
            set
            {
                SetPropertyValue("MinNightWed", ref _MinNightWed, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        public int MinNightThu
        {
            get
            {
                return _MinNightThu;
            }
            set
            {
                SetPropertyValue("MinNightThu", ref _MinNightThu, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        public int MinNightFri
        {
            get
            {
                return _MinNightFri;
            }
            set
            {
                SetPropertyValue("MinNightFri", ref _MinNightFri, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        public int MinNightSat
        {
            get
            {
                return _MinNightSat;
            }
            set
            {
                SetPropertyValue("MinNightSat", ref _MinNightSat, value);
            }
        }

        [Appearance("", Criteria = "IsNight = false", Visibility = ViewItemVisibility.Hide)]
        [VisibleInListView(false)]
        public int MinNightSun
        {
            get
            {
                return _MinNightSun;
            }
            set
            {
                SetPropertyValue("MinNightSun", ref _MinNightSun, value);
            }
        }

        [Appearance("", Criteria = "IsHour = false", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Rate 1 Hours")]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateFirstHour
        {
            get
            {
                return _RateFirstHour;
            }
            set
            {
                SetPropertyValue("RateFirstHour", ref _RateFirstHour, value);
            }
        }

        [Appearance("", Criteria = "IsHour = false", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Rate 2 Hours")]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateSecondHour
        {
            get
            {
                return _RateSecondHour;
            }
            set
            {
                SetPropertyValue("RateSecondHour", ref _RateSecondHour, value);
            }
        }

        [Appearance("", Criteria = "IsHour = false", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Rate 3 Hours")]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateThirdHour
        {
            get
            {
                return _RateThirdHour;
            }
            set
            {
                SetPropertyValue("RateThirdHour", ref _RateThirdHour, value);
            }
        }

        [Appearance("", Criteria = "IsHour = false", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Rate 4 Hours")]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateFourthHour
        {
            get
            {
                return _RateFourthHour;
            }
            set
            {
                SetPropertyValue("RateFourthHour", ref _RateFourthHour, value);
            }
        }

        [Appearance("", Criteria = "IsHour = false", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Rate 5 Hours")]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateFifthHour
        {
            get
            {
                return _RateFifthHour;
            }
            set
            {
                SetPropertyValue("RateFifthHour", ref _RateFifthHour, value);
            }
        }

        [Appearance("", Criteria = "IsHour = false", Visibility = ViewItemVisibility.Hide)]
        [XafDisplayName("Rate 6 Hours")]
        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        [VisibleInListView(false)]
        public decimal RateSixthHour
        {
            get
            {
                return _RateSixthHour;
            }
            set
            {
                SetPropertyValue("RateSixthHour", ref _RateSixthHour, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime EffectiveFrom
        {
            get
            {
                return _EffectiveFrom;
            }
            set
            {
                SetPropertyValue("EffectiveFrom", ref _EffectiveFrom, value);
            }
        }

        [VisibleInListView(false)]
        public DateTime EffectiveTo
        {
            get
            {
                return _EffectiveTo;
            }
            set
            {
                SetPropertyValue("EffectiveTo", ref _EffectiveTo, value);
            }
        }

        [XafDisplayName("Include 10% tax VAT")]
        public bool Include10PercentageTaxVAT
        {
            get
            {
                return _Include10PercentageTaxVAT;
            }
            set
            {
                SetPropertyValue("Include10PercentageTaxVAT", ref _Include10PercentageTaxVAT, value);
            }
        }

        public bool IncludeServiceCharge
        {
            get
            {
                return _IncludeServiceCharge;
            }
            set
            {
                SetPropertyValue("IncludeServiceCharge", ref _IncludeServiceCharge, value);
            }
        }

        [ModelDefault("DisplayFormat", "{0: #,####,###,###,###}"), ModelDefault("EditMask", "#,####,###,###,###")]
        public decimal MoneyValue
        {
            get
            {
                return _MoneyValue;
            }
            set
            {
                SetPropertyValue("MoneyValue", ref _MoneyValue, value);
            }
        }
        #endregion Properties

        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelRoomType-HotelRateTypes")]
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

        [Association("HotelRateType-HotelRateTypeInclusions"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelRateTypeInclusion> Inclusions
        {
            get
            {
                return GetCollection<HotelRateTypeInclusion>("Inclusions");
            }
        }

        [Association("HotelRateType-HotelRateTypeExtraCharges"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelRateTypeExtraCharge> ExtraCharges
        {
            get
            {
                return GetCollection<HotelRateTypeExtraCharge>("ExtraCharges");
            }
        }

        #endregion Association


        #region Logic

        public void IsNightChecked()
        {
            IsHour = false;
            OnChanged("IsHour");
            IsStandardRate = false;
            OnChanged("IsStandardRate");

            CheckMon = true;
            OnChanged("CheckMon");
            CheckTue = true;
            OnChanged("CheckTue");
            CheckWed = true;
            OnChanged("CheckWed");
            CheckThu = true;
            OnChanged("CheckThu");
            CheckFri = true;
            OnChanged("CheckFri");
            CheckSat = true;
            OnChanged("CheckSat");
            CheckSun = true;
            OnChanged("CheckSun");
        }

        public void IsNightUnChecked()
        {
            UpchargeExtraBed = default(decimal);
            OnChanged("UpchargeExtraBed");
            UpchargeExtraPerson = default(decimal);
            OnChanged("UpchargeExtraPerson");

            CheckMon = false;
            OnChanged("CheckMon");
            CheckTue = false;
            OnChanged("CheckTue");
            CheckWed = false;
            OnChanged("CheckWed");
            CheckThu = false;
            OnChanged("CheckThu");
            CheckFri = false;
            OnChanged("CheckFri");
            CheckSat = false;
            OnChanged("CheckSat");
            CheckSun = false;
            OnChanged("CheckSun");

            RateMon = default(decimal);
            OnChanged("RateMon");
            RateTue = default(decimal);
            OnChanged("RateTue");
            RateWed = default(decimal);
            OnChanged("RateWed");
            RateThu = default(decimal);
            OnChanged("RateThu");
            RateFri = default(decimal);
            OnChanged("RateFri");
            RateSat = default(decimal);
            OnChanged("RateSat");
            RateSun = default(decimal);
            OnChanged("RateSun");

            MinNightMon = default(int);
            OnChanged("MinNightMon");
            MinNightTue = default(int);
            OnChanged("MinNightTue");
            MinNightWed = default(int);
            OnChanged("MinNightWed");
            MinNightThu = default(int);
            OnChanged("MinNightThu");
            MinNightFri = default(int);
            OnChanged("MinNightFri");
            MinNightSat = default(int);
            OnChanged("MinNightSat");
            MinNightSun = default(int);
            OnChanged("MinNightSun");
        }

        public void IsHoursChecked()
        {
            IsNight = false;
            OnChanged("IsNight");
            IsStandardRate = false;
            OnChanged("IsStandardRate");
        }

        public void IsHoursUnChecked()
        {
            UpchargeExtraPerson = default(decimal);
            OnChanged("UpchargeExtraPerson");

            RateFirstHour = default(decimal);
            OnChanged("RateFirstHour");
            RateSecondHour = default(decimal);
            OnChanged("RateSecondHour");
            RateThirdHour = default(decimal);
            OnChanged("RateThirdHour");
            RateFourthHour = default(decimal);
            OnChanged("RateFourthHour");
            RateFifthHour = default(decimal);
            OnChanged("RateFifthHour");
            RateSixthHour = default(decimal);
            OnChanged("RateSixthHour");
        }

        public void IsStandardRateChecked()
        {
            IsNight = false;
            OnChanged("IsNight");
            IsHour = false;
            OnChanged("IsHour");
        }

        #endregion Logic
    }
}
