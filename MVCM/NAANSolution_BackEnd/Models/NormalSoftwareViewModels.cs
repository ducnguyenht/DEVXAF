using CMS.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAANSolution_BackEnd.Models
{
    public class NormalSoftwareViewModels
    {
        public int? Id { get; set; }
        public string TitleVN { get; set; }
        public string ImageAvatarVN { get; set; }
        public string MetaDescriptionVN { get; set; }
        public string UrlVN { get; set; }
        public string Type { get; set; }
        public string PageComponent { get; set; }
        public bool IsActive { get; set; }
        public Article_BO MapToBO()
        {
            Article_BO ret = new Article_BO();
            ret.Id = Id;
            ret.TitleVN = TitleVN;
            ret.ImageAvatarVN = ImageAvatarVN;
            ret.MetaDescriptionVN = MetaDescriptionVN;
            ret.UrlVN = UrlVN;
            ret.Type = Type;
            ret.PageComponent = PageComponent;
            ret.IsActive = IsActive;
            return ret;
        }

        public void MapFromBO(Article_BO bo)
        {
            if (bo == null) { return; }
            else
            {
                this.Id = bo.Id;
                this.TitleVN = bo.TitleVN;
                this.ImageAvatarVN = bo.ImageAvatarVN;
                this.MetaDescriptionVN = bo.MetaDescriptionVN;
                this.UrlVN = bo.UrlVN;
                this.Type = bo.Type;
                this.PageComponent = bo.PageComponent;
                this.IsActive = bo.IsActive;
            }
        }
        public static IList<NormalSoftwareViewModels> MapFromBOs(IList<Article_BO> bos)
        {
            IList<NormalSoftwareViewModels> apiObjs = new List<NormalSoftwareViewModels>();
            foreach (var bo in bos)
            {
                NormalSoftwareViewModels apiObj = new NormalSoftwareViewModels();
                apiObj.MapFromBO(bo);
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
    }
}