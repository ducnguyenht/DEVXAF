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
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking.GuestSharingDetail;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("DisplayName")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    public class HotelFolio : BaseObject
    {
        public HotelFolio(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private HotelGuestSharing _HotelSharing;
        private string _DisplayName;
        private BillingInstructionEnum _BillingInstruction;
        private string _GuestName;
        private HotelBooking _Booking;
        private string _Name;


        #region Properties


        public string DisplayName
        {
            get
            {
                //string displayname = " ";
                
                //if (this.Name != null)
                //    displayname = this.Name;
                //if (this.HotelSharing != null)
                //    displayname += '|' + HotelSharing.FullName;
                //   //// displayname = this.Name + '|';
                //   // try
                //   // {
                //   //     displayname = this.Name + '|' + this.Booking.HotelGuestSharing.FirstOrDefault().FullName;
                //   // }
                //   // catch
                //   // {
                //   // }
                //return displayname;
                return Name + '|' + GuestName;      
            }
            //set
            //{
            //    SetPropertyValue("DisplayName", ref _DisplayName, value);
            //    //if (!IsLoading && !IsSaving)
            //    //{
            //    //    string displayname = " ";
            //    //    if (Name != null)
            //    //        displayname = Name;
            //    //    if (this.HotelSharing.FullName != null)
            //    //        displayname += '|' + HotelSharing.FullName;
            //    //}
            //}
        }

        [Browsable(false)]
        public HotelGuestSharing HotelSharing
        {
            get
            {
                return _HotelSharing;
            }
            set
            {
                SetPropertyValue("HotelSharing", ref _HotelSharing, value);
            }
        }

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

       
        public string GuestName
        {
            get
            {
              
                return _GuestName;
            }
            set
            {
                SetPropertyValue("GuestName", ref _GuestName, value);
            }
        }

        /// <summary>
        /// Hướng dẫn thanh toán
        /// </summary>
        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public BillingInstructionEnum BillingInstruction
        {
            get
            {
                return _BillingInstruction;
            }
            set
            {
                SetPropertyValue("BillingInstruction", ref _BillingInstruction, value);
            }
        }
        #endregion Properties



        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelBooking-HotelFolios")]
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


        [Association("HotelFolio-HotelFolioDetailChargeRules"), DevExpress.Xpo.Aggregated]
        public XPCollection<HotelFolioDetailChargeRule> ChargeRules
        {
            get
            {
                return GetCollection<HotelFolioDetailChargeRule>("ChargeRules");
            }
        }
        #endregion Association


        #region Logic




        //protected override void OnChanged(string propertyName, object oldValue, object newValue)
        //{
        //    base.OnChanged(propertyName, oldValue, newValue);
        //    if (propertyName == "HotelGuestSharing.FullName")
        //    {
        //        if (this.Booking.HotelGuestSharing.FirstOrDefault().FullName != null)
        //        {
        //            DisplayName = Name + '|' + Booking.HotelGuestSharing.FirstOrDefault().FullName;
        //        }
        //    }
        //}
        #endregion
    }
}
