using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThueXeMay.Models;

namespace ThueXeMay.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        RENT_MOTOREntities myObj = new RENT_MOTOREntities();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mail()
        {
            var item = myObj.mails.Where(i => i.IsRead == false).OrderByDescending(i => i.ContactId).ToList();
            ViewBag.Mail = item.Count();
            return PartialView("_Mail", item);
        }
        public ActionResult AllMail()
        {
            var item = myObj.mails.OrderByDescending(i => i.ContactId).ToList();
            return View("AllMail", item);
        }
        public ActionResult DeleteMail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mail mail = myObj.mails.Find(id);
            if (mail == null)
            {
                return HttpNotFound();
            }
            myObj.mails.Remove(mail);
            myObj.SaveChanges();
            ThongBao("Xoá thành công!!!", "success");
            return RedirectToAction("AllMail");
        }

        public ActionResult MailDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mail type = myObj.mails.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            type.IsRead= true;
            myObj.SaveChanges();
            return View("Mail", type);
        }
        public ActionResult ContactAdmin()
        {
            var item = myObj.contacts.Single();
            return View("ContactAdmin", item);
        }
        public ActionResult EditContact(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact contact = myObj.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContact([Bind(Include = "id,address,phone,email,facebook_link")] contact contact)
        {
            if (ModelState.IsValid)
            {
                myObj.Entry(contact).State = EntityState.Modified;
                myObj.SaveChanges();
                return RedirectToAction("ContactAdmin");
            }
            return View(contact);
        }
    }
}