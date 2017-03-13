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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution4.Module.Web.Editors.Custom3
{
    [PropertyEditor(typeof(string), "Custom3", false)]
    public class Custom3EditorASPxPropertyEditor : ASPxPropertyEditor, IComplexViewItem
    {
        private IObjectSpace db;
        private XafApplication application;
        private ASPxComboBox dropDownControl;
        private List<string> valueList;
        private List<string> filterList;

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
            dropDownControl.EnableCallbackMode = true;
            dropDownControl.CallbackPageSize = 10;
            return dropDownControl;
        }

        protected void ASPxComboBox_OnItemsRequestedByFilterCondition_SQL(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            if (filterList == null)
                filterList = new List<string>();

            if (valueList == null)
                valueList = new List<string>();
            valueList.Clear();
            //foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
            //    valueList.Add(culture.EnglishName + "(" + culture.Name + ")");
            string search = e.Filter.ToLower();
            IList<SortProperty> sortProps = new List<SortProperty>();
            sortProps.Add(new SortProperty("PropertyName", SortingDirection.Ascending));
            CriteriaOperator cr = new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty("PropertyName"), search);
            Session ss = ((XPObjectSpace)db).Session;
            Type type = this.CurrentObject.GetType();
            XPView clients = new XPView(ss, type, "PropertyName", cr);
            var Sorting = new SortingCollection();
            Sorting.Add(new SortProperty("PropertyName", SortingDirection.Descending));
            clients.Sorting = Sorting;
            clients.SkipReturnedRecords = e.BeginIndex;
            clients.TopReturnedRecords = e.EndIndex;
            //XPView clients = new XPView(Session.DefaultSession, typeof(PersistentObject1)); 
            //clients.Properties.Add(new ViewProperty("Name", SortDirection.None, "Name", false, true)); 
            //PO1_View.Properties.Add(new ViewProperty("Order", SortDirection.Descending, "Order", false, true));
            foreach (ViewRecord item in clients)
            {
                //string s = item["PropertyName"].ToString();
                valueList.Add(item["PropertyName"].ToString());
            }

            //var lst = db.CreateCollection(this.CurrentObject.GetType(), cr, sortProps);
            //foreach (var item in lst)
            //{
            //    valueList.Add(DataBinder.Eval(item, "PropertyName").ToString());
            //}

            filterList = (from u in valueList
                          where u.ToLower().Contains(e.Filter.ToLower())
                          select u).Skip(e.BeginIndex).Take(e.EndIndex).ToList();

            dropDownControl.Items.Clear();

            FillCombobox(e.Filter);
        }

        protected void ASPxComboBox_OnItemRequestedByValue_SQL(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;

            filterList = (from u in valueList
                          where u.ToLower().Contains(e.Value.ToString().ToLower())
                          select u).ToList();

            dropDownControl.Items.Clear();
            FillCombobox(e.Value.ToString());
        }

        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (dropDownControl != null)
                dropDownControl.ValueChanged -= new EventHandler(EditValueChangedHandler);
            base.BreakLinksToControl(unwireEventsOnly);
        }

        void FillCombobox(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                foreach (string item in filterList)
                    dropDownControl.Items.Add(item);
            }
        }

        public void Setup(DevExpress.ExpressApp.IObjectSpace objectSpace, DevExpress.ExpressApp.XafApplication application)
        {
            this.db = objectSpace;
            this.application = application;
        }
    }
}
