using DevExpress.ExpressApp.Editors;
using System;
using System.Globalization;
using System.Web.UI.WebControls;

using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.ExpressApp.Model;
using DevExpress.Web.ASPxEditors;
using DevExpress.ExpressApp;
using Solution4.Module.BusinessObjects;
using System.Web.UI;

namespace Solution4.Module.Web.Editors
{
    [PropertyEditor(typeof(string), "TestProp", false)]
    public class CustomStringEditor : ASPxPropertyEditor, IComplexViewItem
    {
        private IObjectSpace db;
        private XafApplication application;

        ASPxComboBox dropDownControl = null;
        public CustomStringEditor(
        Type objectType, IModelMemberViewItem info)
            : base(objectType, info) { }
        protected override void SetupControl(WebControl control)
        {
            if (ViewEditMode == ViewEditMode.Edit)
            {
                //foreach (CultureInfo culture in CultureInfo.GetCultures(
                //CultureTypes.InstalledWin32Cultures))
                //{
                //    ((ASPxComboBox)control).Items.Add(
                //        culture.EnglishName + "(" + culture.Name + ")"
                //        );
                //}
                var tt = this.CurrentObject;
                if (this.CurrentObject != null)
                {
                    var lst = db.GetObjects(this.CurrentObject.GetType());
                    //var lst = db.GetObjects<DomainObject1>();
                    foreach (var item in lst)
                    {
                        var t = ((ASPxComboBox)control);
                        ((ASPxComboBox)control).Items.Add(
                            //DataBinder.Eval(DateTime.Now, "TimeOfDay.Hours");
                            DataBinder.Eval(item, "PropertyName1").ToString()
                            //item.PropertyName1
                           );
                    }
                }

            }
        }
        protected override WebControl CreateEditModeControlCore()
        {
            dropDownControl = RenderHelper.CreateASPxComboBox();
            dropDownControl.DropDownStyle = DropDownStyle.DropDown;
            dropDownControl.ItemStyle.Font.Strikeout = true;
            dropDownControl.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith;
            dropDownControl.ValueChanged += new EventHandler(EditValueChangedHandler);
            return dropDownControl;
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (dropDownControl != null)
            {
                dropDownControl.ValueChanged -= new EventHandler(EditValueChangedHandler);
            }
            base.BreakLinksToControl(unwireEventsOnly);
        }

        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.db = objectSpace;
            this.application = application;
        }
    }
}
