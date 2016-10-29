using DevExpress.ExpressApp.Editors;
using System;

namespace CustomControlXAF161V1.Web
{
    public partial class WebUserControl1 : System.Web.UI.UserControl, IComplexControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void IComplexControl.Refresh()
        {

        }




        void IComplexControl.Setup(DevExpress.ExpressApp.IObjectSpace objectSpace, DevExpress.ExpressApp.XafApplication application)
        {
            //throw new NotImplementedException();
        }
    }
}