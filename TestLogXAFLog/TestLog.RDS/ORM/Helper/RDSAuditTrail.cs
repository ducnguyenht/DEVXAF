using NASDMS.Systems;
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
                //Db db = new Db();
                string oid = Oid.ToString();
                //.All(where: "IsActive=@0", parms: new { IsActive })
                //var auditTrails = db.AuditTrails.All();//.Where(o => o.Oid == oid);//(where: "Oid=@0", parms: new { oid });//.Where(    o => o.Oid == oid).OrderByDescending(o => o.ChangedOn).ToList();
                var auditTrails = db.AuditTrails.All(where: "Oid=@0", parms: new object[] { oid });//.Where(    o => o.Oid == oid).OrderByDescending(o => o.ChangedOn).ToList();


                //db.Dispose();
                return auditTrails.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal static void AddAuditTrail(Guid Oid, string ChangedBy, string Data, CategoryAudit category, ActionAudit action)
        {
            try
            {
                //Db db = new Db();
                AuditTrail h = new AuditTrail();
                h.Oid = Oid.ToString();
                h.ChangedBy = ChangedBy;
                h.Data = Data;
                h.ChangedOn = DateTime.Now;
                h.CategoryAudit = category;
                h.ActionAudit = action;
                db.AuditTrails.Insert(h);
                //db.AuditTrails.Add(h);
                //db.SaveChanges();
                //db.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
