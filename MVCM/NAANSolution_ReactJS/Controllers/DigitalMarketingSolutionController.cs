using CMS.OnDemandServices;
using NAANSolution_ReactJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_ReactJS.Controllers
{
    public class DigitalMarketingSolutionController : Controller
    {
        private readonly Articles articlesService;
        public DigitalMarketingSolutionController()
        {
            articlesService = new Articles();
        }
        // GET: DigitalMarketingSolution
        [Route("tu-van-thiet-ke-web-theo-nhu-cau")]
        public ActionResult BuiltOnDemandWebsite()
        {
            var bo = articlesService.GetItem("TVTKWTNC");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("dich-vu-cai-thien-thu-hang-web")]
        public ActionResult SeoConsultingServices()
        {
            var bo = articlesService.GetItem("DVCTTHW");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("tro-choi-quang-cao")]
        public ActionResult BuiltOnDemandMarketingGame()
        {
            var bo = articlesService.GetItem("TCQCTHSP");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
    }
}