using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining.Admin
{
    public partial class AddAuthor : System.Web.UI.Page
    {
        DBConnect conn = new DBConnect();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AutoGenerate();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

             cmd = new SqlCommand("sp_InsertAuthor", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
            cmd.Parameters.AddWithValue("@name", txtAuthorName.Text.Trim());
            conn.OpenConn();

            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.CloseConn();
                Response.Write("<script>alert('Saved succcessfully')</script>");
                clearControl();
                AutoGenerate();

            }
            else
            {
                conn.CloseConn();
                Response.Write("<script>alert('Record not inserted')</script>");
            }
        }

        public void AutoGenerate()
        {
            try
            {
                int r;
                conn.OpenConn();
                 cmd = new SqlCommand("select max(author_id) as ID from author_master_tbl", conn.GetConnection());
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string d = rdr[0].ToString();
                    if (d == "")
                    {
                        txtID.Text = "101";
                    }
                    else
                    {
                        r = Convert.ToInt32(rdr[0].ToString());
                        r = r + 1;
                        txtID.Text = r.ToString();
                    }
                    txtID.ReadOnly = true;
                }
                conn.CloseConn();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }
        private void clearControl()
        {
            txtID.Text= txtAuthorName.Text = string.Empty;
            txtID.Focus();
        }
    }
}