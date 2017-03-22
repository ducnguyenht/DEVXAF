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
using TestLog.RDS;
using TestLog.RDS.Services.AuditTrailServices;

namespace TestLogXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class DomainObject1 : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DomainObject1(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private string _Test1;
        private string _Test;
        [RuleUniqueValue(DefaultContexts.Save, CustomMessageTemplate = "test đã tồn tại")]
        public string test
        {
            get
            {
                return _Test;
            }
            set
            {
                SetPropertyValue("test", ref _Test, value);
            }
        }
        [RuleUniqueValue(DefaultContexts.Save, CustomMessageTemplate = "Test1 đã tồn tại")]
        public string Test1
        {
            get
            {
                return _Test1;
            }
            set
            {
                SetPropertyValue("Test1", ref _Test1, value);
            }
        }

        [Association("DomainObject1-DomainObject3s")]
        public XPCollection<DomainObject3> DomainObject3s
        {
            get
            {
                return GetCollection<DomainObject3>("DomainObject3s");
            }
        }


        private readonly IAuditTrailService AuditTrailService = new AuditTrailService();

        //[Delayed]
        public List<History> History
        {
            get
            {
                List<History> lstH = new List<BusinessObjects.History>();
                List<AuditTrail> auditTrails = new List<AuditTrail>();
                AuditTrailService.GetAuditTrails(ref auditTrails, this.Oid);
                foreach (var item in auditTrails)
                {
                    History h = new History(Session);
                    h.ChangedBy = item.ChangedBy;
                    h.Data = item.Data;
                    h.ChangedOn = item.ChangedOn.Value;
                    lstH.Add(h);
                }
                return lstH;
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            string newValueStr = "";
            string oldValueStr = "";
            bool isSaveHistory = false;
            switch (propertyName)
            {
                case "test":
                    if (oldValue != null)
                    {
                        oldValueStr = oldValue.ToString();
                    }
                    newValueStr = this.test;
                    isSaveHistory = true;
                    break;
                case "Test1":
                    if (oldValue != null)
                    {
                        oldValueStr = oldValue.ToString();
                    }
                    newValueStr = this.Test1;
                    isSaveHistory = true;
                    break;
            }

            if (isSaveHistory)
            {
                string s = TrackHistory(propertyName, newValueStr, oldValueStr);
            }

        }
        HistoryHelper helper = new HistoryHelper();
        public string TrackHistory(string propertyName, string newValueStr, string oldValueStr)
        {
            helper.UpdateDetail(propertyName, oldValueStr, newValueStr);
            return helper.DescriptionHistory();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (helper.DescriptionHistory() != "")
            {
                string ChangedBy = "User A";
                AuditTrailService.AddAuditTrail(this.Oid, ChangedBy, helper.DescriptionHistory());
            }
            OnChanged("History");
        }


    }
}

