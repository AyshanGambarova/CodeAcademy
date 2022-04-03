using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Models
{
    public class AboutUs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string ButtonText { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
