using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_5._2_ASP_MVC.Models
{
    public class MailInfo
    {
        public string From { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Subject { get; set; } 
        public string Body { get; set; }
    }
}