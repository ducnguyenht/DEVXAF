using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_BackEnd.Controllers
{
    [Authorize]
    public class LayoutController : Controller
    {
        // GET: Layout
        [Route("layout"), Authorize]
        public ActionResult Layout()
        {
            return View();
        }
    }
}