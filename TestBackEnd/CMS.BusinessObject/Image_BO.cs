using CMS.BusinessObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessObjects
{
    public class Image_BO : BusinessObject
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
    }
}
