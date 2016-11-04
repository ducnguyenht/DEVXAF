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
using CMSModule.BusinessObjects.CMS.WebStructure;

namespace CMSModule.Module.BusinessObjects.CMS.Contents
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class Article : Content
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Article(Session session)
            : base(session)
        {
            ContentType = ContentType.Article;
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #region English

        #endregion English

        #region Vietnamese
        //private string _RoutingVN;
        //private string _DescriptionVN;
        //private string _TitleVN;
        // Fields...
        private string _DescriptionVN;
        private string _TitleVN;

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
        [Size(SizeAttribute.Unlimited)]
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
        #endregion Vietnamese

        protected override string PackageToJson()
        {
            return "AAA";
        }
    }
}
