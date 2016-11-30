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
using CMSModule.Module.BusinessObjects.CMS.Galina._3_Accomodation;

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class AccomodationSuperiorRoom : BaseObject
    {
        public AccomodationSuperiorRoom(Session session)  : base(session)  { }
        public override void AfterConstruction() { base.AfterConstruction();}

        // Fields...

        // Fields...
        private string _DescriptionP01RU;
        private string _DescriptionP01VN;
        private string _DescriptionP01;
        private string _TitleP01RU;
        private string _TitleP01VN;
        private string _TitleP01;

        public string TitleP01
        {
            get
            {
                return _TitleP01;
            }
            set
            {
                SetPropertyValue("TitleP01", ref _TitleP01, value);
            }
        }

        public string TitleP01VN
        {
            get
            {
                return _TitleP01VN;
            }
            set
            {
                SetPropertyValue("TitleP01VN", ref _TitleP01VN, value);
            }
        }

        public string TitleP01RU
        {
            get
            {
                return _TitleP01RU;
            }
            set
            {
                SetPropertyValue("TitleP01RU", ref _TitleP01RU, value);
            }
        }

        public string DescriptionP01
        {
            get
            {
                return _DescriptionP01;
            }
            set
            {
                SetPropertyValue("DescriptionP01", ref _DescriptionP01, value);
            }
        }

        public string DescriptionP01VN
        {
            get
            {
                return _DescriptionP01VN;
            }
            set
            {
                SetPropertyValue("DescriptionP01VN", ref _DescriptionP01VN, value);
            }
        }

        public string DescriptionP01RU
        {
            get
            {
                return _DescriptionP01RU;
            }
            set
            {
                SetPropertyValue("DescriptionP01RU", ref _DescriptionP01RU, value);
            }
        }


        #region Association
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<ListImagesSuperiorRoom> ListSlider
        {
            get
            {
                return GetCollection<ListImagesSuperiorRoom>("ListSlider");
            }
        }

        #endregion
    }
}
