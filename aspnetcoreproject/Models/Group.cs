using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Student> Students { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
        //public List<Student> Students { get; set; }
    }
}
