using CMS.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAANSolution_ReactJS.Models
{
    public class LuceneViewModels
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string AvatarUrl { get; set; }
        public int Limit { get; set; }
        public bool SearchDefault { get; set; }
        public LuceneData_BO LuceneData { get; set; }
        public IEnumerable<LuceneData_BO> AllLuceneData { get; set; }
        public IEnumerable<LuceneData_BO> SearchIndexData { get; set; }
    //    public IList<LuceneData> SearchFieldList { get; set; }
        public string SearchTerm { get; set; }
        public string SearchField { get; set; }

        public LuceneData_BO MapToBO()
        {
            LuceneData_BO ret = new LuceneData_BO();
            ret.Id = Id;
            ret.Title = Title;
            ret.Url = Url;
            ret.Description = Description;
            ret.AvatarUrl = AvatarUrl;
            return ret;
        }

        public void MapFromBO(LuceneData_BO bo)
        {
            if (bo == null) { return; }
            else
            {
                this.Id = bo.Id;
                this.Title = bo.Title;
                this.Url = bo.Url;
                this.Description = bo.Description;
                this.AvatarUrl = bo.AvatarUrl;
            }
        }
        public static IList<LuceneViewModels> MapFromBOs(IList<LuceneData_BO> bos)
        {
            IList<LuceneViewModels> apiObjs = new List<LuceneViewModels>();
            foreach (var bo in bos)
            {
                LuceneViewModels apiObj = new LuceneViewModels();
                apiObj.MapFromBO(bo);
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
    }
}