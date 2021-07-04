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
        readonly GeneralContext _context;

        public AdminController(GeneralContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        public IActionResult AdminPage()
        {
            return View(_context.Users.ToList() );
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

        [HttpGet]
        public void FindId(int? Id)
        {
            if (Id == null)
            {
                HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult EditPerson(int? Id)
        {
            FindId(Id: Id);
            User user = _context.Users.Find(Id);
            if (user != null)
            {
                SelectList roles = new SelectList(_context.Roles, "Id", "Name");
                ViewBag.Roles = roles;
                return View(user);
            }
            return RedirectToAction("AdminPage", "Admin");
        }

        [HttpPost]
        public ActionResult EditPerson(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("AdminPage", "Admin");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            User user = _context.Users.Find(Id);
            FindId(Id: Id);
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("AdminPage", "Admin");
        }
        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
