using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai12.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            String username = Request["username"];
            String password = Request["password"];

            if (username != null && password != null && username.CompareTo(password) == 0)
            {
                HttpCookie account = new HttpCookie("account");
                HttpContext.Response.Cookies.Remove("account");
                account.Value = username + password;
                HttpContext.Response.SetCookie(account);
                return RedirectToAction("Index", "TinhBinhPhuong");
            }
            ViewBag.msg = "Đăng nhập không thành công";
            return View("Index");

        }
    }
}