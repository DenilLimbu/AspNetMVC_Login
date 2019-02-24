using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCLogin.Layers.DataLayer
{

    public class DataAccess : IDataAccess
    {
        string connStr = ConfigurationManager.ConnectionStrings["BANKDBCONN"].ConnectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        /// 
        public object GetSingleAnswer(string sql, List<DbParameter> PList)
        {
            object obj = null;
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in PList)
                    cmd.Parameters.Add(p);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return obj;
        }

        public System.Data.DataTable GetDataTable(string sql, List<DbParameter> PList)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in PList)
                    cmd.Parameters.Add(p);
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public int InsOrUpdOrDel(string sql, List<DbParameter> PList)
        {
            int rows = 0;
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter p in PList)
                    cmd.Parameters.Add(p);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

    }
}
