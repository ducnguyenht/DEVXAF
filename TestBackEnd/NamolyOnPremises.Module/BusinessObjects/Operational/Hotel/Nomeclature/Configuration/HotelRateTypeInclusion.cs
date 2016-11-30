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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    public class HotelRateTypeInclusion : BaseObject
    {
        public HotelRateTypeInclusion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }



        // Fields...
        private HotelRateType _RateType;
        private string _Description;
        private object _Type;
        private string _Title;




        #region Properties


        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                SetPropertyValue("Title", ref _Title, value);
            }
        }

        public object Type
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
        [Association("HotelRateType-HotelRateTypeInclusions")]
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

        #endregion Association
    }
}
