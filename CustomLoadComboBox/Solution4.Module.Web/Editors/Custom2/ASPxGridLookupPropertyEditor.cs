using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Filtering;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Web.ASPxGridLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution4.Module.Web.Editors.Custom2
{
    [PropertyEditor(typeof(BaseObject), EditorAliases.LookupPropertyEditor, true)]

    public class ASPxGridLookupPropertyEditor : ASPxLookupPropertyEditor
    {
        ASPxGridLookup lookup = null;
        public ASPxGridLookupPropertyEditor(Type objectType, DevExpress.ExpressApp.Model.IModelMemberViewItem model)
            : base(objectType, model)
        {
        }

        protected override System.Web.UI.WebControls.WebControl CreateEditModeControlCore()
        {
            lookup = new ASPxGridLookup();
            lookup.ValueChanged += ExtendedEditValueChangedHandler;
            lookup.GridView.SettingsBehavior.AllowSelectByRowClick = true;
            lookup.GridView.SettingsBehavior.AllowSelectSingleRowOnly = true;
            lookup.GridView.AutoGenerateColumns = true;
            lookup.IncrementalFilteringMode = DevExpress.Web.ASPxEditors.IncrementalFilteringMode.Contains;
            lookup.SelectionMode = GridLookupSelectionMode.Single;
            lookup.GridView.KeyFieldName = "Oid";
            return lookup;
        }

        protected override void ReadEditModeValueCore()
        {
            var obj = CurrentObject as BaseObject;
            var os = DevExpress.ExpressApp.Xpo.XPObjectSpace.FindObjectSpaceByObject(obj);

            lookup.GridView.DataSource = os.GetObjects(GetUnderlyingType(), new LocalizedCriteriaWrapper(Model.DataSourceCriteria, obj).CriteriaOperator);
            lookup.Load += delegate(object s, EventArgs e)
            {
                lookup.GridView.DataBind();
                var propertyValue = obj.GetMemberValue(propertyName) as BaseObject;
                if (propertyValue != null)
                {
                    lookup.GridView.Selection.SelectRowByKey(propertyValue.Oid);
                }
            };
        }
        protected override void WriteValueCore()
        {
            var obj = CurrentObject as BaseObject;
            obj.SetMemberValue(PropertyName, ControlValue);
        }
        protected override object GetControlValueCore()
        {
            return lookup.Value != null ? DevExpress.ExpressApp.Xpo.XPObjectSpace.FindObjectSpaceByObject(CurrentObject).GetObjectByKey(GetUnderlyingType(), lookup.Value) : null;
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (lookup != null)
            {
                lookup.ValueChanged -= ExtendedEditValueChangedHandler;
            }
            base.BreakLinksToControl(unwireEventsOnly);
        }
    }
}
