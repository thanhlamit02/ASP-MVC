using Bai_4._3_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_4._3_ASP_MVC.Controllers
{
    public class DiemThiController : Controller
    {
        // GET: DiemThi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TinhDiemThi(SinhVien sv)
        {
            double  tongDiem = 0, diemKV = 0;

            //Xét điều kiện điểm khu vực
            if(sv.khuVuc == "Khu vực A")
            {
                diemKV = 1;
            }

            else if(sv.khuVuc == "Khu vực B")
            {
                diemKV = 2;
            }
            
            else 
            { 
                diemKV = 3;
            }

            //Xét điểm
            if(sv.kiemTra == "on")
            {
                tongDiem = sv.diemToan + sv.diemLy + sv.diemHoa + diemKV + 1;
            }

            

            string ketQua = "";
            if (tongDiem >= 20)
                ketQua = "Đỗ đại học";
            else if (tongDiem >= 15)
                ketQua = "Đỗ cao đẳng";
            else if (tongDiem >= 10)
                ketQua = "Đỗ trung cấp";
            else
                ketQua = "Thi trượt";

            ViewBag.ten = sv.hoTen;
            ViewBag.tongDiem = tongDiem;
            ViewBag.kq = ketQua;

            return View();
        }
    }
}