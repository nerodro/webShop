using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShoping.Models;
using WebShoping.ViewModels;

namespace WebShoping.Controllers
{
    public class CategorieController : Controller
    {
        GeneralContext _context;

        public CategorieController(GeneralContext context)
        {
            _context = context;
        }
        public IActionResult Tech(/*int? category*/)
        {
            //IQueryable<Categorie> categories = _context.Categories.Include(p => p.Id);
            //if  (category !=null && category !=0)
            //{
            //    categories = categories.Where(p => p.Id == 1);
            //}
            //List<Product> products = _context.Products.ToList();
            //ProductModel productModel = new ProductModel
            //{
            //    Products = new SelectList(products, "Id","Name","Price")
            //};
            return View(_context.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoriesId = 1").ToList());
        }
        public IActionResult Pc()
        {
            return View(_context.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoriesId = 2").ToList());
        }
    }
}
