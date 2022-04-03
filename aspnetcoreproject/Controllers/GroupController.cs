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
    public class GroupController : Controller
    {
        private readonly ConnectToDb db;
        public GroupController(ConnectToDb _db)
        {
            db = _db;
        }
       
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Group> groups = await db.Groups.Include(x => x.Category).Include(x => x.Teacher).Where(x => x.CategoryId == id).ToListAsync();
            return View(groups);

        }
        public async Task<IActionResult> ReturnAll()
        {
            ViewBag.Gtypes = await db.Categories.ToListAsync();
            List<Group> groups = await db.Groups.Include(x => x.Category).Include(x => x.Teacher).ToListAsync();
            return View(groups);
        }
    }
}
