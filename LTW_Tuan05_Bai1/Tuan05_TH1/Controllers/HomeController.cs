using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan05_TH1.Models;
using Tuan05_TH1.ViewModels;
namespace Tuan05_TH1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DuLieu csdl = new DuLieu();
        public ActionResult HienThiNhanVien()
        {
            List<Employee> ds = csdl.dsNV;
            return View(ds);
        }

        public ActionResult HienThiPhongBan()
        {
            List<Deparment> dspb = csdl.dsPB;
            return View(dspb);
        }

        [HttpGet]
        public ActionResult ChiTietPhongBan(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("HienThiPhongBan");
            }

            csdl.HienThiDuLieu(id.Value);
            Deparment result = csdl.PB;
            List<Employee> ds = csdl.LayDSNVTheoPB(id.Value);

            DuLieuViewModel vm = new DuLieuViewModel
            {
                PB = result,
                dsNV = ds
            };

            return View(vm);
        }
    }
}
