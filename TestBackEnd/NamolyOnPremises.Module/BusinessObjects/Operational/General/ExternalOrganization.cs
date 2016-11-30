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
    [ImageName("Ico.ExternalOrganization")]
    [DefaultProperty("Name")]
    [Indices("Code", "Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class ExternalOrganization : BaseObject
    {
        public ExternalOrganization(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            OrganizationType = General.OrganizationType.Organization;
        }

        // Fields...
        private bool _IsSupplier;
        private bool _IsOTA;
        private bool _IsTATO;
        private City _City;
        private Country _Country;
        private string _Email;
        private string _Fax;
        private string _Phone;
        private string _TaxCode;
        private string _Address;
        private string _BillingAdress;
        private OrganizationType _OrganizationType;
        private string _Name;
        private string _Code;


        #region Properties
        [Index(0)]
        [RuleUniqueValue(DefaultContexts.Save)]
        [RuleRequiredField(DefaultContexts.Save)]
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

        [Size(512)]
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
            }
        }

        [Size(512)]
        public string BillingAdress
        {
            get
            {
                return _BillingAdress;
            }
            set
            {
                SetPropertyValue("BillingAdress", ref _BillingAdress, value);
            }
        }

        [Size(32)]
        public string TaxCode
        {
            get
            {
                return _TaxCode;
            }
            set
            {
                SetPropertyValue("TaxCode", ref _TaxCode, value);
            }
        }

        [Size(32)]
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        }

        [Size(32)]
        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                SetPropertyValue("Fax", ref _Fax, value);
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        }

        [ImmediatePostData]
        public Country Country
        {
            get
            {
                return _Country;
            }
            set
            {
                var countryOld = _Country;
                SetPropertyValue("Country", ref _Country, value);
                if (!IsSaving && !IsLoading)
                    if (countryOld != _Country)
                    {
                        if (_Country == null)
                        {
                            City = null;
                            OnChanged("City");
                        }
                        else
                        {
                            if (City != null)
                                if (City.Country != _Country)
                                {
                                    City = null;
                                    OnChanged("City");
                                }
                        }
                    }
            }
        }

        [DataSourceProperty("CityDataSource")]
        [ImmediatePostData]
        public City City
        {
            get
            {
                return _City;
            }
            set
            {
                SetPropertyValue("City", ref _City, value);
                if (!IsSaving && !IsLoading)
                {
                    if (_City != null)
                    {
                        Country = _City.Country;
                        OnChanged("Country");
                    }
                }
            }
        }

        public OrganizationType OrganizationType
        {
            get
            {
                return _OrganizationType;
            }
            set
            {
                SetPropertyValue("OrganizationType", ref _OrganizationType, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsTATO
        {
            get
            {
                return _IsTATO;
            }
            set
            {
                SetPropertyValue("IsTATO", ref _IsTATO, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsOTA
        {
            get
            {
                return _IsOTA;
            }
            set
            {
                SetPropertyValue("IsOTA", ref _IsOTA, value);
            }
        }

        [VisibleInListView(false)]
        public bool IsSupplier
        {
            get
            {
                return _IsSupplier;
            }
            set
            {
                SetPropertyValue("IsSupplier", ref _IsSupplier, value);
            }
        }
        #endregion Properties

        #region Association

        [Association("ExternalOrganization-ExternalUsers"), DevExpress.Xpo.Aggregated]
        public XPCollection<ExternalUser> ExternalUsers
        {
            get
            {
                return GetCollection<ExternalUser>("ExternalUsers");
            }
        }

        #endregion Association

        #region Logic

        protected XPCollection<City> CityDataSource
        {
            get
            {
                if (Country != null)
                    return new XPCollection<City>(Session, new BinaryOperator("Country", Country));
                else
                    return new XPCollection<City>(Session);
            }
        }

        #endregion Logic

    }

    public enum OrganizationType
    {
        [DevExpress.Xpo.DisplayName("Individual")]
        Individual,
        [DevExpress.Xpo.DisplayName("Organization")]
        Organization,
    }
}
