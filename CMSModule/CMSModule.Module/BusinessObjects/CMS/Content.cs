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
    public abstract class Content : BaseObject
    {
        public Content(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        // Fields...
        private string _DataJson;
        private ContentType _ContentType;
        private PageComponent _PageComponent;
        private string _Title;
        private string _Description;
        private string _Code;
        [Browsable(false)]
        public ContentType ContentType
        {
            get
            {
                return _ContentType;
            }
            set
            {
                SetPropertyValue("ContentType", ref _ContentType, value);
            }
        }
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
        [Size(SizeAttribute.Unlimited)]
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


        [Association("PageComponent-Contents")]
        public PageComponent PageComponent
        {
            get
            {
                return _PageComponent;
            }
            set
            {
                SetPropertyValue("PageComponent", ref _PageComponent, value);
            }
        }

        public string DataJson
        {
            get
            {
                return _DataJson;
            }
            set
            {
                SetPropertyValue("DataJson", ref _DataJson, value);
            }
        }
        protected abstract string PackageToJson();

    }
    public enum ContentType
    {
        [DevExpress.Xpo.DisplayName("Article")]
        Article,
        [DevExpress.Xpo.DisplayName("Advertisement")]
        Advertisement,
        [DevExpress.Xpo.DisplayName("Image")]
        Image,
        [DevExpress.Xpo.DisplayName("Video")]
        Video,
        [DevExpress.Xpo.DisplayName("Event")]
        Event,
        [DevExpress.Xpo.DisplayName("ImageList")]
        ImageList,
        [DevExpress.Xpo.DisplayName("SalesLocations")]
        SalesLocations,
        [DevExpress.Xpo.DisplayName("Other")]
        Other
    }
}