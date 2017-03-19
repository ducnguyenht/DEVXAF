using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design.WebControls;


namespace WebGui.AEButton
{
    public class AEButtonDesigner : ButtonDesigner
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
            AEButton aeb = (AEButton)Component;

            if (aeb.ID != "" && aeb.ID != null)
            {
                StringWriter sw = new StringWriter();
                HtmlTextWriter tw = new HtmlTextWriter(sw);
                aeb.RenderButton(tw);
                return sw.ToString();
            }
            else
                return GetEmptyDesignTimeHtml();
        }
    }
}
