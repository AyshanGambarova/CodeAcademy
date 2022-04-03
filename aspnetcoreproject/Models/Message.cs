using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad və soyad daxil olunmayıb."), MaxLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Əlaqə nömrəsi düzgün daxil olunmayıb.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Kateqoriya daxil olunmayıb.")]
        public string Category { get; set; }
        public Message()
        { }
        public Message(string FullName,string PhoneNumber,string Category)
        {
            this.FullName = FullName;
            this.PhoneNumber = PhoneNumber;
            this.Category = Category;
        }
        
    }
}
