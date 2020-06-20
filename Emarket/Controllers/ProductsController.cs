using Emarket.Models;
using Emarket.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Emarket.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Products
        public ActionResult Create()
        {
            var viewmodel = new ProductFormViewModel
            {
                Categories = _context.Categories.ToList(),
                Heading = "Add Product"

            };
            return View("ProductForm",viewmodel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProductFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Categories = _context.Categories.ToList();
                return View("ProductForm", viewmodel);
            }
            if (viewmodel.ImageUpload != null)
            {
                var path = Path.Combine(Server.MapPath("~/Images"), viewmodel.ImageUpload.FileName);
                viewmodel.ImageUpload.SaveAs(path);
                viewmodel.image = viewmodel.ImageUpload.FileName;

            }


            var product = new Product()
            {
                name = viewmodel.name,
                description = viewmodel.description,
                image = viewmodel.image,
                categoryid = viewmodel.category,
                price = viewmodel.price
            };


            var cindb = _context.Categories.Single(c => c.id == product.categoryid);
            cindb.number_of_products++;

          _context.Products.Add(product);
         _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {

            var products = _context.Products.Single(p => p.id == id );

            var viewmodel = new ProductFormViewModel()
            {
                id = id,
                Categories = _context.Categories.ToList(),
                name = products.name,
                description = products.description,
                price = products.price,
                category = products.categoryid,
                image = products.image,
                Heading = "Edit Product"
            };
            return View("ProductForm", viewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductFormViewModel viewmodel)
        {
            


            var product = _context.Products
                .Single(p => p.id == viewmodel.id );

            var cindb = _context.Categories.Single(c => c.id == product.categoryid);
            if (cindb.number_of_products > 0)
            {
                cindb.number_of_products--;
            }
            if (!ModelState.IsValid)
            {
                viewmodel.Categories = _context.Categories.ToList();
                return View("ProductForm", viewmodel);

            }

           
           
           

            product.name = viewmodel.name;
            product.description = viewmodel.description;
            product.price = viewmodel.price;
            product.image = viewmodel.image;
            product.categoryid = viewmodel.category;


            var oldpath = Path.Combine(Server.MapPath("~/Images"), product.image);
            if (viewmodel.ImageUpload != null)
            {
                System.IO.File.Delete(oldpath);
                var path = Path.Combine(Server.MapPath("~/Images"), viewmodel.ImageUpload.FileName);
                viewmodel.ImageUpload.SaveAs(path);

                product.image = viewmodel.ImageUpload.FileName;
            }
            var cnew = _context.Categories.Single(c => c.id == viewmodel.category);
            cnew.number_of_products++;
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.category).SingleOrDefault(n => n.id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        public ActionResult Search(ProductViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

    }
}