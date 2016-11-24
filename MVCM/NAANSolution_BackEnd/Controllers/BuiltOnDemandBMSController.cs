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
    public class BuiltOnDemandBMSController : Controller
    {
        private readonly Articles articlesService;
        public BuiltOnDemandBMSController()
        {
            articlesService = new Articles();
        }
        // GET: BuiltOnDemandBMS
        #region Phần Mềm Quản Lý Bán Hàng Trực Tuyến
        [Route("phan-mem-quan-ly-ban-hang-truc-tuyen"), Authorize]
        public ActionResult BuiltOnDemandRMS()
        {
            var bo = articlesService.GetItem("QMQLBHTT");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandRMSAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandRMS");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Chuỗi Cung Ứng
        [Route("phan-mem-quan-ly-chuoi-cung-ung"), Authorize]
        public ActionResult BuiltOnDemandDMS()
        {
            var bo = articlesService.GetItem("PMQLCCU");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandDMSAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandDMS");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Tài Chính Kế Toán
        [Route("phan-mem-quan-ly-tai-chinh-ke-toan"), Authorize]
        public ActionResult BuiltOnDemandFinanceManagementSoftware()
        {
            var bo = articlesService.GetItem("QMQLTCKT");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandFinanceManagementSoftwareAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandFinanceManagementSoftware");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Nhân Sự
        [Route("phan-mem-quan-ly-nhan-su"), Authorize]
        public ActionResult BuiltOnDemandHumanResourceManagementSoftware()
        {
            var bo = articlesService.GetItem("PMQLNS");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandHumanResourceManagementSoftwareAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandHumanResourceManagementSoftware");
        }
        #endregion
       
        #region Phần Mềm Quản Lý Quan Hệ Khách Hàng
        [Route("phan-mem-quan-ly-quan-he-khach-hang"), Authorize]
        public ActionResult BuiltOnDemandCrmSoftware()
        {
            var bo = articlesService.GetItem("PMQLQHKH");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandCrmSoftwareAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandCrmSoftware");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Hệ Thống Phân Phối
        [Route("phan-mem-quan-ly-he-thong-phan-phoi"), Authorize]
        public ActionResult BuiltOnDemandDmsSoftware()
        {
            var bo = articlesService.GetItem("PMQLHTPP");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandDmsSoftwareAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandDmsSoftware");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Trang Trại Nafaly
        [Route("phan-mem-quan-ly-trang-trai-Nafaly"), Authorize]
        public ActionResult FarmingManagementSofwareNafaly()
        {
            var bo = articlesService.GetItem("PMQLTTN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FarmingManagementSofwareNafalyAdd(ArticleViewModels article)
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
            return RedirectToAction("FarmingManagementSofwareNafaly");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Nghiệp Vụ Thương Mại Thép NAANSteel
        [Route("phan-mem-quan-ly-nghiep-vu-thuong-mai-thep-NAANSteel"), Authorize]
        public ActionResult SteelTradingBusinessManagementSofwareNAANSteel()
        {
            var bo = articlesService.GetItem("PMQLNVTMTN");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SteelTradingBusinessManagementSofwareNAANSteelAdd(ArticleViewModels article)
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
            return RedirectToAction("SteelTradingBusinessManagementSofwareNAANSteel");
        }
        #endregion
        
        #region Phần Mềm Quản Lý Tổ Chức Hiệp Hội
        [Route("phan-mem-quan-ly-to-chuc-hiep-hoi"), Authorize]
        public ActionResult BuiltOnDemandAccociationManagementSoftware()
        {
            var bo = articlesService.GetItem("PMQLTCHH");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandAccociationManagementSoftwareAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandAccociationManagementSoftware");
        }
        #endregion
    }
}