using P04201702.Domain;
using P04201702.WebV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04201702.WebV1.DAL
{
    public class Documentations
    {
        public Documentations()
        {

        }

        #region Lấy bài viết theo id
        #region Lấy theo tất cả ngôn ngữ
        public Documentation_BO GetItem(int id)
        {
            var dbObj = P04201702Context.Documentations.Single(id);
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.TitlePageEN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.Level = dbObj.Level;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #region Lấy theo tiếng việt
        public Documentation_BO GetItemVN(int id)
        {
            var dbObj = P04201702Context.Documentations.Single(id);
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #region Lấy theo tiếng anh
        public Documentation_BO GetItemEN(int id)
        {
            var dbObj = P04201702Context.Documentations.Single(id);
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #endregion

        #region Lấy bài viết theo Routing
        #region Lấy theo tất cả ngôn ngữ
        public Documentation_BO GetItemRouting(string url)
        {
            var dbObj = P04201702Context.Documentations.Single(where: "RoutingVN = @0 or RoutingEN = @1", parms: new object[] { url, url });
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #region Lấy theo tiếng việt
        public Documentation_BO GetItemRoutingVN(string url)
        {
            var dbObj = P04201702Context.Documentations.Single(where: "RoutingVN = @0", parms: new object[] { url });
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #region Lấy theo tiếng anh
        public Documentation_BO GetItemRoutingEN(string url)
        {
            var dbObj = P04201702Context.Documentations.Single(where: "RoutingEN = @0", parms: new object[] { url });
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #endregion

        #region Lấy bài viết theo ô chứa
        #region Lấy theo tất cả ngôn ngữ
        public Documentation_BO GetItem(string pageComponent)
        {
            var dbObj = P04201702Context.Documentations.Single(where: "PageComponent = @0", parms: new object[] { pageComponent });
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #region Lấy theo tiếng việt
        public Documentation_BO GetItemVN(string pageComponent)
        {
            var dbObj = P04201702Context.Documentations.Single(where: "PageComponent = @0", parms: new object[] { pageComponent });
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #region Lấy theo tiếng anh
        public Documentation_BO GetItemEN(string pageComponent)
        {
            var dbObj = P04201702Context.Documentations.Single(where: "PageComponent = @0", parms: new object[] { pageComponent });
            if (dbObj != null)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                return apiObj;
            }
            else { return null; }
        }
        #endregion
        #endregion

        #region Lấy danh sách bài viết theo ô chứa
        #region Lấy theo tất cả ngôn ngữ
        public List<Documentation_BO> GetListItem(string pageComponent)
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "PageComponent = @0", parms: new object[] { pageComponent }, orderBy: "DisplayOrder ASC");
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.TitlePageEN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        public List<Documentation_BO> GetListItemParent(string pageComponent)
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "PageComponent = @0 and ParentId is null", parms: new object[] { pageComponent }, orderBy: "DisplayOrder ASC");
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.TitlePageEN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        #endregion
        #region Lấy theo tiếng việt
        public List<Documentation_BO> GetListItemVN(string pageComponent)
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "PageComponent = @0", parms: new object[] { pageComponent });
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        public List<Documentation_BO> GetListItemParentVN(string pageComponent)
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "PageComponent = @0 and ParentId is null", parms: new object[] { pageComponent }, orderBy: "DisplayOrder ASC");
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        #endregion
        #region Lấy theo tiếng anh
        public List<Documentation_BO> GetListItemEN(string pageComponent)
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "PageComponent = @0", parms: new object[] { pageComponent });
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        public List<Documentation_BO> GetListItemParentEN(string pageComponent)
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "PageComponent = @0 and ParentId is null", parms: new object[] { pageComponent }, orderBy: "DisplayOrder ASC");
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        #endregion
        #endregion

        #region Lấy danh sách bài viết theo ParentId
        #region Lấy theo tất cả ngôn ngữ
        public List<Documentation_BO> GetListParent()
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "ParentId is not null");
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.TitlePageEN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        #endregion
        #region Lấy theo tiếng việt
        public List<Documentation_BO> GetListParentVN()
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "ParentId <> @null");
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageVN = dbObj.TitlePageVN;
                apiObj.MetaDescriptionVN = dbObj.MetaDescriptionVN;
                apiObj.TitleVN = dbObj.TitleVN;
                apiObj.ImageAvatarUrlVN = dbObj.ImageAvatarUrlVN;
                apiObj.DescriptionVN = dbObj.DescriptionVN;
                apiObj.ContentVN = dbObj.ContentVN;
                apiObj.RoutingVN = dbObj.RoutingVN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        #endregion
        #region Lấy theo tiếng anh
        public List<Documentation_BO> GetListParentEN()
        {
            IEnumerable<Documentation> dbObjs = P04201702Context.Documentations.All(where: "ParentId <> @null");
            List<Documentation_BO> apiObjs = new List<Documentation_BO>();
            foreach (var dbObj in dbObjs)
            {
                Documentation_BO apiObj = new Documentation_BO();
                apiObj.Id = dbObj.Id;
                apiObj.TitlePageEN = dbObj.TitlePageEN;
                apiObj.MetaDescriptionEN = dbObj.MetaDescriptionEN;
                apiObj.TitleEN = dbObj.TitleEN;
                apiObj.ImageAvatarUrlEN = dbObj.ImageAvatarUrlEN;
                apiObj.DescriptionEN = dbObj.DescriptionEN;
                apiObj.ContentEN = dbObj.ContentEN;
                apiObj.RoutingEN = dbObj.RoutingEN;
                apiObj.DisplayOrder = dbObj.DisplayOrder;
                apiObj.PageComponent = dbObj.PageComponent;
                apiObj.IsActive = dbObj.IsActive;
                apiObj.Level = dbObj.Level;
                apiObj.IsLeaf = dbObj.IsLeaf;
                apiObj.ParentId = dbObj.ParentId;
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
        #endregion
        #endregion

        #region Thêm mới một bài viết
        public void AddItem(Documentation_BO postedItem)
        {
            Documentation newDbObj = new Documentation();
            newDbObj.Id = postedItem.Id;
            newDbObj.TitlePageVN = postedItem.TitlePageVN;
            newDbObj.TitlePageEN = postedItem.TitlePageEN;
            if (postedItem.TitleVN != null)
            {
                newDbObj.TitleVN = postedItem.TitleVN.Trim();
            }
            else
            {
                newDbObj.TitleVN = postedItem.TitleVN;
            }
            if (postedItem.TitleEN != null)
            {
                newDbObj.TitleEN = postedItem.TitleEN.Trim();
            }
            else
            {
                newDbObj.TitleEN = postedItem.TitleEN;
            }
            if (postedItem.ImageAvatarUrlVN != null)
            {
                newDbObj.ImageAvatarUrlVN = postedItem.ImageAvatarUrlVN.Trim();
            }
            else
            {
                newDbObj.ImageAvatarUrlVN = postedItem.ImageAvatarUrlVN;
            }
            if (postedItem.ImageAvatarUrlEN != null)
            {
                newDbObj.ImageAvatarUrlEN = postedItem.ImageAvatarUrlEN.Trim();
            }
            else
            {
                newDbObj.ImageAvatarUrlEN = postedItem.ImageAvatarUrlEN;
            }
            if (postedItem.DescriptionVN != null)
            {
                newDbObj.DescriptionVN = postedItem.DescriptionVN.Trim();
            }
            else
            {
                newDbObj.DescriptionVN = postedItem.DescriptionVN;
            }
            if (postedItem.DescriptionEN != null)
            {
                newDbObj.DescriptionEN = postedItem.DescriptionEN.Trim();
            }
            else
            {
                newDbObj.DescriptionEN = postedItem.DescriptionEN;
            }
            newDbObj.ContentVN = postedItem.ContentVN;
            newDbObj.ContentEN = postedItem.ContentEN;

            if (postedItem.MetaDescriptionVN != null)
            {
                newDbObj.MetaDescriptionVN = postedItem.MetaDescriptionVN.Trim();
            }
            else
            {
                newDbObj.MetaDescriptionVN = postedItem.MetaDescriptionVN;
            }
            if (postedItem.MetaDescriptionEN != null)
            {
                newDbObj.MetaDescriptionEN = postedItem.MetaDescriptionEN.Trim();
            }
            else
            {
                newDbObj.MetaDescriptionEN = postedItem.MetaDescriptionEN;
            }

            if (postedItem.RoutingVN != null)
            {
                newDbObj.RoutingVN = postedItem.RoutingVN.Trim();
            }
            else
            {
                newDbObj.RoutingVN = postedItem.RoutingVN;
            }
            if (postedItem.RoutingEN != null)
            {
                newDbObj.RoutingEN = postedItem.RoutingEN.Trim();
            }
            else
            {
                newDbObj.RoutingEN = postedItem.RoutingEN;
            }
            newDbObj.Category = postedItem.Category;
            newDbObj.PageComponent = postedItem.PageComponent;
            newDbObj.DisplayOrder = postedItem.DisplayOrder;
            newDbObj.IsActive = postedItem.IsActive;
            newDbObj.ParentId = postedItem.ParentId;
            newDbObj.IsLeaf = postedItem.IsLeaf;
            newDbObj.Level = postedItem.Level;
            P04201702Context.Documentations.Insert(newDbObj);
        }
        #endregion

        #region Cập nhật bài viết
        #region Cập nhập một bài viết
        public void UpdateItem(Documentation_BO postedItem)
        {
            var dbObj = P04201702Context.Documentations.Single(postedItem.Id);
            dbObj.Id = postedItem.Id;
            dbObj.TitlePageVN = postedItem.TitlePageVN;
            dbObj.TitlePageEN = postedItem.TitlePageEN;
            if (postedItem.TitleVN != null)
            {
                dbObj.TitleVN = postedItem.TitleVN.Trim();
            }
            else
            {
                dbObj.TitleVN = postedItem.TitleVN;
            }
            if (postedItem.TitleEN != null)
            {
                dbObj.TitleEN = postedItem.TitleEN.Trim();
            }
            else
            {
                dbObj.TitleEN = postedItem.TitleEN;
            }
            if (postedItem.ImageAvatarUrlVN != null)
            {
                dbObj.ImageAvatarUrlVN = postedItem.ImageAvatarUrlVN.Trim();
            }
            else
            {
                dbObj.ImageAvatarUrlVN = postedItem.ImageAvatarUrlVN;
            }
            if (postedItem.ImageAvatarUrlEN != null)
            {
                dbObj.ImageAvatarUrlEN = postedItem.ImageAvatarUrlEN.Trim();
            }
            else
            {
                dbObj.ImageAvatarUrlEN = postedItem.ImageAvatarUrlEN;
            }
            if (postedItem.DescriptionVN != null)
            {
                dbObj.DescriptionVN = postedItem.DescriptionVN.Trim();
            }
            else
            {
                dbObj.DescriptionVN = postedItem.DescriptionVN;
            }
            if (postedItem.DescriptionEN != null)
            {
                dbObj.DescriptionEN = postedItem.DescriptionEN.Trim();
            }
            else
            {
                dbObj.DescriptionEN = postedItem.DescriptionEN;
            }
            dbObj.ContentVN = postedItem.ContentVN;
            dbObj.ContentEN = postedItem.ContentEN;


            if (postedItem.MetaDescriptionVN != null)
            {
                dbObj.MetaDescriptionVN = postedItem.MetaDescriptionVN.Trim();
            }
            else
            {
                dbObj.MetaDescriptionVN = postedItem.MetaDescriptionVN;
            }
            if (postedItem.MetaDescriptionEN != null)
            {
                dbObj.MetaDescriptionEN = postedItem.MetaDescriptionEN.Trim();
            }
            else
            {
                dbObj.MetaDescriptionEN = postedItem.MetaDescriptionEN;
            }

            if (postedItem.RoutingVN != null)
            {
                dbObj.RoutingVN = postedItem.RoutingVN.Trim();
            }
            else
            {
                dbObj.RoutingVN = postedItem.RoutingVN;
            }
            if (postedItem.RoutingEN != null)
            {
                dbObj.RoutingEN = postedItem.RoutingEN.Trim();
            }
            else
            {
                dbObj.RoutingEN = postedItem.RoutingEN;
            }
            // dbObj.PageComponent = postedItem.PageComponent;
            dbObj.DisplayOrder = postedItem.DisplayOrder;
            dbObj.IsActive = postedItem.IsActive;
            //dbObj.ParentId = postedItem.ParentId;
            //dbObj.IsLeaf = postedItem.IsLeaf;
            //dbObj.Level = postedItem.Level;
            P04201702Context.Documentations.Update(dbObj);
        }
        #endregion

        #endregion

        #region Xoá bài viết

        #region Xoá một bài viết
        public void DeleteItem(int id)
        {
            var dbObj = P04201702Context.Documentations.Single(id);
            P04201702Context.Documentations.Delete(dbObj);
        }
        #endregion
        #region Xoá nhiều bài viết
        public void DeleteItem(IEnumerable<int> id)
        {
            foreach (var i in id)
            {
                var dbObj = P04201702Context.Documentations.Single(i);
                P04201702Context.Documentations.Delete(dbObj);
            }

        }
        #endregion
        #endregion
    }
}
