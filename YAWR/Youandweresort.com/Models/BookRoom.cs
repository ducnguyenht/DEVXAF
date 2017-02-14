using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Youandweresort.com.Models
{
    public class BookRoom
    {         
        [Required(ErrorMessage = "Arrival date is required")]
        public string ArrivalDate { get; set; }
        [Required(ErrorMessage = "Departure date  is required")]
        public string DepartureDate { get; set; }
        public string Nights { get; set; }
        [Required(ErrorMessage = "Kind of Rooms is required")]
        public string Rooms { get; set; }
        [Required(ErrorMessage = "Rooms is required")]
        public int QuantityRooms { get; set; }
        [Required(ErrorMessage = "Adults is required")]
        public int Adults { get; set; }
        public int Children { get; set; }
        [Required(ErrorMessage = "Fullname is required")]        
        [StringLength(60)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Messages { get; set; }     
    }
}