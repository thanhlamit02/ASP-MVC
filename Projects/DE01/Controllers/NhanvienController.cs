using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DE01.Models;

namespace DE01.Controllers
{
    public class NhanvienController : Controller
    {
        private Model1 db = new Model1();

        [ChildActionOnly]

        public PartialViewResult DanhSachPhong()
        {
            var list = db.Phong.ToList();
            return PartialView(list);
        }
        [Route("nhanViens/nhanVienByPhong/{Maphong}")]
        public ActionResult HienThiListTheoPhong(int Maphong)
        {
            var list = db.NhanVien.Where(p => p.Maphong == Maphong).ToList();
            return View(list);
        }

        // GET: Nhanvien
        public ActionResult Index()
        {
            var nhanVien = db.NhanVien.Include(n => n.Phong);
            return View(nhanVien.ToList());
        }
        // GET: Nhanvien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Nhanvien/Create
        public ActionResult Create()
        {
            ViewBag.Maphong = new SelectList(db.Phong, "Maphong", "Tenphong");
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(NhanVien nhanVien)
        {
            try
            {
                db.NhanVien.Add(nhanVien);
                db.SaveChanges();
                return Json(new { result = true, JsonRequestBehavior.AllowGet });
            } catch(Exception er)
            {
                return Json(new { result = false, error = er.Message });
            }
        }

        // GET: Nhanvien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maphong = new SelectList(db.Phong, "Maphong", "Tenphong", nhanVien.Maphong);
            return View(nhanVien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manv,Hoten,Tuoi,Diachi,Luong,Maphong")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maphong = new SelectList(db.Phong, "Maphong", "Tenphong", nhanVien.Maphong);
            return View(nhanVien);
        }

        // GET: Nhanvien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanVien.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanVien.Find(id);
            db.NhanVien.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
