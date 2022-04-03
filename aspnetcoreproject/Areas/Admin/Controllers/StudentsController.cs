using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspnetcoreproject.DAL;
using aspnetcoreproject.Models;
using aspnetcoreproject.Utils;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace aspnetcoreproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly ConnectToDb _context;
        private readonly IWebHostEnvironment _env;

        public StudentsController(ConnectToDb context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var connectToDb = _context.Students.Include(s => s.Group).Include(s => s.Group.Teacher);
            return View(await connectToDb.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Group)
                .Include(s => s.Group.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,CAP,Email,PhoneNumber,TeacherId,GroupId,Image,ImageFile")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (!student.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "File must be an image.");
                    return View();
                }
                if (!student.ImageFile.IsValidSize(500))
                {
                    ModelState.AddModelError("ImageFile", "Max file size is 500 kbs.");
                    return View();
                }
                student.Image = await student.ImageFile.Upload(_env.WebRootPath, @"uploads\students");
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", student.GroupId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", student.Group.TeacherId);
            return View(student);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", student.GroupId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", student.Group.TeacherId);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,CAP,Email,PhoneNumber,TeacherId,GroupId,Image,ImageFile")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (!student.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "File must be an image.");
                    return View();
                }
                if (!student.ImageFile.IsValidSize(500))
                {
                    ModelState.AddModelError("ImageFile", "Max file size is 500 kbs.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"uploads\students", student.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                student.Image = await student.ImageFile.Upload(_env.WebRootPath, @"uploads\students");
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", student.GroupId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", student.Group.TeacherId);
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Group)
                .Include(s => s.Group.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            string filePath = Path.Combine(_env.WebRootPath, @"uploads\students", student.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
