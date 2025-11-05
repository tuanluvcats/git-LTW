using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Tuan10_BT9.Models;

namespace LTW_Tuan10_BT9.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        db_ThuvienEntities data = new db_ThuvienEntities();

        public ActionResult Main(string search)
        {
            var dsSach = from s in data.Saches
                         select s;

            if (!String.IsNullOrEmpty(search))
            {
                dsSach = dsSach.Where(s => s.TenSach.Contains(search) || s.MoTa.Contains(search));
                ViewBag.Search = search;
            }
            else
            {
                dsSach = dsSach.OrderByDescending(s => s.NgayCapNhat).Take(5);
            }

            return View(dsSach.ToList());
        }


        public ActionResult DSMenu_ChuDe()
        {
            List<ChuDe> dsCD = data.ChuDes.Take(10).ToList();
            return PartialView(dsCD);
        }

        public ActionResult HTDanhSachTheoChuDe(string id)
        {
            var dsSach = data.Saches
                             .Where(s => s.MaChuDe == id)
                             .ToList();

            var chude = data.ChuDes.FirstOrDefault(c => c.MaChuDe == id);
            if (chude != null)
                ViewBag.ChuDe = chude.TenChuDe;
            else
                ViewBag.ChuDe = "";

            return View(dsSach);
        }
        public ActionResult DSMenu_NXB()
        {
            List<NhaXuatBan> dsNXB = data.NhaXuatBans.Take(10).ToList();
            return PartialView(dsNXB);
        }
        public ActionResult HTDanhSachTheoNXB(string id)
        {
            var dsSach = data.Saches
                             .Where(s => s.MaNXB == id)
                             .ToList();

            var nxb = data.NhaXuatBans.FirstOrDefault(c => c.MaNXB == id);
            if (nxb != null)
                ViewBag.NhaXuatBan = nxb.TenNXB;
            else
                ViewBag.NhaXuatBan = "";

            return View(dsSach);
        }
    }
}
