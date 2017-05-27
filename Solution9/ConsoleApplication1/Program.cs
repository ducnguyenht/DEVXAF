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
            BBBB b = new BBBB { Name = "asdfsd" };//Id = Guid.NewGuid(), 
            db.BBBBs.Insert(b);
            var cc = db.BBBBs.All();
            var tt = 1;
        }
    }
}
