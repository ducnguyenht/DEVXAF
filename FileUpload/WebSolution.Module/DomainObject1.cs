using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Drawing;
using WebSolution.Module.Web.Editors;
using System.Web;
using System.IO;

namespace WebSolution.Module
{
    [DefaultClassOptions]
    //[FileAttachment("File")]
    public class DomainObject1 : BaseObject
    {
        public DomainObject1(Session session)
            : base(session)
        {
        }

        private FileData _file;
        [NonPersistent]
        public FileData FileData
        {
            get
            {
                return _file;
            }
            set
            {
                SetPropertyValue("File", ref _file, value);
            }
        }

        //can refesh listview
        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [ASPxReadOnlyImageSizeAttribute(100, 100, "Width", "Height")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        public string PresentationImage
        {
            get
            {
                if (ImageUrl != null)
                {
                    return ImageUrl;
                }
                return "";
            }
        }
        private string _ImageUrl;

        [Size(1028)]
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
        protected override void OnSaving()
        {
            base.OnSaving();
            if (FileData != null)
            {
                if (!FileData.IsEmpty)
                {
                    string filePath = HttpContext.Current.Request.MapPath("~/FileData/" + FileData.FileName);
                    Stream stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
                    FileData.SaveToStream(stream);
                    ImageUrl = "FileData/" + FileData.FileName;
                    stream.Close();
                    FileData.Clear();
                }
            }
        }
        protected override void OnDeleting()
        {
            base.OnDeleting();
            string filePath = HttpContext.Current.Request.MapPath(ImageUrl);
            File.Delete(filePath);
        }
    }
}
