using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamolyNomenclature.Domain
{
    public class ExPropsHotel : BusinessEntityProperty
    {
        public string _CancellationPolicy { get; set; }
        public string _CheckInPolicy { get; set; }
        public BusinessEntityProperty CreateCancellationPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.CancellationPolicy;
            bep.PropertyValue = _CancellationPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }
        public BusinessEntityProperty CreateCheckInPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.CheckInPolicy;
            bep.PropertyValue = _CheckInPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }
    }
}
