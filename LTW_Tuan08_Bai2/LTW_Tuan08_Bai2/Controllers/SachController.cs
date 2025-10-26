using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Tuan08_Bai2.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data.Entity;
using System.Data;

namespace LTW_Tuan08_Bai2.Controllers
{
    public class SachController : Controller
    {
        qltvEntities1 data = new qltvEntities1();
        // GET: /Sach/
        public ActionResult DMSach(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var dsSach = data.saches
                             .OrderBy(s => s.tenSach)
                             .ToPagedList(pageNumber, pageSize);
            return View(dsSach);
        }

        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(data.chudes.ToList().OrderBy(n => n.tenChuDe), "maCD", "tenChuDe");
            ViewBag.MaNXB = new SelectList(data.nhaxuatbans.ToList().OrderBy(n => n.tenNXB), "maNXB", "tenNXB");
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(sach SachID, HttpPostedFileBase fileUpload)
        {

            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                ViewBag.MaCD = new SelectList(data.chudes.OrderBy(n => n.tenChuDe).ToList(), "maCD", "tenChuDe", SachID.maCD);
                ViewBag.MaNXB = new SelectList(data.nhaxuatbans.OrderBy(n => n.tenNXB).ToList(), "maNXB", "tenNXB", SachID.maNXB);
                return View(SachID);
            }

            if (ModelState.IsValid)
            {

                var filename = Path.GetFileName(fileUpload.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/images"), filename);

                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại !";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }

                SachID.anhBia = filename;

                data.saches.Add(SachID);
                data.SaveChanges();
                return RedirectToAction("DMSach");
            }

            ViewBag.MaCD = new SelectList(data.chudes.OrderBy(n => n.tenChuDe).ToList(), "maCD", "tenChuDe", SachID.maCD);
            ViewBag.MaNXB = new SelectList(data.nhaxuatbans.OrderBy(n => n.tenNXB).ToList(), "maNXB", "tenNXB", SachID.maNXB);


            return View(SachID);
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            sach sach_detail = data.saches.Where(row => row.maSach == ID).FirstOrDefault();
            ViewBag.maSach = sach_detail.maSach;
            if (sach_detail == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach_detail);
        }


        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var sach_delete = data.saches
                .Include(s => s.chude)
                .Include(s => s.nhaxuatban)
                .FirstOrDefault(s => s.maSach == ID);

            if (sach_delete == null)
            {
                return HttpNotFound();
            }

            return View(sach_delete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ID)
        {
            var sach_delete = data.saches.Find(ID);
            if (sach_delete == null)
            {
                return HttpNotFound();
            }

            if (!string.IsNullOrEmpty(sach_delete.anhBia))
            {
                var path = Server.MapPath("~/Content/images/" + sach_delete.anhBia);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            data.saches.Remove(sach_delete);
            data.SaveChanges();

            return RedirectToAction("DMSach");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sach_edit = data.saches.FirstOrDefault(m => m.maSach == id);

            if (sach_edit == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ViewBag.MaCD = new SelectList(data.chudes.OrderBy(n => n.tenChuDe).ToList(), "maCD", "tenChuDe", sach_edit.maCD);
            ViewBag.MaNXB = new SelectList(data.nhaxuatbans.OrderBy(n => n.tenNXB).ToList(), "maNXB", "tenNXB", sach_edit.maNXB);

            return View(sach_edit);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(sach sach_edit, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaCD = new SelectList(data.chudes.OrderBy(n => n.tenChuDe).ToList(), "maCD", "tenChuDe", sach_edit.maCD);
            ViewBag.MaNXB = new SelectList(data.nhaxuatbans.OrderBy(n => n.tenNXB).ToList(), "maNXB", "tenNXB", sach_edit.maNXB);

            if (!ModelState.IsValid)
            {
                return View(sach_edit);
            }

            if (fileUpload != null)
            {
                var filename = Path.GetFileName(fileUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), filename);

                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }

                sach_edit.anhBia = filename;
            }

            data.Entry(sach_edit).State = EntityState.Modified;
            data.SaveChanges();

            return RedirectToAction("DMSach");
        }
    }
}
