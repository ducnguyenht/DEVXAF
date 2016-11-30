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

namespace CMSModule.Module.BusinessObjects.ChatSystem
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ChatPrivateMessageDetail : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ChatPrivateMessageDetail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private string _Message;
        private string _ChatToEmailID;
        private string _MasterEmailID;

        public string MasterEmailID
        {
            get
            {
                return _MasterEmailID;
            }
            set
            {
                SetPropertyValue("MasterEmailID", ref _MasterEmailID, value);
            }
        }

        public string ChatToEmailID
        {
            get
            {
                return _ChatToEmailID;
            }
            set
            {
                SetPropertyValue("ChatToEmailID", ref _ChatToEmailID, value);
            }
        }

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                SetPropertyValue("Message", ref _Message, value);
            }
        }
        //public int ID { get; set; }
        //public string MasterEmailID { get; set; }
        //public string ChatToEmailID { get; set; }
        //public string Message { get; set; }



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