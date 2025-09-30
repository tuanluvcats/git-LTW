using LTW_Tuan05_Bai2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Tuan05_Bai2.Models;
using LTW_Tuan05_Bai2.ViewModels;


namespace LTW_Tuan05_Bai2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DuLieu csdl = new DuLieu();
        public ActionResult HienThiLoai()
        {
            List<Loai> ds = csdl.dsLoai;
            return View(ds);
        }

        public ActionResult HienThiSanPham()
        {
            List<SanPham> dssp = csdl.dsSP;
            return View(dssp);
        }
        [HttpGet]
        public ActionResult SanPhamTheoLoai(int? id)
        {
            var vm = new DuLieuViewModel
            {
                DSLoai = csdl.dsLoai,
                ChonLoai = id.HasValue ? csdl.dsLoai.FirstOrDefault(l => l.MaLoai == id.Value) : null,
                DSSanPham = id.HasValue
                    ? csdl.dsSP.Where(sp => sp.MaLoai == id.Value).ToList()
                    : new List<SanPham>()
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult TimKiemSanPham(string keyword)
        {
            var dsSP = csdl.dsSP.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                dsSP = dsSP.Where(sp => sp.TenSP.ToLower().Contains(keyword.ToLower()));
            }

            ViewBag.Keyword = keyword;                 
            ViewBag.SoLuong = dsSP.Count();          

            return View(dsSP.ToList());              
        }
        [HttpGet]
        public ActionResult PhanLoaiSP(int? id)
        {
            var vm = new DuLieuViewModel
            {
                DSLoai = csdl.dsLoai,
                ChonLoai = id.HasValue ? csdl.dsLoai.FirstOrDefault(l => l.MaLoai == id.Value) : null,
                DSSanPham = id.HasValue
                    ? csdl.dsSP.Where(sp => sp.MaLoai == id.Value).ToList()
                    : new List<SanPham>()
            };

            return View(vm);
        }
    }
}