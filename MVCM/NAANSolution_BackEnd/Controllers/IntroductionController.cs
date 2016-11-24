using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_BackEnd.Controllers
{
    [Authorize]
    public class IntroductionController : Controller
    {
        // GET: AboutUs
        [Route("tuyen-dung"), Authorize]
        public ActionResult Career()
        {
            return View();
        }
        [Route("lien-he"), Authorize]
        public ActionResult ContactUs()
        {
            return View();
        }
        [Route("tuyen-dung/tao-moi-vi-tri-tuyen-dung"), Authorize]
        public ActionResult CreateCareerIndex()
        {
            return View();
        }
    }
}