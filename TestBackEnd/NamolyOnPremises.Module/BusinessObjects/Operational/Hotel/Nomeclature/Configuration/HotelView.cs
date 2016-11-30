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
    [ImageName("ModelEditor_ListView")]
    [DefaultProperty("Name")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    [RuleCombinationOfPropertiesIsUnique("HotelView_Unique", DefaultContexts.Save, "Name, Hotel", CustomMessageTemplate = "View exists.")]

    [Indices("Name")]
    public class HotelView : BaseObject
    {
        public HotelView(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private HotelInfomation _Hotel;
        private string _Description;
        private string _Name;




        #region Properties

        [RuleRequiredField(DefaultContexts.Save)]
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

        #endregion Properties

        #region Association

        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Association("HotelInfomation-HotelViews")]
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
