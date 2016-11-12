using InsuranceAM.WebApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var t = new EmployeeDAO();
            var s = t.GetEmployeesByTitle();
            var tt = 1;
            return View();
        }
    }
}