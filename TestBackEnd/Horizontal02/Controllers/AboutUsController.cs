using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizontal02.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs

        [Route("about-us")]
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}