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
    public class HomeController : Controller
    {
        private readonly Images imageService;
        private readonly Articles articleService;
        public HomeController()
        {
            imageService = new Images();
            articleService = new Articles();
        }
        [Route("trang-chu")]
        public ActionResult Home()
        {
            //Danh sách slider trang chủ
            var modelImage = imageService.GetData("SLTC", "Slider");
            //ImageViewModels là view của slider trang chủ
            var apiModelImage = ImageViewModels.MapFromBOs(modelImage);
            //Danh sách phần mềm nổi bật
            var modelFeaturedSoftware = articleService.GetFeaturedItem();
            var apiModelFeaturedSoftware = FeaturedSoftwareViewModels.MapFromBOs(modelFeaturedSoftware);
            //Danh sách kho phần mềm
            var modelNormalSoftware = articleService.GetNormalItem();
            var apiModelNormalSoftware = NormalSoftwareViewModels.MapFromBOs(modelNormalSoftware);
            //Danh sách kho giao diện web
            var modelWebInterface = imageService.GetData("KGDW", "Slider");
            var apiModelWEbInterface = WebInterfaceViewModels.MapFromBOs(modelWebInterface);
            HomeViewModels homeViewModels = new HomeViewModels();
            homeViewModels.imageViewModels = apiModelImage;
            homeViewModels.FeaturedSoftwareViewModels = apiModelFeaturedSoftware;
            homeViewModels.NormalSoftwareViewModels = apiModelNormalSoftware;
            homeViewModels.WebInterfaceViewModels = apiModelWEbInterface;
            return View("Home", homeViewModels);
        }
        #region Slider
        //Tạo mới một slider
        [Route("trang-chu/tao-moi-slider")]
        public ActionResult CreateSlider()
        {
            ImageViewModels slider = new ImageViewModels();

            return View(slider);
        }
        [HttpPost]
        public ActionResult CreateSliderAdd(ImageViewModels image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = image.MapToBO();
                    imageService.AddItem(bo);
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
            return RedirectToAction("Home");
        }
        //Cập nhật một slider
        [Route("trang-chu/cap-nhat-slider/{sliderId}")]
        public ActionResult UpdateSlider(int sliderId)
        {
            var bo = imageService.GetItem(sliderId);
            ImageViewModels slider = new ImageViewModels();
            slider.MapFromBO(bo);
            return View(slider);
        }
        [HttpPost]
        public ActionResult UpdateSliderUpdate(ImageViewModels image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = image.MapToBO();
                    imageService.UpdateItem(bo);
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
            return RedirectToAction("Home");
        }
        public ActionResult DeleteSlider(int sliderId)
        {
            if (sliderId != null)
            {
                try
                {
                    imageService.DeleteItem(sliderId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Home");
        }
        [HttpPost]
        public ActionResult DeleteMultipleSlider(IEnumerable<int> sliderId)
        {
            if (sliderId != null)
            {
                try
                {
                    imageService.DeleteMultipleImages(sliderId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Home");
        }
        #endregion
        #region Phần mềm nổi bật
        [Route("trang-chu/danh-sach-phan-mem")]
        public ActionResult ListApp()
        {
            var modelListApp = articleService.GetListTypeNull();
            var apiModelListApp = ArticleViewModels.MapFromBOs(modelListApp);
            return View("ListApp", apiModelListApp);
        }
        //Thêm vào phần mềm nổi bật
      //  [HttpPost]
        public ActionResult UpDateFeaturedApp(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    articleService.UpdateAppItem(id, "PMNB");
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
            return RedirectToAction("ListApp");
        }
        //Thêm nhiều vào phần mềm nổi bật
        [HttpPost]
        public ActionResult UpDateFeaturedListApp(IEnumerable<int> id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    articleService.UpdateAppItem(id, "PMNB");
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
            return RedirectToAction("ListApp");
        }
        //Xoá khỏi danh sách phần mềm nổi bật
        public ActionResult DeleteApp(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    articleService.DeleteAppItem(id);
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
            return RedirectToAction("Home");
        }
        //Xoá nhiều khỏi danh sách phần mềm nổi bật
        [HttpPost]
        public ActionResult DeleteListApp(IEnumerable<int> idItem)
        {
            if (idItem != null)
            {
                try
                {
                    articleService.DeleteAppItem(idItem);
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
            return RedirectToAction("Home");
        }
        #endregion
        #region Kho phần mềm
        [Route("trang-chu/kho-phan-mem")]
        public ActionResult ListNormalApp()
        {
            var modelListApp = articleService.GetListTypeNull();
            var apiModelListApp = ArticleViewModels.MapFromBOs(modelListApp);
            return View("ListNormalApp", apiModelListApp);
        }
        //Thêm vào phần mềm nổi bật
        //  [HttpPost]
        public ActionResult UpNormalApp(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    articleService.UpdateAppItem(id, "PMBT");
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
            return RedirectToAction("ListNormalApp");
        }
        //Thêm nhiều vào phần mềm nổi bật
        [HttpPost]
        public ActionResult UpDateNormalListApp(IEnumerable<int> id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    articleService.UpdateAppItem(id, "PMBT");
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
            return RedirectToAction("ListNormalApp");
        }
        #endregion
        #region SupportOnline
        [Route("trang-chu/tao-moi-ho-tro-truc-tuyen"), Authorize]
        public ActionResult CreateSupportOnline()
        {
            return View();
        }
        #endregion
        #region WebInterface
        [Route("trang-chu/tao-moi-giao-dien-web")]
        public ActionResult CreateWebInterface()
        {
            WebInterfaceViewModels webInterface = new WebInterfaceViewModels();
            return View(webInterface);
        }
        [HttpPost]
        public ActionResult CreateWebInterfaceAdd(WebInterfaceViewModels webInterface)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = webInterface.MapToBO();
                    imageService.AddItem(bo);
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
            return RedirectToAction("Home");
        }
        //Cập nhật một giao diện web
        [Route("trang-chu/cap-nhat-kho-giao-dien-web/{webInterfaceId}")]
        public ActionResult UpdateWebInterface(int webInterfaceId)
        {
            var bo = imageService.GetItem(webInterfaceId);
            WebInterfaceViewModels webInterface = new WebInterfaceViewModels();
            webInterface.MapFromBO(bo);
            return View(webInterface);
        }
        [HttpPost]
        public ActionResult UpdateWebInterfaceUpdate(WebInterfaceViewModels webInterface)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = webInterface.MapToBO();
                    imageService.UpdateItem(bo);
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
            return RedirectToAction("Home");
        }
        public ActionResult DeleteWebInterface(int webInterfaceId)
        {
            if (webInterfaceId != null)
            {
                try
                {
                    imageService.DeleteItem(webInterfaceId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Home");
        }
        [HttpPost]
        public ActionResult DeleteMultipleWebInterface(IEnumerable<int> webInterfaceId)
        {
            if (webInterfaceId != null)
            {
                try
                {
                    imageService.DeleteMultipleImages(webInterfaceId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Home");
        }
        #endregion
        #region Comment
        [Route("trang-chu/tao-moi-nhan-xet"), Authorize]
        public ActionResult CreateComment()
        {
            return View();
        }
        #endregion
    }
}