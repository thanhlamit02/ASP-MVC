﻿using System.Web;
using System.Web.Mvc;

namespace BaiTH_6_ASP_MVC_Razor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
