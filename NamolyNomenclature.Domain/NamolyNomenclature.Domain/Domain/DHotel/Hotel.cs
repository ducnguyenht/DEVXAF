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
        public new bool IsRestaurant { get; set; }
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


                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.AlarmService, this.IsAlarmService.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.ExchangeCurrency, this.IsExchangeCurrency.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Frontdesk24Hr, this.IsFrontdesk24Hr.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Lifts, this.IsLifts.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.SpecialHelpService, this.IsSpecialHelpService.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.TicketingService, this.IsTicketingService.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.TourDesk, this.IsTourDesk.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.AirConditioning, this.IsAirConditioning.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.CableTelevision, this.IsCableTelevision.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Fan, this.IsFan.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Freewater, this.IsFreewater.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Hairdryer, this.IsHairdryer.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Iron, this.IsIron.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.NonSmokingRoom, this.IsNonSmokingRoom.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Safe, this.IsSafe.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.ShoeShineTool, this.IsShoeShineTool.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Slippers, this.IsSlippers.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.SmokingRoom, this.IsSmokingRoom.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.TeaCoffee, this.IsTeaCoffee.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Telephone, this.IsTelephone.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Television, this.IsTelevision.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.ToiletAndBathroom, this.IsToiletAndBathroom.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Towel, this.IsTowel.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.BarLounge, this.IsBarLounge.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.BBQFacilities, this.IsBBQFacilities.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Breakfast, this.IsBreakfast.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Minibar, this.IsMinibar.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Restaurant, this.IsRestaurant.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.BusinessCenter, this.IsBusinessCenter.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.ConferenceFacilitiesRoom, this.IsConferenceFacilitiesRoom.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Photocopy, this.IsPhotocopy.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.DryCleaningFacilities, this.IsDryCleaningFacilities.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.LaundryService, this.IsLaundryService.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.GolfCourt, this.IsGolfCourt.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.GymFitnessCenter, this.IsGymFitnessCenter.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Pool, this.IsPool.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.SpaSauna, this.IsSpaSauna.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.TennisCourt, this.IsTennisCourt.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.WifiAtFO, this.IsWifiAtFO.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.WifiAtRoom, this.IsWifiAtRoom.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.CarParking, this.IsCarParking.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.CarRental, this.IsCarRental.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.FreeParking, this.IsFreeParking.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.Parking, this.IsParking.ToString()));
                    uow.Insert(CreateExPropNonLang(HotelPropertyKeyName.PickOffDropOff, this.IsPickOffDropOff.ToString()));

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
                AlarmService.PropertyValue = this.IsAlarmService.ToString();
                var ExchangeCurrency = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ExchangeCurrency);
                ExchangeCurrency.PropertyValue = this.IsExchangeCurrency.ToString();
                var Frontdesk24Hr = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Frontdesk24Hr);
                Frontdesk24Hr.PropertyValue = this.IsFrontdesk24Hr.ToString();
                var Lifts = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Lifts);
                Lifts.PropertyValue = this.IsLifts.ToString();
                var SpecialHelpService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.SpecialHelpService);
                SpecialHelpService.PropertyValue = this.IsSpecialHelpService.ToString();
                var TicketingService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TicketingService);
                TicketingService.PropertyValue = this.IsTicketingService.ToString();
                var TourDesk = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TourDesk);
                TourDesk.PropertyValue = this.IsTourDesk.ToString();

                var AirConditioning = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.AirConditioning);
                AirConditioning.PropertyValue = this.IsAirConditioning.ToString();
                var CableTelevision = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CableTelevision);
                CableTelevision.PropertyValue = this.IsCableTelevision.ToString();
                var Fan = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Fan);
                Fan.PropertyValue = this.IsFan.ToString();
                var Freewater = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Freewater);
                Freewater.PropertyValue = this.IsFreewater.ToString();
                var Hairdryer = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Hairdryer);
                Hairdryer.PropertyValue = this.IsHairdryer.ToString();
                var Iron = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Iron);
                Iron.PropertyValue = this.IsIron.ToString();
                var NonSmokingRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.NonSmokingRoom);
                NonSmokingRoom.PropertyValue = this.IsNonSmokingRoom.ToString();
                var Safe = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Safe);
                Safe.PropertyValue = this.IsSafe.ToString();
                var ShoeShineTool = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ShoeShineTool);
                ShoeShineTool.PropertyValue = this.IsShoeShineTool.ToString();
                var Slippers = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Slippers);
                Slippers.PropertyValue = this.IsSlippers.ToString();
                var SmokingRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.SmokingRoom);
                SmokingRoom.PropertyValue = this.IsSmokingRoom.ToString();
                var TeaCoffee = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TeaCoffee);
                TeaCoffee.PropertyValue = this.IsTeaCoffee.ToString();
                var Telephone = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Telephone);
                Telephone.PropertyValue = this.IsTelephone.ToString();
                var Television = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Television);
                Television.PropertyValue = this.IsTelevision.ToString();
                var ToiletAndBathroom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ToiletAndBathroom);
                ToiletAndBathroom.PropertyValue = this.IsToiletAndBathroom.ToString();
                var Towel = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Towel);
                Towel.PropertyValue = this.IsTowel.ToString();

                var BarLounge = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.BarLounge);
                BarLounge.PropertyValue = this.IsBarLounge.ToString();
                var BBQFacilities = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.BBQFacilities);
                BBQFacilities.PropertyValue = this.IsBBQFacilities.ToString();
                var Breakfast = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Breakfast);
                Breakfast.PropertyValue = this.IsBreakfast.ToString();
                var Minibar = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Minibar);
                Minibar.PropertyValue = this.IsMinibar.ToString();
                var Restaurant = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Restaurant);
                Restaurant.PropertyValue = this.IsRestaurant.ToString();

                var BusinessCenter = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.BusinessCenter);
                BusinessCenter.PropertyValue = this.IsBusinessCenter.ToString();
                var ConferenceFacilitiesRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ConferenceFacilitiesRoom);
                ConferenceFacilitiesRoom.PropertyValue = this.IsConferenceFacilitiesRoom.ToString();
                var Photocopy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Photocopy);
                Photocopy.PropertyValue = this.IsPhotocopy.ToString();

                var DryCleaningFacilities = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.DryCleaningFacilities);
                DryCleaningFacilities.PropertyValue = this.IsDryCleaningFacilities.ToString();
                var LaundryService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.LaundryService);
                LaundryService.PropertyValue = this.IsLaundryService.ToString();

                var GolfCourt = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.GolfCourt);
                GolfCourt.PropertyValue = this.IsGolfCourt.ToString();
                var GymFitnessCenter = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.GymFitnessCenter);
                GymFitnessCenter.PropertyValue = this.IsGymFitnessCenter.ToString();
                var Pool = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Pool);
                Pool.PropertyValue = this.IsPool.ToString();
                var SpaSauna = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.SpaSauna);
                SpaSauna.PropertyValue = this.IsSpaSauna.ToString();
                var TennisCourt = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TennisCourt);
                TennisCourt.PropertyValue = this.IsTennisCourt.ToString();

                var WifiAtFO = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.WifiAtFO);
                WifiAtFO.PropertyValue = this.IsWifiAtFO.ToString();
                var WifiAtRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.WifiAtRoom);
                WifiAtRoom.PropertyValue = this.IsWifiAtRoom.ToString();

                var CarParking = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CarParking);
                CarParking.PropertyValue = this.IsCarParking.ToString();
                var CarRental = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CarRental);
                CarRental.PropertyValue = this.IsCarRental.ToString();
                var FreeParking = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.FreeParking);
                FreeParking.PropertyValue = this.IsFreeParking.ToString();
                var Parking = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Parking);
                Parking.PropertyValue = this.IsParking.ToString();
                var PickOffDropOff = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.PickOffDropOff);
                PickOffDropOff.PropertyValue = this.IsPickOffDropOff.ToString();

                using (var uow = new NamolyNomenclatureUnitOfWork())
                {
                    uow.Update(this as BusinessEntity);
                    uow.Update(CancellationPolicy_EN);
                    uow.Update(CheckInPolicy_EN);
                    uow.Update(CheckOutPolicy_EN);
                    uow.Update(ChildAndExtraBedRoomPolicy_EN);
                    uow.Update(ReservationPolicy_EN);

                    uow.Update(CancellationPolicy_VN);
                    uow.Update(CheckInPolicy_VN);
                    uow.Update(CheckOutPolicy_VN);
                    uow.Update(ChildAndExtraBedRoomPolicy_VN);
                    uow.Update(ReservationPolicy_VN);

                    uow.Update(AlarmService);
                    uow.Update(ExchangeCurrency);
                    uow.Update(Frontdesk24Hr);
                    uow.Update(Lifts);
                    uow.Update(SpecialHelpService);
                    uow.Update(TicketingService);
                    uow.Update(TourDesk);

                    uow.Update(AirConditioning);
                    uow.Update(CableTelevision);
                    uow.Update(Fan);
                    uow.Update(Freewater);
                    uow.Update(Hairdryer);
                    uow.Update(Iron);
                    uow.Update(NonSmokingRoom);
                    uow.Update(Safe);
                    uow.Update(ShoeShineTool);
                    uow.Update(Slippers);
                    uow.Update(SmokingRoom);
                    uow.Update(TeaCoffee);
                    uow.Update(Telephone);
                    uow.Update(Television);
                    uow.Update(ToiletAndBathroom);
                    uow.Update(Towel);

                    uow.Update(BarLounge);
                    uow.Update(BBQFacilities);
                    uow.Update(Breakfast);
                    uow.Update(Minibar);
                    uow.Update(Restaurant);

                    uow.Update(BusinessCenter);
                    uow.Update(ConferenceFacilitiesRoom);
                    uow.Update(Photocopy);

                    uow.Update(DryCleaningFacilities);
                    uow.Update(LaundryService);

                    uow.Update(GolfCourt);
                    uow.Update(GymFitnessCenter);
                    uow.Update(Pool);
                    uow.Update(SpaSauna);
                    uow.Update(TennisCourt);

                    uow.Update(WifiAtFO);
                    uow.Update(WifiAtRoom);

                    uow.Update(CarParking);
                    uow.Update(CarRental);
                    uow.Update(FreeParking);
                    uow.Update(Parking);
                    uow.Update(PickOffDropOff);
                }
            }
        }

        public void ReadFromDB()
        {
            this.ExPropsHotel_EN = ReadFromDBWithLanguage(Languages.EN);
            this.ExPropsHotel_VN = ReadFromDBWithLanguage(Languages.VN);
            this.IsAlarmService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.AlarmService).PropertyValue.ToBool();
            this.IsExchangeCurrency = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ExchangeCurrency).PropertyValue.ToBool();
            this.IsFrontdesk24Hr = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Frontdesk24Hr).PropertyValue.ToBool();
            this.IsLifts = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Lifts).PropertyValue.ToBool();
            this.IsSpecialHelpService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.SpecialHelpService).PropertyValue.ToBool();
            this.IsTicketingService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TicketingService).PropertyValue.ToBool();
            this.IsTourDesk = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TourDesk).PropertyValue.ToBool();
            this.IsAirConditioning = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.AirConditioning).PropertyValue.ToBool();
            this.IsCableTelevision = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CableTelevision).PropertyValue.ToBool();
            this.IsFan = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Fan).PropertyValue.ToBool();
            this.IsFreewater = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Freewater).PropertyValue.ToBool();
            this.IsHairdryer = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Hairdryer).PropertyValue.ToBool();
            this.IsIron = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Iron).PropertyValue.ToBool();
            this.IsNonSmokingRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.NonSmokingRoom).PropertyValue.ToBool();
            this.IsSafe = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Safe).PropertyValue.ToBool();
            this.IsShoeShineTool = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ShoeShineTool).PropertyValue.ToBool();
            this.IsSlippers = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Slippers).PropertyValue.ToBool();
            this.IsSmokingRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.SmokingRoom).PropertyValue.ToBool();
            this.IsTeaCoffee = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TeaCoffee).PropertyValue.ToBool();
            this.IsTelephone = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Telephone).PropertyValue.ToBool();
            this.IsTelevision = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Television).PropertyValue.ToBool();
            this.IsToiletAndBathroom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ToiletAndBathroom).PropertyValue.ToBool();
            this.IsTowel = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Towel).PropertyValue.ToBool();
            this.IsBarLounge = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.BarLounge).PropertyValue.ToBool();
            this.IsBBQFacilities = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.BBQFacilities).PropertyValue.ToBool();
            this.IsBreakfast = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Breakfast).PropertyValue.ToBool();
            this.IsMinibar = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Minibar).PropertyValue.ToBool();
            this.IsRestaurant = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Restaurant).PropertyValue.ToBool();
            this.IsBusinessCenter = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.BusinessCenter).PropertyValue.ToBool();
            this.IsConferenceFacilitiesRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ConferenceFacilitiesRoom).PropertyValue.ToBool();
            this.IsPhotocopy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Photocopy).PropertyValue.ToBool();
            this.IsDryCleaningFacilities = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.DryCleaningFacilities).PropertyValue.ToBool();
            this.IsLaundryService = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.LaundryService).PropertyValue.ToBool();
            this.IsGolfCourt = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.GolfCourt).PropertyValue.ToBool();
            this.IsGymFitnessCenter = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.GymFitnessCenter).PropertyValue.ToBool();
            this.IsPool = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Pool).PropertyValue.ToBool();
            this.IsSpaSauna = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.SpaSauna).PropertyValue.ToBool();
            this.IsTennisCourt = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.TennisCourt).PropertyValue.ToBool();
            this.IsWifiAtFO = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.WifiAtFO).PropertyValue.ToBool();
            this.IsWifiAtRoom = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.WifiAtRoom).PropertyValue.ToBool();
            this.IsCarParking = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CarParking).PropertyValue.ToBool();
            this.IsCarRental = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CarRental).PropertyValue.ToBool();
            this.IsFreeParking = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.FreeParking).PropertyValue.ToBool();
            this.IsParking = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.Parking).PropertyValue.ToBool();
            this.IsPickOffDropOff = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.PickOffDropOff).PropertyValue.ToBool();

        }
        private ExPropsHotel ReadFromDBWithLanguage(string language)
        {
            var prop = new ExPropsHotel();
            prop._CancellationPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CancellationPolicy, language).PropertyValue;
            prop._CheckInPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckInPolicy, language).PropertyValue;
            prop._CheckOutPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckOutPolicy, language).PropertyValue;
            prop._ChildAndExtraBedRoomPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ChildAndExtraBedRoomPolicy, language).PropertyValue;
            prop._ReservationPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.ReservationPolicy, language).PropertyValue;
            return prop;
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



//this.ExPropsHotel_VN._CancellationPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CancellationPolicy, Languages.VN).PropertyValue;
//this.ExPropsHotel_VN._CheckInPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckInPolicy, Languages.VN).PropertyValue;

//this.ExPropsHotel_EN._CancellationPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CancellationPolicy, Languages.EN).PropertyValue;
//this.ExPropsHotel_EN._CheckInPolicy = ReadBusinessEntityDB(this.Id, HotelPropertyKeyName.CheckInPolicy, Languages.EN).PropertyValue;