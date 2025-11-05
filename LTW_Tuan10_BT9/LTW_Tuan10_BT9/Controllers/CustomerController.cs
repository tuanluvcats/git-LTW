using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Tuan10_BT9.Models;

namespace LTW_Tuan10_BT9.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        db_ThuvienEntities data = new db_ThuvienEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string TaiKhoan, string MatKhau, string submitButton)
        {
            if (submitButton == "Đăng ký")
            {
                return RedirectToAction("Register");
            }

            var kh = data.KhachHangs
                         .FirstOrDefault(k => k.TaiKhoan == TaiKhoan && k.MatKhau == MatKhau);

            if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                return View("LoginSuccess", kh); 
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var exist = data.KhachHangs.FirstOrDefault(k => k.TaiKhoan == kh.TaiKhoan);
                if (exist != null)
                {
                    ViewBag.ThongBao = "Tài khoản đã tồn tại!";
                    return View();
                }

                data.KhachHangs.Add(kh);
                data.SaveChanges();
                ViewBag.ThongBao = "Đăng ký thành công! Hãy đăng nhập.";
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
