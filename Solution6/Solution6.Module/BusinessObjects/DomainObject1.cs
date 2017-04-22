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

namespace Solution6.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
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
        private string _String1;
        private City _City;
        private Country _Country;
        private string _Address;
        [Size(1028)]
        [ImmediatePostData]
        [EditorAlias("Custom3"), VisibleInListView(true)]
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

        public string String1
        {
            get
            {
                return _String1;
            }
            set
            {
                SetPropertyValue("String1", ref _String1, value);
            }
        }
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

        public City City
        {
            get
            {
                return _City;
            }
            set
            {
                SetPropertyValue("City", ref _City, value);
            }
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            if (Country == null || City == null)
            {
                if (!String.IsNullOrEmpty(Address))
                {
                    string strThanhPho = "";
                    string strQuocGia = "";
                    var split = Address.Split(',');

                    if (Country == null && split.Count()==5 && split[4].Trim() != "")
                    {
                        
                       
                        var idx = Address.IndexOf(',');
                        var t = 1;

                        strQuocGia = split[4].Trim();
                        strQuocGia = strQuocGia.ToLower() == "vietnam" ? "Việt Nam" : strQuocGia;
                        var objQuocGia = Session.FindObject<Country>(new BinaryOperator("Name", strQuocGia));
                        if (objQuocGia == null)
                        {
                            objQuocGia = new Country(Session);
                            objQuocGia.Name = strQuocGia;
                            objQuocGia.Save();
                        }
                        this.Country = objQuocGia;
                    }
                    if (City == null && split.Count()==5 && split[3].Trim() != "")
                    {
                        strThanhPho = split[3].Trim();
                        var objThanhPho = Session.FindObject<City>(new BinaryOperator("Name", strThanhPho));
                        if (objThanhPho == null)
                        {
                            objThanhPho = new City(Session);
                            objThanhPho.Name = strThanhPho;
                            objThanhPho.Save();
                        }
                        this.City = objThanhPho;
                    }

                }
            }
            //123 Ngô Đức Kế, phường 12, Bình Thạnh, Hồ Chí Minh, Vietnam
        }
    }
}
