using NASDMS.RDS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using db = NASDMS.RDS.NASDMSContext;
namespace WebApplication1.Models
{
    public class AuditTrailViewModel
    {
        public static int total { get; set; }
        public static List<AuditTrail> GetAuditTrail(Int32 startRecord, Int32 maxRecords, String sortColumns)
        {
            //var auditTrails = db.AuditTrails.All(where: "Oid=@0", parms: new object[] { oid }, orderBy: "ChangedOn DESC");
            var ttotal = 0;
            string where = "";
            object[] parms = new object[] { };
            string orderBy = "";
            //var products = ArtContext.Products.Paged(out model.TotalRows, where: where, orderBy: orderBy, page: page, pageSize: pageSize, parms: parms);

            //            SELECT a.i, a.j, (
            //    SELECT count(*) from test b where a.j >= b.j AND a.i = b.i
            //) AS row_number FROM test a

            var lst = db.AuditTrails.Paged(out ttotal, page: startRecord + 1, pageSize: maxRecords).ToList();
            total = ttotal;
            return lst;
        }
        public static int Total()
        {
            return total;
        }
    }
}