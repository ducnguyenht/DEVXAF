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
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

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

                //var tt = this.CurrentObject;
                if (this.CurrentObject != null)
                {
                    //var lst = db.GetObjects(this.CurrentObject.GetType());
                    IList<SortProperty> sortProps = new List<SortProperty>();
                    sortProps.Add(new SortProperty("PropertyName", SortingDirection.Ascending));
                    var lst = db.CreateCollection(this.CurrentObject.GetType(), null, sortProps);
                    //var lst = db.GetObjects<DomainObject1>();
                    var ttt = ((ASPxComboBox)control).Items;
                    if (ttt.Count < lst.Count)
                    {
                        ttt.Clear();
                        foreach (var item in lst)
                        {
                            try
                            {
                                //var t = ((ASPxComboBox)control);
                                ttt.Add(
                                    //DataBinder.Eval(DateTime.Now, "TimeOfDay.Hours");
                                 DataBinder.Eval(item, "PropertyName").ToString()
                                    //item.PropertyName1
                                );
                            }
                            catch (Exception)
                            {
                            }

                        }
                    }
                }

            }
        }
        protected override WebControl CreateEditModeControlCore()
        {
            if (dropDownControl == null)
            {
                dropDownControl = RenderHelper.CreateASPxComboBox();
                dropDownControl.DropDownStyle = DropDownStyle.DropDown;
                dropDownControl.ItemStyle.Font.Strikeout = true;
                dropDownControl.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith;
            }
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


//foreach (CultureInfo culture in CultureInfo.GetCultures(
//CultureTypes.InstalledWin32Cultures))
//{
//    ((ASPxComboBox)control).Items.Add(
//        culture.EnglishName + "(" + culture.Name + ")"
//        );
//}