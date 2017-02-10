using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamolyNomenclature.Domain
{
    public class ExPropsRestaurant : BusinessEntityProperty
    {
        public string _CancellationPolicy { get; set; }
        public BusinessEntityProperty CreateCancellationPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)RestaurantPropertyCategory.RestaurantPolicy;
            bep.PropertyKey = (int)RestaurantPropertyKeyName.CheckInPolicy;
            bep.PropertyValue = _CancellationPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }
    }
}
