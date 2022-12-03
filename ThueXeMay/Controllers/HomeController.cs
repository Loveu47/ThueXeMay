using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThueXeMay.Models;
namespace ThueXeMay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        RENT_MOTOREntities myObj = new RENT_MOTOREntities();
        public ActionResult Layout_Contact()
        {
            var items = myObj.contacts.Take(1);
            return PartialView("Layout_Contact", items);
        }
    }
}
