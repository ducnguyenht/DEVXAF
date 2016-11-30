using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class NewsController : Controller
    {
        [Route("explore-nha-trang")]
        public ActionResult ExploreNhaTrang()
        {
            return View();
        }

        [Route("explore-nha-trang/{id}")]
        public ActionResult ExploreNhaTrangDetail(string id)
        {
            return View();
        }
    }
}