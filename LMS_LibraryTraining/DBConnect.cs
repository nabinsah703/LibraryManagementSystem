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
    }
}