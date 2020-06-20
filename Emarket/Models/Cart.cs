using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Emarket.Models
{
    
    public class Cart
    {
        [ForeignKey("product_id")]
        public Product product { get; set; }

        
        public int product_id { get; set; }
        public DateTime added_at { get; set; }
    }
}