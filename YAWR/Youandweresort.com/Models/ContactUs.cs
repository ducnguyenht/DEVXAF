using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Youandweresort.com.Models
{
    public class ContactUs
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get;set;}
        [Required(ErrorMessage = "Messages is required")]
        public string Messages { get; set; }
    }
}