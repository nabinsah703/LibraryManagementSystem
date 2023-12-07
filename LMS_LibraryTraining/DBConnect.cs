using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace LMS_LibraryTraining
{
    public class DBConnect
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);


        public SqlConnection GetConnection()
        {
            return con;
        }



        public void CloseConn()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public void OpenConn()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }


        public DataTable Load_Data(SqlCommand sqlCommand)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                dt.Dispose();
                da.Dispose();
                CloseConn();
            }
        }

        public bool InsertUpdateData(SqlCommand cmd)
        {
            bool recordSaved;

            try
            {
                OpenConn();
                cmd.ExecuteNonQuery();
                recordSaved = true;
            }
            catch
            {

                recordSaved = false;
            }
            finally
            {
                CloseConn();
            }
            return recordSaved;
        }

    }
}