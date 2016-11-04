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

namespace CMSModule.Module.BusinessObjects.CMS.Contents
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class Event : Content
    {
        public Event(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.ContentType = ContentType.Event;
        }
        // Fields...
        private string _LocationVN;
        private string _Location;
        private DateTime _ToDate;
        private DateTime _FromDate;



        public DateTime FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                SetPropertyValue("FromDate", ref _FromDate, value);
            }
        }

        public DateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                SetPropertyValue("ToDate", ref _ToDate, value);
            }
        }


        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                SetPropertyValue("Location", ref _Location, value);
            }
        }


        public string LocationVN
        {
            get
            {
                return _LocationVN;
            }
            set
            {
                SetPropertyValue("LocationVN", ref _LocationVN, value);
            }
        }



        protected override string PackageToJson()
        {
            return "";
        }
    }
}