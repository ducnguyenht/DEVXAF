﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_ReactJS.Controllers
{
    public class ReactJSController : Controller
    {
        // GET: ReactJS
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMessage()
        {
            return Json(new { result = "Hello World From ReactJS Controller NAAN" }, JsonRequestBehavior.AllowGet);
        }
    }
}