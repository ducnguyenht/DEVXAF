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
    public class DigitalMarketingSolutionController : Controller
    {
        private readonly Articles articlesService;
        public DigitalMarketingSolutionController()
        {
            articlesService = new Articles();
        }
        // GET: DigitalMarketingSolution
        #region Tư Vấn Thiết Kế Wev Theo Nhu Cầu
        [Route("tu-van-thiet-ke-web-theo-nhu-cau"), Authorize]
        public ActionResult BuiltOnDemandWebsite()
        {
            var bo = articlesService.GetItem("TVTKWTNC");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandWebsiteAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandWebsite");
        }
        #endregion
        #region Dịch Vụ Cải Thiện Thứ Hạng Web
        [Route("dich-vu-cai-thien-thu-hang-web"), Authorize]
        public ActionResult SeoConsultingServices()
        {
            var bo = articlesService.GetItem("DVCTTHW");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SeoConsultingServicesAdd(ArticleViewModels article)
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
            return RedirectToAction("SeoConsultingServices");
        }
        #endregion
        #region Trò Chơi Quảng Cáo Thương Hiệu Sản Phẩm
        [Route("tro-choi-quang-cao-thuong-hieu-san-pham"), Authorize]
        public ActionResult BuiltOnDemandMarketingGame()
        {
            var bo = articlesService.GetItem("TCQCTHSP");
            ArticleViewModels article = new ArticleViewModels();
            article.MapFromBO(bo);
            return View(article);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BuiltOnDemandMarketingGameAdd(ArticleViewModels article)
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
            return RedirectToAction("BuiltOnDemandMarketingGame");
        }
        #endregion

    }
}