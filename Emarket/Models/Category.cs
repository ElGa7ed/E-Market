using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emarket.Models
{
    public class Category
    {
        public byte id { get; set; }
        [Required]
        public string name { get; set; }
        public int number_of_products { get; set; }
    }
}