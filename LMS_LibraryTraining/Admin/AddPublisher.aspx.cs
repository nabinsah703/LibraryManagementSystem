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
    public partial class AddPublisher : System.Web.UI.Page
    {
        DBConnect conn = new DBConnect();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AutoGenerate();
                BindPublisherRecord();

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_InsertPublisher", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtpublisherID.Text.Trim());
            cmd.Parameters.AddWithValue("@name", txtpublisherName.Text.Trim());
            conn.OpenConn();

            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.CloseConn();
                Response.Write("<script>alert('Saved succcessfully')</script>");
                clearControl();
                BindPublisherRecord();
                AutoGenerate();

            }
            else
            {
                conn.CloseConn();
                Response.Write("<script>alert('Record not inserted')</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_UpdatePublisher", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtpublisherID.Text.Trim());
            cmd.Parameters.AddWithValue("@name", txtpublisherName.Text.Trim());
            conn.OpenConn();

            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.CloseConn();
                Response.Write("<script>alert('Updated succcessfully')</script>");
                clearControl();
                BindPublisherRecord();
                AutoGenerate();
                btnAdd.Visible = true;
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

        public void AutoGenerate()
        {
            try
            {
                int r;
                conn.OpenConn();
                cmd = new SqlCommand("select max(publisher_id) as ID from publisher_master_tbl", conn.GetConnection());
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string d = rdr[0].ToString();
                    if (d == "")
                    {
                        txtpublisherID.Text = "1001";
                    }
                    else
                    {
                        r = Convert.ToInt32(rdr[0].ToString());
                        r = r + 1;
                        txtpublisherID.Text = r.ToString();
                    }
                    txtpublisherID.ReadOnly = true;
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
            txtpublisherID.Text = txtpublisherName.Text = string.Empty;
            txtpublisherName.Focus();
        }

        private void searchDataForUpdate(int? idd)
        {
            cmd = new SqlCommand("sp_getPublisherByID", conn.GetConnection());
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
                txtpublisherID.Text = ds.Tables[0].Rows[0]["publisher_id"].ToString();
                txtpublisherName.Text = ds.Tables[0].Rows[0]["publisher_name"].ToString();
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('No Record Found ... Try Again ...')</script>");

            }
        }

        private void BindPublisherRecord()
        {
            cmd = new SqlCommand("sp_getPublisherList", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            conn.OpenConn();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rptRepeater.DataSource = dt;
            rptRepeater.DataBind();
        }

        protected void rptRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                cmd = new SqlCommand("sp_DeletePublisher", conn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);
                conn.OpenConn();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.CloseConn();
                    Response.Write("<script>alert('Deleted succcessfully')</script>");
                    clearControl();
                    BindPublisherRecord();
                    AutoGenerate();
                    btnAdd.Visible = true;
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
    }
}