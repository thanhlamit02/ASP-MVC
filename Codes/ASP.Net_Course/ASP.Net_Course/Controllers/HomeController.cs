using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Net_Course.Models;

namespace ASP.Net_Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MayTinh().khoiTao5May());
        }

        public ActionResult giaThapNhat()
        {
            var ds2May = new MayTinh().khoiTao5May();
            object ds = ds2May.OrderBy(m => m.giaBan)
                .Take(2);
            return View(ds2May);
        }
    }
}