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
using DevExpress.Xpo.Metadata;
using NamolyOnPremises.Module.BusinessObjects.Operational.HRM;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.General
{
    [DefaultClassOptions]
    [ImageName("Ico.InternalOrganization")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class InternalOrganization : BaseObject
    {
        public InternalOrganization(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        // Fields...
        private Image _Logo;
        private string _TaxCode;
        private string _Phone;
        private string _Address;
        private string _Name;


        #region Properties

        [Size(300)]
        [RuleRequiredField(DefaultContexts.Save)]
        [VisibleInListView(true)]
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

        [Size(30)]
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        }

        [Size(50)]
        public string TaxCode
        {
            get
            {
                return _TaxCode;
            }
            set
            {
                SetPropertyValue("TaxCode", ref _TaxCode, value);
            }
        }

        [Size(500)]
        [VisibleInListView(true)]
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
            }
        }

        [DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter)),
        ImageEditor(ListViewImageEditorCustomHeight = 32, DetailViewImageEditorFixedHeight = 64)]
        public Image Logo
        {
            get
            {
                return _Logo;
            }
            set
            {
                SetPropertyValue("Logo", ref _Logo, value);
            }
        }
        #endregion Properties


        #region Association

        [Association("InternalOrganization-Employees"), DevExpress.Xpo.Aggregated]
        public XPCollection<Employee> Employees
        {
            get
            {
                return GetCollection<Employee>("Employees");
            }
        }

        #endregion Association
    }
}
