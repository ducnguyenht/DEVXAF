using P04201702.WebV1.DAL;
using P04201702.WebV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P04201702.WebV1.Controllers
{
    public class DocumentationController : Controller
    {
        // GET: Documentation
        private readonly Documentations documentationService;
        public DocumentationController()
        {
            documentationService = new Documentations();
        }
        // GET: Documentation
        #region Lấy dữ liệu ở trang chủ
        [Route("tai-lieu")]
        public ActionResult Documentation()
        {
            var documentSeo = documentationService.GetItem(Constants.DOCSEO);
            DocumentSeoViewModels documentSeoViewModels = new DocumentSeoViewModels();
            documentSeoViewModels.MapFromBO(documentSeo);
            var documentList = documentationService.GetListItemParent(Constants.ListDocument);
            var documentListViewModels = DocumentNavigationTreeViewModels.MapFromBOs(documentList);
            DocumentViewModels documentViewModels = new DocumentViewModels();
            documentViewModels.DocumentSeoViewModels = documentSeoViewModels;
            documentViewModels.DocumentNavigationTreeViewModels = documentListViewModels;
            return View("Documentation", documentViewModels);
        }
        #endregion

        #region Thêm mới dữ liệu
        #region Thêm dữ liệu SEO
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentationSeoAdd(DocumentSeoViewModels DocumentSeo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = DocumentSeo.MapToBO();
                    if (DocumentSeo.Id > 0)
                    {
                        documentationService.UpdateItem(bo);
                    }
                    else
                    {
                        documentationService.AddItem(bo);
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
            return RedirectToAction("Documentation");
        }
        #endregion

        #region Tạo mới danh sách ứng dụng
        [Route("tai-lieu/tao-moi-tai-lieu")]
        public ActionResult CreateDocumentation()
        {
            DocumentNavigationTreeViewModels Documentation = new DocumentNavigationTreeViewModels();
            return View(Documentation);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateDocumentationAdd(DocumentNavigationTreeViewModels DocumentationViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bo = DocumentationViewModel.MapToBO();
                    documentationService.AddItem(bo);
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
            return RedirectToAction("Documentation");
        }
        #endregion

        #region Tạo mới con của bài viết
        [Route("tai-lieu/tao-cap-con-cho-bai-viet")]
        public ActionResult CreateSupDocumentation(GetParentAndLevel getParentLevel)
        {
            DocumentNavigationTreeViewModels documentationViewModel = new DocumentNavigationTreeViewModels();
            documentationViewModel.ParentId = getParentLevel.ParentId;
            documentationViewModel.Level = getParentLevel.Level;
            ViewBag.RoutingVN = getParentLevel.Routing;
            return View(documentationViewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateSupDocumentationAdd(DocumentNavigationTreeViewModels documentNavi)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var bo = documentNavi.MapToBO();
                        documentationService.AddItem(bo);
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
            }
            return Redirect("~/tai-lieu/" + documentNavi.RoutingVN.Trim());
        }
        #endregion
        #endregion

        #region Cập nhật tài liệu
        [Route("tai-lieu/{route}")]
        public ActionResult Detail(string route)
        {
            var documentDetail = documentationService.GetItemRouting(route);
            DocumentNavigationTreeViewModels documentNaviViewModels = new DocumentNavigationTreeViewModels();
            documentNaviViewModels.MapFromBO(documentDetail);
            return View(documentNaviViewModels);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult documentationUpdate(DocumentNavigationTreeViewModels documentNavi)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var bo = documentNavi.MapToBO();
                        documentationService.UpdateItem(bo);
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
            }
            return Redirect("~/tai-lieu/" + documentNavi.RoutingVN.Trim());
        }
        #endregion

        #region Xoá dữ liệu
        public ActionResult DeleteDocument(int DocumentId)
        {
            if (DocumentId != null)
            {
                try
                {
                    documentationService.DeleteItem(DocumentId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Documentation");
        }
        [HttpPost]
        public ActionResult DeleteMultipleDocument(IEnumerable<int> DocumentId)
        {
            if (DocumentId != null)
            {
                try
                {
                    documentationService.DeleteItem(DocumentId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Documentation");
        }
        #endregion

        #region Thể hiện navigation
        public ActionResult Navigation()
        {
            var navsModel = documentationService.GetListItem(Constants.ListDocument);
            var navsViewModel = BuildTreeAndGetRoots(navsModel);
            return PartialView("_NavigationPartial", navsViewModel);
        }

        IEnumerable<DocumentNavigationTreeViewModels> BuildTreeAndGetRoots(List<Documentation_BO> actualObjects)
        {
            Dictionary<int?, DocumentNavigationTreeViewModels> lookup = new Dictionary<int?, DocumentNavigationTreeViewModels>();
            actualObjects.ForEach(x => lookup.Add(x.Id, DocumentNavigationTreeViewModels.MapFromBOStatic(x)));
            foreach (var item in lookup.Values)
            {
                DocumentNavigationTreeViewModels proposedParent;
                if (item.ParentId != null)
                {
                    if (lookup.TryGetValue(item.ParentId, out proposedParent))
                    {
                        item.ParentId = proposedParent.Id;
                        if (item.IsLeaf == true)
                        {
                            item.IsNull = "null";
                        }
                        proposedParent.Childs.Add(item);
                    }
                }
            }
            return lookup.Values.Where(x => x.ParentId == null);
        }
        #endregion
    }
}