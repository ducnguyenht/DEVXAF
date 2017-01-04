using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P04201702.WebV1.Models
{
    public class Documentation_BO
    {
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
        public string PageComponent { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int? Level { get; set; }
        public int? ParentId { get; set; }
        public bool IsLeaf { get; set; }
    }
}