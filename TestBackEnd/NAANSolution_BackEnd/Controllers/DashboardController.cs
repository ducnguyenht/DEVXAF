﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_BackEnd.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [Route("dashboard"), Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}