using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}