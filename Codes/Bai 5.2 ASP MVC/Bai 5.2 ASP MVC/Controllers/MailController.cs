using Bai_5._2_ASP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Bai_5._2_ASP_MVC.Controllers
{
    public class MailController : Controller
    {
        // GET: MailInfo
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MailInfo model)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(model.From);
                mail.To.Add(model.To);
                mail.Subject = model.Subject;
                mail.Body = model.Body;
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential("laotuong2002@gmail.com", "kdcebtadpiyyajwt"); //Nhập tài khoản, mật khẩu gmail
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = nc;
                smtp.Send(mail);
            }
            return RedirectToAction("Index", "Mail");
        }
    }
}