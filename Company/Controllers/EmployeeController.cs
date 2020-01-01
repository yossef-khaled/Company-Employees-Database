using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.Models;

namespace Company.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDB DB;
        public EmployeeController()
        {
            DB = new CompanyDB();
        }
        [HttpGet]
        public ActionResult EmployeeIndex()
        {
            var Employees_Table = DB.Employees.ToList();
            return View(Employees_Table);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            DB.Employees.Add(employee);
            DB.SaveChanges();
            return RedirectToAction("EmployeeIndex");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var Emp = DB.Employees.Single(ww => ww.EmployeeID == ID);
            return View(Emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            int EmpID = employee.EmployeeID;
            DB.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("EmployeeIndex");
        }
        public ActionResult Delete(int ID)
        {
            var Emp = DB.Employees.Single(ww => ww.EmployeeID == ID);
            DB.Employees.Remove(Emp);
            DB.SaveChanges();
            return RedirectToAction("EmployeeIndex");
        }
    }
}