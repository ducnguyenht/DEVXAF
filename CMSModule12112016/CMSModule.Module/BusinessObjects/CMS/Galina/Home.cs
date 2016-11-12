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
using System.Drawing;

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class Home : BaseObject
    {
        public Home(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        [XafDisplayName("Image")]
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
        [Size(1028), ModelDefault("RowCount", "1")]//, Browsable(false)]
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
                    var request = HttpContext.Current.Request;
                    var requestUrl = request.Url;
                    string filePath = request.MapPath("~/FileData/" + FileData.FileName);
                    if (!File.Exists(filePath))
                    {
                        Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        FileData.SaveToStream(stream);
                        var currentPicture = System.Drawing.Image.FromStream(new System.IO.MemoryStream(FileData.Content));
                        var thumbImage = ImageHelper.ScaleImage(currentPicture, 100);
                        int fileExtPos = FileData.FileName.LastIndexOf(".");
                        string thumbPath = "";
                        if (fileExtPos >= 0)
                            thumbPath = FileData.FileName.Substring(0, fileExtPos) + "_thumb" + Path.GetExtension(FileData.FileName);
                        thumbImage.Save(request.MapPath("~/FileData/" + thumbPath));
                        stream.Close();

                    }
                    PresentationImageUrl = requestUrl.Scheme + "://" + requestUrl.Host + ":" + requestUrl.Port + "/FileData/" + FileData.FileName;
                    FileData.Clear();
                }
            }
        }
        protected override void OnDeleting()
        {
            base.OnDeleting();
            try
            {
                File.Delete(HttpContext.Current.Request.MapPath(new Uri(PresentationImageUrl).PathAndQuery));
                File.Delete(HttpContext.Current.Request.MapPath(ImageHelper.ToThumb(new Uri(PresentationImageUrl).PathAndQuery)));
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