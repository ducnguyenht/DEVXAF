using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Drawing;
using WebSolution.Module.Web.Editors;

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
        [Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        private FileData _file;
        public FileData File
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


        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [ASPxReadOnlyImageSizeAttribute(100, 100, "Width", "Height")]
        [VisibleInListView(false), VisibleInLookupListView(false)]
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
        }
    }
}
