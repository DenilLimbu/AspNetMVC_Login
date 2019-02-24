using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogin.Layers.DataLayer
{
    public interface IRepository
    {
        string IsValidUser(string email, string password);
    }
}
