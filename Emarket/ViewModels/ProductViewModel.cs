using Emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emarket.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> UpcomingProducts { get; set; }



        public string SearchTerm { get; set; }
    }
}