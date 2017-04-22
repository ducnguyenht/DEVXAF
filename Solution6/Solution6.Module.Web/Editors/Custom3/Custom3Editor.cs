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
using Newtonsoft.Json.Linq;
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
            dropDownControl.ClientSideEvents.KeyDown =
                   @"function onKeyDown(s, e) {
                        if (e.htmlEvent.keyCode == 13) {
                            s.PerformCallback(s.inputElement.value);
                        }                     
                    }";
            dropDownControl.DropDownStyle = DropDownStyle.DropDown;
            dropDownControl.IncrementalFilteringDelay = 9999999;
            dropDownControl.IncrementalFilteringMode = IncrementalFilteringMode.Contains;//lỗi unikey ko gõ được
            dropDownControl.EnableCallbackMode = true;
            dropDownControl.CallbackPageSize = 10;
            dropDownControl.ValueChanged += new EventHandler(EditValueChangedHandler);
            dropDownControl.ItemRequestedByValue += ASPxComboBox_OnItemRequestedByValue_SQL;
            dropDownControl.Callback += dropDownControl_Callback;
            return dropDownControl;
        }
        
        void dropDownControl_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            string search = e.Parameter.ToLower();//.RemoveDiacritics();
            if (String.IsNullOrEmpty(search)) return;
            dropDownControl.Text = e.Parameter;

            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false", Uri.EscapeDataString(search));
            System.Net.WebClient wc = new System.Net.WebClient();
            System.IO.Stream stream = wc.OpenRead(requestUri);
            string jsonAddressFromGoogle = "";
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                jsonAddressFromGoogle = reader.ReadToEnd();
            }
            JObject json = JObject.Parse(jsonAddressFromGoogle);
            var postTitles =
                             from p in json["results"]
                             select (string)p["formatted_address"];
            dropDownControl.Items.Clear();
            dropDownControl.Items.Add(e.Parameter);
            foreach (var item in postTitles)
            {
                dropDownControl.Items.Add(item);
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