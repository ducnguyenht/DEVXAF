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
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    public class HotelFolioDetailChargeRule : BaseObject
    {
        public HotelFolioDetailChargeRule(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private HotelFolio _Folio;
        private HotelBooking _Booking;
        private string _Note;
        private PostTypeEnum _PostType;
        private HotelRateTypeExtraCharge _Service;


        #region Properties

        public HotelRateTypeExtraCharge Service
        {
            get
            {
                return _Service;
            }
            set
            {
                SetPropertyValue("Service", ref _Service, value);
            }
        }

        public PostTypeEnum PostType
        {
            get
            {
                return _PostType;
            }
            set
            {
                SetPropertyValue("PostType", ref _PostType, value);
            }
        }

        [Size(250)]
        [VisibleInListView(true)]
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                SetPropertyValue("Note", ref _Note, value);
            }
        }

       
        #endregion Properties

        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelBooking-HotelFolioDetailChargeRules")]
        public HotelBooking Booking
        {
            get
            {
                return _Booking;
            }
            set
            {
                SetPropertyValue("Booking", ref _Booking, value);
            }
        }


        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelFolio-HotelFolioDetailChargeRules")]
        public HotelFolio Folio
        {
            get
            {
                return _Folio;
            }
            set
            {
                SetPropertyValue("Folio", ref _Folio, value);
            }
        }
        #endregion Association



        #region Logic

        

        #endregion Logic

    }
}
