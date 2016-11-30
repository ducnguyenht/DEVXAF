using CMS.OnDemandServices;
using NAANSolution_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_BackEnd.Controllers
{
    [Authorize]
    public class HospitalityManagementSolutionController : Controller
    {
        private readonly Articles articlesService;
        public HospitalityManagementSolutionController()
        {
            articlesService = new Articles();
        }
        // GET: HospitalityManagementSolution
        #region Thiết Kế Trang Web Khách Sạn
        [Route("thiet-ke-trang-web-khach-san"), Authorize]
        public ActionResult HotelWebsiteDesign()
        {
            var bo = articlesService.GetItem("TKTWKS");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult HotelWebsiteDesignAdd(ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LuceneViewModels luceneViewModels = new LuceneViewModels();
                    luceneViewModels.Id = article.Id;
                    luceneViewModels.Title = article.TitleVN;
                    luceneViewModels.Url = article.UrlVN.Replace("-", " ").Trim();
                    luceneViewModels.Description = article.MetaDescriptionVN;
                    luceneViewModels.AvatarUrl = article.ImageAvatarVN;
                    var lucene = luceneViewModels.MapToBO();
                    var bo = article.MapToBO();
                    if (article.Id > 0)
                    {
                        articlesService.UpdateItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                    else
                    {
                        articlesService.AddItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return RedirectToAction("HotelWebsiteDesign");
        }
        #endregion
        
        #region Phần Mềm Đặt Phòng Trực Tuyến
        [Route("phan-mem-dat-phong-truc-tuyen"), Authorize]
        public ActionResult HotelBookingEngine()
        {
            var bo = articlesService.GetItem("PMDPTT");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult HotelBookingEngineAdd(ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LuceneViewModels luceneViewModels = new LuceneViewModels();
                    luceneViewModels.Id = article.Id;
                    luceneViewModels.Title = article.TitleVN;
                    luceneViewModels.Url = article.UrlVN.Replace("-", " ").Trim();
                    luceneViewModels.Description = article.MetaDescriptionVN;
                    luceneViewModels.AvatarUrl = article.ImageAvatarVN;
                    var lucene = luceneViewModels.MapToBO();
                    var bo = article.MapToBO();
                    if (article.Id > 0)
                    {
                        articlesService.UpdateItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                    else
                    {
                        articlesService.AddItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return RedirectToAction("HotelBookingEngine");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Khách Sạn Namoly
        [Route("phan-mem-quan-ly-khach-san-Namoly"), Authorize]
        public ActionResult HospitalityPropertyManagementSoftwareNamoly()
        {
            var bo = articlesService.GetItem("PMQLKSN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult HospitalityPropertyManagementSoftwareNamolyAdd(ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LuceneViewModels luceneViewModels = new LuceneViewModels();
                    luceneViewModels.Id = article.Id;
                    luceneViewModels.Title = article.TitleVN;
                    luceneViewModels.Url = article.UrlVN.Replace("-", " ").Trim();
                    luceneViewModels.Description = article.MetaDescriptionVN;
                    luceneViewModels.AvatarUrl = article.ImageAvatarVN;
                    var lucene = luceneViewModels.MapToBO();
                    var bo = article.MapToBO();
                    if (article.Id > 0)
                    {
                        articlesService.UpdateItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                    else
                    {
                        articlesService.AddItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return RedirectToAction("HospitalityPropertyManagementSoftwareNamoly");
        }
        #endregion

        #region Phần Mềm Quản Lý Nhà Hàng Namoly
        [Route("phan-mem-quan-ly-nha-hang-Namoly"), Authorize]
        public ActionResult NamolyRestaurantProfessional()
        {
            var bo = articlesService.GetItem("PMQLNHN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NamolyRestaurantProfessionalAdd(ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LuceneViewModels luceneViewModels = new LuceneViewModels();
                    luceneViewModels.Id = article.Id;
                    luceneViewModels.Title = article.TitleVN;
                    luceneViewModels.Url = article.UrlVN.Replace("-", " ").Trim();
                    luceneViewModels.Description = article.MetaDescriptionVN;
                    luceneViewModels.AvatarUrl = article.ImageAvatarVN;
                    var lucene = luceneViewModels.MapToBO();
                    var bo = article.MapToBO();
                    if (article.Id > 0)
                    {
                        articlesService.UpdateItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                    else
                    {
                        articlesService.AddItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return RedirectToAction("NamolyRestaurantProfessional");
        }
        #endregion

        #region Phần Mềm Quản Lý Spa Namoly
        [Route("phan-mem-quan-ly-spa-Namoly"), Authorize]
        public ActionResult NamolySpaProfessional()
        {
            var bo = articlesService.GetItem("PMQLSN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NamolySpaProfessionalAdd(ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LuceneViewModels luceneViewModels = new LuceneViewModels();
                    luceneViewModels.Id = article.Id;
                    luceneViewModels.Title = article.TitleVN;
                    luceneViewModels.Url = article.UrlVN.Replace("-", " ").Trim();
                    luceneViewModels.Description = article.MetaDescriptionVN;
                    luceneViewModels.AvatarUrl = article.ImageAvatarVN;
                    var lucene = luceneViewModels.MapToBO();
                    var bo = article.MapToBO();
                    if (article.Id > 0)
                    {
                        articlesService.UpdateItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                    else
                    {
                        articlesService.AddItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return RedirectToAction("NamolySpaProfessional");
        }
        #endregion

        #region Phần Mềm Quản Lý Nhà Hàng Khách Sạn Spa Namoly
        [Route("phan-mem-quan-ly-nha-hang-khach-san-spa-Namoly"), Authorize]
        public ActionResult NamolyEnterprise()
        {
            var bo = articlesService.GetItem("PMQLNHKSSN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NamolyEnterpriseAdd(ArticleViewModels article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LuceneViewModels luceneViewModels = new LuceneViewModels();
                    luceneViewModels.Id = article.Id;
                    luceneViewModels.Title = article.TitleVN;
                    luceneViewModels.Url = article.UrlVN.Replace("-", " ").Trim();
                    luceneViewModels.Description = article.MetaDescriptionVN;
                    luceneViewModels.AvatarUrl = article.ImageAvatarVN;
                    var lucene = luceneViewModels.MapToBO();
                    var bo = article.MapToBO();
                    if (article.Id > 0)
                    {
                        articlesService.UpdateItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                    else
                    {
                        articlesService.AddItem(bo);
                        GoLucene.AddUpdateLuceneIndex(lucene);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return RedirectToAction("NamolyEnterprise");
        }
        #endregion
    }
}