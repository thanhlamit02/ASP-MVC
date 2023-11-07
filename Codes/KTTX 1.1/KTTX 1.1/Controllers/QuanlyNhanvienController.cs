using KTTX_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTTX_1._1.Controllers
{
    public class QuanlyNhanvienController : Controller
    {
        // GET: QuanlyNhanvien
        List<Nhanvien> ds = new List<Nhanvien>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSach()
        {
            Nhanvien nv1 = new Nhanvien("NV01", "Nguyễn Vân Anh", "Hà Nội", 15, 200000);
            ds.Add(nv1);
            Nhanvien nv2 = new Nhanvien("NV02", "Lê Thu Hà", "Hải Phòng", 27, 250000);
            ds.Add(nv2);
            Nhanvien nv3 = new Nhanvien("NV03", "Nguyễn Văn Hoàng", "Hà Nội", 18, 250000);
            ds.Add(nv3);
            Nhanvien nv4 = new Nhanvien("NV04", "Trần Thu Hương", "Hải Phòng", 25, 190000);
            ds.Add(nv4);
            Nhanvien nv5 = new Nhanvien("NV05", "Ngô Phương Thảo", "Quảng Ninh", 20, 180000);
            ds.Add(nv5);
            return View(ds);
        }

        public ActionResult Input()
        {
            return View();
        }

        public ActionResult Res(Nhanvien nv)
        {
            nv.tienluong = nv.songaylam * nv.luongngay;
            return View(nv);
        }
    }
}