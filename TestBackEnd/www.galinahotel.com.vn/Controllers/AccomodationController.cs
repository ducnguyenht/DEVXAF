using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class AccomodationController : Controller
    {
        [Route("superior-room")]
        public ActionResult SuperiorRoom()
        {
            return View();
        }

        [Route("deluxe-room")]
        public ActionResult DeluxeRoom()
        {
            return View();
        }


        [Route("city-view-suite")]
        public ActionResult CityViewSuite()
        {
            return View();
        }

        [Route("sea-view-suite")]
        public ActionResult SeaViewSuite()
        {
            return View();
        }
    }
}