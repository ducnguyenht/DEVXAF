using AutoMapper;
using NamolyNomenclature.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCMD
{
    class Program
    {
        static void Main(string[] args)
        {

            #region update
            var hsdb2 = NamolyNomenclatureContext.Hotels.Single(48);

            var ht1 = NamolyNomenclatureContext.Hotels.Single
                (where: "Name='You And We'");
            if (ht1 == null)
            {
                ht1 = new Hotel();
                ht1.Name = "You And We";
                ht1.Address = "so 5 YAW";
                ht1.City = "HCM";
                ht1.Code = "yaw";
                ht1.Country = "VN";
                ht1.Email = "yaw@mail.com";
                ht1.Fax = "11111111";
                ht1.Phone = "222222222";
                ht1.Website = "www.youandwe.com";
                ht1.ExPropsHotel_VN.CheckInPolicy = "chinh sach tra phong YAW html";
                ht1.ExPropsHotel_VN.CancellationPolicy = "chinh sach huy phong YAW html";
                ht1.ExPropsHotel_VN.CheckOutPolicy = "chinh sach tra phong YAW html";
                ht1.ExPropsHotel_VN.ChildAndExtraBedRoomPolicy = "chinh sach tre em va them giuong phong YAW html";
                ht1.ExPropsHotel_VN.ReservationPolicy = "chinh sach dat phong YAW html";
                ht1.ExPropsHotel_EN.CheckInPolicy = "check in policy YAW  html";
                ht1.ExPropsHotel_EN.CancellationPolicy = "cancellation policy YAW  html";
                ht1.ExPropsHotel_EN.CheckOutPolicy = "_CheckOutPolicy YAW  html";
                ht1.ExPropsHotel_EN.ChildAndExtraBedRoomPolicy = "_ChildAndExtraBedRoomPolicy YAW  html";
                ht1.ExPropsHotel_EN.ReservationPolicy = "_ReservationPolicy YAW  html";
                ht1.IsAlarmService = true;
                ht1.IsBBQFacilities = true;
                ht1.IsCableTelevision = true;
                ht1.CreateOrUpdateToDB();
            }
            else
            {
                ht1.Name = "You And We";
                ht1.Address = "Update so 5 YAW";
                ht1.City = "update HCM";
                ht1.Code = "updateyaw";
                ht1.Country = "VN";
                ht1.Email = "yaw@mail.com";
                ht1.Fax = "3333333333";
                ht1.Phone = "444444444";
                ht1.Website = "www.youandwe.com";
                ht1.ExPropsHotel_VN.CheckInPolicy = "cap nhat chinh sach tra phong YAW html";
                ht1.ExPropsHotel_VN.CancellationPolicy = "cap nhat chinh sach huy phong YAW html";
                ht1.ExPropsHotel_EN.CheckInPolicy = "update check in policy YAW html";
                ht1.ExPropsHotel_EN.CancellationPolicy = "update cancellation policy YAW html";
                ht1.IsAlarmService = false;
                ht1.CreateOrUpdateToDB();
            }

            var ht = NamolyNomenclatureContext.Hotels.Single
                (where: "Name=@0", parms: "galina nha trang");
            if (ht == null)
            {
                ht = new Hotel();
                ht.Name = "galina nha trang";
                ht.Address = "so 5 hung vuong nha trang";
                ht.City = "NT";
                ht.Code = "galinatrang";
                ht.Country = "VN";
                ht.Email = "galina@mail.com";
                ht.Fax = "1111111111";
                ht.Phone = "222222222";
                ht.Website = "www.galinahotel.com";
                ht.ExPropsHotel_VN.CheckInPolicy = "chinh sach tra phong galina html";
                ht.ExPropsHotel_VN.CancellationPolicy = "chinh sach huy phong galina html";
                ht.ExPropsHotel_EN.CheckInPolicy = "check in policy galina html";
                ht.ExPropsHotel_EN.CancellationPolicy = "cancellation policy galina html";
                ht.IsAlarmService = true;
                ht.CreateOrUpdateToDB();
            }
            else
            {
                ht.Name = "galina nha trang";
                ht.Address = "Update so 5 hung vuong nha trang";
                ht.City = "update NT";
                ht.Code = "updategalinatrang";
                ht.Country = "VN";
                ht.Email = "updategalina@mail.com";
                ht.Fax = "333333333";
                ht.Phone = "4444444444";
                ht.Website = "www.updategalinahotel.com";

                ht.ExPropsHotel_VN.CheckInPolicy = "cap nhat chinh sach tra phong galina html";
                ht.ExPropsHotel_VN.CancellationPolicy = "cap nhat chinh sach huy phong galina  html";
                ht.ExPropsHotel_EN.CheckInPolicy = "update check in policy galina html";
                ht.ExPropsHotel_EN.CancellationPolicy = "update cancellation policy galina html";
                ht.IsAlarmService = false;
                ht.IsAirConditioning = true;
                ht.IsBarLounge = true;
                ht.CreateOrUpdateToDB();
            }
            var lstHotel = NamolyNomenclatureContext.Hotels.All();
            foreach (var item in lstHotel)
            {
                //NamolyNomenclatureContext.Hotels.Delete(item);
            }
            #endregion




            Mapper.Initialize(c =>
            {
                c.CreateMap<HotelModel, Hotel>();
                c.CreateMap<HotelModel, ExPropsHotel>();
            });
            var hotelModel = new HotelModel();
            hotelModel.CancellationPolicy_VN = "huy phong html";
            hotelModel.CheckInPolicy_VN = "nhan phong html";
            hotelModel.CheckOutPolicy_VN = "tra phong html";
            hotelModel.ChildAndExtraBedRoomPolicy_VN = "tre em va them giuong html";
            hotelModel.ReservationPolicy_VN = "dat phong html";

            hotelModel.CancellationPolicy_EN = "cancel room html";
            hotelModel.CheckInPolicy_EN = "check in room  html";
            hotelModel.CheckOutPolicy_EN = "check out room  html";
            hotelModel.ChildAndExtraBedRoomPolicy_EN = "child and extra  html";
            hotelModel.ReservationPolicy_EN = "reservation room html";

            var h = Mapper.Map<Hotel>(hotelModel);

            h.ExPropsHotel_EN.CancellationPolicy = hotelModel.CancellationPolicy_EN;
            h.ExPropsHotel_EN.CheckInPolicy = hotelModel.CheckInPolicy_EN;
            h.ExPropsHotel_EN.CheckOutPolicy = hotelModel.CheckOutPolicy_EN;
            h.ExPropsHotel_EN.ChildAndExtraBedRoomPolicy = hotelModel.ChildAndExtraBedRoomPolicy_EN;
            h.ExPropsHotel_EN.ReservationPolicy = hotelModel.ReservationPolicy_EN;

            h.ExPropsHotel_VN.CancellationPolicy = hotelModel.CancellationPolicy_VN;
            h.ExPropsHotel_VN.CheckInPolicy = hotelModel.CheckInPolicy_VN;
            h.ExPropsHotel_VN.CheckOutPolicy = hotelModel.CheckOutPolicy_VN;
            h.ExPropsHotel_VN.ChildAndExtraBedRoomPolicy = hotelModel.ChildAndExtraBedRoomPolicy_VN;
            h.ExPropsHotel_VN.ReservationPolicy = hotelModel.ReservationPolicy_VN;
        }
    }
}

