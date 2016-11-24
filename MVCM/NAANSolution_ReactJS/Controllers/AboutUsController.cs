using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_ReactJS.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        [Route("tuyen-dung")]
        public ActionResult Career()
        {
            return View();
        }

        [Route("tuyen-dung/ho-tro-khach-hang-va-qa-qc-thuc-tap")]
        public ActionResult CareerQAQC()
        {
                        
            return View();
        }

        [Route("tuyen-dung/lap-trinh-vien-thuc-tap")]
        public ActionResult CareerProgrammerTrainee()
        {
            return View();
        }

        [Route("tuyen-dung/ban-hang")]
        public ActionResult CareerSale()
        {
            return View();
        }

        [Route("lien-he")]
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}