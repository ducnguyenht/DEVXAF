using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P04201702.WebV1.Models
{
    public class DocumentSeoViewModels
    {
        public DocumentSeoViewModels()
        {

        }
        public int? Id { get; set; }
        public string TitlePageVN { get; set; }
        public string TitlePageEN { get; set; }
        public string MetaDescriptionVN { get; set; }
        public string MetaDescriptionEN { get; set; }
        public string TitleVN { get; set; }
        public string TitleEN { get; set; }
        public string ContentVN { get; set; }
        public string ContentEN { get; set; }
        public string PageComponent { get; set; }
        public bool IsActive { get; set; }
        public Documentation_BO MapToBO()
        {
            Documentation_BO ret = new Documentation_BO();
            ret.Id = Id;
            ret.TitlePageVN = TitlePageVN;
            ret.TitlePageEN = TitlePageEN;
            ret.MetaDescriptionVN = MetaDescriptionVN;
            ret.MetaDescriptionEN = MetaDescriptionEN;
            ret.TitleVN = TitleVN;
            ret.TitleEN = TitleEN;
            ret.ContentVN = ContentVN;
            ret.ContentEN = ContentEN;
            ret.PageComponent = PageComponent;
            ret.IsActive = IsActive;
            return ret;
        }

        public void MapFromBO(Documentation_BO bo)
        {
            if (bo == null) { return; }
            else
            {
                this.Id = bo.Id;
                this.TitlePageVN = bo.TitlePageVN;
                this.TitlePageEN = bo.TitlePageEN;
                this.MetaDescriptionVN = bo.MetaDescriptionVN;
                this.MetaDescriptionEN = bo.MetaDescriptionEN;
                this.TitleVN = bo.TitleVN;
                this.TitleEN = bo.TitleEN;
                this.ContentVN = bo.ContentVN;
                this.ContentEN = bo.ContentEN;
                this.PageComponent = bo.PageComponent;
                this.IsActive = bo.IsActive;
            }
        }
        public static IList<DocumentSeoViewModels> MapFromBOs(IList<Documentation_BO> bos)
        {
            IList<DocumentSeoViewModels> apiObjs = new List<DocumentSeoViewModels>();
            foreach (var bo in bos)
            {
                DocumentSeoViewModels apiObj = new DocumentSeoViewModels();
                apiObj.MapFromBO(bo);
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
    }
}