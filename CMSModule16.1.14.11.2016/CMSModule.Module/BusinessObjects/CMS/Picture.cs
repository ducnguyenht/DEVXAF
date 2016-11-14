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

namespace CMSModule.Module.BusinessObjects.CMS {
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class Picture : BaseObject { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Picture(Session session)
            : base(session) {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();            
        }
        
        [Association("Article-Pictures"),Browsable(false)]
        public Article Article
        {
        	get
        	{
        		return _Article;
        	}
        	set
        	{
        	  SetPropertyValue("Article", ref _Article, value);
        	}
        }   
        private Article _Article;

        private string _PresentationImageUrl;
      
        public string PresentationImageUrl {
            get {
                return _PresentationImageUrl;
            }
            set {
                SetPropertyValue("PresentationImageUrl", ref _PresentationImageUrl, value);
            }
        }

        
        [EditorAlias("ASPxReadOnlyImagePropertyEditor"), VisibleInLookupListView(false)]//VisibleInListView(false),
        public string PresentationThumbnail {
            get {
                if(PresentationImageUrl != null) {
                    return ImageHelper.ToThumb(PresentationImageUrl);
                    //PresentationImageUrl.Substring(0, PresentationImageUrl.LastIndexOf('.')) + "_thumb" + PresentationImageUrl.Substring(PresentationImageUrl.LastIndexOf('.'));
                }
                return "";
            }
        }

        private FileData _FileData;
        [NonPersistent, VisibleInListView(false), XafDisplayName("Choose Image")]
        public FileData FileData {
            get {
                return _FileData;
            }
            set {
                SetPropertyValue("FileData", ref _FileData, value);
            }
        }

        protected override void OnSaving() {
            base.OnSaving();
            if(FileData != null) {
                if(!FileData.IsEmpty) {
                    var request = System.Web.HttpContext.Current.Request;
                    var requestUrl = request.Url;
                    string filePath = request.MapPath("~/FileData/" + FileData.FileName);
                    if(!System.IO.File.Exists(filePath)) {
                        System.IO.Stream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        FileData.SaveToStream(stream);
                        var currentPicture = System.Drawing.Image.FromStream(new System.IO.MemoryStream(FileData.Content));
                        var thumbImage = ImageHelper.ScaleImage(currentPicture, 70);
                        int fileExtPos = FileData.FileName.LastIndexOf(".");
                        string thumbPath = "";
                        if(fileExtPos >= 0)
                            thumbPath = FileData.FileName.Substring(0, fileExtPos) + "_thumb" + System.IO.Path.GetExtension(FileData.FileName);
                        thumbImage.Save(request.MapPath("~/FileData/" + thumbPath));
                        stream.Close();
                    }
                    PresentationImageUrl = requestUrl.Scheme + "://" + requestUrl.Host + ":" + requestUrl.Port + "/FileData/" + FileData.FileName;
                    FileData.Clear();
                }
            }
        }

        //protected override void OnDeleting()
        //{
        //    base.OnDeleting();
        //    string urlDelete = new Uri(ImageUrl).PathAndQuery;
        //    File.Delete(HttpContext.Current.Request.MapPath(urlDelete));
        //    File.Delete(HttpContext.Current.Request.MapPath(ImageHelper.ToThumb(urlDelete)));
        //}   
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