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
using TestLog.RDS.Services.AuditTrailServices;

namespace TestLogXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class DomainObject3 : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DomainObject3(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private DomainObject1 _DomainObject1;
        private string _Code;

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
        // Fields...
        private string _Name;

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

        [Association("DomainObject1-DomainObject3s")]
        public DomainObject1 DomainObject1
        {
            get
            {
                return _DomainObject1;
            }
            set
            {
                SetPropertyValue("DomainObject1", ref _DomainObject1, value);
            }
        }
        HistoryHelper helper = new HistoryHelper();
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            string newValueStr = "";
            string oldValueStr = "";
            bool isSaveHistory = false;
            switch (propertyName)
            {
                case "Code":
                    if (oldValue != null)
                    {
                        oldValueStr = oldValue.ToString();
                    }
                    newValueStr = this.Code;
                    isSaveHistory = true;
                    break;
                case "Name":
                    if (oldValue != null)
                    {
                        oldValueStr = oldValue.ToString();
                    }
                    newValueStr = this.Name;
                    isSaveHistory = true;
                    break;
            }
            if (isSaveHistory)
            {
                //DomainObject1.TrackHistory("\t\t" + propertyName, oldValueStr, newValueStr);
                helper.UpdateDetail("\t\t" + propertyName, oldValueStr, newValueStr);
            }
        }
        private readonly IAuditTrailService AuditTrailService = new AuditTrailService();
        protected override void OnSaving()
        {
            base.OnSaving();
            if (helper.DescriptionHistory() != "")
            {
                string ChangedBy = "userA";
                AuditTrailService.AddAuditTrail(DomainObject1.Oid, ChangedBy, helper.DescriptionHistory());
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