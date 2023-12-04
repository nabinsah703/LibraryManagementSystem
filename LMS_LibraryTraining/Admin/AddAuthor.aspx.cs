using System;
using System.Collections.Generic;
using System.Data;
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
                BindAuthorRecord();

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
                BindAuthorRecord();
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
            txtID.Text = txtAuthorName.Text = string.Empty;
            txtID.Focus();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                searchDataForUpdate(Convert.ToInt32(id));
            }
            else if (e.CommandName == "delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                cmd = new SqlCommand("sp_DeleteAuthor", conn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);
                conn.OpenConn();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.CloseConn();
                    Response.Write("<script>alert('Deleted succcessfully')</script>");
                    clearControl();
                    BindAuthorRecord();
                    AutoGenerate();
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                }
                else
                {
                    conn.CloseConn();
                    Response.Write("<script>alert('Record not Deleted')</script>");
                }
            }
        }

        private void searchDataForUpdate(int? idd)
        {
            cmd = new SqlCommand("sp_getAuthorByID", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", idd);
            conn.OpenConn();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds, "dt");
            conn.CloseConn();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["AuthorID"] = ds.Tables[0].Rows[0]["author_id"].ToString();
                txtID.Text = ds.Tables[0].Rows[0]["author_id"].ToString();
                txtAuthorName.Text = ds.Tables[0].Rows[0]["author_name"].ToString();
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('No Record Found ... Try Again ...')</script>");

            }
        }

        private void BindAuthorRecord()
        {
            cmd = new SqlCommand("sp_getAuthorList", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            conn.OpenConn();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("sp_UpdateAuthor", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
            cmd.Parameters.AddWithValue("@name", txtAuthorName.Text.Trim());
            conn.OpenConn();

            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.CloseConn();
                Response.Write("<script>alert('Updated succcessfully')</script>");
                clearControl();
                BindAuthorRecord();
                AutoGenerate();
                btnSubmit.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }
            else
            {
                conn.CloseConn();
                Response.Write("<script>alert('Record not Updated')</script>");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}