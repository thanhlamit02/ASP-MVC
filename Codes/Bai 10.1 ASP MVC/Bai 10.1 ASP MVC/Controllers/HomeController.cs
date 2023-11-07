using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai_10._1_ASP_MVC.Models;
using PagedList;

namespace Bai_10._1_ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        private FShopDB db = new FShopDB();
        public ActionResult Index()
        {
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

        public ActionResult DisplaySuplier(int? page)
        {
            var supplies = db.Nha_CC.Select(s => s);

            // Sắp xếp trước khi phân trang
            supplies = supplies.OrderBy(s => s.MaNCC);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(supplies.ToPagedList(pageNumber, pageSize));
        }
    }
}