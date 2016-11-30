using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class ComingSoonController : Controller
    {
        [Route("coming-soon")]
        public ActionResult ComingSoon()
        {
            return View();
        }
    }
}