using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            //Gáng dữ liệu cho Breadcrumb
            //ViewBag.Breadcrumbs = new List<Breadcrumb>{
            //    new Breadcrumb { Code = "1", Name = "Chọn phòng", Class="active"},
            //    new Breadcrumb { Code = "2", Name = "Chi tiết đặt phòng", Class=""},
            //    new Breadcrumb { Code = "3", Name = "Thanh toán", Class=""},
            //    new Breadcrumb { Code = "4", Name = "Kết quả", Class=""},
            //};
            return View();
        }
        // GET: Information
        public ActionResult Information(int? Id)
        {
            ViewBag.Id = Id;
            //Gáng dữ liệu cho Breadcrumb
            //ViewBag.Breadcrumbs = new List<Breadcrumb>{
            //    new Breadcrumb { Code = "1", Name = "Chọn phòng", Class="success"},
            //    new Breadcrumb { Code = "2", Name = "Chi tiết đặt phòng", Class="active"},
            //    new Breadcrumb { Code = "3", Name = "Thanh toán", Class=""},
            //    new Breadcrumb { Code = "4", Name = "Kết quả", Class=""},
            //};
            return View();
        }
        // GET: Payment
        public ActionResult Payment()
        {
            //Gáng dữ liệu cho Breadcrumb
            //ViewBag.Breadcrumbs = new List<Breadcrumb>{
            //    new Breadcrumb { Code = "1", Name = "Chọn phòng", Class="success"},
            //    new Breadcrumb { Code = "2", Name = "Chi tiết đặt phòng", Class="success"},
            //    new Breadcrumb { Code = "3", Name = "Thanh toán", Class="active"},
            //    new Breadcrumb { Code = "4", Name = "Kết quả", Class=""},
            //};
            return View();
        }
    }
}