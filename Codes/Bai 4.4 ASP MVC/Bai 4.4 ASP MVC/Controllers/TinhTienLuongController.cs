using Bai_4._4_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_4._4_ASP_MVC.Controllers
{
    public class TinhTienLuongController : Controller
    {
        // GET: TinhTienLuong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TinhTienLuong(NhanVien nv) {
            double tienLinh = 0, phuCap = 0;
            double NCTL = 0;

            //Xét điều kiện ngày công thực lĩnh
            if(nv.ngayCong < 25)
            {
                NCTL = nv.ngayCong;
            }
            else
            {
                NCTL = (nv.ngayCong - 25) * 2 + 25;
            }

            //Xét phụ cấp với điều kiện là chức vụ
            if(nv.chucVu == "Trưởng phòng")
            {
                phuCap = 500000;
            }
            else
            {
                phuCap = 300000;
            }
            tienLinh = nv.bacLuong * 650000 * NCTL + phuCap;

            ViewBag.maNV = nv.maNV;
            ViewBag.ngayCong = nv.ngayCong;
            ViewBag.tienLinh = tienLinh;
            
            return View();
        }
    }
}