    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLogin.Models
{
    public class User
    {
        public Guid UserID { get; set;}

        [Required]
        [StringLength(100, ErrorMessage = "FirstName must be at least 5 characters in length", MinimumLength = 5)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "LastName must be at least 5 characters in length", MinimumLength = 5)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}