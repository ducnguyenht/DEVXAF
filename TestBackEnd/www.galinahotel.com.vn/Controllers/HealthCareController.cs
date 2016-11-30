using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class HealthCareController : Controller
    {
        [Route("tranditional-medicince")]
        public ActionResult TranditionalMedicince()
        {
            return View();
        }

        [Route("orthodontic-center")]
        public ActionResult OrthodonticCenter(){
            return View();
        }



        [Route("about-yoga-class")]
        public ActionResult AboutYogaClass(){
            return View();
        }
    }
}