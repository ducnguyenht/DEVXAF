using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class GalleryController : Controller
    {
      [Route("gallery")]
        public ActionResult Gallery()
        {
            return View();
        }
    }
}