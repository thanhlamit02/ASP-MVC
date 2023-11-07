using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_4._1_ASP_MVC.Models
{
    public class Calculate
    {
        public double soA { get; set; }
        public double soB { get; set; }
        public string Phep { get; set; }

        public double Tinh()
        {
            double ketqua = 0;

            if (Phep == "+")
            {
                ketqua = soA + soB;
            }
            else if (Phep == "-")
            {
                ketqua = soA - soB;
            }
            else if (Phep == "*")
            {
                ketqua = soA * soB;
            }
            else if (Phep == "/") 
            {
                ketqua = soA / soB;
            }
             return ketqua;
        }
    }
}