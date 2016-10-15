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
using DevExpress.ExpressApp.Utils;

namespace DucDemoCodeSequencev1.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class CodeSequenceConfig : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CodeSequenceConfig(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.ZeroDisplay = 2;
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private int _ZeroDisplay;
        private string _DelimiterSecond;
        private string _DelimiterFirst;
        private AutoType _AutoType;
        private PrefixPartType _PrefixPartType;
        private string _Prefix;
        private Type _Type;
        [ValueConverter(typeof(TypeToStringConverter))]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        public Type Type
        {
            get
            {
                return _Type;
            }
            set
            {
                SetPropertyValue("Type", ref _Type, value);
            }
        }

        public string Prefix
        {
            get
            {
                return _Prefix;
            }
            set
            {
                SetPropertyValue("Prefix", ref _Prefix, value);
            }
        }
        
        public string DelimiterFirst
        {
            get
            {
                return _DelimiterFirst;
            }
            set
            {
                SetPropertyValue("DelimiterFirst", ref _DelimiterFirst, value);
            }
        }
        public PrefixPartType PrefixPartType
        {
            get
            {
                return _PrefixPartType;
            }
            set
            {
                SetPropertyValue("PrefixPartType", ref _PrefixPartType, value);
            }
        }

        public string DelimiterSecond
        {
            get
            {
                return _DelimiterSecond;
            }
            set
            {
                SetPropertyValue("DelimiterSecond", ref _DelimiterSecond, value);
            }
        }


        public int ZeroDisplay
        {
            get
            {
                return _ZeroDisplay;
            }
            set
            {
                SetPropertyValue("ZeroDisplay", ref _ZeroDisplay, value);
            }
        }

        public AutoType AutoType
        {
            get
            {
                return _AutoType;
            }
            set
            {
                SetPropertyValue("AutoType", ref _AutoType, value);
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
    public enum PrefixPartType
    {
        String,
        IssueDate
    }
    public enum AutoType
    {
        Semi=0,
        Auto=1,
        None=2
    }
}
