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
using System.IO;
using System.Web;

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class Picture : BaseObject
    {
        public Picture(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private HeathCare _HeathCare;
        private MudBathAndSpa _MudBathAndSpa;
        private Wedding _Wedding;
        private Dining _Dining;
        //private About _About;
        private Accomodation _Accomodation;
        private string _ImageUrl;
        private FileData _FileData;




        [Association, Browsable(false)]
        public HeathCare HeathCare
        {
            get
            {
                return _HeathCare;
            }
            set
            {
                SetPropertyValue("HeathCare", ref _HeathCare, value);
            }
        }
        // Fields...

        [Association, Browsable(false)]
        public MudBathAndSpa MudBathAndSpa
        {
            get
            {
                return _MudBathAndSpa;
            }
            set
            {
                SetPropertyValue("MudBathAndSpa", ref _MudBathAndSpa, value);
            }
        }



        [Association, Browsable(false)]
        public Wedding Wedding
        {
            get
            {
                return _Wedding;
            }
            set
            {
                SetPropertyValue("Wedding", ref _Wedding, value);
            }
        }


        [Association, Browsable(false)]
        public Dining Dining
        {
            get
            {
                return _Dining;
            }
            set
            {
                SetPropertyValue("Dining", ref _Dining, value);
            }
        }

        //[Browsable(false)]
        //[Association]
        //public About About
        //{
        //    get
        //    {
        //        return _About;
        //    }
        //    set
        //    {
        //        SetPropertyValue("About", ref _About, value);
        //    }
        //}


        [Browsable(false)]
        [Association]
        public Accomodation Accomodation
        {
            get
            {
                return _Accomodation;
            }
            set
            {
                SetPropertyValue("Accomodation", ref _Accomodation, value);
            }
        }


        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnail
        {
            get
            {
                if (ImageUrl != null)
                {
                    return ImageUrl.Substring(0, ImageUrl.LastIndexOf('.')) + "_thumb" + ImageUrl.Substring(ImageUrl.LastIndexOf('.'));
                }
                return "";
            }
        }


        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageUrl
        {
            get
            {
                return _ImageUrl;
            }
            set
            {
                SetPropertyValue("ImageUrl", ref _ImageUrl, value);
            }
        }


        [NonPersistent, XafDisplayName("Choose Image"), VisibleInListView(false)]//, 
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




        protected override void OnSaving()
        {
            base.OnSaving();
            ImageUrl = ValidateSystem.SaveFileToServer(FileData, "All");
        }


        protected override void OnDeleting()
        {
            base.OnDeleting();
            try
            {
                File.Delete(HttpContext.Current.Request.MapPath(new Uri(ImageUrl).PathAndQuery));
                File.Delete(HttpContext.Current.Request.MapPath(ImageHelper.ToThumb(new Uri(ImageUrl).PathAndQuery)));
            }
            catch (Exception)
            {
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
//    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
//    this.PersistentProperty = "Paid";
//}