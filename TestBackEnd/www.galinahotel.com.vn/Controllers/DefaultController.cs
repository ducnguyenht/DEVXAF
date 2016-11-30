using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using www.galinahotel.com.vn.Models.Default;

namespace www.galinahotel.com.vn.Controllers
{
    public class DefaultController : Controller
    {


        public ActionResult p_Header()
        {
            HttpCookie ThisLanguage = System.Web.HttpContext.Current.Request.Cookies["NOPLanguage"];
            if (ThisLanguage != null)
            {
                switch (ThisLanguage.Value)
                {
                    case "en":
                        {
                            var Navigations = new List<Navigation>();
                            var NavigationChilds = new List<NavigationChild>();
                            var NavigationChild = new NavigationChild();
                            var Navigation = new Navigation { Code = "1", Title = "About", Routing = "gioi-thieu", Class = "active", Child = null };
                            Navigations.Add(Navigation);
                            NavigationChild = new NavigationChild
                            {
                                Code = "21",
                                Title = "Phòng Cao Cấp",
                                Routing = "phong-cao-cap"
                            };
                            NavigationChilds.Add(NavigationChild);
                            NavigationChild = new NavigationChild
                            {
                                Code = "21",
                                Title = "Phòng Vip",
                                Routing = "phong-vip"
                            };
                            NavigationChilds.Add(NavigationChild);
                            Navigation = new Navigation { Code = "2", Title = "Phòng Nghỉ", Routing = "", Class = "", Child = NavigationChilds };
                            Navigations.Add(Navigation);
                            ViewBag.Navigations = Navigations;
                            break;
                        }
                    case "vi":
                        {


                            var Navigations = new List<Navigation>();
                            var NavigationChilds = new List<NavigationChild>();
                            var NavigationChild = new NavigationChild();
                            var Navigation = new Navigation { Code = "1", Title = "Giới Thiệu", Routing = "gioi-thieu", Class = "active", Child = null };
                            Navigations.Add(Navigation);
                            NavigationChild = new NavigationChild
                            {
                                Code = "21",
                                Title = "Phòng Cao Cấp",
                                Routing = "phong-cao-cap"
                            };
                            NavigationChilds.Add(NavigationChild);
                            NavigationChild = new NavigationChild
                            {
                                Code = "21",
                                Title = "Phòng Vip",
                                Routing = "phong-vip"
                            };
                            NavigationChilds.Add(NavigationChild);
                            Navigation = new Navigation { Code = "2", Title = "Phòng Nghỉ", Routing = "", Class = "", Child = NavigationChilds };
                            Navigations.Add(Navigation);
                            ViewBag.Navigations = Navigations;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                HttpCookie Language = new HttpCookie("NOPLanguage");
                Language.Value = "en";
                System.Web.HttpContext.Current.Response.Cookies.Add(Language);
                var Navigations = new List<Navigation>();
                var NavigationChilds = new List<NavigationChild>();
                var NavigationChild = new NavigationChild();
                var Navigation = new Navigation { Code = "1", Title = "About", Routing = "gioi-thieu", Class = "active", Child = null };
                Navigations.Add(Navigation);
                NavigationChild = new NavigationChild
                {
                    Code = "21",
                    Title = "Phòng Cao Cấp",
                    Routing = "phong-cao-cap"
                };
                NavigationChilds.Add(NavigationChild);
                NavigationChild = new NavigationChild
                {
                    Code = "21",
                    Title = "Phòng Vip",
                    Routing = "phong-vip"
                };
                NavigationChilds.Add(NavigationChild);
                Navigation = new Navigation { Code = "2", Title = "Phòng Nghỉ", Routing = "", Class = "", Child = NavigationChilds };
                Navigations.Add(Navigation);
                ViewBag.Navigations = Navigations;
            }
            return PartialView();
        }


        public ActionResult p_Footer()
        {
            return PartialView();
        }
    }
}