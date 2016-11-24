using CMS.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAANSolution_BackEnd.Models
{
    public class ImageViewModels
    {
        public int? Id { get; set; }
        public string TitleVN { get; set; }
        public string TitleEN { get; set; }
        public string ImageUrlVN { get; set; }
        public string ImageUrlEN { get; set; }
        public string DescriptionVN { get; set; }
        public string DescriptionEN { get; set; }
        public string KeywordVN { get; set; }
        public string KeywordEN { get; set; }
        public string UrlVN { get; set; }
        public string UrlEN { get; set; }
        public string Type { get; set; }
        public int IndexVN { get; set; }
        public int IndexEN { get; set; }
        public string PageComponent { get; set; }
        public bool IsActive { get; set; }
        public Image_BO MapToBO()
        {
            Image_BO ret = new Image_BO();
            ret.Id = Id;
            ret.TitleVN = TitleVN;
            ret.TitleEN = TitleEN;
            ret.ImageUrlVN = ImageUrlVN;
            ret.ImageUrlEN = ImageUrlEN;
            ret.DescriptionVN = DescriptionVN;
            ret.DescriptionEN = DescriptionEN;
            ret.KeywordVN = KeywordVN;
            ret.KeywordEN = KeywordEN;
            ret.UrlVN = UrlVN;
            ret.UrlEN = UrlEN;
            ret.Type = Type;
            ret.IndexVN = IndexVN;
            ret.IndexEN = IndexEN;
            ret.PageComponent = PageComponent;
            ret.IsActive = IsActive;
            return ret;
        }

        public void MapFromBO(Image_BO bo)
        {
            if (bo == null) { return; }
            else
            {
                this.Id = bo.Id;
                this.TitleVN = bo.TitleVN;
                this.TitleEN = bo.TitleEN;
                this.ImageUrlVN = bo.ImageUrlVN;
                this.ImageUrlEN = bo.ImageUrlEN;
                this.DescriptionVN = bo.DescriptionVN;
                this.DescriptionEN = bo.DescriptionEN;
                this.KeywordVN = bo.KeywordVN;
                this.KeywordEN = bo.KeywordEN;
                this.UrlVN = bo.UrlVN;
                this.UrlEN = bo.UrlEN;
                this.Type = bo.Type;
                this.IndexVN = bo.IndexVN;
                this.IndexEN = bo.IndexEN;
                this.PageComponent = bo.PageComponent;
                this.IsActive = bo.IsActive;
            }
        }
        public static IList<ImageViewModels> MapFromBOs(IList<Image_BO> bos)
        {
            IList<ImageViewModels> apiObjs = new List<ImageViewModels>();
            foreach (var bo in bos)
            {
                ImageViewModels apiObj = new ImageViewModels();
                apiObj.MapFromBO(bo);
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
    }
}