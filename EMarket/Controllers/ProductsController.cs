using EMarket.Models;
using EMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EMarket.Controllers
{
    public class ProductsController : Controller
    {
        
        ApplicationDbContext Db = new ApplicationDbContext();
        
        // GET: Products
        
        public ActionResult ListOfProducts(string searching)
        {
            return View(Db.Products.Include(c => c.category).Where(c => c.category.name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult AddProduct()
        {
            var x = Db.Categories.ToList();
            var Vm = new ProductCategoryVM
            {
                Category = x,
                Product = new Product()
            };
            return View(Vm);
        }

        [HttpPost]
        public ActionResult AddNew(ProductCategoryVM prod, HttpPostedFileBase ImgFile)
        {

            string path = Path.Combine(Server.MapPath("~/Uploads"), ImgFile.FileName);
            ImgFile.SaveAs(path);
            prod.Product.image = ImgFile.FileName;
            //Session["img"] = prod.Product.image;


            if (prod.Product.id == 0)
            {
                Db.Products.Add(prod.Product);

            } else { 

                var prodInDb = Db.Products.SingleOrDefault(c => c.id == prod.Product.id);
               
                prodInDb.name = prod.Product.name;
                prodInDb.image = prod.Product.image;
                prodInDb.description = prod.Product.description;
                prodInDb.price = prod.Product.price;
                prodInDb.category_id = prod.Product.category_id;
                
            }

            if(prod.Product.id == 0)
            {
                if (prod.Product.category_id == 1)
                {
                    var x = Db.Categories.SingleOrDefault(c => c.id == 1);
                    x.number_of_products = prod.Product.category.number_of_products + 1;
                    x.name = prod.Product.category.name;
                    Db.Entry(x).State = EntityState.Modified;

                }
                else if (prod.Product.category_id == 2)
                {
                    var x = Db.Categories.SingleOrDefault(c => c.id == 2);
                    x.number_of_products = prod.Product.category.number_of_products + 1;
                    x.name = prod.Product.category.name;
                    Db.Entry(x).State = EntityState.Modified;
                }
                else if (prod.Product.category_id == 3)
                {
                    var x = Db.Categories.SingleOrDefault(c => c.id == 3);
                    x.number_of_products = prod.Product.category.number_of_products + 1;
                    x.name = prod.Product.category.name;
                    Db.Entry(x).State = EntityState.Modified;
                }
            }
            

            Db.SaveChanges();
                return RedirectToAction("ListOfProducts", "Products");
        }


        public ActionResult Details (string name)
        {
            var x = Db.Products.Include(c => c.category).Where(c => c.name.Equals(name));

            if (x == null)
                return HttpNotFound();

            return View(x);
        }

        public ActionResult Edit (int id)
        {
            var prod = Db.Products.SingleOrDefault(c => c.id == id);

            if (prod == null)
                return HttpNotFound();

            var vm = new ProductCategoryVM
            {
                Product = prod,
                Category = Db.Categories.ToList()
            };
            return View("Edit", vm);
        }

        
        public ActionResult Delete (int Id)
        {
            var prod = Db.Products.SingleOrDefault(c => c.id == Id);

            if (prod == null)
            { 
                return HttpNotFound();

            } else if (prod.category_id == 1)
            {
                var x = Db.Categories.SingleOrDefault(c => c.id == 1);
                x.number_of_products = prod.category.number_of_products - 1;
                x.name = prod.category.name;
                Db.Entry(x).State = EntityState.Modified;

            }
            else if (prod.category_id == 2)
            {
                var x = Db.Categories.SingleOrDefault(c => c.id == 2);
                x.number_of_products = prod.category.number_of_products - 1;
                x.name = prod.category.name;
                Db.Entry(x).State = EntityState.Modified;
            }
            else if (prod.category_id == 3)
            {
                var x = Db.Categories.SingleOrDefault(c => c.id == 3);
                x.number_of_products = prod.category.number_of_products - 1;
                x.name = prod.category.name;
                Db.Entry(x).State = EntityState.Modified;
            }

            Db.Products.Remove(prod);
            Db.SaveChanges();

            return RedirectToAction("ListOfProducts", "Products");
        }

        public ActionResult AddToCart (int prodId)
        {

            var cart = new Cart()
            {
                Product_id = prodId,
                Added_at = DateTime.Now
            };
           
            
            Db.Carts.Add(cart);
            Db.SaveChanges();
            

            return RedirectToAction("ListOfProducts");
        }

        public ActionResult DeleteFromCart (int prodID)
        {
            var prod = Db.Carts.Include(c => c.Product).Single(c => c.Product_id == prodID);

            if (prod == null)
                return HttpNotFound();

            Db.Carts.Remove(prod);
            Db.SaveChanges();

            return RedirectToAction("ListOfProducts", "Products");
        }
    }
}