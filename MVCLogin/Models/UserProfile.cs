using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLogin.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }

        public Guid UserUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "FirstName must be at least 7 digits", MinimumLength = 10)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        public string FirstLineAddress { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string MaritalStatus { get; set; }
    }
}