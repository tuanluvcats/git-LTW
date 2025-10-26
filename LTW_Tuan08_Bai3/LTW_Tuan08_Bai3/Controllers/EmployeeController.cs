using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Tuan08_Bai3.Models;
using System.Data.Entity;
using System.Data;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace LTW_Tuan08_Bai3.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        QL_NhanSuEntities data = new QL_NhanSuEntities();

        public ActionResult Index(int? page, int? deptId)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ViewBag.Departments = data.tbl_Department.OrderBy(d => d.Name).ToList();
            ViewBag.SelectedDeptId = deptId;

            var dsEmp = data.tbl_Employee
                            .Include(e => e.tbl_Department)
                            .OrderBy(e => e.Id)
                            .AsQueryable();

            if (deptId.HasValue)
            {
                dsEmp = dsEmp.Where(e => e.DeptId == deptId.Value);
            }

            return View(dsEmp.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GenderList = new SelectList(new[] { "Nam", "Nữ" });

            ViewBag.DeptId = new SelectList(data.tbl_Department.OrderBy(d => d.Name), "DeptId", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Employee emp)
        {
            if (ModelState.IsValid)
            {
                data.tbl_Employee.Add(emp);
                data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderList = new SelectList(new[] { "Nam", "Nữ" }, emp.Gender);
            ViewBag.DeptId = new SelectList(data.tbl_Department.OrderBy(d => d.Name), "DeptId", "Name", emp.DeptId);

            return View(emp);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var emp = data.tbl_Employee
                          .Include(e => e.tbl_Department)
                          .FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var emp = data.tbl_Employee.Find(id);
            if (emp == null)
                return HttpNotFound();

            ViewBag.GenderList = new SelectList(new[] { "Nam", "Nữ" }, emp.Gender);
            ViewBag.DeptId = new SelectList(data.tbl_Department.OrderBy(d => d.Name), "DeptId", "Name", emp.DeptId);

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Employee emp)
        {
            if (ModelState.IsValid)
            {
                data.Entry(emp).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderList = new SelectList(new[] { "Nam", "Nữ" }, emp.Gender);
            ViewBag.DeptId = new SelectList(data.tbl_Department.OrderBy(d => d.Name), "DeptId", "Name", emp.DeptId);

            return View(emp);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var emp = data.tbl_Employee
                          .Include(e => e.tbl_Department)
                          .FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var emp = data.tbl_Employee.Find(id);
            if (emp == null)
                return HttpNotFound();

            data.tbl_Employee.Remove(emp);
            data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}