using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignFrontEnd.Controllers
{
    public class FrontEndController : Controller
    {
        // GET: FrontEnd
        public ActionResult Index()
        {
            return View();
        }
    }
}