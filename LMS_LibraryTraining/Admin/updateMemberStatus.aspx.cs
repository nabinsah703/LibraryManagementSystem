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

            if (!this.IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            cmd = new SqlCommand("sp_getMemberAllRecord", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            GridView1.DataSource = Load_Data(cmd);
            GridView1.DataBind();
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
                conn.CloseConn();
                BindGridView();
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label mid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDisplayID");
            int ID = Convert.ToInt32(mid.Text);


            cmd = new SqlCommand("sp_deleteMemberRecord", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@member_id", ID);
            conn.OpenConn();
            cmd.ExecuteNonQuery();
            conn.CloseConn();
            BindGridView();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // this code is woking when we use DataBound field in .aspx file 
            //int id = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
            //string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

            //string dob = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            //string contact = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            //string email = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            //string state = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            //string pincode = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            //string fulladdress = ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
            //string city = ((TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0]).Text;

            Label mid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDisplayID");
            int ID = Convert.ToInt32(mid.Text);

            TextBox updatetxtname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditName");
            TextBox updatetxtdob = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditdob");
            TextBox updatetxtcontact = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditcontact");
            TextBox updatetxtemail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditemail");
            DropDownList updatetxtstate = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlEditstate");
            TextBox updatetxtpincode = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditpincode");
            TextBox updatetxtfulladdress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditaddress");
            TextBox updatetxtcity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditcity");

            cmd = new SqlCommand("sp_UpdateMemberRecord", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@full_name", updatetxtname.Text);
            cmd.Parameters.AddWithValue("@dob", updatetxtdob.Text);
            cmd.Parameters.AddWithValue("@contact_no", updatetxtcontact.Text);
            cmd.Parameters.AddWithValue("@email", updatetxtemail.Text);
            cmd.Parameters.AddWithValue("@state", updatetxtstate.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@pincode", updatetxtpincode.Text);
            cmd.Parameters.AddWithValue("@full_address", updatetxtfulladdress.Text);
            cmd.Parameters.AddWithValue("@city", updatetxtcity.Text);
            cmd.Parameters.AddWithValue("@member_id", ID);
            conn.OpenConn();
            cmd.ExecuteNonQuery();
            conn.CloseConn();
            GridView1.EditIndex = -1;
            BindGridView();


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
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
                conn.CloseConn();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlEditStateValue = (DropDownList)e.Row.FindControl("ddlEditstate");
                Label lblstate = (Label)e.Row.FindControl("lblEidtstate");
                ddlEditStateValue.SelectedValue = lblstate.Text;
            }
        }
    }
}