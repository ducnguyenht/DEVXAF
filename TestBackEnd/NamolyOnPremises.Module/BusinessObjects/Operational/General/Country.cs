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

namespace NamolyOnPremises.Module.BusinessObjects.Operational.General
{
    [DefaultClassOptions]
    [ImageName("BO_Country_v92")]
    [DefaultProperty("DisplayName")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [Indices("Code", "Name")]

    public class Country : BaseObject
    {
        public Country(Session session)
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


        #region Properties

        [Index(0)]
        [Size(2)]
        [RuleRequiredField(DefaultContexts.Save), RuleUniqueValue(DefaultContexts.Save)]
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                SetPropertyValue("Code", ref _Code, (!String.IsNullOrEmpty(value) ? value.ToUpper() : value));
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

        [VisibleInListView(false), VisibleInDetailView(false)]
        public string DisplayName
        {
            get
            {
                return Code + " | " + Name;
            }
        }
        #endregion Properties

        #region Association

        [Association("Country-Citys"), DevExpress.Xpo.Aggregated]
        public XPCollection<City> Cities
        {
            get
            {
                return GetCollection<City>("Cities");
            }
        }

        #endregion Association

        #region Logic

        protected override void OnSaving()
        {
            if (Code != null)
            {
                if (Code.Length < 2)
                    throw new UserFriendlyException("Country code must have 2 characters.");
            }
            base.OnSaving();
        }

        #endregion Logic

    }
}
