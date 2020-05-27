using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarket.Models
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public int number_of_products { get; set; }

        public IEnumerable<Product> products { get; set; }
    }
}