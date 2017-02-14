using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class DestinationController : Controller
    {
        [Route("destination")]
        public ActionResult Destination()
        {
            return View();
        }
    }
}