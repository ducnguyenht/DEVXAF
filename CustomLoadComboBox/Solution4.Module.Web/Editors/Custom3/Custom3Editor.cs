using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Web.ASPxEditors;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Web.UI.WebControls;
using System.Linq;
namespace Solution4.Module.Web.Editors.Custom3
{
    [PropertyEditor(typeof(string), "Custom3", false)]
    public class Custom3EditorASPxPropertyEditor : ASPxPropertyEditor, IComplexViewItem
    {
        private IObjectSpace db;
        private XafApplication application;
        private ASPxComboBox dropDownControl;

        public Custom3EditorASPxPropertyEditor(
            Type objectType, IModelMemberViewItem info)
            : base(objectType, info)
        {
        }

        protected override void SetupControl(WebControl control)
        {
            if (control is ASPxComboBox)
                dropDownControl = (ASPxComboBox)control;
        }

        protected override WebControl CreateEditModeControlCore()
        {
            dropDownControl = RenderHelper.CreateASPxComboBox();
            dropDownControl.ValueChanged += new EventHandler(EditValueChangedHandler);
            dropDownControl.ItemsRequestedByFilterCondition += ASPxComboBox_OnItemsRequestedByFilterCondition_SQL;
            dropDownControl.ItemRequestedByValue += ASPxComboBox_OnItemRequestedByValue_SQL;
            dropDownControl.DropDownStyle = DropDownStyle.DropDown;
            dropDownControl.IncrementalFilteringDelay = 300;
            //dropDownControl.IncrementalFilteringMode = IncrementalFilteringMode.Contains;//lỗi unikey ko gõ được
            dropDownControl.EnableCallbackMode = true;
            dropDownControl.CallbackPageSize = 10;
            return dropDownControl;
        }

        protected void ASPxComboBox_OnItemsRequestedByFilterCondition_SQL(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            string search = e.Filter.ToLower();//.RemoveDiacritics();
            if (String.IsNullOrEmpty(search)) return;


            //XPQuery<Solution4.Module.BusinessObjects.DomainObject1> security = new XPQuery<Solution4.Module.BusinessObjects.DomainObject1>(((XPObjectSpace)db).Session);
            //var q = from s in security
            //        where s.Property2 == null
            //        select new { s.PropertyName, s.Obj2.Prop1 };
            //var lsit = q.ToList();

            XPView clients = new XPView(
                 ((XPObjectSpace)db).Session,
                 this.CurrentObject.GetType(),
                 "PropertyName",
                 new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty("PropertyName"), search)
             );
            clients.Sorting.Add(new SortProperty("PropertyName", SortingDirection.Descending));
            clients.SkipReturnedRecords = e.BeginIndex;
            clients.TopReturnedRecords = e.EndIndex;

            dropDownControl.Items.Clear();
            foreach (ViewRecord item in clients)
            {
                dropDownControl.Items.Add(item["PropertyName"].ToString());
            }

        }

        protected void ASPxComboBox_OnItemRequestedByValue_SQL(object source, ListEditItemRequestedByValueEventArgs e) { }

        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (dropDownControl != null)
                dropDownControl.ValueChanged -= new EventHandler(EditValueChangedHandler);
            base.BreakLinksToControl(unwireEventsOnly);
        }

        public void Setup(DevExpress.ExpressApp.IObjectSpace objectSpace, DevExpress.ExpressApp.XafApplication application)
        {
            this.db = objectSpace;
            this.application = application;
        }
    }
}
//CriteriaOperator filterCriteria = new BinaryOperator(column, "%" + e.Filter + "%", BinaryOperatorType.Like);
//new BinaryOperator("PropertyName", "%" + search + "%", BinaryOperatorType.Like)

//long value = 0;
//           if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
//               return;
//           if (String.IsNullOrEmpty(e.Value.ToString().ToLower())) return;
//           dropDownControl.Items.Clear();
//           clients.Criteria = new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty("PropertyName"), e.Value.ToString().ToLower());
//           foreach (ViewRecord item in clients)
//           {
//               dropDownControl.Items.Add(item["PropertyName"].ToString());
//           }

//FillCombobox(e.Value.ToString());

//void FillCombobox(string filter)
//{
//    if (!String.IsNullOrEmpty(filter))
//    {
//        foreach (string item in filterList)
//            dropDownControl.Items.Add(item);
//    }
//}