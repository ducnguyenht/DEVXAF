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

namespace NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration
{
    [DefaultClassOptions]
    [ImageName("Action_Debug_Stop")]
    [DefaultProperty("Name")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    public class HotelImage : BaseObject
    {
        public HotelImage(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        // Fields...
        private HotelInfomation _Hotel;
        private string _ImageUrl;
        private string _Name;
        private object _Type;


        #region Properties

        public object Type
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

        [Size(500)]
        [VisibleInListView(true)]
        public string ImageUrl
        {
            get
            {
                return _ImageUrl;
            }
            set
            {
                SetPropertyValue("ImageUrl", ref _ImageUrl, value);
            }
        }

        #endregion Properties



        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelInfomation-HotelImages")]
        public HotelInfomation Hotel
        {
            get
            {
                return _Hotel;
            }
            set
            {
                SetPropertyValue("Hotel", ref _Hotel, value);
            }
        }

        #endregion Association
    }
}
