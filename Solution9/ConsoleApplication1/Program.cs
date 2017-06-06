using db = Namoly.Booking.Engine.Repository.Spark.NamolyBookingEngineContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Namoly.Booking.Engine.Repository.Spark;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var aa = db.BBBBs.All();
            BBBB b = new BBBB { Name = "ZXCZXCZXC" };//Id = Guid.NewGuid(), 
            db.BBBBs.Insert(b);
            var tt=  db.BBBBs.Single(new Guid("140512b2-c499-4602-bccf-50e30260a5b1"));
            AAAA a = new AAAA { BBBB = new Guid("140512b2-c499-4602-bccf-50e30260a5b1"), NameAAA = "AAAA111" };
            db.AAAAs.Insert(a);
            var cc = db.BBBBs.All();
            var dd = db.AAAAs.All();
            var ttasdas = 1;
            //var ttt = b;
            var sdfsd = 1;
        }
    }
}
