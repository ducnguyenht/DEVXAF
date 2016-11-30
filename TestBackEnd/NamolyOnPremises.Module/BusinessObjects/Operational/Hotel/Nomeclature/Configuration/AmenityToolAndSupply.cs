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
    [XafDisplayName("Amenity/Tool&supplies")]
    [DefaultClassOptions]
    [ImageName("BO_Product_Group")]
    [DefaultProperty("Name")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]

    [RuleCombinationOfPropertiesIsUnique("AmenityToolAndSupply_Unique", DefaultContexts.Save, "Name, Type")]
    //[Persistent("DatabaseTableName")]
    public class AmenityToolAndSupply : BaseObject
    {
        public AmenityToolAndSupply(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private string _Description;
        private AmenityToolAndSupplyEnum _Type;
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

        public AmenityToolAndSupplyEnum Type
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
    }

    public enum AmenityToolAndSupplyEnum
    {
        Amenity = 0,
        ToolAndSupply = 1
    }

}
