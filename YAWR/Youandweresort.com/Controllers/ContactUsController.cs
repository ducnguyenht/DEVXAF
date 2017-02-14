using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Youandweresort.com.Models;

namespace Youandweresort.com.Controllers
{
    public class ContactUsController : Controller
    {
        [Route("contact-us")]
        public ActionResult ContactUs()
        {
            var model = new ContactUs();
            return View();
        }
        [HttpPost]
        public ActionResult SendMailCts(ContactUs model) {
            if (ModelState.IsValid)
            {
                #region Gửi mail cho nhóm hỗ trợ
                // Dùng cho người quản lý mail Book từ khách hàng (Admin)
                List<ReceiverEmail> listReceiverEmailSupport = new List<ReceiverEmail>();
                listReceiverEmailSupport.Add(new ReceiverEmail { ReceiverEmailAddress = "nhan.nguyen@naansolution.com", ReceiverFullName = "Nhân Nguyễn" });
                string bodySupport = "Thông báo từ" + " " + model.Name + "<br>" + "Tiêu đề:" + model.Subject +"<br>" + "Email:" + model.Email +"<br>" + "Tin nhắn:" + model.Messages +"<br>";
                SendEmail.BookRoomYAW("Nhân Nguyễn", "nhan.nguyen@naansolution.com", listReceiverEmailSupport, "Mail Liên Hệ", bodySupport);
                #endregion
                #region Gửi mail cho khách hàng
                // Dùng cho khách hàng
                List<ReceiverEmail> listReceiverEmailCustomer = new List<ReceiverEmail>();
                listReceiverEmailCustomer.Add(new ReceiverEmail { ReceiverEmailAddress = model.Email, ReceiverFullName = model.Name });
                string bodyCustomer = "Cảm ơn bạn " + " "+ model.Name + " "+ "đã liên hệ với chúng tôi - Chúng tôi sẽ liên lạc với bạn sớm nhất có thể . Chúc bạn có một ngày tràn đầy niềm vui và hạnh phúc !";
                SendEmail.BookRoomYAW("Robot Booking", "nhan.nguyen@naansolution.com", listReceiverEmailCustomer, "Mail tự động", bodyCustomer);
                #endregion
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Mail sended.");
        }
    }
}