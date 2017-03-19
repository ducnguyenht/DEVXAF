using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANCMS.Controllers.CMS.Components.Default.ComponentBasic
{
    [RoutePrefix("cms/components/default/componentbasic")]
    public class ComponentBasicController : Controller
    {
        // GET: ComponentBasic
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}