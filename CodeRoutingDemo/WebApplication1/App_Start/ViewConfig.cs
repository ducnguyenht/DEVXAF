using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCodeRouting;
using System.Web.Mvc;
namespace WebApplication1.App_Start
{
    public class ViewConfig
    {
        public static void AdjustViewEngines(ViewEngineCollection viewEngines)
        {
            // Turn off WebFormViewEngine. Use Razor only.
            var webformViewEngine = viewEngines.OfType<WebFormViewEngine>().FirstOrDefault();
            if (webformViewEngine != null)
                viewEngines.Remove(webformViewEngine);

            // Activate MvcCodeRouting view wrapper
            viewEngines.EnableCodeRouting();
        }
    }
}