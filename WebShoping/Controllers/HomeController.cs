using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebShoping.Models;
using Microsoft.AspNetCore.Session;
using System.IO;

namespace WebShoping.Controllers
{
    public class HomeController : Controller
    {
        GeneralContext _context;
        

        public HomeController(GeneralContext context)
        {
            _context = context;
        }
        public IActionResult Index(string name)
        {
            return View(_context.Products.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
