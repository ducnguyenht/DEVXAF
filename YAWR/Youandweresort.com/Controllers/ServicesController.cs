using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class ServicesController : Controller
    {
        [Route("pool-and-private-beach")]
        public ActionResult PoolPrivateBeach()
        {
            return View();
        }
        [Route("family-cinema")]
        public ActionResult FamilyCinema()
        {
            return View();
        }
        [Route("billiard")]
        public ActionResult Billiard()
        {
            return View();
        }
        [Route("kids-playground")]
        public ActionResult KidsPlayground()
        {
            return View();
        }
        [Route("live-music")]
        public ActionResult LiveMusic()
        {
            return View();
        }
    }
}