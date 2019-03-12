using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogin.Layers.BusinessLayer
{
    public interface IBusinessAuthentication
    {
        string IsValidUser(string email, string password);

        string IsFullRegistration(Guid userid);

        List<UserProfile> GetUserProfile(Guid userid);

        Guid InsertUserDetails(string firstname, string lastname, string email, string password);


        Guid Register(Guid userid, string phonenumber, DateTime birthdate, string address, string postcode, string state, string country, string maritalstatus);
    }
}