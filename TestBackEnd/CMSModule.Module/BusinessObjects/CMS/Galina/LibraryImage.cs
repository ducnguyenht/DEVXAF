﻿using System;
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

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class LibraryImage : BaseObject
    {
        public LibraryImage(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        // Fields...
        private string _Code;

        private string _TitleRU;
        private string _TitleVN;
        private string _Title;

        private string _DescriptionRU;
        private string _DescriptionVN;
        private string _Description;

        private string _RoutingVN;
        private string _RoutingRU;
        private string _Routing;


        #region get-set
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                SetPropertyValue("Code", ref _Code, value);
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

        public string DescriptionVN
        {
            get
            {
                return _DescriptionVN;
            }
            set
            {
                SetPropertyValue("DescriptionVN", ref _DescriptionVN, value);
            }
        }

        public string DescriptionRU
        {
            get
            {
                return _DescriptionRU;
            }
            set
            {
                SetPropertyValue("DescriptionRU", ref _DescriptionRU, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                SetPropertyValue("Title", ref _Title, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVN
        {
            get
            {
                return _TitleVN;
            }
            set
            {
                SetPropertyValue("TitleVN", ref _TitleVN, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRU
        {
            get
            {
                return _TitleRU;
            }
            set
            {
                SetPropertyValue("TitleRU", ref _TitleRU, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
        public string Routing
        {
            get
            {
                return _Routing;
            }
            set
            {
                SetPropertyValue("Routing", ref _Routing, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
        public string RoutingVN
        {
            get
            {
                return _RoutingVN;
            }
            set
            {
                SetPropertyValue("RoutingVN", ref _RoutingVN, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), VisibleInListView(false)]
        public string RoutingRU
        {
            get
            {
                return _RoutingRU;
            }
            set
            {
                SetPropertyValue("RoutingRU", ref _RoutingRU, value);
            }
        }




        #endregion


        #region event
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                //case "Title":
                //    Routing = ValidateSystem.RejectMarks(Title, "-");
                //    break;
                //case "TitleVN":
                //    RoutingVN = ValidateSystem.RejectMarks(TitleVN, "-");
                //    break;
                //case "TitleRU":
                //    RoutingRU = ValidateSystem.RejectMarks(TitleRU, "-");
                //    break;
            }
        }

      
        protected override void OnSaving()
        {
            if (!(Session is NestedUnitOfWork) && Session.IsNewObject(this))
            {
                Code = CustomDistributedIdGeneratorHelper.Generate(this.Session.DataLayer, this.GetType(), true, Code);
            }
            base.OnSaving();

        }

        #endregion
    }
}