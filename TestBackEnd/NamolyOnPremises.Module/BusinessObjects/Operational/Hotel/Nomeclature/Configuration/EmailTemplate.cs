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
using NamolyOnPremises.Module.Interfaces;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [DefaultClassOptions]
    [ImageName("Ico.Email")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class EmailTemplate : BaseObject, IHtmlEditorDisableTabView
    {
        public EmailTemplate(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private string _Content;
        private string _Description;
        private string _Subject;
        private EmailTypeEnum _Type;
        private string _Language;
        private string _SentBy;
        private string _EmailSender;
        private string _Name;



        #region Properties

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

        public string EmailSender
        {
            get
            {
                return _EmailSender;
            }
            set
            {
                SetPropertyValue("EmailSender", ref _EmailSender, value);
            }
        }

        public string SentBy
        {
            get
            {
                return _SentBy;
            }
            set
            {
                SetPropertyValue("SentBy", ref _SentBy, value);
            }
        }

        public string Language
        {
            get
            {
                return _Language;
            }
            set
            {
                SetPropertyValue("Language", ref _Language, value);
            }
        }

        public EmailTypeEnum Type
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

        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                SetPropertyValue("Subject", ref _Subject, value);
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

        [Size(SizeAttribute.Unlimited)]
        public string Content
        {
            get
            {
                return _Content;
            }
            set
            {
                SetPropertyValue("Content", ref _Content, value);
            }
        }
        #endregion Properties
    }

    public enum EmailTypeEnum
    {
        Comfirmation = 0,
        Deposit = 1,
        ThanksForCustomer = 2
    }
}
