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
using NamolyOnPremises.Module.BusinessObjects.Operational.System.Security;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.General
{
    [DefaultClassOptions]
    [ImageName("BO_Employee")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [Indices("Code", "Name")]
    public class ExternalUser : BaseObject
    {
        public ExternalUser(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        // Fields...
        private string _Name;
        private string _Code;
        private ExternalOrganization _ExternalOrganization;


        #region Properties
        [Index(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)]
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

        [Index(1)]
        [RuleRequiredField(DefaultContexts.Save)]
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

        #endregion Properties

        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("ExternalOrganization-ExternalUsers")]
        public ExternalOrganization ExternalOrganization
        {
            get
            {
                return _ExternalOrganization;
            }
            set
            {
                SetPropertyValue("ExternalOrganization", ref _ExternalOrganization, value);
            }
        }

        [XafDisplayName("User Account"), ToolTip("User Account")]
        [ModelDefault("LookupEditorMode", "AllItems")]
        [Association("ExternalUser-SecurityApplicationUsers")]
        public XPCollection<SecurityApplicationUser> SecurityApplicationUsers
        {
            get
            {
                return GetCollection<SecurityApplicationUser>("SecurityApplicationUsers");
            }
        }
        #endregion Association
    }
}
