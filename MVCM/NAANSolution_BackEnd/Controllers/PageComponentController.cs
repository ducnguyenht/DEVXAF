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
    public class PageComponentController : Controller
    {
        private readonly PageComponents pageComponentsService;
        public PageComponentController()
        {
            pageComponentsService = new PageComponents();
        }
        // GET: PageComponent
        #region Get list
        [ValidateInput(false), Route("loai-o-chua")]
        public ActionResult PageComponentGridView()
        {
            var model = pageComponentsService.GetData();
            var apiModel = PageComponentViewModels.MapFromBOs(model);
            return View("PageComponentGridView",apiModel);
        }
        #endregion
        #region New
        [Route("loai-o-chua/tao-moi-loai-o-chua")]
        public ActionResult PageComponentAddNew()
        {
            PageComponentViewModels page = new PageComponentViewModels();

            return View(page);
        }
        [HttpPost, ValidateInput(false), Route("loai-o-chua")]
        public ActionResult PageComponentAdd(PageComponentViewModels pageComponent)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = pageComponent.MapToBO();
                    pageComponentsService.AddItem(bo);
                    message = "Member successfully added";
                }
                catch(Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            return RedirectToAction("PageComponentGridView", new { message = message });
        }
        #endregion
        #region Update
        [Route("loai-o-chua/cap-nhat-loai-o-chua/{pageComponentId}")]
        public ActionResult PageComponentViewUpdate(int pageComponentId)
        {
            var bo = pageComponentsService.GetItem(pageComponentId);
            PageComponentViewModels page = new PageComponentViewModels();
            page.MapFromBO(bo);
            return View(page);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PageComponentUpdate(PageComponentViewModels pageComponent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = pageComponent.MapToBO();
                    pageComponentsService.UpdateItem(bo);
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
            return RedirectToAction("PageComponentGridView");
        }
        #endregion
        #region Delete
        [ValidateInput(false)]
        public ActionResult PageComponentDelete(int IdPageComponent)
        {
            if (IdPageComponent != null)
            {
                try
                {
                    pageComponentsService.DeleteItem(IdPageComponent);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("PageComponentGridView");
        }
        #endregion
    }
}