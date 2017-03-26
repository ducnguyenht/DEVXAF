using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestLogXAF.Web
{
    public partial class WebUserControl1 : System.Web.UI.UserControl, IXpoSessionAwareControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            NASDMS.RDS.Services.AuditTrailServices.IAuditTrailService AuditTrailService = new NASDMS.RDS.Services.AuditTrailServices.AuditTrailService();
            List<NASDMS.RDS.AuditTrail> auditTrails = new List<NASDMS.RDS.AuditTrail>();

            try
            {
                Guid Oid = new Guid("1e01c667-8f46-4e83-83dd-6b4d8aef701f");
                AuditTrailService.GetAuditTrails(ref auditTrails, Oid);

            }
            catch (Exception) { }
            ASPxGridView1.DataSource = auditTrails;
            ASPxGridView1.DataBind();

        }

        public void UpdateDataSource(DevExpress.Xpo.Session session)
        {
            //throw new NotImplementedException();
        }
    }
}