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
        List<UserProfile> GetUserProfile(Guid userid);
    }
}