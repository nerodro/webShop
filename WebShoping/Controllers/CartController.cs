using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShoping.Models;

namespace WebShoping.Controllers
{
    public class CartController : Controller
    {

        GeneralContext _context;

        public CartController(GeneralContext context)
        {
            _context = context;
        }
        [HttpGet]
        public void FindId(int? Id)
        {
            if (Id == null)
            {
                HttpNoFound();
            }
        }
        [HttpGet]
        public IActionResult AddProductToCart(int? Id)
        {
            FindId(Id: Id);
            Product product = _context.Products.Find(Id);
            Cart cart = new Cart();
            if (product != null)
            {
                cart.NameProduct = product.NameProduct;
                cart.Price = product.Price;
                //cart.Count = product.Count;
                cart.ProductId = product.Id;
                return View(cart);
            }
            return RedirectToAction("Lk","Cart");
        }

        [HttpPost]
        public IActionResult AddProductToCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return RedirectToAction("Lk","Cart");
        }
        public IActionResult Lk()
        {
            return View(_context.Carts.ToList());
        }

        [HttpGet]
        public IActionResult DeleteProductFromCart(int? Id)
        {
            Cart cart = _context.Carts.Find(Id);
            FindId(Id: Id);
            return View(cart);
        }

        [HttpPost, ActionName("DeleteProductFromCart")]
        public IActionResult DeleteConfirmed(Cart cart)
        {
            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return RedirectToAction("Lk", "Cart");
        }

        public IActionResult Pay(int? Id)
        {
            
            return View();
        }
        public IActionResult Payed()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        private IActionResult HttpNoFound()
        {
            throw new NotImplementedException();
        }
    }
}
