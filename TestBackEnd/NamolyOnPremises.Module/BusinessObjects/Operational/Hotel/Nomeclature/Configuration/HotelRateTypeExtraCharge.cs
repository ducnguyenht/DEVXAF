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
    [XafDisplayName("Extra Charge")]
    [DefaultClassOptions]
    [ImageName("BO_Opportunity")]
    [DefaultProperty("Name")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    public class HotelRateTypeExtraCharge : BaseObject
    {
        public HotelRateTypeExtraCharge(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private HotelPackage _Package;
        private HotelRateType _RateType;
        private string _Description;
        private decimal _Rate;
        private HotelExtraChargeCategory _Category;
        private string _Name;



        #region Properties


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

        public HotelExtraChargeCategory Category
        {
            get
            {
                return _Category;
            }
            set
            {
                SetPropertyValue("Category", ref _Category, value);
            }
        }


        public decimal Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                SetPropertyValue("Rate", ref _Rate, value);
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
        [Association("HotelRateType-HotelRateTypeExtraCharges")]
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

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelPackage-HotelRateTypeExtraCharges")]
        public HotelPackage Package
        {
            get
            {
                return _Package;
            }
            set
            {
                SetPropertyValue("Package", ref _Package, value);
            }
        }

        #endregion Association
    }
}
