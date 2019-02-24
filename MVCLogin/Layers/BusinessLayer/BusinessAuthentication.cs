using MVCLogin.Layers.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLogin.Layers.BusinessLayer
{
    public class BusinessAuthentication : IBusinessAuthentication
    {
        IRepository _repo = new Repository();

        public string IsValidUser(string email, string password)
        {
            string result;
            try
            {
                result  = _repo.IsValidUser(email, password);
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}