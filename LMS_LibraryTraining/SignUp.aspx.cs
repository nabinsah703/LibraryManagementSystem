using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining
{
    public partial class SignUp : System.Web.UI.Page
    {
        DBConnect conn = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AutoGenerate();

            }
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            if (checkDuplicateMemberExist())
            {
                Response.Write("<script>alert('User already exists.')</script>");
                

            }
            else
            {
                createAccount();
            }
        }

        private void clearTextBox()
        {
            txtfulladdress.Text = txtFullname.Text = txtCity.Text = txtEmail.Text = ddlstate.Text = txtMemberID.Text = txtMemberID.Text = txtpincode.Text = txtContact.Text = txtDob.Text = string.Empty;
            txtFullname.Focus();
        }

        private void createAccount()
        {

            cmd = new SqlCommand("sp_createaccount", conn.GetConnection());
            cmd.Parameters.AddWithValue("@full_name", txtFullname.Text.Trim());
            cmd.Parameters.AddWithValue("@dob", txtDob.Text.Trim());
            cmd.Parameters.AddWithValue("@contact_no", txtContact.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@state", ddlstate.Text.Trim());
            cmd.Parameters.AddWithValue("@pincode", txtpincode.Text.Trim());
            cmd.Parameters.AddWithValue("@full_address", txtfulladdress.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtMemberID.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
            cmd.Parameters.AddWithValue("@account_status", "Pending");
            cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
            cmd.CommandType = CommandType.StoredProcedure;
            conn.OpenConn();

            if(cmd.ExecuteNonQuery()==1) {
                Response.Write("<script>alert('Account created succcessfully')</script>");
                clearTextBox();
                AutoGenerate();
            } 
            else
            {
                Response.Write("<script>alert('Try again.....')</script>");

            }
            conn.CloseConn();
        }

        protected bool checkDuplicateMemberExist()
        {
            cmd = new SqlCommand("sp_checkMemberExist", conn.GetConnection());
            cmd.Parameters.AddWithValue("@member_id", txtMemberID.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.CommandType= CommandType.StoredProcedure;
            conn.OpenConn();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            
            da.Fill(dt);
            conn.CloseConn();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
        public void AutoGenerate()
        {
            try
            {
                int r;
                conn.OpenConn();
                 cmd = new SqlCommand("select max(member_id) as ID from member_master_tbl", conn.GetConnection());
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string d = rdr[0].ToString();
                    if (d == "")
                    {
                        txtMemberID.Text = "1001";
                    }
                    else
                    {
                        r = Convert.ToInt32(rdr[0].ToString());
                        r = r + 1;
                        txtMemberID.Text = r.ToString();
                    }
                    txtMemberID.ReadOnly = true;
                }
                conn.CloseConn();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }
    }
}