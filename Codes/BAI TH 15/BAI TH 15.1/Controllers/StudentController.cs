using BAI_TH_15._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAI_TH_15._1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            // Tạo một đối tượng Student trống để truyền vào View
            var student = new Student();
            return View(student);
        }

        // Action method để xử lý yêu cầu gửi đi
        [HttpPost]
        public ActionResult Index(Student student)
        {
            // Kiểm tra xem dữ liệu đã hợp lệ hay chưa
            if (ModelState.IsValid)
            {
                // Hiển thị thông tin sinh viên ra màn hình
                return View("Result", student);
            }
            else
            {
                // Nếu dữ liệu không hợp lệ, hiển thị lại form nhập thông tin
                return View(student);
            }
        }

        // Action method để lấy danh sách huyện theo tỉnh sử dụng Ajax
        public JsonResult GetDistricts(string province)
        {
            // Truy vấn CSDL hoặc lấy dữ liệu từ nguồn khác để lấy danh sách huyện
            var districts = new List<string>();

            // Trả về danh sách huyện dưới dạng JSON
            return Json(districts, JsonRequestBehavior.AllowGet);
        }
    }
}