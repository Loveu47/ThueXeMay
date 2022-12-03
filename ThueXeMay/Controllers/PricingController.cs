using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThueXeMay.Models;
namespace ThueXeMay.Controllers
{
    public class PricingController : Controller
    {
        // GET: Pricing
        public ActionResult Index()
        {
            return View();
        }
        RENT_MOTOREntities myObj = new RENT_MOTOREntities();

        public ActionResult Price_Type()
        {
            var items = myObj.types.ToList();
            return PartialView("Price_Type", items);
        }
        public ActionResult Type(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                var items = myObj.bikes.Where(i => (bool)i.IsActive).ToList();
                return View("TypeCar", items);
            }
            else
            {
                var items = myObj.bikes.Where(i => (bool)i.IsActive).Where(j=>j.type.Equals(type)).ToList();
                return View("TypeCar", items);
            }
        }
    }

}