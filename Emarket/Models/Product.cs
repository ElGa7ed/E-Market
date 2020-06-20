using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emarket.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }

        public Category category { get; set; }

        public byte categoryid { get; set; }
    }
}