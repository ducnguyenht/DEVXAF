using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace NamolyNomenclature.Domain
{
    public class Hotel : BusinessEntity
    {
        public Hotel()
        {
            this.IsHotel = true;
            ExPropsHotel_VN = new ExPropsHotel();
            ExPropsHotel_EN = new ExPropsHotel();
        }

        //#region 1.HotelPolicy
        //public string CancellationPolicy { get; set; }
        //public string CheckInPolicy { get; set; }
        //public string CheckOutPolicy { get; set; }
        //public string ChildAndExtraBedRoomPolicy { get; set; }
        //public string ReservationPolicy { get; set; }
        //#endregion 1.HotelPolicy

        #region 1.FOService
        public bool IsAlarmServiceFO { get; set; }
        public bool IsExchangeCurrencyFO { get; set; }
        public bool IsFrontdesk24HrFO { get; set; }
        public bool IsLiftsFO { get; set; }
        public bool IsSpecialHelpServiceFO { get; set; }
        public bool IsTicketingServiceFO { get; set; }
        public bool IsTourDeskFO { get; set; }
        #endregion 1.FOService

        #region 2.RoomService
        public bool IsAirConditioningRS { get; set; }
        public bool IsCableTelevisionRS { get; set; }
        public bool IsFanRS { get; set; }
        public bool IsFreewaterRS { get; set; }
        public bool IsHairdryerRS { get; set; }
        public bool IsIronRS { get; set; }
        public bool IsNonSmokingRoomRS { get; set; }
        public bool IsSafeRS { get; set; }
        public bool IsShoeShineToolRS { get; set; }
        public bool IsSlippersRS { get; set; }
        public bool IsSmokingRoomRS { get; set; }
        public bool IsTeaCoffeeRS { get; set; }
        public bool IsTelephoneRS { get; set; }
        public bool IsTelevisionRS { get; set; }
        public bool IsToiletAndBathroomRS { get; set; }
        public bool IsTowelRS { get; set; }
        #endregion 2.RoomService

        #region 3.FoodAndDrink
        public bool IsBarLoungeFAD { get; set; }
        public bool IsBBQFacilitiesFAD { get; set; }
        public bool IsBreakfastFAD { get; set; }
        public bool IsMinibarFAD { get; set; }
        public bool IsRestaurantFAD { get; set; }
        #endregion 3.FoodAndDrink

        #region 4.Business
        public bool IsBusinessCenterB { get; set; }
        public bool IsConferenceFacilitiesRoomB { get; set; }
        public bool IsPhotocopyB { get; set; }
        #endregion 4.Business

        #region 5.Laundry
        public bool IsDryCleaningFacilitiesL { get; set; }
        public bool IsLaundryServiceL { get; set; }
        #endregion 5.Laundry
        #region 6.SportHealthCare
        public bool IsGolfCourtSHC { get; set; }
        public bool IsGymFitnessCenterSHC { get; set; }
        public bool IsPoolSHC { get; set; }
        public bool IsSpaSaunaSHC { get; set; }
        public bool IsTennisCourtSHC { get; set; }
        #endregion 6.SportHealthCare
        #region 7.Internet
        public bool IsWifiAtFOI { get; set; }
        public bool IsWifiAtRoomI { get; set; }
        #endregion 7.Internet
        #region 8.ParkingVehicles
        public bool IsCarParkingPV { get; set; }
        public bool IsCarRentalPV { get; set; }
        public bool IsFreeParkingPV { get; set; }
        public bool IsParkingPV { get; set; }
        public bool IsPickOffDropOffPV { get; set; }
        #endregion 8.ParkingVehicles
        public ExPropsHotel ExPropsHotel_VN { get; set; }
        public ExPropsHotel ExPropsHotel_EN { get; set; }

        public void CreateOrUpdateToDB()
        {
            if (this.Id == null)
            {
                using (var uow = new NamolyNomenclatureUnitOfWork())
                {
                    uow.Insert(this as BusinessEntity);

                    uow.Insert(ExPropsHotel_VN.CreateCancellationPolicy(Languages.VN, this.Id));
                    uow.Insert(ExPropsHotel_VN.CreateCheckInPolicy(Languages.VN, this.Id));
                    uow.Insert(ExPropsHotel_VN.CreateCheckOutPolicy(Languages.VN, this.Id));
                    uow.Insert(ExPropsHotel_VN.CreateChildAndExtraBedRoomPolicy(Languages.VN, this.Id));
                    uow.Insert(ExPropsHotel_VN.CreateReservationPolicy(Languages.VN, this.Id));

                    uow.Insert(ExPropsHotel_EN.CreateCancellationPolicy(Languages.EN, this.Id));
                    uow.Insert(ExPropsHotel_EN.CreateCheckInPolicy(Languages.EN, this.Id));
                    uow.Insert(ExPropsHotel_EN.CreateCheckOutPolicy(Languages.EN, this.Id));
                    uow.Insert(ExPropsHotel_EN.CreateChildAndExtraBedRoomPolicy(Languages.EN, this.Id));
                    uow.Insert(ExPropsHotel_EN.CreateReservationPolicy(Languages.EN, this.Id));

                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.AlarmService, this.IsAlarmServiceFO.ToString()));
                }
            }
            else
            {
                var CancellationPolicy_EN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CancellationPolicy, Languages.EN);
                CancellationPolicy_EN.PropertyValue = this.ExPropsHotel_EN._CancellationPolicy;
                var CheckInPolicy_EN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckInPolicy, Languages.EN);
                CheckInPolicy_EN.PropertyValue = this.ExPropsHotel_EN._CheckInPolicy;
                var CheckOutPolicy_EN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckOutPolicy, Languages.EN);
                CheckOutPolicy_EN.PropertyValue = this.ExPropsHotel_EN._CheckOutPolicy;
                var ChildAndExtraBedRoomPolicy_EN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ChildAndExtraBedRoomPolicy, Languages.EN);
                ChildAndExtraBedRoomPolicy_EN.PropertyValue = this.ExPropsHotel_EN._ChildAndExtraBedRoomPolicy;
                var ReservationPolicy_EN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ReservationPolicy, Languages.EN);
                ReservationPolicy_EN.PropertyValue = this.ExPropsHotel_EN._ReservationPolicy;

                var CancellationPolicy_VN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CancellationPolicy, Languages.VN);
                CancellationPolicy_VN.PropertyValue = this.ExPropsHotel_VN._CancellationPolicy;
                var CheckInPolicy_VN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckInPolicy, Languages.VN);
                CheckInPolicy_VN.PropertyValue = this.ExPropsHotel_VN._CheckInPolicy;
                var CheckOutPolicy_VN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckOutPolicy, Languages.VN);
                CheckOutPolicy_VN.PropertyValue = this.ExPropsHotel_VN._CheckOutPolicy;
                var ChildAndExtraBedRoomPolicy_VN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ChildAndExtraBedRoomPolicy, Languages.VN);
                ChildAndExtraBedRoomPolicy_VN.PropertyValue = this.ExPropsHotel_VN._ChildAndExtraBedRoomPolicy;
                var ReservationPolicy_VN = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ReservationPolicy, Languages.VN);
                ReservationPolicy_VN.PropertyValue = this.ExPropsHotel_VN._ReservationPolicy;

                var AlarmService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.AlarmService);
                AlarmService.PropertyValue = this.IsAlarmServiceFO.ToString();

                using (var uow = new NamolyNomenclatureUnitOfWork())
                {
                    uow.Update(this as BusinessEntity);
                    uow.Update(CancellationPolicy_EN);
                    uow.Update(CheckInPolicy_EN);
                    uow.Update(CancellationPolicy_VN);
                    uow.Update(CheckInPolicy_VN);
                    uow.Update(AlarmService);
                }
            }
        }

        private BusinessEntityProperty CreateExPropNonLang(HotelPropertyKeyName hotelPropertyKeyName, string PropertyValue)
        {
            var exPropNonLang = new BusinessEntityProperty();
            exPropNonLang.Category = (int)HotelPropertyCategory.HotelConvenient;
            exPropNonLang.PropertyKey = (int)hotelPropertyKeyName;
            exPropNonLang.PropertyValue = PropertyValue;
            exPropNonLang.Language = Languages.VN;
            exPropNonLang.BusinessEntityId = this.Id;
            return exPropNonLang;
        }

        public void ReadFromDB()
        {
            this.ExPropsHotel_VN._CancellationPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CancellationPolicy, Languages.VN).PropertyValue;
            this.ExPropsHotel_VN._CheckInPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckInPolicy, Languages.VN).PropertyValue;

            this.ExPropsHotel_EN._CancellationPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CancellationPolicy, Languages.EN).PropertyValue;
            this.ExPropsHotel_EN._CheckInPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckInPolicy, Languages.EN).PropertyValue;

            var AlarmServiceFO_FDB = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.AlarmService);
            if (AlarmServiceFO_FDB != null)
            {
                this.IsAlarmServiceFO = AlarmServiceFO_FDB.PropertyValue.ToBool();
            }
        }

        private BusinessEntityProperty ReadBusinessEntityDB(int? hotel_Id, HotelPropertyKeyName hotelPropertyKeyName, string language = Languages.VN)
        {
            return NamolyNomenclatureContext.BusinessEntityProperties.Single(
                    where: "BusinessEntityId=@0 and PropertyKey=@1 and Language=@2",
                    parms: new object[] { hotel_Id, hotelPropertyKeyName, language });
        }

        private Hotel FindHotelByName(string Name, string language = null)
        {
            var prop = NamolyNomenclatureContext.Hotels.Single(
                where: "Name=@0",
                    parms: new object[] { Name });
            return prop != null ? prop : null;
        }
    }

    public enum HotelPropertyCategory
    {
        NA = 0,
        /// <summary>
        /// Chính sách
        /// </summary>
        HotelPolicy = 100,
        /// <summary>
        /// Tiện nghi
        /// </summary>
        HotelConvenient = 200
    }
    public enum HotelPropertyKeyName
    {
        NA = 0,
        #region 1.Policy 0-100 ------------
        /// <summary>
        /// Chính sách hủy phòng
        /// </summary>
        CancellationPolicy = 1,//x
        /// <summary>
        /// Chính sách nhận phòng 
        /// </summary>
        CheckInPolicy = 2,//x
        /// <summary>
        /// Chính sách trả phòng
        /// </summary>
        CheckOutPolicy = 3,//x
        /// <summary>
        /// Chính sách trẻ em và giường thêm phòng
        /// </summary>
        ChildAndExtraBedRoomPolicy = 4,//x
        /// <summary>
        /// Chính sách đặt phòng  
        /// </summary>
        ReservationPolicy = 5,//x
        #endregion Policy 0-100-------------

        #region 2.Convenient(Tien nghi) 101-300----------------------------------------

        #region 1.FO Service-------------
        /// <summary>
        /// Dịch vụ báo thức
        /// </summary>
        AlarmService = 101,//x  
        /// <summary>
        /// The exchange currency(Thu đổi ngoại tệ)
        /// </summary>
        ExchangeCurrency = 102,//x
        /// <summary>
        /// Lễ tân 24h
        /// </summary>
        Frontdesk24Hr = 103,//x
        /// <summary>
        /// The lifts (Thang máy)
        /// </summary>
        Lifts = 104,
        /// <summary>
        /// The special help service(dịch vụ trợ giúp đặc biệt)
        /// </summary>
        SpecialHelpService = 105,
        /// <summary>
        /// The ticketing service (dịch vụ bán vé)
        /// </summary>
        TicketingService = 106,
        /// <summary>
        /// The tour desk (Bàn bán Tour)
        /// </summary>
        TourDesk = 107,
        #endregion FO Service-------------

        #region 2.Room Service(Dịch vụ phòng)--------------------------
        /// <summary>
        /// The air conditioning (máy lạnh)
        /// </summary>
        AirConditioning = 150,
        /// <summary>
        /// The cable television (truyền hình cáp)
        /// </summary>
        CableTelevision = 151,
        /// <summary>
        /// The fan (quạt máy)
        /// </summary>
        Fan = 152,
        /// <summary>
        /// Nước đóng chai miến phí
        /// </summary>
        Freewater = 153,//x
        /// <summary>
        /// The hairdryer(máy sấy tóc)
        /// </summary>
        Hairdryer = 154,
        /// <summary>
        /// The iron (bàn ủi)
        /// </summary>
        Iron = 155,
        /// <summary>
        /// The non smoking room (phòng không hút thuốc)
        /// </summary>
        NonSmokingRoom = 156,
        /// <summary>
        /// The safe(kết sắt)
        /// </summary>
        Safe = 157,
        /// <summary>
        /// The shoe shine tool (dụng cụ đánh giày)
        /// </summary>
        ShoeShineTool = 158,
        /// <summary>
        /// The slippers (dép đi trong phòng)
        /// </summary>
        Slippers = 159,
        /// <summary>
        /// The smoking room (Phòng hút thuốc)
        /// </summary>
        SmokingRoom = 160,
        /// <summary>
        /// The tea coffee (trà/cà phê pha sẵn)
        /// </summary>
        TeaCoffee = 161,
        /// <summary>
        /// The telephone (điện thoại)
        /// </summary>
        Telephone = 162,
        /// <summary>
        /// The television (Tivi)
        /// </summary>
        Television = 163,
        /// <summary>
        /// The toilet and bathroom (nhà vệ sinh và phòng tắm riêng)
        /// </summary>
        ToiletAndBathroom = 164,
        /// <summary>
        /// The towel(khăn tắm)
        /// </summary>
        Towel = 165,
        #endregion Room Service(Dịch vụ phòng)--------------------------

        #region 3.Food And Drink (Thức ăn và đồ uống)-----------------
        /// <summary>
        /// The bar lounge (Bar)
        /// </summary>
        BarLounge = 190,
        /// <summary>
        /// The BBQ facilities(dụng cụ nướng thịt)
        /// </summary>
        BBQFacilities = 191,
        /// <summary>
        /// The breakfast(bữa sáng)
        /// </summary>
        Breakfast = 192,
        /// <summary>
        /// The minibar(tủ lạnh)
        /// </summary>
        Minibar = 193,
        /// <summary>
        /// The restaurant (Nhà hàng)
        /// </summary>
        Restaurant = 194,//x
        #endregion Food And Drink (Thức ăn và đồ uống)-----------------

        #region 4.Business (dịch vụ doanh nhân)--------
        /// <summary>
        /// The business center(trung tâm thương mại)
        /// </summary>
        BusinessCenter = 210,//x
        /// <summary>
        /// The conference facilities room(thiết bị/phòng họp)
        /// </summary>
        ConferenceFacilitiesRoom = 211,
        /// <summary>
        /// The photocopy(copy)
        /// </summary>
        Photocopy = 212,
        #endregion Business (dịch vụ doanh nhân)-------

        #region 5.Laundry (dịch vụ giặt ủi)-----------
        /// <summary>
        /// (Thiết bị giặt ủi)
        /// </summary>
        DryCleaningFacilities = 230,//x
        /// <summary>
        ///  (dịch vụ giặt ủi tại khách sạn)
        /// </summary>
        LaundryService = 231,
        #endregion Laundry (dịch vụ giặt ủi)----------

        #region 6.Sport/health care (thể thao giải trí/chăm sóc sức khỏe)------
        /// <summary>
        /// The golf court(sân golf)
        /// </summary>
        GolfCourt = 240,
        /// <summary>
        /// The gym(phòng tập thể hình/thể dục)
        /// </summary>
        GymFitnessCenter = 241,
        /// <summary>
        /// The pool(bể bơi)
        /// </summary>
        Pool = 242,//x
        /// <summary>
        /// The spa sauna(thư giãn làm đẹp/xông hơi)
        /// </summary>
        SpaSauna = 243,
        /// <summary>
        /// The tennis court(sân tennis)
        /// </summary>
        TennisCourt = 244,
        #endregion Sport/health care (thể thao giải trí/chăm sóc sức khỏe)------

        #region 7.Internet ----------------------------
        /// <summary>
        /// The wifi at fo (wifi tại tiền sảnh)
        /// </summary>
        WifiAtFO = 261,
        /// <summary>
        /// The wifi at room (wifi tại phòng)
        /// </summary>
        WifiAtRoom = 260,//x
        #endregion Internet ---------------------------

        #region 8.Parking/ vehicles (bãi đỗ xe/cho thuê xe)-----

        /// <summary>
        /// The car parking (fees may apply) (bãi đỗ xe (có thể áp dụng phí)
        /// </summary>
        CarParking = 280,
        /// <summary>
        /// The car rental(cho thuê xe)
        /// </summary>
        CarRental = 281,
        /// <summary>
        /// The free parking (đỗ xe miễn phí)
        /// </summary>
        FreeParking = 282,//x
        /// <summary>
        /// The parking(bãi đỗ xe thu phí)
        /// </summary>
        Parking = 283,
        /// <summary>
        /// The pick off drop off(dịch vụ đưa đón)
        /// </summary>
        PickOffDropOff = 284,
        #endregion Parking/ vehicles (bãi đỗ xe/cho thuê xe)-----
        #endregion Convenient(Tien nghi) 101-300 ---------------------------------------------
    }
}


//if (this.Id==null)
//{
//    NamolyNomenclatureContext.BusinessEntities.Single(Id);
//}
//var hotel = FindHotelByName(this.Name);