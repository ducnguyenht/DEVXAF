﻿using System.Web;
using System.Web.Mvc;

namespace www.galinahotel.com.vn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
