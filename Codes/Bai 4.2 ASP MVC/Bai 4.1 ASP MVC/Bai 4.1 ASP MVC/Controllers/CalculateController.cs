using Bai_4._1_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_4._1_ASP_MVC.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        public ActionResult Index(Calculate c)
        {
            ViewBag.KetQua = c.Tinh();
            return View();
        }
    }
}