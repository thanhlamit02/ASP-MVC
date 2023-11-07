using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bai_5._3_ASP_MVC.Models;

namespace Bai_5._3_ASP_MVC.Controllers
{
    public class SendMailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Bai_5._3_ASP_MVC.Models.MailInfo model, HttpPostedFileBase file)
        {
            MailMessage mm = new MailMessage(model.From, model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            if(file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                mm.Attachments.Add(new Attachment(file.InputStream, fileName));
            }

            // Upload files
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("laotuong2002@gmail.com", "kdcebtadpiyyajwt"); //Nhập tài khoản, mật khẩu gmail
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail was sent successfully";
            return View();
        }
    }
}