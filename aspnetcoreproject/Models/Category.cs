using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Icon { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public List<Group> Groups { get; set; }
    }
}
