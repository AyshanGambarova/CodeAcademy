using aspnetcoreproject.DAL;
using aspnetcoreproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConnectToDb db;
        public HomeController(ConnectToDb _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                Banners = db.Banners.ToList(),
                LeftOfCategory = db.LeftOfCategories.FirstOrDefault(),
                Categories = db.Categories.ToList(),
                TopOfUs = db.TopOfUs.FirstOrDefault(),
                AboutUs = db.AboutUs.ToList(),
                LeftOfContact = db.LeftOfContact.FirstOrDefault()
                
            };
            return View(hvm);
        }
        public async Task<IActionResult> AddMessage(string name,string surname,string SelectionNumber,string PhoneNumber,string category)
        {
           
            Message message = new Message();
            message.FullName = name + " " + surname;
            message.PhoneNumber = SelectionNumber + PhoneNumber;
            message.Category = category;

            db.Messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
