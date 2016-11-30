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
    [ImageName("ActionGroup_EasyTestRecorder")]
    [DefaultProperty("PolicyType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [RuleCombinationOfPropertiesIsUnique("HotelPolicy_Unique", DefaultContexts.Save, "PolicyType, Hotel", CustomMessageTemplate = "Policy exists.")]

    public class HotelPolicy : BaseObject
    {
        public HotelPolicy(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private HotelInfomation _Hotel;
        private string _PolicyContent;
        private object _PolicyType;



        #region Properties


        public object PolicyType
        {
            get
            {
                return _PolicyType;
            }
            set
            {
                SetPropertyValue("PolicyType", ref _PolicyType, value);
            }
        }

        [Size(SizeAttribute.Unlimited)]
        public string PolicyContent
        {
            get
            {
                return _PolicyContent;
            }
            set
            {
                SetPropertyValue("PolicyContent", ref _PolicyContent, value);
            }
        }

        #endregion Properties

        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelInfomation-HotelPolicys")]
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

        #endregion Association
    }
}
