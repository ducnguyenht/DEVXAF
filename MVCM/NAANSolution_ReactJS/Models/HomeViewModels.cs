using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAANSolution_ReactJS.Models
{
    public class HomeViewModels
    {
        public IList<SliderViewModels> SliderViewModels { get; set; }
        public IList<FeaturedSoftwareViewModels> FeaturedSoftwareViewModels { get; set; }
        public IList<NormalSoftwareViewModels> NormalSoftwareViewModels { get; set; }
        public IList<WebInterfaceViewModels> WebInterfaceViewModels { get; set; }
    }
}