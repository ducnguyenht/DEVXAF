using CMS.BusinessObjects;
using CMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.OnDemandServices
{
    public class Images
    {
        public Images()
        {
        }
        /// <summary>
        /// Lấy ra một hình ảnh thuộc ô chứa nào
        /// </summary>
        /// <param name="pageComponent"></param>
        /// <returns></returns>
        public Image_BO GetItem(int imageId)
        {
            var dbObj = CMSContext.Images.Single(imageId);
            if (dbObj != null)
            {
                Image_BO apiObj = new Image_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageUrlVN = dbObj.ImageUrlVN;
                apiObj.ImageUrlEN = dbObj.ImageUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.KeywordVN = dbObj.KeywordVN;
                apiObj.KeywordEN = dbObj.KeywordEN;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.UrlEN = dbObj.UrlEN;
                apiObj.Type = dbObj.Type;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.IndexEN = dbObj.IndexEN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                return apiObj;
            }
            else { return null; }

        }
        /// <summary>
        /// Lấy hình ảnh thuộc loại và ô chứa nào
        /// </summary>
        /// <param name="pageComponent"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Image_BO> GetData(string pageComponent, string type)
        {
            IEnumerable<Image> dbObjs = CMSContext.Images.All(where: "PageComponent = @0 and Type = @1", parms: new object[] { pageComponent, type }, orderBy: "IndexVN ASC");
            List<Image_BO> ret = new List<Image_BO>();
            foreach (var dbObj in dbObjs)
            {
                Image_BO apiObj = new Image_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageUrlVN = dbObj.ImageUrlVN;
                apiObj.ImageUrlEN = dbObj.ImageUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.KeywordVN = dbObj.KeywordVN;
                apiObj.KeywordEN = dbObj.KeywordEN;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.UrlEN = dbObj.UrlEN;
                apiObj.Type = dbObj.Type;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.IndexEN = dbObj.IndexEN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                ret.Add(apiObj);
            }
            return ret;
        }
        /// <summary>
        /// Lấy toàn bộ hình ảnh
        /// </summary>
        /// <returns></returns>
        public List<Image_BO> GetData()
        {
            IEnumerable<Image> dbObjs = CMSContext.Images.All();
            List<Image_BO> ret = new List<Image_BO>();
            foreach (var dbObj in dbObjs)
            {
                Image_BO apiObj = new Image_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageUrlVN = dbObj.ImageUrlVN;
                apiObj.ImageUrlEN = dbObj.ImageUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.KeywordVN = dbObj.KeywordVN;
                apiObj.KeywordEN = dbObj.KeywordEN;
                apiObj.UrlVN = dbObj.UrlVN;
                apiObj.UrlEN = dbObj.UrlEN;
                apiObj.Type = dbObj.Type;
                apiObj.IndexVN = dbObj.IndexVN;
                apiObj.IndexEN = dbObj.IndexEN;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                ret.Add(apiObj);
            }
            return ret;
        }
        /// <summary>
        /// Tạo mới hình ảnh
        /// </summary>
        /// <param name="postedItem"></param>
        public void AddItem(Image_BO postedItem)
        {
            Image newDbObj = new Image();
            newDbObj.Id = postedItem.Id;
            newDbObj.TitleVN = postedItem.TitleVN;
            newDbObj.TitleEN = postedItem.TitleEN;
            newDbObj.ImageUrlVN = postedItem.ImageUrlVN;
            newDbObj.ImageUrlEN = postedItem.ImageUrlEN;
            newDbObj.DescriptionVN = postedItem.DescriptionVN;
            newDbObj.DescriptionEN = postedItem.DescriptionEN;
            newDbObj.KeywordVN = postedItem.KeywordVN;
            newDbObj.KeywordEN = postedItem.KeywordEN;
            newDbObj.UrlVN = postedItem.UrlVN;
            newDbObj.UrlEN = postedItem.UrlEN;
            newDbObj.Type = postedItem.Type;
            newDbObj.IndexVN = postedItem.IndexVN;
            newDbObj.IndexEN = postedItem.IndexEN;
            newDbObj.PageComponent = postedItem.PageComponent;
            newDbObj.IsActive = postedItem.IsActive;
            CMSContext.Images.Insert(newDbObj);
        }
        /// <summary>
        /// Cập nhật hình ảnh
        /// </summary>
        /// <param name="postedItem"></param>
        public void UpdateItem(Image_BO postedItem)
        {
            var dbObj = CMSContext.Images.Single(postedItem.Id);
            dbObj.Id = postedItem.Id;
            dbObj.TitleVN = postedItem.TitleVN;
            dbObj.TitleEN = postedItem.TitleEN;
            dbObj.ImageUrlVN = postedItem.ImageUrlVN;
            dbObj.ImageUrlEN = postedItem.ImageUrlEN;
            dbObj.DescriptionVN = postedItem.DescriptionVN;
            dbObj.DescriptionEN = postedItem.DescriptionEN;
            dbObj.KeywordVN = postedItem.KeywordVN;
            dbObj.KeywordEN = postedItem.KeywordEN;
            dbObj.UrlVN = postedItem.UrlVN;
            dbObj.UrlEN = postedItem.UrlEN;
            dbObj.Type = postedItem.Type;
            dbObj.IndexVN = postedItem.IndexVN;
            dbObj.IndexEN = postedItem.IndexEN;
            dbObj.PageComponent = postedItem.PageComponent;
            dbObj.IsActive = postedItem.IsActive;
            CMSContext.Images.Update(dbObj);
        }
        /// <summary>
        /// Xoá hình ảnh
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(int id)
        {
            var dbObj = CMSContext.Images.Single(id);
            CMSContext.Images.Delete(dbObj);
        }
        /// <summary>
        /// Xoá nhiều hình ảnh
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMultipleImages(IEnumerable<int> sliderId)
        {
            foreach (var id in sliderId)
            {
                var dbObj = CMSContext.Images.Single(id);
                CMSContext.Images.Delete(dbObj);
            }
        }
    }
}
