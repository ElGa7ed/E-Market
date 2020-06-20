using Emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emarket.Controllers.api
{
    public class CartController : ApiController
    {
         private ApplicationDbContext _context;
         public CartController()
        {
            _context = new ApplicationDbContext();
        }
         [HttpPost]
         public IHttpActionResult Add(int id)
         {

             var cart = new Cart
             {
                 product_id = id,
                 added_at = DateTime.Now
             };
             _context.Cart.Add(cart);
             _context.SaveChanges();
             return Ok();
         }
         [HttpDelete]
         public IHttpActionResult Delete(int id)
         {

             var cart = _context.Cart.SingleOrDefault(p => p.product_id == id);
             
             if (cart == null)
                 return NotFound();
             _context.Cart.Remove(cart);
             _context.SaveChanges();
             return Ok();
         }
    }
}
