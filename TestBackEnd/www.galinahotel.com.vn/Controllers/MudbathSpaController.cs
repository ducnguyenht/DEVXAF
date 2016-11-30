using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class MudbathSpaController : Controller
    {
        [Route("mud-bath")]
        public ActionResult Mudbath()
        {
            return View();
        }
        [Route("spa")]
        public ActionResult Spa()
        {
            return View();
        }
    }
}