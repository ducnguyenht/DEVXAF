using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace AspNetLight
{
    public partial class _Default : Page 
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AEDropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Button1.BackColor = Color.FromName(this.AEDropDownList1.SelectedItem.Value);
            this.AEDropDownList1.UpdateControl(this.Button1);
        }

        protected void AEButton1_Click(object sender, EventArgs e)
        {
            this.CheckBox1.Checked = !this.CheckBox1.Checked;
            this.AEButton1.UpdateControl(this.CheckBox1);
        }

        protected void AECheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox1.ReadOnly = this.AECheckBox1.Checked;
            this.AECheckBox1.UpdateControl(this.TextBox1);

        }

        protected void AETextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Button2.Text = this.AETextBox1.Text;
            this.AETextBox1.UpdateControl(this.Button2);
        }

      

      
    }
}
