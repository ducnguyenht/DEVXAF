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
    [ImageName("BO_Sale_Item_v92")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class HotelPackage : BaseObject
    {
        public HotelPackage(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        // Fields...
        private string _Descriprtion;
        private string _Name;

        #region Properties

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


        public string Descriprtion
        {
            get
            {
                return _Descriprtion;
            }
            set
            {
                SetPropertyValue("Descriprtion", ref _Descriprtion, value);
            }
        }
        #endregion Properties


        #region Association

        [Association("HotelPackage-HotelRateTypeExtraCharges"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelRateTypeExtraCharge> ExtraCharge
        {
            get
            {
                return GetCollection<HotelRateTypeExtraCharge>("ExtraCharge");
            }
        }

        #endregion Association
    }
}
