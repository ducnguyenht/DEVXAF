using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youandweresort.com.Controllers
{
    public class GalinaSpaController : Controller
    {
        [Route("galina-spa")]
        public ActionResult GalinaSpa()
        {
            return View();
        }
    }
}