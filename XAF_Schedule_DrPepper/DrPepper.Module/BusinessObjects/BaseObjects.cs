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
using System.Drawing;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo.Metadata;
using Xpand.ExpressApp.IO.Core;
using Xpand.Persistent.Base.General;

namespace DrPepper.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    [NonPersistent]
    public abstract class VideoPerson : BaseObject
    {
        string _address;
       
        string _middleName;
        protected VideoPerson(Session session)
            : base(session)
        {
        }
        #region Person
        const string defaultFullNameFormat = "{LastName} {MiddleName} {FirstName}";
        const string defaultFullNamePersistentAlias = "concat(FirstName,' ',MiddleName,' ', LastName)";
        readonly PersonImpl person = new PersonImpl();


        static VideoPerson()
        {
            PersonImpl.FullNameFormat = defaultFullNameFormat;
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { SetPropertyValue("MiddleName", ref _middleName, value); }
        }

      


        public void SetFullName(string fullName)
        {
            person.SetFullName(fullName);
        }
        [RuleRequiredField]
        public string FirstName
        {
            get { return person.FirstName; }
            set
            {
                person.FirstName = value;
                OnChanged("FirstName");
            }
        }
        [RuleRequiredField]
        public string LastName
        {
            get { return person.LastName; }
            set
            {
                person.LastName = value;
                OnChanged("LastName");
            }
        }

        [DevExpress.Xpo.DisplayName("BirthDate")]
        public DateTime Birthday
        {
            get { return person.Birthday; }
            set
            {
                person.Birthday = value;
                OnChanged("Birthday");
            }
        }

        //        [ObjectValidatorIgnoreIssue(typeof(ObjectValidatorDefaultPropertyIsNonPersistentNorAliased)),
        //         SearchMemberOptions(SearchMemberMode.Include)]
        [PersistentAlias(defaultFullNamePersistentAlias)]
        public string FullName
        {
            get
            {
                return EvaluateAlias("FullName") as string;
                //                return ObjectFormatter.Format(PersonImpl.FullNameFormat, this,
                //                                              EmptyEntriesMode.RemoveDelimeterWhenEntryIsEmpty);
            }
        }

        [Size(255)]
        public string Email
        {
            get { return person.Email; }
            set
            {
                person.Email = value;
                OnChanged("Email");
            }
        }

        [Size(SizeAttribute.Unlimited), Delayed(true), ValueConverter(typeof(ImageValueConverter))]
        public Image Photo
        {
            get { return GetDelayedPropertyValue<Image>("Photo"); }
            set { SetDelayedPropertyValue("Photo", value); }
        }



        [Size(SizeAttribute.Unlimited)]
        [RuleRequiredField]
        public string Address
        {
            get { return _address; }
            set { SetPropertyValue("Address", ref _address, value); }
        }
        #endregion
    }

}
