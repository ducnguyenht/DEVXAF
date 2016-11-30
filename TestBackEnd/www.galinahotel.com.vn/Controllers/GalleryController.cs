using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class GalleryController : Controller
    {
        [Route("images")]
        public ActionResult Images()
        {
            return View();
        }

        [Route("videos")]
        public ActionResult Videos()
        {
            return View();
        }
    }
}