using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class DefaultController : Controller
    {
        
        public ActionResult Header()
        {
            return PartialView();
        }


        public ActionResult Navigation()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}