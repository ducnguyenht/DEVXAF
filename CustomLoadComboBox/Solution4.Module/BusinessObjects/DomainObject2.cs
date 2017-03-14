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

namespace Solution4.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class DomainObject2 : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DomainObject2(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private bool _Prop4;
        private string _Prop3;
        private string _Prop2;
        private string _Prop1;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Prop1
        {
            get
            {
                return _Prop1;
            }
            set
            {
                SetPropertyValue("Prop1", ref _Prop1, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Prop2
        {
            get
            {
                return _Prop2;
            }
            set
            {
                SetPropertyValue("Prop2", ref _Prop2, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Prop3
        {
            get
            {
                return _Prop3;
            }
            set
            {
                SetPropertyValue("Prop3", ref _Prop3, value);
            }
        }

        public bool Prop4
        {
            get
            {
                return _Prop4;
            }
            set
            {
                SetPropertyValue("Prop4", ref _Prop4, value);
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
        //    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
        //    this.PersistentProperty = "Paid";
        //}
    }
}
