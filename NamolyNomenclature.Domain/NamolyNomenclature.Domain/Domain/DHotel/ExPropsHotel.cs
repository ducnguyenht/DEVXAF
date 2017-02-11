using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamolyNomenclature.Domain
{
    public class ExPropsHotel //: BusinessEntityProperty
    {
        public string CancellationPolicy { get; set; }
        public BusinessEntityProperty CreateCancellationPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.CancellationPolicy;
            bep.PropertyValue = CancellationPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }

        public string CheckInPolicy { get; set; }
        public BusinessEntityProperty CreateCheckInPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.CheckInPolicy;
            bep.PropertyValue = CheckInPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }

        public string CheckOutPolicy { get; set; }
        public BusinessEntityProperty CreateCheckOutPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.CheckOutPolicy;
            bep.PropertyValue = CheckOutPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }

        public string ChildAndExtraBedRoomPolicy { get; set; }
        public BusinessEntityProperty CreateChildAndExtraBedRoomPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.ChildAndExtraBedRoomPolicy;
            bep.PropertyValue = ChildAndExtraBedRoomPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }

        public string ReservationPolicy { get; set; }
        public BusinessEntityProperty CreateReservationPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.ReservationPolicy;
            bep.PropertyValue = ReservationPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }
    }
}
