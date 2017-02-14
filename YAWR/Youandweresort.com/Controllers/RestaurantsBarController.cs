using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class RestaurantsBarController : Controller
    {
        [Route("amarin-restaurant")]
        public ActionResult AmarinRestaurant()
        {
            return View();
        }
        [Route("galina-beach-restaurant")]
        public ActionResult GalinaBeachRestaurant()
        {
            return View();
        }
        [Route("hibis-beach-bar")]
        public ActionResult HibisBeachBar()
        {
            return View();
        }
    }
}