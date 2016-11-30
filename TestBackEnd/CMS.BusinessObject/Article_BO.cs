using CMS.BusinessObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessObjects
{
    public class Article_BO : BusinessObject
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
    }
}
