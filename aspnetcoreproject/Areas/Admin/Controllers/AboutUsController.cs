using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspnetcoreproject.DAL;
using aspnetcoreproject.Models;
using Microsoft.AspNetCore.Hosting;
using aspnetcoreproject.Utils;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace aspnetcoreproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutUsController : Controller
    {
        private readonly ConnectToDb _context;
        private readonly IWebHostEnvironment _env;

        public AboutUsController(ConnectToDb context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutUs.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutUs = await _context.AboutUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutUs == null)
            {
                return NotFound();
            }

            return View(aboutUs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Text,Image,ButtonText,ImageFile")] AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                if (!aboutUs.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "File must be an image.");
                    return View();
                }
                if (!aboutUs.ImageFile.IsValidSize(500))
                {
                    ModelState.AddModelError("ImageFile", "Max file size is 500 kbs.");
                    return View();
                }
                aboutUs.Image = await aboutUs.ImageFile.Upload(_env.WebRootPath, @"uploads\us");
                _context.Add(aboutUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutUs);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutUs = await _context.AboutUs.FindAsync(id);
            if (aboutUs == null)
            {
                return NotFound();
            }
            return View(aboutUs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,Image,ButtonText,ImageFile")] AboutUs aboutUs)
        {
            if (id != aboutUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (aboutUs.ImageFile != null)
                {
                    if (!aboutUs.ImageFile.IsImage())
                    {
                        ModelState.AddModelError("ImageFile", "File must be an image.");
                        return View();
                    }
                    if (!aboutUs.ImageFile.IsValidSize(500))
                    {
                        ModelState.AddModelError("ImageFile", "Max file size is 500 kbs.");
                        return View();
                    }
                    string filePath = Path.Combine(_env.WebRootPath, @"uploads\us", aboutUs.Image);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    aboutUs.Image = await aboutUs.ImageFile.Upload(_env.WebRootPath, @"uploads\us");
                }
                try
                {
                    _context.Update(aboutUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutUsExists(aboutUs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aboutUs);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutUs = await _context.AboutUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutUs == null)
            {
                return NotFound();
            }

            return View(aboutUs);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutUs = await _context.AboutUs.FindAsync(id);
            string filePath = Path.Combine(_env.WebRootPath, @"uploads\us", aboutUs.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.AboutUs.Remove(aboutUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutUsExists(int id)
        {
            return _context.AboutUs.Any(e => e.Id == id);
        }
    }
}
