using Solution10.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = Solution10.Domain.Solution10Context;
namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var all = db.DemoAs.All();
            DemoA o1 = new DemoA { 
                Name = "a1", 
                Code="a1", 
                DateCreated= DateTime.Now,
                DemoB = new Guid("61188c91-0a4a-4235-b08f-79f70bc0cf6e"),
                Description="a1",
            };
            db.DemoAs.Insert(o1);
            var all1 = db.DemoAs.All();
            var cc = o1;
            var tt = db.DemoAs.Single(o1.Oid);
            db.DemoAs.Delete(o1);
            var ttt = 1;
            //AAAA a = new AAAA { BBBB = new Guid("140512b2-c499-4602-bccf-50e30260a5b1"), NameAAA = "AAAA1" };
            //db.AAAAs.Insert(a);
            //var cc = db.BBBBs.All();
            //var dd = db.AAAAs.All();
            var ttasdas = 1;
            //var ttt = b;
            var sdfsd = 1;
        }
    }
}
