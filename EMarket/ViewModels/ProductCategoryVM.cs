using EMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarket.ViewModels
{
    public class ProductCategoryVM
    {
        public IEnumerable<Category> Category { get; set; }

        public Product Product { get; set; }
    }
}