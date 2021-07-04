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
        public IActionResult Tech()
        {
            return View(_context.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoriesId = 1").ToList());
        }
        public IActionResult Pc()
        {
            return View(_context.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoriesId = 2").ToList());
        }
    }
}
