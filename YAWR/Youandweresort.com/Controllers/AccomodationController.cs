using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class AccomodationController : Controller
    {
        [Route("accomodation")]
        public ActionResult Accomodation()
        {
            return View();
        }
        [Route("deluxe-sea-view")]
        public ActionResult DeluxeSeaView()
        {
            return View();
        }


        [Route("premier-deluxe-sea-view")]
        public ActionResult PremierDeluxeSeaView()
        {
            return View();
        }

        [Route("executive-deluxe-sea-view")]
        public ActionResult ExecutiveDeluxeSeaView()
        {
            return View();
        }

        [Route("balcony-beachfront-villa")]
        public ActionResult BalconyBeachfrontVilla()
        {
            return View();
        }

        [Route("ancient-beachfront-villa")]
        public ActionResult AncientBeachfrontVilla()
        {
            return View();
        }
        [Route("impeccable-beach-step-villa")]
        public ActionResult ImpeccableBeachStepVilla()
        {
            return View();
        }


    }
}