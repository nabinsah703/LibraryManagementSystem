using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect DBConnect = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // for user login 
            SqlCommand cmd = new SqlCommand("sp_UserLogin", DBConnect.GetConnection());
            DBConnect.OpenConn();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@member_id", txtMemberID.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
          

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Response.Write("<script> alert('Login Successfully'); </script>");
                    Session["role"] = "user";
                    Session["fullname"] = dr.GetValue(0).ToString();
                    Session["username"] = dr.GetValue(1).ToString();
                    Session["status"] = dr.GetValue(3).ToString();
                }
                Response.Redirect("~/UserScreen/UserHome.aspx");

            }
            else
            {
                Response.Write("<script> alert('Invalid Credential... try again'); </script>");

            }
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_adminLogin", DBConnect.GetConnection());
            DBConnect.OpenConn();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@username", txtAdminID.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtAdminpassword.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Response.Write("<script> alert('Login Successfully'); </script>");
                    Session["Adminrole"] = "Admin";
                    Session["Adminfullname"] = dr.GetValue(2).ToString();
                    Session["Adminusername"] = dr.GetValue(0).ToString();
                }
                Response.Redirect("~/Admin/AdminHome.aspx");

            }
            else
            {
                Response.Write("<script> alert('Invalid Credential... try again'); </script>");

            }
        }
    }
}