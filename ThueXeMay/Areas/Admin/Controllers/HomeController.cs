using System;
using System.Collections.Generic;
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
            var item = myObj.mails.Where(i=>i.IsRead == false).OrderByDescending(i=>i.ContactId).ToList();
            ViewBag.Mail = item.Count();
            return PartialView("_Mail", item);
        }
        public ActionResult AllMail()
        {
            var item = myObj.mails.OrderByDescending(i => i.ContactId).ToList();
            return View("AllMail", item);
        }
        public ActionResult DeleteMail(int id)
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
    }
}