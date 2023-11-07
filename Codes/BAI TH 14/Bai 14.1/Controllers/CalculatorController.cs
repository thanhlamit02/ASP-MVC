using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_14._1.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        // Action method để xử lý yêu cầu tính toán
        [HttpPost]
        public JsonResult Calculate(double num1, double num2, string operation)
        {
            double result = 0;

            // Thực hiện phép tính tương ứng
            switch (operation)
            {
                case "add":
                    result = num1 + num2;
                    break;
                case "subtract":
                    result = num1 - num2;
                    break;
                case "multiply":
                    result = num1 * num2;
                    break;
                case "divide":
                    result = num1 / num2;
                    break;
            }

            // Trả về kết quả dưới dạng JSON
            return Json(result);
        }
    }
}