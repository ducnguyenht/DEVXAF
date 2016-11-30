using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class CameraLiveController : Controller
    {
        [Route("camera-live")]
        public ActionResult CameraLive()
        {
            return View();
        }
    }
}