//.ForMember(d => d.ExPropsHotel_VN._CancellationPolicy, o => o.MapFrom(s => s.CancellationPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._CheckInPolicy, o => o.MapFrom(s => s.CheckInPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._CheckOutPolicy, o => o.MapFrom(s => s.CheckOutPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._ChildAndExtraBedRoomPolicy, o => o.MapFrom(s => s.ChildAndExtraBedRoomPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._ReservationPolicy, o => o.MapFrom(s => s.ReservationPolicy_VN));

//c.CreateMap<HotelModel, Hotel>()
//    .ForMember(d=>d.ExPropsHotel_EN, o => o.ResolveUsing(fa =>
//    {

//    }
//));

//c.ReplaceMemberName(@"_VN", "");
//c.ReplaceMemberName(@"_EN", "");
//c.CreateMap<HotelModel, Hotel>()
//.ForMember(d => d.ExPropsHotel_VN._CancellationPolicy, o => o.MapFrom(s => s.CancellationPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._CheckInPolicy, o => o.MapFrom(s => s.CheckInPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._CheckOutPolicy, o => o.MapFrom(s => s.CheckOutPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._ChildAndExtraBedRoomPolicy, o => o.MapFrom(s => s.ChildAndExtraBedRoomPolicy_VN))
//.ForMember(d => d.ExPropsHotel_VN._ReservationPolicy, o => o.MapFrom(s => s.ReservationPolicy_VN))

//.ForMember(d => d.ExPropsHotel_EN._CancellationPolicy, o => o.MapFrom(s => s.CancellationPolicy_EN))
//.ForMember(d => d.ExPropsHotel_EN._CheckInPolicy, o => o.MapFrom(s => s.CheckInPolicy_EN))
//.ForMember(d => d.ExPropsHotel_EN._CheckOutPolicy, o => o.MapFrom(s => s.CheckOutPolicy_EN))
//.ForMember(d => d.ExPropsHotel_EN._ChildAndExtraBedRoomPolicy, o => o.MapFrom(s => s.ChildAndExtraBedRoomPolicy_EN))
//.ForMember(d => d.ExPropsHotel_EN._ReservationPolicy, o => o.MapFrom(s => s.ReservationPolicy_EN))
//;       
//c.CreateMap<FatherModel, Father>()
//      .ForMember(dest => dest.Son.Id, opt => opt.MapFrom(src => src.SonId));


