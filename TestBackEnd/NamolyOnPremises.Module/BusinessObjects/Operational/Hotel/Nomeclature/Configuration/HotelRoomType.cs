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

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [DefaultClassOptions]
    [ImageName("Action_WindowList")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [Indices("Code", "Name")]
    public class HotelRoomType : BaseObject
    {
        public HotelRoomType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }



        // Fields...
        private HotelInfomation _Hotel;
        private string _Description;
        private int _OverbookNumber;
        private int _BabyCotAllowed;
        private int _ExtraBedAllowed;
        private int _MaxOccupancy;
        private int _BaseOccupancy;
        private string _Name;
        private string _Code;



        #region Properties

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

        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public int BaseOccupancy
        {
            get
            {
                return _BaseOccupancy;
            }
            set
            {
                SetPropertyValue("BaseOccupancy", ref _BaseOccupancy, value);
            }
        }

        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public int MaxOccupancy
        {
            get
            {
                return _MaxOccupancy;
            }
            set
            {
                SetPropertyValue("MaxOccupancy", ref _MaxOccupancy, value);
            }
        }

        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public int ExtraBedAllowed
        {
            get
            {
                return _ExtraBedAllowed;
            }
            set
            {
                SetPropertyValue("ExtraBedAllowed", ref _ExtraBedAllowed, value);
            }
        }

        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public int BabyCotAllowed
        {
            get
            {
                return _BabyCotAllowed;
            }
            set
            {
                SetPropertyValue("BabyCotAllowed", ref _BabyCotAllowed, value);
            }
        }

        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public int OverbookNumber
        {
            get
            {
                return _OverbookNumber;
            }
            set
            {
                SetPropertyValue("OverbookNumber", ref _OverbookNumber, value);
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
        #endregion Properties



        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelInfomation-HotelRoomTypes")]
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

        [Association("HotelRoomType-HotelRateTypes"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelRateType> Rates
        {
            get
            {
                return GetCollection<HotelRateType>("Rates");
            }
        }
        #endregion Association
    }
}
