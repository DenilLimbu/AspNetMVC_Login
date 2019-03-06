using MVCLogin.Layers.DataLayer;
using MVCLogin.Models;
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

        public List<UserProfile> GetUserProfile(Guid userid)
        {
            List<UserProfile> result= new List<UserProfile>();
            try
            {
                result = _repo.GetUserProfile(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public Guid InsertUserDetails(string firstname, string lastname, string email, string password)
        {
            Guid result;

            try
            {
                result = _repo.InsertUserDetails(firstname, lastname, email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public Guid Register(Guid userid, string phonenumber, DateTime birthdate, string address, string postcode, string state, string country, string maritalstatus)
        {
            Guid result;

            try
            {
                    result = _repo.Register(userid, phonenumber, birthdate, address, postcode, state, country, maritalstatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}