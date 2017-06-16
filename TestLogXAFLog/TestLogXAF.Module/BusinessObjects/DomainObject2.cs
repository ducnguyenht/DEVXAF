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
    public class DomainObject2 : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DomainObject2(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private int _Value3;
        private string _Value2;
        private string _Value1;

        public string Value1
        {
            get
            {
                return _Value1;
            }
            set
            {
                SetPropertyValue("Value1", ref _Value1, value);
            }
        }

        public string Value2
        {
            get
            {
                return _Value2;
            }
            set
            {
                SetPropertyValue("Value2", ref _Value2, value);
            }
        }

        public int Value3
        {
            get
            {
                return _Value3;
            }
            set
            {
                SetPropertyValue("Value3", ref _Value3, value);
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

        HistoryHelper helper = new HistoryHelper();
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            string newValueStr = "";
            string oldValueStr = "";
            bool isSaveHistory = false;
            switch (propertyName)
            {
                case "Value1":
                    if (oldValue != null)
                    {
                        oldValueStr = oldValue.ToString();
                    }
                    newValueStr = this.Value1;
                    isSaveHistory = true;
                    break;
                case "Value2":
                    if (oldValue != null)
                    {
                        oldValueStr = oldValue.ToString();
                    }
                    newValueStr = this.Value2;
                    isSaveHistory = true;
                    break;
                case "Value3":
                    if (oldValue != null)
                    {
                        oldValueStr = oldValue.ToString();
                    }
                    newValueStr = this.Value3.ToString();
                    isSaveHistory = true;
                    break;

            }

            if (isSaveHistory) helper.UpdateDetail(propertyName, oldValueStr, newValueStr);
        }




        protected override void OnSaved()
        {
            base.OnSaved();
            //if (helper.DescriptionHistory() != "")
            //{
            //    string ChangedBy = "User A";
            //    AuditTrailService.AddAuditTrail(this.Oid, ChangedBy, helper.DescriptionHistory(), NASDMS.Systems.CategoryAudit.DomainObject2, NASDMS.Systems.ActionAudit.action1);
            //}
            //OnChanged("History");
        }
    }
}