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
    [ImageName("BO_Country_v92")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class City : BaseObject
    {
        public City(Session session)
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

        private Area _Area;
        private Country _Country;
        private bool _IsActive;
        private string _Description;
        private string _Name;
        private string _Code;
        [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "Mã số không được để trống"), RuleUniqueValue(DefaultContexts.Save, CustomMessageTemplate = "Mã số đã tồn tại")]
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
        #region Association

        [Association("Country-Cities")]
        [DataSourceCriteria("IsActive == true")]

        public Country Country
        {
            get
            {
                return _Country;
            }
            set
            {
                SetPropertyValue("Country", ref _Country, value);
            }
        }
        [Association("City-Provinces")]
        public XPCollection<Province> Provinces
        {
            get
            {
                return GetCollection<Province>("Provinces");
            }
        }

        [Association("Area-Cities")]
        [DataSourceCriteria("IsActive == true")]
        public Area Area
        {
            get
            {
                return _Area;
            }
            set
            {
                SetPropertyValue("Area", ref _Area, value);
            }
        }
        #endregion Association
    }
}
