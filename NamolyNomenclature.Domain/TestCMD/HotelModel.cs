using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCMD
{
    public class HotelModel
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string TaxCode { get; set; }
        public decimal? Longtitude { get; set; }
        public decimal? Latitude { get; set; }
        public string MapMarkerURL { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string CancellationPolicy_VN { get; set; }
        public string CheckInPolicy_VN { get; set; }
        public string CheckOutPolicy_VN { get; set; }
        public string ChildAndExtraBedRoomPolicy_VN { get; set; }
        public string ReservationPolicy_VN { get; set; }

        public string CancellationPolicy_EN { get; set; }
        public string CheckInPolicy_EN { get; set; }
        public string CheckOutPolicy_EN { get; set; }
        public string ChildAndExtraBedRoomPolicy_EN { get; set; }
        public string ReservationPolicy_EN { get; set; }


        #region 1.FOService
        public bool IsAlarmService { get; set; }
        public bool IsExchangeCurrency { get; set; }
        public bool IsFrontdesk24Hr { get; set; }
        public bool IsLifts { get; set; }
        public bool IsSpecialHelpService { get; set; }
        public bool IsTicketingService { get; set; }
        public bool IsTourDesk { get; set; }
        #endregion 1.FOService

        #region 2.RoomService
        public bool IsAirConditioning { get; set; }
        public bool IsCableTelevision { get; set; }
        public bool IsFan { get; set; }
        public bool IsFreewater { get; set; }
        public bool IsHairdryer { get; set; }
        public bool IsIron { get; set; }
        public bool IsNonSmokingRoom { get; set; }
        public bool IsSafe { get; set; }
        public bool IsShoeShineTool { get; set; }
        public bool IsSlippers { get; set; }
        public bool IsSmokingRoom { get; set; }
        public bool IsTeaCoffee { get; set; }
        public bool IsTelephone { get; set; }
        public bool IsTelevision { get; set; }
        public bool IsToiletAndBathroom { get; set; }
        public bool IsTowel { get; set; }
        #endregion 2.RoomService

        #region 3.FoodAndDrink
        public bool IsBarLounge { get; set; }
        public bool IsBBQFacilities { get; set; }
        public bool IsBreakfast { get; set; }
        public bool IsMinibar { get; set; }
        public bool IsRestaurant { get; set; }
        #endregion 3.FoodAndDrink

        #region 4.Business
        public bool IsBusinessCenter { get; set; }
        public bool IsConferenceFacilitiesRoom { get; set; }
        public bool IsPhotocopy { get; set; }
        #endregion 4.Business

        #region 5.Laundry
        public bool IsDryCleaningFacilities { get; set; }
        public bool IsLaundryService { get; set; }
        #endregion 5.Laundry
        #region 6.SportHealthCare
        public bool IsGolfCourt { get; set; }
        public bool IsGymFitnessCenter { get; set; }
        public bool IsPool { get; set; }
        public bool IsSpaSauna { get; set; }
        public bool IsTennisCourt { get; set; }
        #endregion 6.SportHealthCare
        #region 7.Internet
        public bool IsWifiAtFO { get; set; }
        public bool IsWifiAtRoom { get; set; }
        #endregion 7.Internet
        #region 8.ParkingVehicles
        public bool IsCarParking { get; set; }
        public bool IsCarRental { get; set; }
        public bool IsFreeParking { get; set; }
        public bool IsParking { get; set; }
        public bool IsPickOffDropOff { get; set; }
        #endregion 8.ParkingVehicles
    }
}
