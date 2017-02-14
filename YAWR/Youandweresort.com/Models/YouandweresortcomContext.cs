using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Youandweresort.com.Models
{
    public class YouandweresortcomContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public YouandweresortcomContext()
            : base("name=YouandweresortcomContext")
        {
        }

        public System.Data.Entity.DbSet<Youandweresort.com.Areas.Admin.Models.LayoutModel> LayoutModels { get; set; }

        public System.Data.Entity.DbSet<Youandweresort.com.Areas.Admin.Models.GalleryModel> GalleryModels { get; set; }

        public System.Data.Entity.DbSet<Youandweresort.com.Areas.Admin.Models.GalleryImage> GalleryImages { get; set; }

    }
}
