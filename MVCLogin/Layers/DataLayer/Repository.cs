using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
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
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<UserProfile> GetUserProfile(Guid userid)
        {
            DataTable dta = new DataTable();

            //List<User> upf = new List<User>();

            List<UserProfile> userprofilelist = new List<UserProfile>();
            

            try
            {
                //string sql = "select FirstName, LastName, Email from Users where UserId=@userid";

                string sql = "select UserProfileID, UserUserId, Phonenumber, BirthDate, Address, PostCode, State, Country, MaritalStatus, Email, FirstName, LastName from UserProfile Inner Join Users on UserProfile.UserUserID = Users.UserID AND Users.UserID=@userid";

                List<DbParameter> plist = new List<DbParameter>();
                SqlParameter p1 = new SqlParameter("@userid", SqlDbType.UniqueIdentifier);
                p1.Value = userid;
                plist.Add(p1);

                dta = _dac.GetDataTable(sql, plist);

                #region
                //    foreach (DataRow row in dta.Rows) // Loop the rows.
                //    {
                //        foreach (var item in row.ItemArray) // then items
                //        {
                //            result.Add(item.ToString());
                //        }
                //    }
                //    List<string> se = result;
                //}
                #endregion

                userprofilelist = dta.AsEnumerable().Select(row =>
                            new UserProfile
                            {
                                UserProfileId = row.Field<int>("UserProfileId"),
                                UserUserId = row.Field<Guid>("UserUserID"),
                                PhoneNumber = row.Field<string>("Phonenumber"),
                                BirthDate = row.Field<DateTime>("BirthDate"),
                                FirstLineAddress = row.Field<string>("Address"),
                                PostCode = row.Field<string>("PostCode"),
                                State = row.Field<string>("State"),
                                Country = row.Field<string>("Country"),
                                MaritalStatus= row.Field<string>("MaritalStatus"),
                                Email = row.Field<string>("Email"),
                                FirstName= row.Field<string>("FirstName"),
                                LastName= row.Field<string>("LastName")
                            }).ToList();
            }


            catch (Exception ex)
            {
                throw ex;
            }
            return userprofilelist;
        }





        public Guid InsertUserDetails(string firstname, string lastname, string email, string password)
        {

            Guid userid = Guid.NewGuid();

            int result = 0;
            try
            {
                string sql = "insert into Users values(@userid, @firstname, @lastname, @email, @password)";
                List<DbParameter> plist = new List<DbParameter>();

                SqlParameter p1 = new SqlParameter("@userid", SqlDbType.UniqueIdentifier);
                p1.Value = userid;
                plist.Add(p1);


                SqlParameter p2 = new SqlParameter("@firstname", SqlDbType.NVarChar, 200);
                p2.Value = firstname;
                plist.Add(p2);

                SqlParameter p3 = new SqlParameter("@lastname", SqlDbType.NVarChar, 200);
                p3.Value = lastname;
                plist.Add(p3);

                SqlParameter p4 = new SqlParameter("@email", SqlDbType.NVarChar, 200);
                p4.Value = email;
                plist.Add(p4);

                SqlParameter p5 = new SqlParameter("@password", SqlDbType.VarChar, 60);
                p5.Value = password;
                plist.Add(p5);

                result = _dac.InsOrUpdOrDel(sql, plist);

                if (result == 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userid;
        }

        public Guid Register(Guid userid, string phonenumber, DateTime birthdate, string address, string postcode, string state, string country, string maritalstatus)
        {
            Random number = new Random();

            int userprofileid = number.Next(0, 10000);

            int result = 0;
            try
            {
                string sql = "insert into UserProfile values(@userprofileid, @userid, @phonenumber, @birthdate, @address, @postcode, @state, @country, @maritalstatus)";
                List<DbParameter> plist = new List<DbParameter>();

                SqlParameter p1 = new SqlParameter("@userprofileid", SqlDbType.Int);
                p1.Value = userprofileid;
                plist.Add(p1);

                SqlParameter p2 = new SqlParameter("@userid", SqlDbType.UniqueIdentifier);
                p2.Value = userid;
                plist.Add(p2);

                SqlParameter p3 = new SqlParameter("@phonenumber", SqlDbType.VarChar, 20);
                p3.Value = phonenumber;
                plist.Add(p3);

                SqlParameter p4 = new SqlParameter("@birthdate", SqlDbType.Date);
                p4.Value = birthdate;
                plist.Add(p4);

                SqlParameter p5 = new SqlParameter("@address", SqlDbType.VarChar, 50);
                p5.Value = address;
                plist.Add(p5);

                SqlParameter p6 = new SqlParameter("@postcode", SqlDbType.VarChar, 50);
                p6.Value = postcode;
                plist.Add(p6);

                SqlParameter p7 = new SqlParameter("@state", SqlDbType.VarChar, 50);
                p7.Value = state;
                plist.Add(p7);

                SqlParameter p8 = new SqlParameter("@country", SqlDbType.VarChar, 50);
                p8.Value = country;
                plist.Add(p8);

                SqlParameter p9 = new SqlParameter("@maritalstatus", SqlDbType.VarChar, 50);
                p9.Value = maritalstatus;
                plist.Add(p9);

                result = _dac.InsOrUpdOrDel(sql, plist);

                if (result == 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userid;
        }
    }
}