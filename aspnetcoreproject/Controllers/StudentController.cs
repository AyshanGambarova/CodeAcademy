using aspnetcoreproject.DAL;
using aspnetcoreproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ConnectToDb db;
        public StudentController(ConnectToDb _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Group group = await db.Groups.Include(x => x.Students).Include(x => x.Teacher).Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return View(group);
          
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Student student = await db.Students.Include(x => x.Group).Include(x => x.Group.Category).Include(x => x.Group.Teacher).FirstOrDefaultAsync(x => x.Id == id);
            return View(student);

        }
    }
}
