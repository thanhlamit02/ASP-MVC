using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Bai_5._1_ASP_MVC.Models;


namespace Bai_5._1_ASP_MVC.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(FormCollection f) 
        {
            //Lấy thông tin từ input type="file"
            var f_hinh = Request.Files["myfileImage"];

            //Lưu hình về Server
            var path_hinh = Server.MapPath("~/Images/" + f_hinh.FileName);
            f_hinh.SaveAs(path_hinh);

            string path = Server.MapPath("~/StaffInfo.txt");
            string[] info =
            {
                f["txtID"], f["txtName"], f["txtDate"], f["txtSalary"], f_hinh.FileName
            };

            //Ghi file StaffInfo.txt
            System.IO.File.WriteAllLines(path, info);
            return View("Index");
        }

        public ActionResult Open()
        {
            //Đọc lại file từ server
            string path = Server.MapPath("~/StaffInfo.txt");
            string[] info = System.IO.File.ReadAllLines(path);

            Staff s = new Staff();
            s.StaffID = int.Parse(info[0]);
            s.StaffName = info[1];
            s.BirthOfDate = DateTime.Parse(info[2]);
            s.Salary = decimal.Parse(info[3]);
            s.StaffImage = info[4];

            //Chuyển các thông tin sang View từ các biến ViewBag
            ViewBag.id = s.StaffID;
            ViewBag.name = s.StaffName;
            ViewBag.birthday = s.BirthOfDate.ToString("yyyy-MM-dd");
            ViewBag.salary = s.Salary;
            ViewBag.image = "../../Images/" + s.StaffImage;

            return View("Index");
        }
    }
}