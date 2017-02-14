using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Youandweresort.com.Areas.Admin.Models
{
    public class GalleryImage
    {
        [Key]
        public int Id { get; set; }
        public int GalleryModel_Id { get; set; }
        public string ImageUrl { get; set; }
        public FAR Type { get; set; }
    }
    public enum FAR
    {
        FOOD = 0,
        WATER = 1
    }
}