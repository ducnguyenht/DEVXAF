using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db = TestLog.RDS.DucTestMySqlEntities;
namespace TestLog.RDS.ORM.Helper
{
    public static class RDSAuditTrail
    {
        internal static List<AuditTrail> GetAuditTrails(Guid Oid)
        {
            try
            {
                Db db = new Db();
                string oid = Oid.ToString();
                var auditTrails = db.AuditTrails.Where(o => o.Oid == oid).OrderByDescending(o => o.ChangedOn).ToList();
                db.Dispose();
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
                Db db = new Db();
                AuditTrail h = new AuditTrail();
                h.Oid = Oid.ToString();
                h.ChangedBy = ChangedBy;
                h.Data = Data;
                h.ChangedOn = DateTime.Now;
                db.AuditTrails.Add(h);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
