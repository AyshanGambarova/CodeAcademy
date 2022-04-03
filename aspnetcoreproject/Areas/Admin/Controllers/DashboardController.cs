using aspnetcoreproject.Areas.Admin.Models;
using aspnetcoreproject.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ConnectToDb db;
        public DashboardController(ConnectToDb _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dvm = new DashboardViewModel();
            dvm.BannerCount = await db.Banners.CountAsync();
            dvm.CategoryCount = await db.Categories.CountAsync();
            dvm.StudentCount = await db.Students.CountAsync();
            dvm.GroupCount = await db.Groups.CountAsync();
          
            return View(dvm);
        }
    }
}
