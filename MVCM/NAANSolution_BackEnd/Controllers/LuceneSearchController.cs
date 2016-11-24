using CMS.BusinessObjects;
using CMS.OnDemandServices;
using NAANSolution_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAANSolution_BackEnd.Controllers
{
    public class LuceneSearchController : Controller
    {
        // GET: LuceneSearch
        public ActionResult Index(string searchTerm, string searchField, bool? searchDefault, int? limit)
        {
            // create default Lucene search index directory
            if (!Directory.Exists(GoLucene._luceneDir)) Directory.CreateDirectory(GoLucene._luceneDir);

            // perform Lucene search
            List<LuceneData_BO> _searchResults;
            if (searchDefault == true)
                _searchResults = (string.IsNullOrEmpty(searchField)
                                   ? GoLucene.SearchDefault(searchTerm)
                                   : GoLucene.SearchDefault(searchTerm, searchField)).ToList();
            else
                _searchResults = (string.IsNullOrEmpty(searchField)
                                   ? GoLucene.Search(searchTerm)
                                   : GoLucene.Search(searchTerm, searchField)).ToList();
            if (string.IsNullOrEmpty(searchTerm) && !_searchResults.Any())
                _searchResults = GoLucene.GetAllIndexRecords().ToList();

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
            return RedirectToAction("Index", new { searchTerm, searchField, searchDefault });
        }
    }
}