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

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ListArticleABout : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ListArticleABout(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        // Fields...
        private string _Code;
        private string _CreateYear;
        private string _DescriptionRU;
        private string _DescriptionVN;
        private string _Description;
        private string _RoutingRU;
        private string _RoutingVN;
        private string _Routing;
        private string _TitleRU;
        private string _TitleVN;
        private string _Title;
        private About _About;

        #region get-set


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

        public string TitleVN
        {
            get
            {
                return _TitleVN;
            }
            set
            {
                SetPropertyValue("TitleVN", ref _TitleVN, value);
            }
        }

        public string TitleRU
        {
            get
            {
                return _TitleRU;
            }
            set
            {
                SetPropertyValue("TitleRU", ref _TitleRU, value);
            }
        }

        public string Routing
        {
            get
            {
                return _Routing;
            }
            set
            {
                SetPropertyValue("Routing", ref _Routing, value);
            }
        }

        public string RoutingVN
        {
            get
            {
                return _RoutingVN;
            }
            set
            {
                SetPropertyValue("RoutingVN", ref _RoutingVN, value);
            }
        }

        public string RoutingRU
        {
            get
            {
                return _RoutingRU;
            }
            set
            {
                SetPropertyValue("RoutingRU", ref _RoutingRU, value);
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

        public string DescriptionVN
        {
            get
            {
                return _DescriptionVN;
            }
            set
            {
                SetPropertyValue("DescriptionVN", ref _DescriptionVN, value);
            }
        }


        public string DescriptionRU
        {
            get
            {
                return _DescriptionRU;
            }
            set
            {
                SetPropertyValue("DescriptionRU", ref _DescriptionRU, value);
            }
        }


        public string CreateYear
        {
            get
            {
                return _CreateYear;
            }
            set
            {
                SetPropertyValue("CreateYear", ref _CreateYear, value);
            }
        }
        #endregion

        #region assocation
        [Browsable(false)]
        [Association]
        public About About
        {
            get
            {
                return _About;
            }
            set
            {
                SetPropertyValue("About", ref _About, value);
            }
        }
        #endregion

        #region event

        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork) && Session.IsNewObject(this))
            {
                Code = CustomDistributedIdGeneratorHelper.Generate(this.Session.DataLayer, this.GetType(), true, Code);
            }



            base.OnSaving();

        }
        #endregion
    }
}
