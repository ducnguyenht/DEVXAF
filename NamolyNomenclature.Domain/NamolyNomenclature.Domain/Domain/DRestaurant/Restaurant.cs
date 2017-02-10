using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamolyNomenclature.Domain
{
    public class Restaurant : BusinessEntity
    {
        public Restaurant()
        {
            this.IsRestaurant = true;
        }
        public ExPropsRestaurant ExPropsRestaurant_VN { get; set; }
        public ExPropsRestaurant ExPropsRestaurant_EN { get; set; }
        public ExPropsRestaurant ExPropsRestaurant_RU { get; set; }

        internal void ReadFromDB()
        {
            throw new NotImplementedException();
        }
    }
    public enum RestaurantPropertyCategory
    {
        NA = 0,
        /// <summary>
        /// Chính sách NH
        /// </summary>
        RestaurantPolicy = 300,
        /// <summary>
        /// Tiện nghi NH
        /// </summary>
        RestaurantConvenient = 400,
    }
    public enum RestaurantPropertyKeyName
    {
        NA = 0,
        CheckInPolicy = 1,
    }
}
