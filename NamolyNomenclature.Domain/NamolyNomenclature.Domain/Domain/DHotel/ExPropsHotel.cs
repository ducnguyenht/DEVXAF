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

        public string _CheckInPolicy { get; set; }
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

        public string _CheckOutPolicy { get; set; }
        public BusinessEntityProperty CreateCheckOutPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.CheckOutPolicy;
            bep.PropertyValue = _CheckOutPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }

        public string _ChildAndExtraBedRoomPolicy { get; set; }
        public BusinessEntityProperty CreateChildAndExtraBedRoomPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.ChildAndExtraBedRoomPolicy;
            bep.PropertyValue = _ChildAndExtraBedRoomPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }

        public string _ReservationPolicy { get; set; }
        public BusinessEntityProperty CreateReservationPolicy(string language, int? businessEntityId)
        {
            var bep = new BusinessEntityProperty();
            bep.Category = (int)HotelPropertyCategory.HotelPolicy;
            bep.PropertyKey = (int)HotelPropertyKeyName.ReservationPolicy;
            bep.PropertyValue = _ReservationPolicy;
            bep.Language = language;
            bep.BusinessEntityId = businessEntityId;
            return bep;
        }
    }
}
