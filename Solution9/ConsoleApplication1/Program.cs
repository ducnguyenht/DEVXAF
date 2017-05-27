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
            //BBBB b = new BBBB { Name = "asdfsd234234asdfsadf" };//Id = Guid.NewGuid(), 
            //db.BBBBs.Insert(b);
            var tt=  db.BBBBs.Single(new Guid("140512b2-c499-4602-bccf-50e30260a5b1"));
            var cc = db.BBBBs.All();
            var ttasdas = 1;
            //var ttt = b;
            var sdfsd = 1;
        }
    }
}
