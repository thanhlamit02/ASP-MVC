using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTTX_1.Models
{
    public class Sanpham
    {
        public string masp { get; set; }
        public string tensp { get; set; }
        public int soluong { get; set; }    
        public double giatien { get; set; }
        public string giamgia { get; set; }

        public double thanhtien { get; set; }

        public Sanpham() { }
        public Sanpham(string masp, string tensp, int soluong, double giatien, string giamgia)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.soluong = soluong;
            this.giatien = giatien;
            this.giamgia = giamgia;
            if(this.giamgia == "Có")
            {
                this.thanhtien = this.soluong * this.giatien * 0.9;   
            }
            else
            {
                this.thanhtien = this.soluong * this.giatien;
            }
        }
    }
}