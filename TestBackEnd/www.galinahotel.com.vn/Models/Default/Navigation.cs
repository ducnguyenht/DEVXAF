using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace www.galinahotel.com.vn.Models.Default
{
    public class Navigation
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Routing { get; set; }
        public string Class { get; set; }
        public List<NavigationChild> Child { get; set; }
    }
    public class NavigationChild
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Routing { get; set; }
    }
}