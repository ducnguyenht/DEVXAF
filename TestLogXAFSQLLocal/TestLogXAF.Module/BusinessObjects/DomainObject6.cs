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

namespace TestLogXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("PropertyName")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class DomainObject6 : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DomainObject6(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private string _PropertyName1;
        private DomainObject5 _DomainObject5;
        private string _PropertyName;

        public string PropertyName
        {
            get
            {
                return _PropertyName;
            }
            set
            {
                SetPropertyValue("PropertyName", ref _PropertyName, value);
            }
        }

        public string PropertyName1
        {
            get
            {
                return _PropertyName1;
            }
            set
            {
                SetPropertyValue("PropertyName1", ref _PropertyName1, value);
            }
        }

        [Association("DomainObject5-DomainObject6s")]
        public DomainObject5 DomainObject5
        {
            get
            {
                return _DomainObject5;
            }
            set
            {
                SetPropertyValue("DomainObject5", ref _DomainObject5, value);
            }
        }
    }
}
