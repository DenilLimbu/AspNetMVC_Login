using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLogin.Models
{
    public class UserProfile
    {


        public int UserProfileId { get; set; }

        public Guid UserUserId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstLineAddress { get; set; }

        public string PostCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string MaritalStatus { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}