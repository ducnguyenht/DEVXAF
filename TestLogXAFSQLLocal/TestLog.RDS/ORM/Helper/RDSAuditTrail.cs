using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = TestLog.RDS.TestLogContext;
namespace TestLog.RDS.ORM.Helper
{
    public static class RDSAuditTrail
    {
        internal static List<AuditTrail> GetAuditTrails(Guid Oid)
        {
            try
            {
                string oid = Oid.ToString();
                var auditTrails = db.AuditTrails.All(where: "Oid=@0", parms: new object[] { oid }, orderBy: "ChangedBy DESC").ToList();
                return auditTrails;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal static void AddAuditTrail(Guid Oid, string ChangedBy, string Data)
        {
            try
            {
                AuditTrail h = new AuditTrail();
                h.Oid = Oid.ToString();
                h.ChangedBy = ChangedBy;
                h.Data = Data;
                h.ChangedOn = DateTime.Now;
                db.AuditTrails.Insert(h);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
