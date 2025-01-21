using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace LifeTravel.Models
{
    public class LifeOfTravel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name:")]
        public string Name  { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100)]
        [Display(Name = "City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Food preference is required.")]
        [StringLength(50)]
        [Display(Name = "Food Preference:")]
        public string FoodPreference { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(15)]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }

        [StringLength(int.MaxValue)]
        [Display(Name = "Comments:")]
        public string Comments { get; set; }

        [Display(Name = "Upload Photo:")]
        public string Photo { get; set; }

        [Display(Name = "Upload Video:")]
        public string Video { get; set; }
    }
}