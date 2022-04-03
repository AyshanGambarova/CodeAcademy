using aspnetcoreproject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.DAL
{
    public class ConnectToDb:IdentityDbContext<AppUser>
    {
        public ConnectToDb(DbContextOptions<ConnectToDb> options) : base(options)
        { }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<LeftOfCategory> LeftOfCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TopOfUs> TopOfUs { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<LeftOfContact> LeftOfContact { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
