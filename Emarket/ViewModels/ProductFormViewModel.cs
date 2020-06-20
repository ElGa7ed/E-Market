using Emarket.Controllers;
using Emarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Emarket.ViewModels
{
    public class ProductFormViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public decimal price { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        [Required]
        public byte category { get; set; }

        public string Heading { get; set; }
        public ProductFormViewModel()
        {
            if (image == null)
            {
                image = "camerashot.png";
            }
        }

        public string Action
        {
            get
            {
                Expression<Func<ProductsController, ActionResult>>
                    update = (c => c.Update(this));

                Expression<Func<ProductsController, ActionResult>>
                    create = (c => c.Create(this));
                var action = (id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

    }
}