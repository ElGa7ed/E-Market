using Emarket.Models;
using Emarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Emarket.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string query = null)
        {
            var upcomingProducts = _context.Products.Include(p => p.category);



            if (!String.IsNullOrWhiteSpace(query))
            {
                upcomingProducts = upcomingProducts.Where(p =>
                       p.name.Contains(query) ||
                       p.category.name.Contains(query));

            }




            var viewModel = new ProductViewModel()
            {
                UpcomingProducts = upcomingProducts,

                SearchTerm = query


            };
            return View(viewModel);
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
        public ActionResult Cart()
        {
            var cart = _context.Cart.Include(c=>c.product).ToList();

            return PartialView("Cart",cart);
        }
    }
}