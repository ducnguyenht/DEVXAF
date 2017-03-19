using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace NAANCMS.Code.Core.ViewEngineFromConfig
{
    public class ViewEngineFromConfig : RazorViewEngine
    {
        public ViewEngineFromConfig()
        {
            LoadLocations();
        }

        private void LoadLocations()
        {
            IList<string> viewLocations = new List<string>();
            IList<string> partialViewLocations = new List<string>();

            var locations = GetViewLocations();
            foreach (ViewLocationElement location in locations)
            {
                viewLocations.Add(location.Path);

                if (location.IsAlsoForPartial)
                {
                    partialViewLocations.Add(location.Path);
                }
            }

            ViewLocationFormats = viewLocations.ToArray();
            PartialViewLocationFormats = partialViewLocations.ToArray();
        }

        private ViewLocationCollection GetViewLocations()
        {
            // Get the application configuration file.
            ViewLocationSection viewLocationSection =
                (ViewLocationSection)ConfigurationManager.GetSection(
                "core/viewLocations");

            if (viewLocationSection != null)
                return viewLocationSection.Locations;

            return new ViewLocationCollection();
        }
    }
}