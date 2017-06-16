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
            Console.WriteLine("Enter DemoA Name: ");
            string result = Console.ReadLine();
            DemoA o1 = new DemoA {
                Name = result, 
                Code="a1new", 
                DateCreated= DateTime.Now,
                DemoB = new Guid("61188c91-0a4a-4235-b08f-79f70bc0cf6e"),
                Description="a1new",
            };
            db.DemoAs.Insert(o1);
            var all1 = db.DemoAs.All();
            var cc = o1;
            var tt = db.DemoAs.Single(o1.Oid);
            Console.WriteLine(tt.ToString());
            result = Console.ReadLine();
            //db.DemoAs.Delete(o1);
            var all11 = db.DemoAs.All();
            DemoB b = new DemoB { Code = "ASD", Name = "BBB1", Price = 123123 };
            db.DemoBs.Insert(b);

            var sdfsd = 1;
        }
    }
}
