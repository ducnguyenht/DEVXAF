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
    public class LibraryImage : BaseObject
    {
        public LibraryImage(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        // Fields...
        private string _RoutingVN;
        private string _RoutingRU;
        private string _Routing;
        private string _TitleRU;
        private string _TitleVN;
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

        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInListView(true), VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnail
        {
            get
            {
                if (PresentationImageUrl != null)
                {
                    return PresentationImageUrl.Substring(0, PresentationImageUrl.LastIndexOf('.')) + "_thumb" + PresentationImageUrl.Substring(PresentationImageUrl.LastIndexOf('.'));
                }
                return "";
            }
        }

        private string _PresentationImageUrl;
        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(false)]//, Browsable(false)]
        public string PresentationImageUrl
        {
            get
            {
                return _PresentationImageUrl;
            }
            set
            {
                SetPropertyValue("PresentationImageUrl", ref _PresentationImageUrl, value);
            }
        }

        private FileData _FileData;
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
            if (FileData != null)
            {
                if (!FileData.IsEmpty)
                {
                    var request = System.Web.HttpContext.Current.Request;
                    var requestUrl = request.Url;
                    string filePath = request.MapPath("~/FileData/" + FileData.FileName);
                    if (!System.IO.File.Exists(filePath))
                    {
                        System.IO.Stream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        FileData.SaveToStream(stream);
                        var currentPicture = System.Drawing.Image.FromStream(new System.IO.MemoryStream(FileData.Content));
                        var thumbImage = ImageHelper.ScaleImage(currentPicture, 100);
                        int fileExtPos = FileData.FileName.LastIndexOf(".");
                        string thumbPath = "";
                        if (fileExtPos >= 0)
                            thumbPath = FileData.FileName.Substring(0, fileExtPos) + "_thumb" + System.IO.Path.GetExtension(FileData.FileName);
                        thumbImage.Save(request.MapPath("~/FileData/" + thumbPath));
                        stream.Close();

                    }
                    PresentationImageUrl = requestUrl.Scheme + "://" + requestUrl.Host + ":" + requestUrl.Port + "/FileData/" + FileData.FileName;
                    FileData.Clear();
                }
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