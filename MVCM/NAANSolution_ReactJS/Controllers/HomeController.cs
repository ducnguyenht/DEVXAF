using CMS.BusinessObjects;
using CMS.OnDemandServices;
using NAANSolution_ReactJS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_ReactJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly Articles articleService;
        private readonly Images imageService;
        public HomeController()
        {
            articleService = new Articles();
            imageService = new Images();
        }
        // GET: Home
        public ActionResult Index()
        {
            //Danh sách slider trang chủ
            var modelSlider = imageService.GetData("SLTC", "Slider");
            //ImageViewModels là view của slider trang chủ
            var apiModelSlider = SliderViewModels.MapFromBOs(modelSlider);
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
            homeViewModels.SliderViewModels = apiModelSlider;
            homeViewModels.FeaturedSoftwareViewModels = apiModelFeaturedSoftware;
            homeViewModels.NormalSoftwareViewModels = apiModelNormalSoftware;
            homeViewModels.WebInterfaceViewModels = apiModelWEbInterface;
            return View(homeViewModels);// RedirectToAction("Index", "ReactJS");
        }
        /// <summary>
        /// Layout Header
        /// Dùng PartialView mục đích làm layout chung
        /// </summary>
        /// <returns></returns>
        public ActionResult p_Haeder()
        {
            return PartialView();
        }
        /// <summary>
        /// Menu
        /// Dùng PartialView mục đích làm layout chung
        /// </summary>
        /// <returns></returns>
        public ActionResult p_Navigation()
        {
            return PartialView();
        }
        /// <summary>
        /// Footer
        /// Dùng PartialView mục đích làm layout chung
        /// </summary>
        /// <returns></returns>
        public ActionResult p_Footer()
        {
            return PartialView();
        }
        /// <summary>
        /// Dùng để chèn cột thông tin bên phải
        /// </summary>
        /// <returns></returns>
        public ActionResult p_Content_Right()
        {
            return PartialView();
        }
        /// <summary>
        /// Dùng để chứa link danh mục phần mềm liên quan 
        /// </summary>
        /// <returns></returns>
        public ActionResult p_Relation_Right()
        {
            return PartialView();
        }
        /// <summary>
        /// Tìm kiếm từ database
        /// </summary>
        /// <param name="fcSearch"></param>
        /// <returns></returns>
        /// 

        //[Route("ket-qua-tim-kiem")]
        //public ActionResult Search(FormCollection fcSearch)
        //{
        //    string name = fcSearch["txtSearch"];
        //    if (name != null && name != "")
        //    {
        //        var model = articlesService.Search(name);
        //        var apiModel = ArticleViewModels.MapFromBOs(model);
        //        return View("Search", apiModel);
        //    }
        //    else
        //    {
        //        var model = articlesService.GetData();
        //        var apiModel = ArticleViewModels.MapFromBOs(model);
        //        return View("Search", apiModel);
        //    }
            
        //}

        public ActionResult ViewSearch(string searchTerm, string searchField, bool? searchDefault, int? limit)
        {
            // create default Lucene search index directory
            if (!Directory.Exists(GoLucene._lucaenDirFontEnd)) Directory.CreateDirectory(GoLucene._lucaenDirFontEnd);

            // perform Lucene search
              List<LuceneData_BO> _searchResults;
           // var _searchResults = LuceneViewModels.MapFromBOs(GoLucene.GetAll());
            if (searchDefault == true)
                _searchResults = (string.IsNullOrEmpty(searchField)
                                   ? GoLucene.SearchDefaultFrontEnd(searchTerm)
                                   : GoLucene.SearchDefaultFrontEnd(searchTerm, searchField)).ToList();
            else
                _searchResults = (string.IsNullOrEmpty(searchField)
                                   ? GoLucene.SearchFrontEnd(searchTerm)
                                   : GoLucene.SearchFrontEnd(searchTerm, searchField)).ToList();
            if (string.IsNullOrEmpty(searchTerm) && !_searchResults.Any())
                _searchResults = GoLucene.GetAllIndexRecordsFrontEnd().ToList();

            //// setup and return view model
            //var search_field_list = new
            //    List<SelectedList> {
            //                            new SelectedList {Text = "(All Fields)", Value = ""},
            //                            new SelectedList {Text = "Id", Value = "Id"},
            //                            new SelectedList {Text = "Name", Value = "Name"},
            //                            new SelectedList {Text = "Description", Value = "Description"}
            //                         };

            //// limit display number of database records
            //var limitDb = limit == null ? 3 : Convert.ToInt32(limit);
            //List<LuceneData> allLuceneData;
            //if (limitDb > 0)
            //{
            //    allSampleData = SampleDataRepository.GetAll().ToList().Take(limitDb).ToList();
            //    ViewBag.Limit = SampleDataRepository.GetAll().Count - limitDb;
            //}
            //else allSampleData = SampleDataRepository.GetAll();

            return View(new LuceneViewModels
            {
                // AllLuceneData = allLuceneData,
                SearchIndexData = _searchResults,
                //LuceneData = new SampleData { Id = 9, Name = "El-Paso", Description = "City in Texas" },
                //  SearchFieldList = search_field_list,
            });
        }

        public ActionResult Search(FormCollection fcSearch, string searchField, string searchDefault)
        {
            string searchTerm = fcSearch["txtSearch"];
            searchField = "";
            return RedirectToAction("ViewSearch", new { searchTerm, searchField, searchDefault });
        }
    }
}