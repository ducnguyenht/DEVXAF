using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class SpecialOffersController : Controller
    {
        [Route("special-offers")]
        public ActionResult SpecialOffers()
        {
            return View();
        }
    }
}