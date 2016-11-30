using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class WeddingController : Controller
    {
        [Route("wedding")]
        public ActionResult GalinaWedding()
        {
            return View();
        }
        [Route("convention")]
        public ActionResult Convention()
        {
            return View();
        }
        [Route("galina-restaurant")]
        public ActionResult GalinaRestaurant()
        {
            return View();
        }
        [Route("galina-lobby-bar-and-lounge")]
        public ActionResult GalinaLobby()
        {
            return View();
        }
    }
}