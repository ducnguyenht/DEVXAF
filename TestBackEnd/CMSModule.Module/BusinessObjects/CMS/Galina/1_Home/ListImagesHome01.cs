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
    public class ListImagesHome01 : BaseObject
    { 
        public ListImagesHome01(Session session): base(session) {   }
        public override void AfterConstruction() { base.AfterConstruction(); }

        // Fields...
        private string _Code;

        private FileData _FileData;
        private string _ImageURL;


        private string _TitleRU;
        private string _TitleVN;
        private string _Title;

        private string _DescriptionRU;
        private string _DescriptionVN;
        private string _Description;

        private string _RoutingVN;
        private string _RoutingRU;
        private string _Routing;

        private Home _Home;


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

        [NonPersistent, XafDisplayName("Choose Image"), VisibleInListView(false)]
        public FileData FileData
        {
            get
            {
                return _FileData;
            }
            set
            {
                SetPropertyValue("FileData", ref _FileData, value);
            }
        }

        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURL
        {
            get
            {
                return _ImageURL;
            }
            set
            {
                SetPropertyValue("ImageURL", ref _ImageURL, value);
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




        #endregion

        #region Association
        [Browsable(false)]
        [Association]
        public Home Home
        {
            get
            {
                return _Home;
            }
            set
            {
                SetPropertyValue("Home", ref _Home, value);
            }
        }

        #endregion

        #region logic
        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnail
        {
            get
            {
                if (ImageURL != null && ImageURL != "")
                {
                    return ImageURL.Substring(0, ImageURL.LastIndexOf('.')) + "_thumb" + ImageURL.Substring(ImageURL.LastIndexOf('.'));
                }
                return "";
            }
        }
        #endregion

        #region event
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "ImageURL":
                    if (oldValue != null && oldValue.ToString() != newValue.ToString())
                    {
                        ValidateSystem.DeleteToServer(oldValue.ToString());
                    }
                    break;
            }
        }


        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork) && Session.IsNewObject(this))
            {
                Code = CustomDistributedIdGeneratorHelper.Generate(this.Session.DataLayer, this.GetType(), true, Code);
            }

            ImageURL = ValidateSystem.SaveFileToServer(FileData, "Home");

            base.OnSaving();

        }
        #endregion
    }
}
