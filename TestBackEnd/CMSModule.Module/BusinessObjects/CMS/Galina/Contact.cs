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

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class Contact : BaseObject
    {
        public Contact(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private string _Address;
        private string _TitleRU;
        private string _TitleVN;
        private string _Title;
        private string _Code;
        private double _Longitude;
        private double _Latitude;
        private string _Website;
        private string _Email;
        private string _MobilePhone;
        private string _Phone;

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

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                SetPropertyValue("Title", ref _Title, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVN
        {
            get
            {
                return _TitleVN;
            }
            set
            {
                SetPropertyValue("TitleVN", ref _TitleVN, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRU
        {
            get
            {
                return _TitleRU;
            }
            set
            {
                SetPropertyValue("TitleRU", ref _TitleRU, value);
            }
        }
        private string _Routing;
        private string _RoutingVN;
        private string _RoutingRU;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Routing
        {
            get
            {
                return _Routing;
            }
            set
            {
                SetPropertyValue("Routing", ref _Routing, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RoutingVN
        {
            get
            {
                return _RoutingVN;
            }
            set
            {
                SetPropertyValue("RoutingVN", ref _RoutingVN, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RoutingRU
        {
            get
            {
                return _RoutingRU;
            }
            set
            {
                SetPropertyValue("RoutingRU", ref _RoutingRU, value);
            }
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MobilePhone
        {
            get
            {
                return _MobilePhone;
            }
            set
            {
                SetPropertyValue("MobilePhone", ref _MobilePhone, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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

        [Size(1024), ModelDefault("RowCount", "1")]
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

        public double Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                SetPropertyValue("Latitude", ref _Latitude, value);
            }
        }

        public double Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                SetPropertyValue("Longitude", ref _Longitude, value);
            }
        }
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Title":
                    Routing = ValidateSystem.RejectMarks(Title, "-");
                    break;
                case "TitleVN":
                    RoutingVN = ValidateSystem.RejectMarks(TitleVN, "-");
                    break;
                case "TitleRU":
                    RoutingRU = ValidateSystem.RejectMarks(TitleRU, "-");
                    break;
            }
        }
        [Association]
        public XPCollection<ContactList> ContactList
        {
            get
            {
                return GetCollection<ContactList>("ContactList");
            }
        }
    }
}

//private string _PersistentProperty;
//[XafDisplayName("My display name"), ToolTip("My hint message")]
//[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
//[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
//public string PersistentProperty {
//    get { return _PersistentProperty; }
//    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
//}

//[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
//public void ActionMethod() {
//    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
//    this.PersistentProperty = "Paid";
//}