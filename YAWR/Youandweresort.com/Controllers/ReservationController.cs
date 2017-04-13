﻿using Microsoft.AspNet.Identity;
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
    public class ReservationController : Controller
    {
        [Route("reservation")]
        public ActionResult Reservation()
        {
            var model = new BookRoom();
            return View(model);
        }

        // set ID khi selected phòng
        [Route("reservation/{room}")]
        public ActionResult ReservationCustom(int? room)
        {
            if (room > 6)
            {
                return RedirectToAction("Reservation");
            }
            else
            {
                ViewBag.RoomCode = room;
                var model = new BookRoom();
                return View(model);
            }
        }

        [HttpPost]
        //bắt buộc có để không bị lỗi
        [Route("reservation/sendmail")]
        public  ActionResult SendMail(BookRoom model)
        {
            if (ModelState.IsValid)
            {
                #region Gửi mail cho nhóm hỗ trợ
                // Dùng cho người quản lý mail Book từ khách hàng (Admin)
                List<ReceiverEmail> listReceiverEmailSupport = new List<ReceiverEmail>();
                listReceiverEmailSupport.Add(new ReceiverEmail { ReceiverEmailAddress = "nhan.nguyen@naansolution.com", ReceiverFullName = "Nhân Nguyễn" });               
                string bodySupport = "<section bgcolor=\"#fff\" class=\"form-email-booking\" >  <table align=\"center\" cellpadding=\"0\" cellspacing=\"0\" class=\"container-for-gmail-android\" width=\"100%\" style=\"border-collapse: collapse !important; min-width: 290px !important; width: 100% !important;\">   <tbody><tr>    <td align=\"left\" valign=\"top\" width=\"100%\" style=\"border-collapse: collapse; font-size: 14px; color: #777777; text-align: center; line-height: 21px; background-color: #333;\" bgcolor=\"#333\">     <center>      <table cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#ffffff\" style=\"border-collapse: collapse !important;\">       <tbody><tr>        <td width=\"100%\" height=\"80\" valign=\"top\" style=\"text-align: center; vertical-align: middle; border-collapse: collapse; font-size: 14px; color: #777777; line-height: 21px; background-color: #333;\" align=\"center\" bgcolor=\"#333\">         <center>          <table cellpadding=\"0\" cellspacing=\"0\" width=\"600\" class=\"w320\" style=\"border-collapse: collapse !important; width: 320px !important;\">           <tbody><tr>            <td class=\"mobile-header-padding-left\" style=\"vertical-align: middle; border-collapse: collapse; font-size: 14px; color: #777777; text-align: center; line-height: 21px; width: 160px !important; padding: 15px 0;\" align=\"center\" valign=\"middle\">             <a href=\"http://youandweresort.naansolution.net/\"><img src=\"http://youandweresort.naansolution.net/Images/logoYouAndWeResort%20copy.png\" alt=\"logo\" style=\"max-width: 28%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none;\"></a>            </td>           </tr>          </tbody></table>         </center>        </td>       </tr>      </tbody></table>     </center>    </td>   </tr>   <tr>    <td align=\"center\" valign=\"top\" width=\"100%\" style=\"font-size: 16px;/* text-transform: uppercase; */letter-spacing: -1px;color: rgba(51, 51, 51, 0.64);border-collapse: collapse;text-align: center;line-height: 21px;background-color: #f7f7f7;padding: 5px 0;\" class=\"content-padding\" bgcolor=\"#f7f7f7\">     <center>      <table cellspacing=\"0\" cellpadding=\"0\" width=\"600\" class=\"w320\" style=\"border-collapse: collapse !important;width: 600px !important;\">       <tbody><tr>        <td class=\"header-lg\" style=\"border-collapse: collapse; font-size: 24px !important; color: #4d4d4d; text-align: center; line-height: normal; font-weight: 700; padding: 35px 0 5px;font-family: 'Open Sans', sans-serif !important;\" align=\"center\">         Xin chào , Admin !!!        </td>       </tr>       <tr>        <td class=\"free-text\" style=\"border-collapse: collapse; font-size: 15px; color: black; text-align: center; line-height: 21px; width: 100% !important; padding: 10px 18px 30px;\" align=\"center\">         Bạn vừa nhận được thông tin đặt phòng từ khách hàng " + model.FullName + "   </td>       </tr>       <tr>        <td class=\"w320\" style=\"border-collapse: collapse; font-size: 14px; color: #777777; text-align: center; line-height: 21px;\" align=\"center\">         <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse: collapse !important;\">          <tbody><tr>           <td class=\"mini-container-left\" style=\"border-collapse: collapse;font-size: 14px;color: #777777;text-align: center;line-height: 21px;width: 278px !important;/* display: block !important; */padding: 0 15px 10px 0;\" align=\"center\">            <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse: collapse !important;\">             <tbody><tr>              <td class=\"mini-block-padding\" style=\"border-collapse: collapse; font-size: 14px; color: #777777; text-align: center; line-height: 21px;\" align=\"center\">               <h5 style=\"font-size: 16px; text-transform: uppercase; letter-spacing: -1px; color: rgba(51, 51, 51, 0.64);\">Thông tin phòng</h5>               <table cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" style=\"border-collapse: separate !important;\">                <tbody><tr>                 <td class=\"mini-block\" style=\"border-collapse: collapse; font-size: 14px; color: #777777; text-align: left; line-height: 21px; border-radius: 1px; width: 253px; background-color: #ffffff; padding: 12px 15px 15px; border: 1px solid #ececec;\" align=\"left\" bgcolor=\"#ffffff\">                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Ngày đến</span><br>                  <p style=\"margin: 5px 0;\">" + model.ArrivalDate + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Ngày đi</span><br>                  <p style=\"margin: 5px 0;\">" + model.DepartureDate + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Đêm</span><br>                  <p style=\"margin: 5px 0;\">" + model.Nights + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px;font-weight: 700;line-height: 1.7;color: #4d4d4d;/* text-transform: capitalize; */padding: 5px 0;\">Loại phòng</span><br>                  <p style=\"margin: 5px 0;\">" + model.Rooms + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Số lượng phòng</span><br>                  <p style=\"margin: 5px 0;\">" + model.QuantityRooms + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Người lớn</span><br>                  <p style=\"margin: 5px 0;\">" + model.Adults + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Trẻ em</span><br>                  <p style=\"margin: 5px 0;\">" + model.Children + "</p>                 </td>                </tr>               </tbody></table>              </td>             </tr>            </tbody></table>           </td>           <td class=\"mini-container-right\" style=\"border-collapse: collapse; font-size: 14px; color: #777777; text-align: center; line-height: 21px; width: 290px !important; display: block !important; padding: 0 15px 15px;\" align=\"center\">            <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse: collapse !important;\">             <tbody><tr>              <td class=\"mini-block-padding\" style=\"border-collapse: collapse; font-size: 14px; color: #777777; text-align: center; line-height: 21px;\" align=\"center\">               <h5 style=\"font-size: 16px; text-transform: uppercase; letter-spacing: -1px; color: rgba(51, 51, 51, 0.64);\">Thông tin khách hàng</h5>               <table cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" style=\"border-collapse: separate !important;\">                <tbody><tr>                 <td class=\"mini-block\" style=\"border-collapse: collapse;font-size: 14px;color: #777777;text-align: left;line-height: 21px;border-radius: 1px;width: 253px;background-color: #ffffff;padding: 12px 15px 15px;border: 1px solid #ececec;\" align=\"left\" bgcolor=\"#ffffff\">                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Họ và tên</span><br>                  <p style=\"margin: 5px 0;\">" + model.FullName + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Email</span><br>                  <p style=\"margin: 5px 0;\">" + model.Email + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Địa chỉ</span><br>                  <p style=\"margin: 5px 0;\">" + model.Address + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Số điện thoại</span><br>                  <p style=\"margin: 5px 0;\">" + model.Phone + "</p>                  <span class=\"header-sm\" style=\"font-size: 16px; font-weight: 700; line-height: 1.7; color: #4d4d4d; text-transform: capitalize; padding: 5px 0;\">Yêu cầu từ khách hàng</span><br>                  <p style=\"margin: 5px 0;\">" + model.Messages + "</p>                  <span class=\"header-sm\" style=\"color: #fff; font-size: 16px; font-weight: 700; line-height: 1.7; text-transform: capitalize; padding: 5px 0;\">----------</span><br>                  <p style=\"color: #fff; margin: 5px 0;\">/-----/</p>                  <span class=\"header-sm\" style=\"color: #fff; font-size: 16px; font-weight: 700; line-height: 1.7; text-transform: capitalize; padding: 5px 0;\">----------</span><br>                  <p style=\"color: #fff; margin: 5px 0;\">/-----/</p>                 </td>                </tr>               </tbody></table>              </td>             </tr>            </tbody></table>           </td>          </tr>         </tbody></table>        </td>       </tr>      </tbody></table>     </center>    </td>   </tr>   <tr>    <td align=\"center\" valign=\"top\" width=\"100%\" style=\"height: 100px; border-collapse: collapse; font-size: 14px; color: #777777; text-align: center; line-height: 21px; background-color: #fff;\" bgcolor=\"#fff\">     <center>      <table cellspacing=\"0\" cellpadding=\"0\" width=\"600\" class=\"w320\" style=\"border-collapse: collapse !important; width: 320px !important;\">       <tbody><tr>        <td style=\"text-align: center; border-collapse: collapse; font-size: 14px; color: #777777; line-height: 21px; padding: 34px 0 0;\" align=\"center\">         <strong>YOU &amp; WE RESORT</strong><br>         Phu Quoc Resort<br>         All rights reserved<br><br>        </td>       </tr>      </tbody></table>     </center>    </td>   </tr>  </tbody></table> </section>";
                 SendEmail.BookRoomYAW("Nhân Nguyễn", "nhan.nguyen@naansolution.com", listReceiverEmailSupport, "Mail Booking", bodySupport);
                #endregion
                #region Gửi mail cho khách hàng
                // Dùng cho khách hàng
                List<ReceiverEmail> listReceiverEmailCustomer = new List<ReceiverEmail>();
                listReceiverEmailCustomer.Add(new ReceiverEmail { ReceiverEmailAddress = model.Email, ReceiverFullName = model.FullName });
                string bodyCustomer = "Dear Ms/Mr " + model.FullName + ", <br />" + "Thank you for your booking. We would get in touch with you within 8 working hours. If you need urgent assistance, we are ready to assist at: +84 (0) 77 6257979. This is an automatic email, please do not reply to this email. <br />Regards,<br />You & We Resort ";
                SendEmail.BookRoomYAW("Robot Booking", "nhan.nguyen@naansolution.com", listReceiverEmailCustomer, "Mail tự động", bodyCustomer);
                #endregion
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Mail sended.");
          
        }
    }
}