using CMSModule.Module.BusinessObjects.CMS.Galina;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using www.galinahotel.com.vn.Models.AboutUs;

namespace www.galinahotel.com.vn.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs

        [Route("about")]
        public ActionResult About()
        {
            HttpCookie ThisLanguage = System.Web.HttpContext.Current.Request.Cookies["NOPLanguage"];
            var aboutUsModel = new AboutUsModel();
            if (ThisLanguage != null)
            {
                var xpoDAO = new XpoDAO();
                var provideUnitOfWork = xpoDAO.ProvideUnitOfWork();
                var ResultData = provideUnitOfWork.FindObject<About>(null);
                switch (ThisLanguage.Value)
                {
                    case "en":
                        {
                            aboutUsModel.Language = "en";
                            aboutUsModel.BannerTitle = ResultData.TitleP01;
                            break;
                        }
                    case "vi":
                        {
                            aboutUsModel.Language = "vi";
                            aboutUsModel.BannerTitle = ResultData.TitleVNP01;
                            break;
                        }
                    default:
                        {
                            aboutUsModel.Language = "en";
                            aboutUsModel.BannerTitle = ResultData.TitleP01;
                            break;
                        }
                }
            }
            else
            {

            }
            return View("AboutUs", aboutUsModel);


            var dao = new XpoDAO();
            var uow = dao.ProvideUnitOfWork();
            var result = uow.FindObject<About>(null);

            string language = "vi";
            AboutUsModel model = new AboutUsModel();

            return View("AboutUs", model);
        }
        [Route("about-us")]
        public ActionResult AboutUs()
        {
            return About();
        }
        [Route("gioi-thieu")]
        public ActionResult GioiThieu()
        {
            return AboutUs();
        }
    }
}