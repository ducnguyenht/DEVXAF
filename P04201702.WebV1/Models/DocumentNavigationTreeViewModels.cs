using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P04201702.WebV1.Models
{
    public class DocumentNavigationTreeViewModels
    {
        public DocumentNavigationTreeViewModels()
        {
            Childs = new List<DocumentNavigationTreeViewModels>();
        }
        public int? Id { get; set; }
        public string TitlePageVN { get; set; }
        public string TitlePageEN { get; set; }
        public string MetaDescriptionVN { get; set; }
        public string MetaDescriptionEN { get; set; }
        public string TitleVN { get; set; }
        public string TitleEN { get; set; }
        public string ImageAvatarUrlVN { get; set; }
        public string ImageAvatarUrlEN { get; set; }
        public string DescriptionVN { get; set; }
        public string DescriptionEN { get; set; }
        public string ContentVN { get; set; }
        public string ContentEN { get; set; }
        public string RoutingVN { get; set; }
        public string RoutingEN { get; set; }
        public string Category { get; set; }
        public int? DisplayOrder { get; set; }
        public string PageComponent { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public bool IsLeaf { get; set; }
        public string IsNull { get; set; }
        public List<DocumentNavigationTreeViewModels> Childs { get; set; }
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
            ret.ImageAvatarUrlVN = ImageAvatarUrlVN;
            ret.ImageAvatarUrlEN = ImageAvatarUrlEN;
            ret.DescriptionVN = DescriptionVN;
            ret.DescriptionEN = DescriptionEN;
            ret.ContentVN = ContentVN;
            ret.ContentEN = ContentEN;
            ret.RoutingVN = RoutingVN;
            ret.RoutingEN = RoutingEN;
            ret.Category = Category;
            ret.DisplayOrder = DisplayOrder;
            ret.PageComponent = PageComponent;
            ret.IsActive = IsActive;
            ret.ParentId = ParentId;
            ret.Level = Level;
            ret.IsLeaf = IsLeaf;
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
                this.ImageAvatarUrlVN = bo.ImageAvatarUrlVN;
                this.ImageAvatarUrlEN = bo.ImageAvatarUrlEN;
                this.DescriptionVN = bo.DescriptionVN;
                this.DescriptionEN = bo.DescriptionEN;
                this.ContentVN = bo.ContentVN;
                this.ContentEN = bo.ContentEN;
                this.RoutingVN = bo.RoutingVN;
                this.RoutingEN = bo.RoutingEN;
                this.Category = bo.Category;
                this.DisplayOrder = bo.DisplayOrder;
                this.PageComponent = bo.PageComponent;
                this.IsActive = bo.IsActive;
                this.ParentId = bo.ParentId;
                this.Level = bo.Level;
                this.IsLeaf = bo.IsLeaf;
            }
        }

        public static DocumentNavigationTreeViewModels MapFromBOStatic(Documentation_BO bo)
        {
            if (bo == null) { return null; }
            else
            {
                DocumentNavigationTreeViewModels ret = new DocumentNavigationTreeViewModels();
                ret.Id = bo.Id;
                ret.TitlePageVN = bo.TitlePageVN;
                ret.TitlePageEN = bo.TitlePageEN;
                ret.MetaDescriptionVN = bo.MetaDescriptionVN;
                ret.MetaDescriptionEN = bo.MetaDescriptionEN;
                ret.TitleVN = bo.TitleVN;
                ret.TitleEN = bo.TitleEN;
                ret.ImageAvatarUrlVN = bo.ImageAvatarUrlVN;
                ret.ImageAvatarUrlEN = bo.ImageAvatarUrlEN;
                ret.DescriptionVN = bo.DescriptionVN;
                ret.DescriptionEN = bo.DescriptionEN;
                ret.ContentVN = bo.ContentVN;
                ret.ContentEN = bo.ContentEN;
                ret.RoutingVN = bo.RoutingVN;
                ret.RoutingEN = bo.RoutingEN;
                ret.Category = bo.Category;
                ret.DisplayOrder = bo.DisplayOrder;
                ret.PageComponent = bo.PageComponent;
                ret.IsActive = bo.IsActive;
                ret.ParentId = bo.ParentId;
                ret.Level = bo.Level;
                ret.IsLeaf = bo.IsLeaf;
                return ret;
            }
        }

        public static IList<DocumentNavigationTreeViewModels> MapFromBOs(IList<Documentation_BO> bos)
        {
            IList<DocumentNavigationTreeViewModels> apiObjs = new List<DocumentNavigationTreeViewModels>();
            foreach (var bo in bos)
            {
                DocumentNavigationTreeViewModels apiObj = new DocumentNavigationTreeViewModels();
                apiObj.MapFromBO(bo);
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
    }
    public class GetParentAndLevel
    {
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public string Routing { get; set; }
    }
}