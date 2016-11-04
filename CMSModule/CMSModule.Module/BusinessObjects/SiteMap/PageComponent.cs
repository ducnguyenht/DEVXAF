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
using CMSModule.Module.BusinessObjects.CMS.Contents;

namespace CMSModule.BusinessObjects.CMS.WebStructure
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class PageComponent : BaseObject
    {
        public PageComponent(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.CreatedOn = DateTime.Now;
        }
        #region Fields
        private Page _Page;
        private WebSite _WebSite;
        private DateTime _ChangedOn;
        private DateTime _CreatedOn;
        private string _Description;
        private string _Name;
        private string _Code;
        #endregion Fields

        #region Foreign Key

        #endregion Foreign Key

        #region Properties

        [Size(128), Indexed]
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
        [Size(256)]
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
        [Size(1024)]
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


        [Browsable(false)]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy}"), ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime CreatedOn
        {
            get
            {
                return _CreatedOn;
            }
            set
            {
                SetPropertyValue("CreatedOn", ref _CreatedOn, value);
            }
        }

        [Browsable(false)]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy}"), ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime ChangedOn
        {
            get
            {
                return _ChangedOn;
            }
            set
            {
                SetPropertyValue("ChangedOn", ref _ChangedOn, value);
            }
        }

        public WebSite WebSite
        {
            get
            {
                return _WebSite;
            }
            set
            {
                SetPropertyValue("WebSite", ref _WebSite, value);
            }
        }


        public Page Page
        {
            get
            {
                return _Page;
            }
            set
            {
                SetPropertyValue("Page", ref _Page, value);
            }
        }

        #endregion Properties

        #region Association
        [Association("PageComponent-Contents"), DevExpress.Xpo.Aggregated]
        public XPCollection<Content> Contents
        {
            get
            {
                return GetCollection<Content>("Contents");
            }
        }


        #endregion Association

        #region Logic

        #endregion Logic

        #region Override

        #endregion Override

    }
    public enum WebSite
    {
        SiteA,
        SiteB,
        SiteC
    }
    public enum Page
    {
        Home,
        AboutUs,
    }

}
