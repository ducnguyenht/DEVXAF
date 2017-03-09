using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web.ASPxEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Solution4.Module.Web.Editors.Custom1
{
    [PropertyEditor(typeof(string), "TestProp1", false)]
    public class CustomStringEditor : ASPxPropertyEditor
    {
        private ASPxComboBox dropDownControl;
        private List<string> valueList;
        private List<string> filterList;

        public CustomStringEditor(
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
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
                valueList.Add(culture.EnglishName + "(" + culture.Name + ")");

            filterList = (from u in valueList
                          where u.ToLower().Contains(e.Filter.ToLower())
                          select u).ToList();

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
    }
}
