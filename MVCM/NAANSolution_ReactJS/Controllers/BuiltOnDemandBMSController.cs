using CMS.OnDemandServices;
using NAANSolution_ReactJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_ReactJS.Controllers
{
    public class BuiltOnDemandBMSController : Controller
    {
        private readonly Articles articlesService;
        public BuiltOnDemandBMSController()
        {
            articlesService = new Articles();
        }
        // GET: BuiltOnDemandBMS
        [Route("phan-mem-quan-ly-ban-hang-truc-tuyen")]
        public ActionResult BuiltOnDemandRMS()
        {
            var bo = articlesService.GetItem("QMQLBHTT");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-quan-he-khach-hang")]
        public ActionResult BuiltOnDemandCrmSoftware()
        {
            var bo = articlesService.GetItem("PMQLQHKH");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-chuoi-cung-ung")]
        public ActionResult BuiltOnDemandDMS() 
        {
            var bo = articlesService.GetItem("PMQLCCU");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-tai-chinh-ke-toan")]
        public ActionResult BuiltOnDemandFinanceManagementSoftware()
        {
            var bo = articlesService.GetItem("QMQLTCKT");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-nhan-su")]
        public ActionResult BuiltOnDemandHumanResourceManagementSoftware()
        {
            var bo = articlesService.GetItem("PMQLNS");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-tai-lieu-dien-tu")]
        public ActionResult ContentManagementSoftware()
        {
            return View();
        }
      
        [Route("phan-mem-quan-ly-he-thong-phan-phoi")]
        public ActionResult BuiltOnDemandDmsSoftware()
        {
            var bo = articlesService.GetItem("PMQLHTPP");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-trang-trai-Nafaly")]
        public ActionResult FarmingManagementSofwareNafaly()
        {
            var bo = articlesService.GetItem("PMQLTTN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-nghiep-vu-thuong-mai-thep-NAANSteel")]
        public ActionResult SteelTradingBusinessManagementSofwareNAANSteel()
        {
            var bo = articlesService.GetItem("PMQLNVTMTN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-to-chuc-hiep-hoi")]
        public ActionResult BuiltOnDemandAccociationManagementSoftware()
        {
            var bo = articlesService.GetItem("PMQLTCHH");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
    }
}