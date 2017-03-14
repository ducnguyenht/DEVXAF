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
    [ImageName("Action_Debug_Breakpoint_Toggle")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class Ward : BaseObject
    {
        public Ward(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;
        }
        [PersistentAlias("Code + ' - ' + Name")]
        public string DisplayName
        {
            get
            {
                return Convert.ToString(EvaluateAlias("DisplayName"));
            }
        }
        #region Properties
        private Province _District;
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
        #endregion Properties
        #region Association

        [Association("District-Ward")]
        public Province District
        {
            get
            {
                return _District;
            }
            set
            {
                SetPropertyValue("District", ref _District, value);
            }
        }
        #endregion Association
    }
}
