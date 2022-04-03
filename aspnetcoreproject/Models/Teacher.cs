using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        public List<Group> Groups { get; set; }
    }
}
