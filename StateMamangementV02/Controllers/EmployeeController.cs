using StateMamangementV02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace StateMamangementV02.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext Db;
        public EmployeeController()
        {
            Db = new CompanyContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var emps = Db.Employees.Include(ww => ww.Department).ToList();
            return View(emps);
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateConfirmed(Employee emp)
        {
            Db.Employees.Add(emp);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
        //

        //Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var emp = Db.Employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee newEmp)
        {
            ///
            //var oldemp = Db.Employees.Find(newEmp.Id);
            //oldemp.Name = newEmp.Name;
            //Db.SaveChanges();
            ///
            Db.Entry(newEmp).State = EntityState.Modified;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        //

        //Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            var emp = Db.Employees.Find(id);
            return View(emp);
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var emp = Db.Employees.Find(id);
            Db.Employees.Remove(emp);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}