using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Drawing;

namespace WebSolution.Module {
    [DefaultClassOptions]
    [FileAttachment("File")]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session)
            : base(session) {
        }
        //[Aggregated]
        //[ExpandObjectMembers(ExpandObjectMembers.Never)]
        private Image _Image;
        private string _FileData;
        private FileData _file;
        public FileData File {
            get {
                return _file;
            }
            set {
                SetPropertyValue("File", ref _file, value);
            }
        }


        public Image Image {
            get {
                return _Image;
            }
            //set {
            //    SetPropertyValue("Image", ref _Image, value);
            //}
        }
    }
}
