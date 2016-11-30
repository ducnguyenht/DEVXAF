using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_BackEnd.Controllers
{
    [Authorize]
    public class OurClientController : Controller
    {
        // GET: OurClient
        [Route("khach-hang-tieu-bieu")]
        public ActionResult OurClient()
        {
            return View();
        }
        [Route("khach-hang-tieu-bieu/tao-moi-khach-hang")]
        public ActionResult CreateOurClient()
        {
            return View();
        }
    }
}