using AuditTrailRDS.RDSMysql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = //NamolyBookingEngine.RDS.NamolyBookingEngineContext
AuditTrailRDS.RDSMysql.AuditTrailRDSContext;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            var t = db.AuditTrails.All();
            foreach (var item in t)
            {
                var ttt = item;
            }
            AuditTrail ad = new AuditTrail();
            ad.Oid = Guid.NewGuid().ToString();
            ad.Data = "test insert 1";
            ad.ChangedBy = "Duc.Nguyen";
            ad.ChangedOn = DateTime.Now;
            //db.AuditTrails.Insert(ad);
            ad.ChangedBy = "Duc.Nguyen 1";
            //new object[] { Id, typeof(ContactMapModels).AssemblyQualifiedName })
            //parms: new object[] { "b08c9206-4ce9-4d44-a484-67f5292e0a35" });
            var objdelete = db.AuditTrails.All(where: "Oid=@0", parms: new object[] { "b08c9206-4ce9-4d44-a484-67f5292e0a35" });//.Where(o => o.ChangedBy == "Duc.Nguyen").FirstOrDefault();
            var tasdf = 1;
            //db.AuditTrails.Delete(ad);
            //if (objdelete != null)
            //{
            //    db.AuditTrails.Delete(objdelete);
            //}



            MySqlConnection mainDB = MySqlMain.OpenConnection();
            mainDB.Open();
            if (mainDB != null)
            {
                string query1 = "SELECT * FROM AuditTrail";

                MySqlCommand cmd = new MySqlCommand(query1, mainDB);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                foreach (var item in dataReader)
                {

                }
            }
            else
                Console.WriteLine("mainDB was null dude");
        }
    }
}
