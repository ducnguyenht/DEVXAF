using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Youandweresort.com.Areas.Admin.Models
{
    public class GalleryModel
    {
        [Key]
        public int Id { get; set; }
        public GalleryItem Gallery_VN { get; set; }
        public GalleryItem Gallery_EN { get; set; }
        public List<GalleryImage> GalleryImage { get; set; }
    }
}