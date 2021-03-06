using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebShoping.Models;
using WebShoping.ViewModels;

namespace WebShoping.Controllers
{
    public class ModerController : Controller
    {
        GeneralContext _context;

        public ModerController(GeneralContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin, moder")]
        public IActionResult Moder()
        {
            return View(_context.Products.ToList());
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductModel product, Categorie categorie) 
        {
        //    SelectList categories = new SelectList(_context.Categories, "Id", "NameCategory");
        //    ViewBag.Categories = categories;
            Product products = new Product { NameProduct = product.NameProduct, Price = product.PriceProduct, Count = product.CountProduct, Categories = product.Categories, CategoriesId = product.CategoriesId };
            //Categorie categories = new Categorie { NameCategory = categorie.NameCategory , Id = categorie.Id};
            if(product.PhotoProduct != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(product.PhotoProduct.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)product.PhotoProduct.Length);
                }
                products.PhotoProduct = imageData;
            }
            _context.Products.Add(products);
            //_context.Categories.Add(categories);
            _context.SaveChanges();
            return RedirectToAction("Moder", "Moder");
        }

        [HttpGet]
        public void FindId(int? Id)
        {
            if (Id == null)
            {
                HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int? Id, ProductModel productPh)
        {
            FindId(Id:Id);
            Product product = _context.Products.Find(Id);
            if (product != null)
            {
                SelectList categories = new SelectList(_context.Categories, "Id", "NameCategory");
                ViewBag.Categories = categories;
                
                return View(product);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Moder", "Moder");
        }

        [HttpGet]
        public ActionResult DeleteProduct(int Id)
        {
            Product product = _context.Products.Find(Id);
            FindId(Id: Id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult DeleteConfirmed(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Moder", "Moder");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
