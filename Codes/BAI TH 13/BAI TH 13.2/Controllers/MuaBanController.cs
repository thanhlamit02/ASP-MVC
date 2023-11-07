using BAI_TH_13._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAI_TH_13._2.Controllers
{
    public class MuaBanController : Controller
    {
        // GET: MuaBan
        // GET: Sanpham 
        public ActionResult Index()
        {
            List<Sanpham> ds = new List<Sanpham>();
            ds.Add(new Sanpham("SP01", "Iphone 14 pro 512GB", "iphone-14-pro-tim.jpg", 1000));
            ds.Add(new Sanpham("SP02", "Vsmart Aren", "vsmart-aren.jpg", 400));
            ds.Add(new Sanpham("SP03", "Realme", "realme-c11-2021-blue-1.jpg", 350));
            Session["hanghoa"] = ds;
            return View(ds);
        }

        public ActionResult Chonmua(SanphamMua spm)
        {
            List<SanphamMua> dsmua = (List<SanphamMua>)Session["giohang"];

            if (dsmua == null)
            {
                dsmua = new List<SanphamMua>();
            }
            if (dsmua.Contains(spm))
            {
                int index = dsmua.IndexOf(spm);
                dsmua[index].soluong++;
            }
            else
            {
                spm.soluong = 1;
                dsmua.Add(spm);
            }
            Session["giohang"] = dsmua;
            return View();
        }
        public ActionResult XoaSanpham(string masp)
        {
            List<SanphamMua> dsmua = (List<SanphamMua>)Session["giohang"];
            SanphamMua s = new SanphamMua();
            s.masp = masp;
            int index = dsmua.IndexOf(s);
            s = dsmua[index];
            dsmua.Remove(s);
            Session["giohang"] = dsmua;
            return View("Chonmua");
        }

        public ActionResult XemGioHang()
        {
            List<SanphamMua> dsmua = (List<SanphamMua>)Session["giohang"];
            return View(dsmua);
        }

        public ActionResult Datmua()
        {
            List<SanphamMua> dsm = (List<SanphamMua>)Session["giohang"];
            Session.Remove("giohang");
            return View(dsm);
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<SanphamMua> dsmua = (List<SanphamMua>)Session["giohang"];
            dsmua.Clear();

            Session["giohang"] = dsmua;
            return View("XemGioHang");
        }
    }
}