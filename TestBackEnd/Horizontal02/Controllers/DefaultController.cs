using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizontal02.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult p_Header()
        {
            return PartialView();
        }

        public ActionResult p_Menu()
        {
            return PartialView();
        }

        public ActionResult p_Footer()
        {
            return PartialView();
        }
    }
}