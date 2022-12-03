using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThueXeMay.Models;

namespace ThueXeMay.Controllers
{
    public class BlogController : Controller
    {
        // GET: Services
        RENT_MOTOREntities myObj = new RENT_MOTOREntities();
        //public ActionResult Index()
        //{
        //    var items = myObj.blogs.Where(j => (bool)j.IsActive).ToList();
        //    return View(items);
        //}
        public ActionResult Index(int? pageNumber)
        {
            if (pageNumber == null) pageNumber = 1;
            int pageSize = 3;
            var blog = myObj.blogs;
            return
            View(blog.Where(j=>(bool)j.IsActive).ToList().OrderBy(i => i.date).ToPagedList((int)pageNumber,
            pageSize));
        }

        public ActionResult Blog_detail(int idbv=0)
        {
            if (idbv == 0)
            {
                return View("Index");
            }
            else
            {
                var items = myObj.blogs.Where(i => (bool)i.IsActive).Where(j => j.id ==idbv).ToList();
                return View("Details", items);
            }
        }
        public ActionResult Blog_other(int id)
        {
            var items = myObj.blogs.Where(i => (bool)i.IsActive).Where(j=>j.id != id).ToList();
            return PartialView("Blog_other", items);
        }
    }
}
