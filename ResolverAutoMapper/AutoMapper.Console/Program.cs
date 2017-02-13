using AutoMapper.RDS;
using NamolyBookingEngine.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = AutoMapper.RDS.AutoMapperContext;
namespace AutoMapper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = @"Website=@0 and PageComponent=@1 and Language=@2";
            var homeBanner = db.WebContents.Single(where: query, parms: new object[] { });
            if (homeBanner == null)
            {
                Website GLNWebsite = Website.GALINAHOTELCOM;//1
                WebpageComponent homeBannerComponent = WebpageComponent.HOME_BANNER;//100
                Language VNLang = Language.VN;//1
                homeBanner = new WebContent();
                homeBanner.Website = (int)GLNWebsite;
                homeBanner.PageComponent = (int)homeBannerComponent;
                homeBanner.Language = (int)VNLang;
                homeBanner.PublishedData = "home banner json data";
                db.WebContents.Insert(homeBanner);
            }


        }
    }
}
