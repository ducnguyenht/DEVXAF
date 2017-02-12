using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Destination
    {
        public int Value { get; set; }
        public int Value2 { get; set; }

        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }

        public Content Content_VN { get; set; }
        public Content Content_EN { get; set; }
        public Destination()
        {
            Content_VN = new Content();
            Content_EN = new Content();
        }


    }
}
