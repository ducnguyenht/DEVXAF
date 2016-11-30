using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class PromotionController : Controller
    {
        [Route("promotion")]
        public ActionResult Promotion()
        {
            return View();
        }

        [Route("promotion/{id}")]
        public ActionResult PromotionDetail(string id)
        {
            return View();
        }
    }
}