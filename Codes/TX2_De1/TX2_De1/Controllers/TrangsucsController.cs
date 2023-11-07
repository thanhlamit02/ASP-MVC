using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TX2_De1.Models;

namespace TX2_De1.Controllers
{
    public class TrangsucsController : Controller
    {
        private QLSanPham2DB db = new QLSanPham2DB();

        // GET: Trangsucs
        public ActionResult Index()
        {
            var trangsucs = db.Trangsucs.Include(t => t.Danhmuc);
            return View(trangsucs.ToList());
        }

        // GET: Trangsucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trangsuc trangsuc = db.Trangsucs.Find(id);
            if (trangsuc == null)
            {
                return HttpNotFound();
            }
            return View(trangsuc);
        }

        // GET: Trangsucs/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc");
            return View();
        }

        // POST: Trangsucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTs,TenTs,Anh,Mota,Soluong,Giatien,MaDanhmuc")] Trangsuc trangsuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trangsuc.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        trangsuc.Anh = FileName;
                    }
                    db.Trangsucs.Add(trangsuc);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", trangsuc.MaDanhmuc);
                return View(trangsuc);
            }
        }

        // GET: Trangsucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trangsuc trangsuc = db.Trangsucs.Find(id);
            if (trangsuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", trangsuc.MaDanhmuc);
            return View(trangsuc);
        }

        // POST: Trangsucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTs,TenTs,Anh,Mota,Soluong,Giatien,MaDanhmuc")] Trangsuc trangsuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trangsuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", trangsuc.MaDanhmuc);
            return View(trangsuc);
        }

        // GET: Trangsucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trangsuc trangsuc = db.Trangsucs.Find(id);
            if (trangsuc == null)
            {
                return HttpNotFound();
            }
            return View(trangsuc);
        }

        // POST: Trangsucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trangsuc trangsuc = db.Trangsucs.Find(id);
            db.Trangsucs.Remove(trangsuc);
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
