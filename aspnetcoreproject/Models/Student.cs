using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CAP { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public int TeacherId { get; set; }
        //public Teacher Teacher { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
