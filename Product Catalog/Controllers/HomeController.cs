using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product_Catalog.Models;

namespace Product_Catalog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);

            return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }

        [Authorize(Roles = "AppAdmin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Admin page.";

            return View();
        }
    }
}