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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace TestLogXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    [Appearance("EditDisabled", AppearanceItemType.Action, "true", TargetItems = "Edit", Enabled = false)]
    [Appearance("NewDisabled", AppearanceItemType.Action, "true", TargetItems = "New", Enabled = false)]
    [Appearance("DeleteDisabled", AppearanceItemType.Action, "true", TargetItems = "Delete", Enabled = false)]
    [NonPersistent]
    public class History : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public History(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        //public int Id { get; set; }
        //public string NameSpace { get; set; }
        //public string Data { get; set; }
        //public string ChangedBy { get; set; }
        //public Nullable<System.DateTime> ChangedOn { get; set; }
        // Fields...
        private DateTime _ChangedOn;
        private string _ChangedBy;
        private string _Data;
        //private string _NameSpace;

        //public string NameSpace
        //{
        //    get
        //    {
        //        return _NameSpace;
        //    }
        //    set
        //    {
        //        SetPropertyValue("NameSpace", ref _NameSpace, value);
        //    }
        //}
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy hh:mm tt}"), ModelDefault("EditMask", "dd/MM/yyyy hh:mm tt")]

        public DateTime ChangedOn
        {
            get
            {
                return _ChangedOn;
            }
            set
            {
                SetPropertyValue("ChangedOn", ref _ChangedOn, value);
            }
        }
        public string ChangedBy
        {
            get
            {
                return _ChangedBy;
            }
            set
            {
                SetPropertyValue("ChangedBy", ref _ChangedBy, value);
            }
        }
        public string Data
        {
            get
            {
                return _Data;
            }
            set
            {
                SetPropertyValue("Data", ref _Data, value);
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
//    // Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
//    this.PersistentProperty = "Paid";
//}