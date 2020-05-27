using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMarket.Models;

namespace EMarket.ViewModels
{
    public class ProdCartVM
    {
        public Product Product { get; set; }

        public Cart Cart { get; set; }
    }
}