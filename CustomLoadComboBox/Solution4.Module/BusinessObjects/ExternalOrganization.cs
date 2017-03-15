using System;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using NASDMS.Module.BusinessObjects.Operational.Nomenclature.General;
using DevExpress.ExpressApp;
namespace NASDMS.Module.BusinessObjects.Operational.CRM.Customer
{
    [DefaultClassOptions]
    [DefaultProperty("Code")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [Indices("Code")]
    public class ExternalOrganization : BaseObject
    {
        public ExternalOrganization(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        #region Properties

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        private string _Code;
        private Nomenclature.General.Country _Country;
        private Ward _Ward;
        private Province _District;
        private City _City;
        private Area _Area;


        [ImmediatePostData]
        public Nomenclature.General.Country Country
        {
            get
            {
                return _Country;
            }
            set
            {
                SetPropertyValue("Country", ref _Country, value);
                if (!IsLoading && !IsSaving)
                {
                    if (_Country == null)
                        City = null;
                }
            }
        }

        [ImmediatePostData]
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

        [DataSourceProperty("AvailableCity")]
        //[EditorAlias("ASPxGridLookupPropertyEditor")]
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
                if (!IsLoading && !IsSaving)
                {
                    if (_City == null)
                        District = null;
                }
            }
        }
        private XPCollection<City> _AvailableCity;
        [Browsable(false)]
        public XPCollection<City> AvailableCity
        {
            get
            {
                _AvailableCity = null;
                _AvailableCity = new XPCollection<City>(
                   Session, new BinaryOperator("Country.Oid", Country != null ? Country.Oid : Guid.Empty)
                       & new BinaryOperator("Area.Oid", Area != null ? Area.Oid : Guid.Empty));

                return _AvailableCity;
            }
        }

        [ImmediatePostData]
        [DataSourceProperty("AvailableDistrict")]
        public Province District
        {
            get
            {
                return _District;
            }
            set
            {
                SetPropertyValue("District", ref _District, value);
                if (!IsLoading && !IsSaving)
                {
                    if (_District == null)
                        Ward = null;
                }
            }
        }
        private XPCollection<Province> _AvailableDistrict;
        [Browsable(false)]
        public XPCollection<Province> AvailableDistrict
        {
            get
            {
                _AvailableDistrict = null;
                _AvailableDistrict = new XPCollection<Province>(
                   Session, new BinaryOperator("City.Oid", City != null ? City.Oid : Guid.Empty));
                return _AvailableDistrict;
            }
        }
        [ImmediatePostData]
        [DataSourceProperty("AvailableWard")]
        public Ward Ward
        {
            get
            {
                return _Ward;
            }
            set
            {
                SetPropertyValue("Ward", ref _Ward, value);
            }
        }
        private XPCollection<Ward> _AvailableWard;
        [Browsable(false)]
        public XPCollection<Ward> AvailableWard
        {
            get
            {
                _AvailableWard = null;
                _AvailableWard = new XPCollection<Ward>(
                   Session, new BinaryOperator("District.Oid", District != null ? District.Oid : Guid.Empty));
                return _AvailableWard;
            }
        }
        private string _Description;
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
        #endregion Properties

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "City")
            {
                if (City != null)
                {
                    Description = City.Name;
                }
                else
                {
                    Description = "";
                }
            }
        }


    }
    public enum CustomerStatus
    {
        /// <summary>
        /// Liên hệ
        /// </summary>
        [DevExpress.Xpo.DisplayName("Submitted")]
        Submitted = 0,
        /// <summary>
        /// Tiềm năng
        /// </summary>
        [DevExpress.Xpo.DisplayName("ContactVerified")]
        ContactVerified = 1,
        /// <summary>
        /// Đang hoạt động
        /// </summary>
        [DevExpress.Xpo.DisplayName("Registered")]
        Registered = 2,
        /// <summary>
        /// Huỷ hợp tác
        /// </summary>
        [DevExpress.Xpo.DisplayName("Terminated")]
        Terminated = 3,
        [DevExpress.Xpo.DisplayName("ChangeStatusTo")]
        ChangeStatusTo = 4
    }
    public enum BusinessType
    {
        [DevExpress.Xpo.DisplayName("Customer")]
        Customer,
        [DevExpress.Xpo.DisplayName("Provider")]
        Provider,
        [DevExpress.Xpo.DisplayName("Both")]
        Both,
    }
    public enum OrganizationType
    {
        [DevExpress.Xpo.DisplayName("Individual")]
        Individual,
        [DevExpress.Xpo.DisplayName("Organization")]
        Organization,
    }
}