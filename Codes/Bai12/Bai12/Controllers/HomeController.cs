using Bai12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai12.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie sv = new HttpCookie("sv");
            sv["maSV"] = "2020601227";
            sv["hoTen"] = "Nguyen Thanh Lam";
            sv["queQuan"] = "Nam Dinh";
            sv.Expires.Add(new TimeSpan(0, 5, 0));
            HttpContext.Response.Cookies.Add(sv);
            return View();
        }

        public ActionResult getCookie()
        {
            ViewBag.maSV = HttpContext.Request.Cookies.Get("sv").Values.Get("maSV");
            ViewBag.hoTen = HttpContext.Request.Cookies.Get("sv").Values.Get("hoTen");
            ViewBag.queQuan = HttpContext.Request.Cookies.Get("sv").Values.Get("queQuan");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult ShowUsers()
        //{
        //    List<User> users = (List<User>)Session["users"];
        //    return View(users);
        //}

        public ActionResult Login()
        {
            List<User> accounts = (List<User>)Session["accounts"];
            String username = Request["username"];
            String password = Request["password"];
            Boolean isLogin = false;
            if (accounts == null)
            {
                accounts = new List<User>();
            }
            accounts.ForEach(item =>
            {
                if (item.username.Equals(username) && item.password.Equals(password))
                {
                    isLogin = true;
                }
            });
            Session["error"] = "Login";
            if (isLogin)
            {
                return RedirectToAction("Index", "TinhBinhPhuong");
            }
            Session["error"] = "Login Error";
            return RedirectToAction("Input");

        }

        public ActionResult Input()
        {
            List<User> ds = new List<User>();
            ds.Add(new User("user1", "1", "A", "a@gmail.com"));
            ds.Add(new User("user2", "2", "B", "b@gmail.com"));
            ds.Add(new User("user3", "3", "C", "c@gmail.com"));
            ds.Add(new User("user4", "4", "D", "d@gmail.com"));
            HttpCookie account = new HttpCookie("account");
            HttpContext.Response.Cookies.Remove("account");
            account.Value = ds.ToString();
            HttpContext.Response.SetCookie(account);
            Session["accounts"] = ds;
            return View();
        }
    }
}