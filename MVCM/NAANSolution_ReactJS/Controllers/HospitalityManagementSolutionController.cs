using CMS.OnDemandServices;
using NAANSolution_ReactJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_ReactJS.Controllers
{
    public class HospitalityManagementSolutionController : Controller
    {
        private readonly Articles articlesService;
        public HospitalityManagementSolutionController()
        {
            articlesService = new Articles();
        }
        // GET: HospitalityManagementSolution
        [Route("thiet-ke-trang-web-khach-san")]
        public ActionResult HotelWebsiteDesign()
        {
            var bo = articlesService.GetItem("TKTWKS");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-dat-phong-truc-tuyen")]
        public ActionResult HotelBookingEngine()
        {
            var bo = articlesService.GetItem("PMDPTT");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-khach-san-Namoly")]
        public ActionResult HospitalityPropertyManagementSoftwareNamoly()
        {
            var bo = articlesService.GetItem("PMQLKSN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-nha-hang-Namoly")]
        public ActionResult NamolyRestaurantProfessional()
        {
            var bo = articlesService.GetItem("PMQLNHN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-spa-Namoly")]
        public ActionResult NamolySpaProfessional()
        {
            var bo = articlesService.GetItem("PMQLSN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [Route("phan-mem-quan-ly-nha-hang-khach-san-spa-Namoly")]
        public ActionResult NamolyEnterprise()
        {
            var bo = articlesService.GetItem("PMQLNHKSSN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
    }
}