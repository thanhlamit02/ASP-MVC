using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai12.Controllers
{
    public class TinhBinhPhuongController : Controller
    {
        // GET: TinhBinhPhuong
        public ActionResult Index()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("account");
            if (cookie == null)
            {
                ViewBag.msg = "Bạn chưa login";
                return View();
            }
            ViewBag.msg = "";
            return View();
        }
    }
}