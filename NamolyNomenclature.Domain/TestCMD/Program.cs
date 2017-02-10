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
            var hsdb2 = NamolyNomenclatureContext.Hotels.Single(43);

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
                ht.ExPropsHotel_VN._CheckInPolicy = "chinh sach tra phong galina html";
                ht.ExPropsHotel_VN._CancellationPolicy = "chinh sach huy phong galina html";
                ht.ExPropsHotel_EN._CheckInPolicy = "check in policy galina html";
                ht.ExPropsHotel_EN._CancellationPolicy = "cancellation policy galina html";
                ht.IsAlarmService = false;
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
                ht.ExPropsHotel_VN._CheckInPolicy = "cap nhat chinh sach tra phong galina html";
                ht.ExPropsHotel_VN._CancellationPolicy = "cap nhat chinh sach huy phong galina  html";
                ht.ExPropsHotel_EN._CheckInPolicy = "update check in policy galina html";
                ht.ExPropsHotel_EN._CancellationPolicy = "update cancellation policy galina html";
                ht.IsAlarmService = true;
                ht.CreateOrUpdateToDB();
            }

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
                ht1.ExPropsHotel_VN._CheckInPolicy = "chinh sach tra phong YAW html";
                ht1.ExPropsHotel_VN._CancellationPolicy = "chinh sach huy phong YAW html";
                ht1.ExPropsHotel_EN._CheckInPolicy = "check in policy YAW  html";
                ht1.ExPropsHotel_EN._CancellationPolicy = "cancellation policy YAW  html";
                ht1.IsAlarmService = true;
                ht1.CreateOrUpdateToDB();
            }
            else
            {
                ht.Name = "You And We";
                ht.Address = "Update so 5 YAW";
                ht.City = "update HCM";
                ht.Code = "updateyaw";
                ht.Country = "VN";
                ht.Email = "yaw@mail.com";
                ht.Fax = "3333333333";
                ht.Phone = "444444444";
                ht.Website = "www.youandwe.com";
                ht.ExPropsHotel_VN._CheckInPolicy = "cap nhat chinh sach tra phong YAW html";
                ht.ExPropsHotel_VN._CancellationPolicy = "cap nhat chinh sach huy phong YAW html";
                ht.ExPropsHotel_EN._CheckInPolicy = "update check in policy YAW html";
                ht.ExPropsHotel_EN._CancellationPolicy = "update cancellation policy YAW html";
                ht.IsAlarmService = false;
                ht.CreateOrUpdateToDB();
            }

            var lstHotel = NamolyNomenclatureContext.Hotels.All();



            #endregion



        }
    }
}

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