//var hotelModel = new HotelModel();
//hotelModel.Address = "so 5 hung vuong nha trang";
//hotelModel.City = "NT";
//hotelModel.Code = "galinatrang";
//hotelModel.Country = "VN";
//hotelModel.Email = "galina@mail.com";
//hotelModel.Fax = "1111111111";
//hotelModel.Id = 48;
//hotelModel.Latitude = 12;
//hotelModel.Longtitude = 22;
//hotelModel.MapMarkerURL = "http://url.com";
//hotelModel.Name = "galina nha trang";
//hotelModel.Phone = "222222222";
//hotelModel.TaxCode = "12312ADDFE";
//hotelModel.Website = "www.galinahotel.com";

//hotelModel.CancellationPolicy_VN = "huy phong html";
//hotelModel.CheckInPolicy_VN = "nhan phong html";
//hotelModel.CheckOutPolicy_VN = "tra phong html";
//hotelModel.ChildAndExtraBedRoomPolicy_VN = "tre em va them giuong html";
//hotelModel.ReservationPolicy_VN = "dat phong html";

//hotelModel.CancellationPolicy_EN = "cancel room html";
//hotelModel.CheckInPolicy_EN = "check in room  html";
//hotelModel.CheckOutPolicy_EN = "check out room  html";
//hotelModel.ChildAndExtraBedRoomPolicy_EN = "child and extra  html";
//hotelModel.ReservationPolicy_EN = "reservation room html";

//hotelModel.IsAirConditioning = true;
//hotelModel.IsAlarmService = false;
//hotelModel.IsBarLounge = true;
//hotelModel.IsBBQFacilities = false;
//hotelModel.IsBreakfast = true;
//hotelModel.IsBusinessCenter = false;
//hotelModel.IsCableTelevision = true;
//hotelModel.IsCarParking = false;
//hotelModel.IsCarRental = true;
//hotelModel.IsConferenceFacilitiesRoom = false;
//hotelModel.IsDryCleaningFacilities = true;
//hotelModel.IsExchangeCurrency = false;
//hotelModel.IsFan = true;
//hotelModel.IsFreeParking = false;
//hotelModel.IsFreewater = true;
//hotelModel.IsRestaurant = false;








//var CancellationPolicy_EN = hsdb1.ExPropsHotel_EN._CancellationPolicy;
//var a= hsdb1.ExPropsHotel_EN._CheckInPolicy;
//hsdb1.CancellationPolicy = "English Cancellation Policy html...";
//hsdb1.CreateOrUpdateToDB(Languages.EN);


//var hsdb2 = NamolyNomenclatureContext.Hotels.Single
//   (where: "Name='galina nha trang'");
//var lstHotel = NamolyNomenclatureContext.Hotels.All();
//var lstHotel1 = NamolyNomenclatureContext.Hotels.All(language: Languages.VN);

//var h = new Hotel();
//h.Address = "so 5 hung vuong nha trang";
//h.City = "HCM";
//h.Code = "galinatrang";
//h.Country = "VN";
//h.Email = "galina@mail.com";
//h.Fax = "12333";
//h.Name = "galina nha trang";
//h.Phone = "11111111111111";
//h.Website = "www.galinahotel.com";
//h.ExPropsHotel_VN._CheckInPolicy = "chinh sach tra phong html";
//h.ExPropsHotel_VN._CancellationPolicy = "chinh sach huy phong html";
//h.ExPropsHotel_EN._CheckInPolicy = "check in policy html";
//h.ExPropsHotel_EN._CancellationPolicy = "cancellation policy html";
//h.IsAlarmServiceFO = true;
//h.CreateOrUpdateToDB();

//var h = Mapper.Map<Hotel>(hsdb1);
//if (h != null)
//{
//    h.Address = "so 5 hung vuong nha trang";
//    h.City = "test";
//    h.Code = "galinatrangggggggggg";
//    h.Country = "VN";
//    h.Email = "galina@mail.com";
//    h.Fax = "12333";
//    h.Name = "galina nha trang";
//    h.Phone = "3434";
//    h.Website = "www.galinahotel.com";

//    h.CancellationPolicy = "8 Test Update 3 Cancellation Policy";
//    h.IsAlarmServiceFO = false;
//    h.CreateOrUpdateToDB(Languages.VN);
//}
//else
//{
//    h = new Hotel();
//    h.Address = "so 5 hung vuong nha trang";
//    h.City = "test";
//    h.Code = "galinatrang";
//    h.Country = "VN";
//    h.Email = "galina@mail.com";
//    h.Fax = "12333";
//    h.Name = "galina nha trang";
//    h.Phone = "3434";
//    h.Website = "www.galinahotel.com";

