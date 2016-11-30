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

namespace NamolyOnPremises.Module.BusinessObjects.Operational.CRM
{
    [DefaultClassOptions]
    [ImageName("BO_Folder")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Customers : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Customers(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        #region properties
        // Fields...
        private string _ID;
        private string _IDType;
        private string _Nationnality;
        private DateTime _DOB;
        private string _Email;

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

        [XafDisplayName("DoB")]
        public DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                SetPropertyValue("DOB", ref _DOB, value);
            }
        }


        public string Nationnality
        {
            get
            {
                return _Nationnality;
            }
            set
            {
                SetPropertyValue("Nationnality", ref _Nationnality, value);
            }
        }


        public string IDType
        {
            get
            {
                return _IDType;
            }
            set
            {
                SetPropertyValue("IDType", ref _IDType, value);
            }
        }

        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                SetPropertyValue("ID", ref _ID, value);
            }
        }



        #endregion


        #region Association

        //contact

        //history transaction

        #endregion
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
        //    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
        //    this.PersistentProperty = "Paid";
        //}
    }
}
