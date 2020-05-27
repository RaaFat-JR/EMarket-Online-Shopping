using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMarket.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Name Is Required!")]
        [Display(Name = "Product Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Price Is Required!")]
        [Display(Name = "Product Price")]
        public int price { get; set; }

        [Required(ErrorMessage = "Image Is Required!")]
        [Display(Name = "Product Image")]
        public string image { get; set; }

        [Required(ErrorMessage = "Say Something in The Description")]
        [Display(Name = "Description")]
        public string description { get; set; }


        public virtual Cart Cart { get; set; }


        public Category category { get; set; }

        [Required(ErrorMessage = "Category Is Required!")]
        [ForeignKey("category")]
        [Display(Name = "Product Category")]
        public int category_id { get; set; }


    }
}