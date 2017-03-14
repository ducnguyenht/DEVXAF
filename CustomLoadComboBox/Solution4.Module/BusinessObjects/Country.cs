using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace NASDMS.Module.BusinessObjects.Operational.Nomenclature.General
{
    [DefaultClassOptions]
    [DefaultProperty("DisplayName")]
    [ImageName("BO_Localization")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class Country : BaseObject
    {
        public Country(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;
        }
        [PersistentAlias("Code + ' | ' + Name")]
        public string DisplayName
        {
            get
            {
                return Convert.ToString(EvaluateAlias("DisplayName"));
            }
        }

        #region Properties
        // Fields...
        private bool _IsActive;
        private string _Description;
        private string _Name;
        private string _Code;

        [RuleRequiredField(DefaultContexts.Save), RuleUniqueValue(DefaultContexts.Save)]
        [Size(2)]
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
        [RuleRequiredField(DefaultContexts.Save), RuleUniqueValue(DefaultContexts.Save)]
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
        [DevExpress.Xpo.Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                SetPropertyValue("Description", ref _Description, value);
            }
        }

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetPropertyValue("IsActive", ref _IsActive, value);
            }
        }
        #endregion Properties

        #region Association
        [Association("Country-Cities")]
        public XPCollection<City> Cities
        {
            get
            {
                return GetCollection<City>("Cities");
            }
        }
        #endregion Association


    }
}
