using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class ContactUsController : Controller
    {
        [Route("contact-us")]
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}