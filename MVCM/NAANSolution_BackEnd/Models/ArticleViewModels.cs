using CMS.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAANSolution_BackEnd.Models
{
    public class ArticleViewModels
    {
        public int? Id { get; set; }
        public string TitleVN { get; set; }
        public string TitleEN { get; set; }
        public string ImageAvatarVN { get; set; }
        public string ImageAvatarEN { get; set; }
        public string DescriptionVN { get; set; }
        public string DescriptionEN { get; set; }
        public string ContentVN { get; set; }
        public string ContentEN { get; set; }
        public string KeywordVN { get; set; }
        public string KeywordEN { get; set; }
        public string MetaKeywordVN { get; set; }
        public string MetaKeywordEN { get; set; }
        public string MetaDescriptionVN { get; set; }
        public string MetaDescriptionEN { get; set; }
        public string MetaFbAdmin { get; set; }
        public string MetaSiteNameFb { get; set; }
        public string MetaPushFb { get; set; }
        public string UrlVN { get; set; }
        public string UrlEN { get; set; }
        public string Type { get; set; }
        public int IndexVN { get; set; }
        public string PageComponent { get; set; }
        public bool IsActive { get; set; }
        public Article_BO MapToBO()
        {
            Article_BO ret = new Article_BO();
            ret.Id = Id;
            ret.TitleVN = TitleVN;
            ret.TitleEN = TitleEN;
            ret.ImageAvatarVN = ImageAvatarVN;
            ret.ImageAvatarEN = ImageAvatarEN;
            ret.DescriptionVN = DescriptionVN;
            ret.DescriptionEN = DescriptionEN;
            ret.ContentVN = ContentVN;
            ret.ContentEN = ContentEN;
            ret.KeywordVN = KeywordVN;
            ret.KeywordEN = KeywordEN;
            ret.MetaKeywordVN = MetaKeywordVN;
            ret.MetaKeywordEN = MetaKeywordEN;
            ret.MetaDescriptionVN = MetaDescriptionVN;
            ret.MetaDescriptionEN = MetaDescriptionEN;
            ret.MetaFbAdmin = MetaFbAdmin;
            ret.MetaPushFb = MetaPushFb;
            ret.MetaSiteNameFb = MetaSiteNameFb;
            ret.UrlVN = UrlVN;
            ret.UrlEN = UrlEN;
            ret.Type = Type;
            ret.IndexVN = IndexVN;
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
                this.TitleEN = bo.TitleEN;
                this.ImageAvatarVN = bo.ImageAvatarVN;
                this.ImageAvatarEN = bo.ImageAvatarEN;
                this.DescriptionVN = bo.DescriptionVN;
                this.DescriptionEN = bo.DescriptionEN;
                this.ContentVN = bo.ContentVN;
                this.ContentEN = bo.ContentEN;
                this.KeywordVN = bo.KeywordVN;
                this.KeywordEN = bo.KeywordEN;
                this.MetaKeywordVN = bo.MetaKeywordVN;
                this.MetaKeywordEN = bo.MetaKeywordEN;
                this.MetaDescriptionVN = bo.MetaDescriptionVN;
                this.MetaDescriptionEN = bo.MetaDescriptionEN;
                this.MetaFbAdmin = bo.MetaFbAdmin;
                this.MetaPushFb = bo.MetaPushFb;
                this.MetaSiteNameFb = bo.MetaSiteNameFb;
                this.UrlVN = bo.UrlVN;
                this.UrlEN = bo.UrlEN;
                this.Type = bo.Type;
                this.IndexVN = bo.IndexVN;
                this.PageComponent = bo.PageComponent;
                this.IsActive = bo.IsActive;
            }
        }
        public static IList<ArticleViewModels> MapFromBOs(IList<Article_BO> bos)
        {
            IList<ArticleViewModels> apiObjs = new List<ArticleViewModels>();
            foreach (var bo in bos)
            {
                ArticleViewModels apiObj = new ArticleViewModels();
                apiObj.MapFromBO(bo);
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        
    }
}