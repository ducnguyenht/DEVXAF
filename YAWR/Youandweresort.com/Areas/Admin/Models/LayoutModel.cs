using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Youandweresort.com.Areas.Admin.Models
{
    public class LayoutModel
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Longtitude { get; set; }
        public string Lattitude { get; set; }
        public HeaderModel Header_VN { get; set; }
        public HeaderModel Header_EN { get; set; }

    }
}