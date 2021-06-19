using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShoping.Models;

namespace WebShoping.Controllers
{
    public class AdminController : Controller
    {
        GeneralContext _context;

        public AdminController(GeneralContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        public IActionResult AdminPage()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult ListModers()
        {
            return View(_context.Users.FromSqlRaw("SELECT * FROM Users WHERE RoleId = 2").ToList());
        }

        [HttpGet]
        public IActionResult AddModer()
        {
            SelectList roles = new SelectList(_context.Roles, "Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public IActionResult AddModer(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("AdminPage", "Admin");
        }

        [Authorize(Roles = "admin")]
        public IActionResult ListUsers()
        {
            return View(_context.Users.FromSqlRaw("SELECT * FROM Users WHERE RoleId = 3").ToList());
        }
    }
}
