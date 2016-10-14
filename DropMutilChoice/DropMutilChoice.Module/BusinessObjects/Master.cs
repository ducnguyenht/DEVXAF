using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace DXExample.Module {
    [DefaultClassOptions]
    public class Master : BaseObject {
        public Master(Session session) : base(session) { DateCreate = DateTime.Now; }
        private DateTime _DateCreate;
        private string _Description;
        private string _Code;
        private bool _ShowHideDetail;
        private string _MasterName;


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
        
        public string MasterName {
            get { return _MasterName; }
            set { SetPropertyValue("MasterName", ref _MasterName, value); }
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

        public DateTime DateCreate
        {
            get
            {
                return _DateCreate;
            }
            set
            {
                SetPropertyValue("DateCreate", ref _DateCreate, value);
            }
        }
        [ImmediatePostData]
        public bool ShowHideDetail
        {
            get
            {
                return _ShowHideDetail;
            }
            set
            {
                SetPropertyValue("ShowHideDetail", ref _ShowHideDetail, value);
            }
        }
        [Association("Master-Details")]
        [Appearance("Single", Visibility = ViewItemVisibility.Hide, Criteria = "!ShowHideDetail", Context = "DetailView")]
        public XPCollection<Detail> Details {
            get { return GetCollection<Detail>("Details"); }
        }
    }
}