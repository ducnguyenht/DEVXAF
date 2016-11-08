using DevExpress.ExpressApp.Model;
using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

using DevExpress.ExpressApp.SystemModule;

namespace UseFunctionCriteriaOperators.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ListViewFilter("AllRecords", "[IsActive] =true", true)]
    //[ListViewFilter("AllRecords", "", true)]

    [ListViewFilter("Today", "[DueDate] = LocalDateTimeToday()")]
    [ListViewFilter("In three days", "[DueDate] >= ADDDAYS(LocalDateTimeToday(), -3) AND [DueDate] < LocalDateTimeToday()")]
    [ListViewFilter("In two weeks", "[DueDate] >= ADDDAYS(LocalDateTimeToday(), -14) AND [DueDate] < LocalDateTimeToday()")]
    [ListViewFilter("The last work week", "[DueDate] > LocalDateTimeLastWeek() AND [DueDate] <= ADDDAYS(LocalDateTimeLastWeek(), 5)")]
    [ListViewFilter("This work week", "[DueDate] > LocalDateTimeThisWeek() AND [DueDate] <= ADDDAYS(LocalDateTimeThisWeek(), 5)")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]

    public class Task : BaseObject
    {
        public Task(Session session)
            : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;
        }
        private bool _IsActive;
        private DateTime dueDate;
        [ModelDefault("EditMask", "d")]
        public DateTime DueDate
        {
            get { return dueDate; }
            set { SetPropertyValue("DueDate", ref dueDate, value); }
        }

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetPropertyValue("IsActive", ref _IsActive, value);
            }
        }
    }

}
