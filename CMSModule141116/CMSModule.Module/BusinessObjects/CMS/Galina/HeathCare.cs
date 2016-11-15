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
    public class HeathCare : BaseObject
    {
        public HeathCare(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        #region English


        private string _SubContentRU;
        private string _SubTitleRU;
        private string _SubNameRU;
        private string _SubContentVN;
        private string _SubNameVN;
        private string _SubTitleVN;
        private string _SubContent;
        private string _SubTitle;
        private string _SubName;
        private string _RoutingRU;
        private string _RoutingVN;
        private string _Routing;
        private string _ContentRU;
        private string _ShortDescriptionRU;
        private string _TitleRU;

        private string _ContentVN;
        private string _ShortDescriptionVN;

        private string _TitleVN;


        private string _Content;
        private string _ShortDescription;
        private string _Title;
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
        public string ShortDescription
        {
            get
            {
                return _ShortDescription;
            }
            set
            {
                SetPropertyValue("ShortDescription", ref _ShortDescription, value);
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



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Name"), VisibleInListView(false)]
        public string SubName
        {
            get
            {
                return _SubName;
            }
            set
            {
                SetPropertyValue("SubName", ref _SubName, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Title"), VisibleInListView(false)]
        public string SubTitle
        {
            get
            {
                return _SubTitle;
            }
            set
            {
                SetPropertyValue("SubTitle", ref _SubTitle, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        [XafDisplayName("Content")]
        public string SubContent
        {
            get
            {
                return _SubContent;
            }
            set
            {
                SetPropertyValue("SubContent", ref _SubContent, value);
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
        public string ShortDescriptionVN
        {
            get
            {
                return _ShortDescriptionVN;
            }
            set
            {
                SetPropertyValue("ShortDescriptionVN", ref _ShortDescriptionVN, value);
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Name VN"), VisibleInListView(false)]
        public string SubNameVN
        {
            get
            {
                return _SubNameVN;
            }
            set
            {
                SetPropertyValue("SubNameVN", ref _SubNameVN, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Title VN"), VisibleInListView(false)]
        public string SubTitleVN
        {
            get
            {
                return _SubTitleVN;
            }
            set
            {
                SetPropertyValue("SubTitleVN", ref _SubTitleVN, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        [XafDisplayName("Content VN")]
        public string SubContentVN
        {
            get
            {
                return _SubContentVN;
            }
            set
            {
                SetPropertyValue("SubContentVN", ref _SubContentVN, value);
            }
        }
        #endregion Vietnamese
        #region Russian
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
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
        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
        public string ShortDescriptionRU
        {
            get
            {
                return _ShortDescriptionRU;
            }
            set
            {
                SetPropertyValue("ShortDescriptionRU", ref _ShortDescriptionRU, value);
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


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Name RU"), VisibleInListView(false)]
        public string SubNameRU
        {
            get
            {
                return _SubNameRU;
            }
            set
            {
                SetPropertyValue("SubNameRU", ref _SubNameRU, value);
            }
        }

        [XafDisplayName("Title RU"), VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SubTitleRU
        {
            get
            {
                return _SubTitleRU;
            }
            set
            {
                SetPropertyValue("SubTitleRU", ref _SubTitleRU, value);
            }
        }


        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        [XafDisplayName("Content RU")]
        public string SubContentRU
        {
            get
            {
                return _SubContentRU;
            }
            set
            {
                SetPropertyValue("SubContentRU", ref _SubContentRU, value);
            }
        }

        #endregion Russian
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

//private string _PersistentProperty;
//[XafDisplayName("My display name"), ToolTip("My hint message")]
//[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
//[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
//public string PersistentProperty {
//    get { return _PersistentProperty; }
//    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
//}

//[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
//public void ActionMethod() {
//    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
//    this.PersistentProperty = "Paid";
//}
