using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Tuan10_BT9.Models;

namespace LTW_Tuan10_BT9.Controllers
{
    public class DetailsController : Controller
    {
        //
        // GET: /Details/

        db_ThuvienEntities data = new db_ThuvienEntities();
        public ActionResult Detail(string id)
        {
            Sach sach = data.Saches.FirstOrDefault(s => s.MaSach == id);

            if (sach == null)
            {
                return HttpNotFound("Không tìm thấy sách!");
            }

            var tacGias = sach.ThamGias
                               .Select(t => t.TacGia.TenTacGia)
                               .ToList();

            ViewBag.TacGias = tacGias;

            var cungChuDe = data.Saches
                    .Where(s => s.MaChuDe == sach.MaChuDe && s.MaSach != sach.MaSach)
                    .Take(4) 
                    .ToList();
            ViewBag.CungChuDe = cungChuDe;

            var cungNXB = data.Saches
                              .Where(s => s.MaNXB == sach.MaNXB && s.MaSach != sach.MaSach)
                              .Take(4)
                              .ToList();
            ViewBag.CungNXB = cungNXB;
            return View(sach);
        }
    }
}
