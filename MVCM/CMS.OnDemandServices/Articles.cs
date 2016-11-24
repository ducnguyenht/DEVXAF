using CMS.BusinessObjects;
using CMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.OnDemandServices
{
    public class Articles
    {
        public Articles()
        {

        }
        public Article_BO GetItem(string pageComponent)
        {
            var dbObj = CMSContext.Articles.Single(where: "PageComponent = @0", parms: new object[] { pageComponent });
            if (dbObj != null)
            {
                Article_BO apiObj = new Article_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarVN = dbObj.ImageAvatarVN;
                apiObj.ImageAvatarEN = dbObj.ImageAvatarEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.KeywordVN = dbObj.KeywordVN;
                apiObj.KeywordEN = dbObj.KeywordEN;
                apiObj.MetaKeywordVN = dbObj.MetaKeywordVN;
                apiObj.MetaKeywordEN = dbObj.MetaKeywordEN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.MetaFbAdmin = dbObj.MetaFbAdmin;
                apiObj.MetaPushFb = dbObj.MetaPushFb;
                apiObj.MetaSiteNameFb = dbObj.MetaSiteNameFb;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.UrlEN = dbObj.UrlEN;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                return apiObj;
            }
            else { return null; }
           
        }
        public List<Article_BO> GetFeaturedItem()
        {
            IEnumerable<Article> dbObjs = CMSContext.Articles.All(where: "Type = @0", parms: new object[] { "PMNB" }, orderBy:"IndexVN ASC");
            List<Article_BO> ret = new List<Article_BO>();
            foreach (var dbObj in dbObjs)
            {
                Article_BO apiObj = new Article_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarVN = dbObj.ImageAvatarVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.Type = dbObj.Type;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                ret.Add(apiObj);
            }
            return ret;
        }
        public List<Article_BO> GetNormalItem()
        {
            IEnumerable<Article> dbObjs = CMSContext.Articles.All(where: "Type = @0", parms: new object[] { "PMBT" }, orderBy: "IndexVN ASC");
            List<Article_BO> ret = new List<Article_BO>();
            foreach (var dbObj in dbObjs)
            {
                Article_BO apiObj = new Article_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarVN = dbObj.ImageAvatarVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.Type = dbObj.Type;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                ret.Add(apiObj);
            }
            return ret;
        }
        public List<Article_BO> GetListTypeNull()
        {
            IEnumerable<Article> dbObjs = CMSContext.Articles.All(where: "Type Is Null", orderBy: "IndexVN ASC");
            List<Article_BO> ret = new List<Article_BO>();
            foreach (var dbObj in dbObjs)
            {
                Article_BO apiObj = new Article_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarVN = dbObj.ImageAvatarVN;
                apiObj.MetaKeywordVN = dbObj.MetaKeywordVN;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.Type = dbObj.Type;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                ret.Add(apiObj);
            }
            return ret;
        }
        public List<Article_BO> Search(string Keyword)
        {
            IEnumerable<Article> dbObjs = CMSContext.Articles.All(where: "TitleVN like @0 or REPLACE(UrlVN,'-',' ') like @1", parms: new object[] { "%" + Keyword.ToUpper() + "%", "%" + Keyword.ToUpper() + "%" });
            List<Article_BO> ret = new List<Article_BO>();
            foreach (var dbObj in dbObjs)
            {
                Article_BO apiObj = new Article_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarVN = dbObj.ImageAvatarVN;
                apiObj.ImageAvatarEN = dbObj.ImageAvatarEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.KeywordVN = dbObj.KeywordVN;
                apiObj.KeywordEN = dbObj.KeywordEN;
                apiObj.MetaKeywordVN = dbObj.MetaKeywordVN;
                apiObj.MetaKeywordEN = dbObj.MetaKeywordEN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.MetaFbAdmin = dbObj.MetaFbAdmin;
                apiObj.MetaPushFb = dbObj.MetaPushFb;
                apiObj.MetaSiteNameFb = dbObj.MetaSiteNameFb;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.UrlEN = dbObj.UrlEN;
                apiObj.Type = dbObj.Type;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                ret.Add(apiObj);
            }
            return ret;
        }
        public List<Article_BO> GetData()
        {
            IEnumerable<Article> dbObjs = CMSContext.Articles.All();
            List<Article_BO> ret = new List<Article_BO>();
            foreach (var dbObj in dbObjs)
            {
                Article_BO apiObj = new Article_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarVN = dbObj.ImageAvatarVN;
                apiObj.ImageAvatarEN = dbObj.ImageAvatarEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.KeywordVN = dbObj.KeywordVN;
                apiObj.KeywordEN = dbObj.KeywordEN;
                apiObj.MetaKeywordVN = dbObj.MetaKeywordVN;
                apiObj.MetaKeywordEN = dbObj.MetaKeywordEN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.MetaFbAdmin = dbObj.MetaFbAdmin;
                apiObj.MetaPushFb = dbObj.MetaPushFb;
                apiObj.MetaSiteNameFb = dbObj.MetaSiteNameFb;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.UrlEN = dbObj.UrlEN;
                apiObj.Type = dbObj.Type;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                ret.Add(apiObj);
            }
            return ret;
        }
        public void AddItem(Article_BO postedItem)
        {
            Article newDbObj = new Article();
            newDbObj.Id = postedItem.Id;
            newDbObj.TitleVN = postedItem.TitleVN;
            newDbObj.TitleEN = postedItem.TitleEN;
            newDbObj.ImageAvatarVN = postedItem.ImageAvatarVN;
            newDbObj.ImageAvatarEN = postedItem.ImageAvatarEN;
            newDbObj.DescriptionVN = postedItem.DescriptionVN;
            newDbObj.DescriptionEN = postedItem.DescriptionEN;
            newDbObj.ContentVN = postedItem.ContentVN;
            newDbObj.ContentEN = postedItem.ContentEN;
            newDbObj.KeywordVN = postedItem.KeywordVN;
            newDbObj.KeywordEN = postedItem.KeywordEN;
            newDbObj.MetaKeywordVN = postedItem.MetaKeywordVN;
            newDbObj.MetaKeywordEN = postedItem.MetaKeywordEN;
            newDbObj.MetaDescriptionVN = postedItem.MetaDescriptionVN;
            newDbObj.MetaDescriptionEN = postedItem.MetaDescriptionEN;
            newDbObj.MetaFbAdmin = postedItem.MetaFbAdmin;
            newDbObj.MetaPushFb = postedItem.MetaPushFb;
            newDbObj.MetaSiteNameFb = postedItem.MetaSiteNameFb;
            newDbObj.UrlVN = postedItem.UrlVN;
            newDbObj.UrlEN = postedItem.UrlEN;
            newDbObj.Type = postedItem.Type;
            newDbObj.IndexVN = postedItem.IndexVN;
            newDbObj.PageComponent = postedItem.PageComponent;
            newDbObj.IsActive = postedItem.IsActive;
            CMSContext.Articles.Insert(newDbObj);
        }
        public void UpdateItem(Article_BO postedItem)
        {
            var dbObj = CMSContext.Articles.Single(postedItem.Id);
            dbObj.Id = postedItem.Id;
            dbObj.TitleVN = postedItem.TitleVN;
            dbObj.TitleEN = postedItem.TitleEN;
            dbObj.ImageAvatarVN = postedItem.ImageAvatarVN;
            dbObj.ImageAvatarEN = postedItem.ImageAvatarEN;
            dbObj.DescriptionVN = postedItem.DescriptionVN;
            dbObj.DescriptionEN = postedItem.DescriptionEN;
            dbObj.ContentVN = postedItem.ContentVN;
            dbObj.ContentEN = postedItem.ContentEN;
            dbObj.KeywordVN = postedItem.KeywordVN;
            dbObj.KeywordEN = postedItem.KeywordEN;
            dbObj.MetaKeywordVN = postedItem.MetaKeywordVN;
            dbObj.MetaKeywordEN = postedItem.MetaKeywordEN;
            dbObj.MetaDescriptionVN = postedItem.MetaDescriptionVN;
            dbObj.MetaDescriptionEN = postedItem.MetaDescriptionEN;
            dbObj.MetaFbAdmin = postedItem.MetaFbAdmin;
            dbObj.MetaPushFb = postedItem.MetaPushFb;
            dbObj.MetaSiteNameFb = postedItem.MetaSiteNameFb;
            dbObj.UrlVN = postedItem.UrlVN;
            dbObj.UrlEN = postedItem.UrlEN;
           // dbObj.Type = postedItem.Type;
            dbObj.IndexVN = postedItem.IndexVN;
            dbObj.PageComponent = postedItem.PageComponent;
            dbObj.IsActive = postedItem.IsActive;
            CMSContext.Articles.Update(dbObj);
        }
        public void UpdateAppItem(int idItem, string type)
        {
            var dbObj = CMSContext.Articles.Single(idItem);
            dbObj.Type = type;
            CMSContext.Articles.Update(dbObj);
        }
        public void UpdateAppItem(IEnumerable<int> idItem, string type)
        {
            foreach (var id in idItem)
            {
                var dbObj = CMSContext.Articles.Single(id);
                dbObj.Type = type;
                CMSContext.Articles.Update(dbObj);
            }
        }
        public void DeleteAppItem(int idItem)
        {
            var dbObj = CMSContext.Articles.Single(idItem);
            dbObj.Type = "";
            CMSContext.Articles.Update(dbObj);
        }
        public void DeleteAppItem(IEnumerable<int> idItem)
        {
            foreach (var id in idItem)
            {
                var dbObj = CMSContext.Articles.Single(id);
                dbObj.Type = "";
                CMSContext.Articles.Update(dbObj);
            }
        }
        public void DeleteItem(int id)
        {
            var dbObj = CMSContext.Articles.Single(id);
            CMSContext.Articles.Delete(dbObj);
        }
    }
}
