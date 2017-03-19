using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design.WebControls;


namespace WebGui.AECheckBox
{
    public class AECheckBoxDesigner : CheckBoxDesigner
    {
       
        public override bool AllowResize
        {
            get
            {
                return true;
            }
        }

        public override string GetDesignTimeHtml()
        {
            // Component is the control instance, defined in the base
            // designer
            AECheckBox chk = (AECheckBox)Component;

            if (chk.ID != "" && chk.ID != null)
            {
                StringWriter sw = new StringWriter();
                HtmlTextWriter tw = new HtmlTextWriter(sw);

                chk.RenderCheckBox(tw);

                return sw.ToString();
            }
            else
                return GetEmptyDesignTimeHtml();

            
        }
    }
}
