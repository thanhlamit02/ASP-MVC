using KTTX_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTTX_1.Controllers
{
    public class QuanlySanphamController : Controller
    {
        // GET: QuanlySanpham
        List<Sanpham> ds = new List<Sanpham>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSach()
        {
            Sanpham sp1 = new Sanpham("S01", "Sản phẩm 1", 10, 100, "0");
            ds.Add(sp1);
            Sanpham sp2 = new Sanpham("S02", "Sản phẩm 2", 20, 120, "1");
            ds.Add(sp2);
            Sanpham sp3 = new Sanpham("S03", "Sản phẩm 3", 15, 200, "1");
            ds.Add(sp3);
            Sanpham sp4 = new Sanpham("S04", "Sản phẩm 4", 30, 150, "0");
            ds.Add(sp4);
            Sanpham sp5 = new Sanpham("S05", "Sản phẩm 5", 20, 50, "1");
            ds.Add(sp5);
            return View(ds);

            //Sản phẩm có giá tiền > 100
            List<Sanpham> ds1 = new List<Sanpham>();
            foreach(var item in ds1)
            {
                if(item.giatien > 100)
                {
                    ds1.Add(item);
                }
            }
            return View(ds1);

            //Sản phẩm giảm giá
            List<Sanpham> ds2 = new List<Sanpham>();
            foreach (var item in ds2)
            {
                if (item.giamgia == "1")
                {
                    ds2.Add(item);
                }
            }
            return View(ds2);
        }
        public ActionResult Input()
        {
            return View();
        }

        public ActionResult KetQua(Sanpham sp)
        {
            if (sp.giamgia == "Có")
            {
                sp.thanhtien = sp.soluong * sp.giatien * 0.9;
            }
            else
            {
                sp.thanhtien = sp.soluong * sp.giatien;
            }
            return View(sp);
        }

    }
}