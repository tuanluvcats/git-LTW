using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Sql;
using LTW_Tuan06_Bai1.Models;
using LTW_Tuan06_Bai1.ViewModels;

namespace LTW_Tuan06_Bai1.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            List<SanPham> ds = csdl.dsSP;
            return View(ds);
        }

        [HttpGet]
        public ActionResult SanPham(string maL = null)
        {
            var viewModel = new ds_SanPham_ViewModel
            {
                Loais = csdl.dsLoai,
                SanPhams = string.IsNullOrEmpty(maL)
                    ? csdl.dsSP
                    : csdl.LaySPTheoLoai(maL)
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ChiTiet(string maSP)
        {
            var sp = csdl.LaySPTheoMa(maSP);
            return View(sp);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string tenKH, string matKhau)
        {
            var kh = csdl.KiemTraDangNhap(tenKH, matKhau);

            if (kh != null)
            {
                Session["TenKhachHang"] = kh.TenKhachHang;
                Session["MaKhachHang"] = kh.MaKhachHang;

                return RedirectToAction("SanPham", "Product");
            }
            else
            {
                ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu!";
                return View();
            }
        }

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(string tenKH, string soDT, string matKhau, string nhapLaiMK)
        {
            if (matKhau != nhapLaiMK)
            {
                ViewBag.ThongBao = "Mật khẩu xác nhận không khớp!";
                return View();
            }

            var kh = new KhachHang
            {
                TenKhachHang = tenKH,
                SoDienThoai = soDT,
                MatKhau = matKhau
            };

            bool kq = csdl.ThemKhachHang(kh);

            if (kq)
            {
                ViewBag.ThongBao = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToAction("DangNhap", "Product");
            }
            else
            {
                ViewBag.ThongBao = "Có lỗi xảy ra khi đăng ký. Vui lòng thử lại!";
                return View();
            }
        }

    }
}
