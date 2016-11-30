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
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Utils;
using NamolyOnPremises.Module.Controllers.Common;

namespace NamolyOnPremises.Module.BusinessObjects.Operational.System.Security
{
    [DefaultClassOptions]
    [ImageName("BO_List")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class ExtendedSecurityRole : SecuritySystemRoleBase
    {
        public ExtendedSecurityRole(Session session)
            : base(session)
        {
        }

        private string _HiddenNavigationItems;
        private string _InternalCode;
        private bool _IsInternal;

        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
        public string HiddenNavigationItems
        {
            get { return _HiddenNavigationItems; }
            set { SetPropertyValue("HiddenNavigationItems", ref _HiddenNavigationItems, value); }
        }


        private string _HiddenActions;
        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
        public string HiddenActions
        {
            get { return _HiddenActions; }
            set { SetPropertyValue("HiddenActions", ref _HiddenActions, value); }
        }

        [Browsable(false)]
        public string InternalCode
        {
            get { return _InternalCode; }
            set { SetPropertyValue("InternalCode", ref _InternalCode, value); }
        }

        [Browsable(false)]
        public bool IsInternal
        {
            get { return _IsInternal; }
            set { SetPropertyValue("IsInternal", ref _IsInternal, value); }
        }

        protected override IEnumerable<IOperationPermission> GetPermissionsCore()
        {
            List<IOperationPermission> result = new List<IOperationPermission>();
            result.AddRange(base.GetPermissionsCore());
            if (!String.IsNullOrEmpty(HiddenNavigationItems))
            {
                foreach (string hiddenNavigationItem in HiddenNavigationItems.Split(';', ','))
                {
                    result.Add(new NavigationItemPermission(hiddenNavigationItem.Trim()));
                }
            }
            if (!String.IsNullOrEmpty(HiddenActions))
            {
                foreach (string hiddenAction in HiddenActions.Split(';', ','))
                {
                    //result.Add(new HideActionByIDPermission(hiddenAction.Trim()));
                }
            }
            return result;
        }

        protected override IEnumerable<IOperationPermissionProvider> GetChildrenCore()
        {
            List<IOperationPermissionProvider> result = new List<IOperationPermissionProvider>();
            result.AddRange(base.GetChildrenCore());
            result.AddRange(new EnumerableConverter<IOperationPermissionProvider, ExtendedSecurityRole>(ChildRoles));
            return result;
        }

        [Association("ParentRoles-ChildRoles")]
        public XPCollection<ExtendedSecurityRole> ChildRoles
        {
            get { return GetCollection<ExtendedSecurityRole>("ChildRoles"); }
        }

        [Association("ParentRoles-ChildRoles")]
        public XPCollection<ExtendedSecurityRole> ParentRoles
        {
            get { return GetCollection<ExtendedSecurityRole>("ParentRoles"); }
        }

        [Association("SecurityApplicationUser-ExtendedSecurityRoles")]
        public XPCollection<SecurityApplicationUser> EmployeeUserAccounts
        {
            get { return GetCollection<SecurityApplicationUser>("EmployeeUserAccounts"); }
        }

    }
}
