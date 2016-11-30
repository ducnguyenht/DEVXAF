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
using NamolyOnPremises.Module.BusinessObjects.Operational.General;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [DefaultClassOptions]
    [ImageName("Action_Chart_Printing_Preview")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class BusinessSource : BaseObject
    {
        public BusinessSource(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }




        // Fields...
        private string _Description;
        private MarketSegment _MarketSegment;
        private string _Website;
        private string _ZipCode;
        private string _Address;
        private City _City;
        private General.Country _Country;
        private string _Name;









        #region Properties

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

        [ImmediatePostData]
        public General.Country Country
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

        [Size(250)]
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

        [Size(20)]
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                SetPropertyValue("ZipCode", ref _ZipCode, value);
            }
        }

        public string Website
        {
            get
            {
                return _Website;
            }
            set
            {
                SetPropertyValue("Website", ref _Website, value);
            }
        }

        public MarketSegment MarketSegment
        {
            get
            {
                return _MarketSegment;
            }
            set
            {
                SetPropertyValue("MarketSegment", ref _MarketSegment, value);
            }
        }

        [Size(250)]
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

        #region Association

        [Association("BusinessSource-HotelContacts"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelContact> Contacts
        {
            get
            {
                return GetCollection<HotelContact>("Contacts");
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
}
