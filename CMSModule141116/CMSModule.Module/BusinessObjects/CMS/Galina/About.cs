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
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class About : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public About(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _ContentRU;
        private string _RoutingRU;
        private string _TitleRU;

        private string _ContentVN;
        private string _RoutingVN;
        private string _TitleVN;


        private string _Content;
        private string _Routing;
        private string _Title;


        #region English
        private string _Code;
        [Browsable(false)]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
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
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        
        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string Content
        {
            get
            {
                return _Content;
            }
            set
            {
                SetPropertyValue("Content", ref _Content, value);
            }
        }
        #endregion English
        #region Vietnamese
        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        
        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVN
        {
            get
            {
                return _ContentVN;
            }
            set
            {
                SetPropertyValue("ContentVN", ref _ContentVN, value);
            }
        }
        #endregion Vietnamese
        #region Russia

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRU
        {
            get
            {
                return _ContentRU;
            }
            set
            {
                SetPropertyValue("ContentRU", ref _ContentRU, value);
            }
        }
        #endregion Russia
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<Picture> Pictures
        {
            get
            {
                return GetCollection<Picture>("Pictures");
            }
        }
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Title":
                    Routing = ValidateSystem.RejectMarks(Title, "-");
                    break;
                case "TitleVN":
                    RoutingVN = ValidateSystem.RejectMarks(TitleVN, "-");
                    break;
                case "TitleRU":
                    RoutingRU = ValidateSystem.RejectMarks(TitleRU, "-");
                    break;
            }
        }
    }
}