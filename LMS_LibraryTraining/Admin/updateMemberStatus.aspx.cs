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
    public partial class updateMemberStatus : System.Web.UI.Page
    {
        DBConnect conn = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                SearchMemberRecord();
            }
        }

        private void SearchMemberRecord()
        {
            cmd = new SqlCommand("sp_getMemberById", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.OpenConn();
            cmd.Parameters.AddWithValue("@id", txtMemberID.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                btnactive.Visible = true;
                btnpending.Visible = true;
                btndeactivate.Visible = true;
                while (dr.Read())
                {
                    txtFullname.Text = dr.GetValue(0).ToString();
                    txtDob.Text = dr.GetValue(1).ToString();
                    txtContact.Text = dr.GetValue(2).ToString();
                    txtEmail.Text = dr.GetValue(3).ToString();
                    ddlstate.Text = dr.GetValue(4).ToString();
                    txtpincode.Text = dr.GetValue(5).ToString();
                    txtfulladdress.Text = dr.GetValue(6).ToString();
                    txtCity.Text = dr.GetValue(7).ToString();


                }
            }
            else
            {
                Response.Write("<script> alert('No Record found... try again'); </script>");
            }
            conn.CloseConn();
        }

        protected void btnactive_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                updateMemberStatusByID("Active");
            }
            else
            {
                Response.Write("<script> alert(' Validation Error... try again'); </script>");
            }

        }

        private void updateMemberStatusByID(string memberStatus)
        {
            if (memberExistOrNot())
            {
                conn.OpenConn();
                cmd = new SqlCommand("sp_updateMemberStatusByID", conn.GetConnection());
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtMemberID.Text.Trim());
                cmd.Parameters.AddWithValue("@qrtype", memberStatus);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script> alert('Record updated successfully...'); </script>");
                }
                else
                {
                    Response.Write("<script> alert(' Record not Updated... try again'); </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Record Not found... try again'); </script>");
            }
        }

        private bool memberExistOrNot()
        {
            conn.OpenConn();
            cmd = new SqlCommand("sp_getMemberById", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", txtMemberID.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.CloseConn();
            if (dt.Rows.Count > 0)
                return true;
            else return false;
        }

        protected void btnpending_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                updateMemberStatusByID("Pending");
            }
            else
            {
                Response.Write("<script> alert(' Validation Error... try again'); </script>");
            }
        }

        protected void btndeactivate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                updateMemberStatusByID("Deactive");
            }
            else
            {
                Response.Write("<script> alert(' Validation Error... try again'); </script>");
            }
        }
    }
}