using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThueXeMay.Models;

namespace ThueXeMay.Areas.Admin.Controllers
{
    public class employeesController : BaseController
    {
        private RENT_MOTOREntities db = new RENT_MOTOREntities();

        // GET: Admin/employees
        public ActionResult Index()
        {
            return View(db.employees.ToList());
        }



        // GET: Admin/employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_employee,account,pass,name,fulControl")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }



        // POST: Admin/employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Admin/employees/Delete/5
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult changeControl(int? id)
        {
            employee employee = db.employees.Find(id);
            if(employee.fulControl == true)
            {
                employee.fulControl = false;
            }
            else
            {
                employee.fulControl = true;
            }
            db.SaveChanges();
            return Json(new
            {
                status = employee.fulControl
            });

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
