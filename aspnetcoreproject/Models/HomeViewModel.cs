using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Models
{
    public class HomeViewModel
    {
        public List<Banner> Banners { get; set; }
        public LeftOfCategory LeftOfCategory { get; set; }
        public List<Category> Categories { get; set; }
        public TopOfUs TopOfUs { get; set; }
        public List<AboutUs> AboutUs { get; set; }
        public LeftOfContact LeftOfContact { get; set; }
        //public Message Message { get; set; }
        //public List<Student> Students { get; set; }
        //public List<Group> Groups { get; set; }
    }
}
