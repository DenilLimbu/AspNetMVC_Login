using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCLogin.Layers.DataLayer
{
    public class Repository : IRepository
    {
        IDataAccess _dac = new DataAccess();

        public string IsValidUser(string email, string password)
        {
            string result = " ";

            try
            {
                string sql = "select UserID from Users where email=@email and password=@password";
                List<DbParameter> plist = new List<DbParameter>();

                SqlParameter p1 = new SqlParameter("@email", SqlDbType.NVarChar, 200);
                p1.Value = email;
                plist.Add(p1);

                SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar, 60);
                p2.Value = password;
                plist.Add(p2);

                object obj = _dac.GetSingleAnswer(sql, plist);
                if (obj != null)
                {
                    result = obj.ToString();
                }
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return result;

        }
    }
}