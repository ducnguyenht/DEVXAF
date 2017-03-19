using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design.WebControls;


namespace WebGui.AETextBox
{
    public class AETextBoxDesigner : TextControlDesigner
    {

        public override bool AllowResize
        {
            get
            {
                return true;
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            // Component is the control instance, defined in the base
            // designer
            AETextBox aetb = (AETextBox)Component;

            if (aetb.ID != "" && aetb.ID != null)
            {
                StringWriter sw = new StringWriter();
                HtmlTextWriter tw = new HtmlTextWriter(sw);
                aetb.RenderTextBox(tw);
                return sw.ToString();
            }
            else
                return GetEmptyDesignTimeHtml();
        }
    }
}
