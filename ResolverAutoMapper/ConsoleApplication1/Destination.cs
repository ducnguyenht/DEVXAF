using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Destination
    {
        public Destination()
        {
            Content_VN = new Content();
            Content_EN = new Content();
        }
        public Content Content_VN { get; set; }
        public Content Content_EN { get; set; }
    }
}
