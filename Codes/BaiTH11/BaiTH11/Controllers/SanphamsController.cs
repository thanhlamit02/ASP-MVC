using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTH11.Models;
using PagedList;

namespace BaiTH11.Controllers
{
    public class SanphamsController : Controller
    {
        private readonly VatDungDB db = new VatDungDB();

        // GET: Sanphams
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            // Các biến sắp xếp
            ViewBag.CurrentSort = sortOrder;

            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "Gia" ? "gia_desc" : "Gia";

            // Lấy giá trị của bộ lọc dữ liệu hiện tại
            if (searchString != null)
            {
                page = 1; // Trang đầu tiên
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            // Lấy danh sách hàng
            var hangs = db.Sanphams.Select(h => h);

            // Lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                hangs = hangs.Where(p => p.Tenvd.Contains(searchString));
            }

            // Sắp xếp
            
            switch (sortOrder)
            {
                case "name_desc":
                    hangs = hangs.OrderByDescending(s => s.Tenvd);
                    break;
                case "Gia":
                    hangs = hangs.OrderBy(s => s.Giatien);
                    break;
                case "gia_desc":
                    hangs = hangs.OrderByDescending(s => s.Giatien);
                    break;
                default:
                    hangs = hangs.OrderBy(s => s.Tenvd);
                    break;
            }
            

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(hangs.ToPagedList(pageNumber, pageSize));
        }


        // GET: Sanphams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: Sanphams/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc");
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mavd,Tenvd,TenAnh,Mota,Giatien,Soluong,MaDanhmuc")] Sanpham sanpham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanpham.TenAnh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        sanpham.TenAnh = FileName;
                    }
                    db.Sanphams.Add(sanpham);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                ViewBag.MaDanhMuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
                return View(sanpham);
            }
        }

        // GET: Sanphams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mavd,Tenvd,TenAnh,Mota,Giatien,Soluong,MaDanhmuc")] Sanpham sanpham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        sanpham.TenAnh = FileName;
                    }
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;
                ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
                return View(sanpham);
            }
        }

        // GET: Sanphams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            try
            {
                db.Sanphams.Remove(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi!" + ex.Message;
                return View("Delete", sanpham);
            }
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
