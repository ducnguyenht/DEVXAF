using System;
using System.Linq;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;

namespace Solution1.Module.BusinessObjects
{
    //[DefaultClassOptions]
    //public class Container: BaseObject {
    //    public Container(Session session) : base(session) { }

    //    public string Name;

    //    [Association("List1Currencies")]
    //    public XPCollection<Currency> List1 { 
    //        get { return GetCollection<Currency>("List1"); }
    //    }
    //}

    [DefaultClassOptions]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]

    public class Container : BaseObject
    {
        public Container(Session session)
            : base(session)
        { }

        private string _TestListMutilChoice;
        private XPCollection<Currency> _AvailableCurrencies;
        [MemberDesignTimeVisibility(false)]
        [NonPersistent]
        public XPCollection<Currency> AvailableCurrencies
        {
            get
            {
                if (_AvailableCurrencies == null)
                    _AvailableCurrencies = new XPCollection<Currency>(Session, CriteriaOperator.Parse("Code like 'C%'"));
                return _AvailableCurrencies;
            }
        }

        private string _CurrencyList;
        [ModelDefault("PropertyEditorType", "Solution1.Module.Web.CurrencyListPropertyEditor")]
        public string CurrencyList
        {
            get
            {
                return _CurrencyList;
            }
            set
            {
                SetPropertyValue("CurrencyList", ref _CurrencyList, value);
            }
        }

        private string _CurrencyListWithCriteria;
        [ModelDefault("PropertyEditorType", "Solution1.Module.Web.CurrencyListPropertyEditor")]
        [DataSourceCriteria("Code like 'S%'")]
        public string CurrencyListWithCriteria
        {
            get
            {
                return _CurrencyListWithCriteria;
            }
            set
            {
                SetPropertyValue("CurrencyListWithCriteria", ref _CurrencyListWithCriteria, value);
            }
        }

        private string _CurrencyListWithDataSource;
        [ModelDefault("PropertyEditorType", "Solution1.Module.Web.CurrencyListPropertyEditor")]
        [DataSourceProperty("AvailableCurrencies")]
        public string CurrencyListWithDataSource
        {
            get
            {
                return _CurrencyListWithDataSource;
            }
            set
            {
                SetPropertyValue("CurrencyListWithDataSource", ref _CurrencyListWithDataSource, value);
            }
        }
        [ModelDefault("PropertyEditorType", "Solution1.Module.Web.CurrencyListPropertyEditor")]
        public string TestListMutilChoice
        {
            get
            {
                return _TestListMutilChoice;
            }
            set
            {
                SetPropertyValue("TestListMutilChoice", ref _TestListMutilChoice, value);
            }
        }
    }
}
