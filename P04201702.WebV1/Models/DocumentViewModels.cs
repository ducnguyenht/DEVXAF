using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P04201702.WebV1.Models
{
    public class DocumentViewModels
    {
        public DocumentViewModels()
        {
            DocumentSeoViewModels documentSeo = new DocumentSeoViewModels();
            DocumentSeoViewModels = documentSeo;
        }
        public DocumentSeoViewModels DocumentSeoViewModels { get; set; }
        public IList<DocumentNavigationTreeViewModels> DocumentNavigationTreeViewModels { get; set; }
    }
}