//    h.CancellationPolicy = "7 Test Update 3 Cancellation Policy";
//    h.IsAlarmServiceFO = true;
//    h.CreateOrUpdateToDB(Languages.VN);
//}

#region read hotel
//var myhotel1 = NamolyNomenclatureContext.Hotels.Single(where: "Name='galina nha trang' and ");
//hs = Mapper.Map<Hotel>(myhotel1);
//if (hs != null)
//{
//    hs.ReadFromDB(Languages.VN);
//}
#endregion read hotel

//Mapper.Initialize(cfg =>
//{
//    cfg.CreateMap<BusinessEntity, Hotel>();
//});
//#region search hotel & delete
//var hsdb = NamolyNomenclatureContext.Hotels.Single(where: "Name='galina nha trang' and ");
//var hs = Mapper.Map<Hotel>(hsdb);
//if (hs != null)
//{
//    hs.ReadFromDB(Languages.VN);
//    NamolyNomenclatureContext.Hotels.Delete(hs);
//}
//#endregion search hotel
//#region add hotel-------------------------------------------------
//var h = new Hotel();
//h.Address = "so 5 hung vuong nha trang";
//h.City = "test";
//h.Code = "galinatrang";
//h.Country = "VN";
//h.Email = "galina@mail.com";
//h.Fax = "12333";
//h.Name = "galina nha trang";
//h.Phone = "3434";
//h.Website = "www.galinahotel.com";

//h.CancellationPolicy = "Test Insert Cancellation Policy";
//h.CheckInPolicy = "Test Insert CheckInPolicy";
//h.CheckOutPolicy = "Test Insert CheckOutPolicy";
//h.ChildAndExtraBedRoomPolicy = "Test Insert ChildAndExtraBedRoomPolicy";
////h.ReservationPolicy = "Test Insert ReservationPolicy";

//h.IsAlarmServiceFO = true;
//h.IsExchangeCurrencyFO = true;
//h.IsFrontdesk24HrFO = true;
//h.CreateOrUpdateToDB(Languages.VN);

//var h1 = new Hotel();
//h1.Address = "123 NDK";
//h1.City = "HCM";
//h1.Code = "alibabatrang";
//h1.Country = "VN";
//h1.Email = "alibaba@mail.com";
//h1.Fax = "12333";
//h1.Name = "alibaba nha trang";
//h1.Phone = "3434";
//h1.Website = "www.alibabahotel.com";

//h1.CancellationPolicy = "1 Test Insert Cancellation Policy";
//h1.CheckInPolicy = "1 Test Insert CheckInPolicy";
//h1.CheckOutPolicy = "1 Test Insert CheckOutPolicy";
//h1.ChildAndExtraBedRoomPolicy = "1 Test Insert ChildAndExtraBedRoomPolicy";
////h.ReservationPolicy = "Test Insert ReservationPolicy";

//h1.IsAlarmServiceFO = true;
//h1.IsExchangeCurrencyFO = true;
//h1.IsFrontdesk24HrFO = true;
//h1.CreateOrUpdateToDB(Languages.VN);
//#endregion add hotel------------------------------------------------
//var ks1db = NamolyNomenclatureContext.Hotels.Single(where: "Name='galina nha trang' and ");
//var ks1 = Mapper.Map<Hotel>(ks1db);
//ks1db.Website = "wwwwww";
//var ks2db = NamolyNomenclatureContext.Hotels.Single(where: "Name='alibaba nha trang' and ");
//var ks2=Mapper.Map<Hotel>(ks2db);
//ks2db.Website = "eeeeeee";
//var CancellationPolicy = NamolyNomenclatureContext.BusinessEntityProperties.Single(
//        where: "BusinessEntityId=@0 and PropertyKey=@1 and Language=@2",
//        parms: new object[] { 9, HotelPropertyKeyName.CancellationPolicy, Languages.VN });
//CancellationPolicy.PropertyValue = "update 1 day";
//var AlarmService = NamolyNomenclatureContext.BusinessEntityProperties.Single(
//        where: "BusinessEntityId=@0 and PropertyKey=@1 and Language=@2",
//        parms: new object[] { 9, HotelPropertyKeyName.AlarmService, Languages.VN });
//AlarmService.PropertyValue = false.ToString();
//using (var uow = new NamolyNomenclatureUnitOfWork())
//{
//    //uow.Update(ks1db as BusinessEntity);
//    //uow.Update(ks2db as BusinessEntity);
//    uow.Update(CancellationPolicy);
//    uow.Update(AlarmService);
//}