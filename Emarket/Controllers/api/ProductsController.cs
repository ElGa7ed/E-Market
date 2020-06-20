using Emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emarket.Controllers.Api
{
    public class ProductsController : ApiController
    {
           private ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
           
            var product = _context.Products.SingleOrDefault(p => p.id == id );
            var cindb = _context.Categories.Single(c => c.id == product.categoryid);
            cindb.number_of_products--;
            if (product == null)
                return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
