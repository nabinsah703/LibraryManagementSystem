using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace LMS_LibraryTraining.UserScreen
{
    public partial class UserProfile : System.Web.UI.Page
    {



        DBConnect conn = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("~/SignOut.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    SearchMember();
                    BindGridData();
                }
            }


        }


        private void BindGridData()
        {
            cmd = new SqlCommand("sp_GetUserIssueBookDetails", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mid", Session["mid"].ToString());
            GridView1.DataSource = conn.Load_Data(cmd);
            GridView1.DataBind();
        }
        private void SearchMember()
        {
            cmd = new SqlCommand("sp_getMemberProfileByID", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@member_id", Session["mid"].ToString());
            DataTable dt2 = new DataTable();
            dt2 = conn.Load_Data(cmd);
            if (dt2.Rows.Count > 0)
            {
                txtFullName.Text = dt2.Rows[0]["full_name"].ToString();
                txtDOB.Text = dt2.Rows[0]["dob"].ToString();
                txtContact.Text = dt2.Rows[0]["contact_no"].ToString();
                txtEmail.Text = dt2.Rows[0]["email"].ToString();
                ddlstate.SelectedValue = dt2.Rows[0]["state"].ToString();
                txtCity.Text = dt2.Rows[0]["city"].ToString().Trim();
                txtPincode.Text = dt2.Rows[0]["pincode"].ToString();
                txtFullAddress.Text = dt2.Rows[0]["full_address"].ToString();
                txtUserID.Text = dt2.Rows[0]["member_id"].ToString();
                txtOldPassword.Text = dt2.Rows[0]["password"].ToString();
                Session["pwd"] = dt2.Rows[0]["password"].ToString();
                lblStatus.Text = dt2.Rows[0]["account_status"].ToString();
                if (dt2.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt2.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt2.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-info");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");

            }
        }







        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (checkvalidation())
                {
                    UpdateUserProfile();

                }
                else
                {
                    Response.Write("<script>alert('validation error try Again');</script>");
                }
            }
        }

        private void UpdateUserProfile()
        {
            cmd = new SqlCommand("sp_UpdateMember_Profile", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
            cmd.Parameters.AddWithValue("@dob", txtDOB.Text);
            cmd.Parameters.AddWithValue("@contact_no", txtContact.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@state", ddlstate.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@pincode", txtPincode.Text);
            cmd.Parameters.AddWithValue("@full_address", txtFullAddress.Text);
            cmd.Parameters.AddWithValue("@member_id", Session["mid"].ToString());
            if (txtNewPassword.Text != string.Empty)
            {
                cmd.Parameters.AddWithValue("@password", txtNewPassword.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@password", Session["pwd"].ToString());
            }

            if (conn.InsertUpdateData(cmd))
            {
                Response.Write("<script> alert('Your Profile updated successfully');</script>");
                Response.Redirect("UserHome.aspx");
            }
            else
            {
                Response.Write("<script> alert('Error! record not inserted ...try again');</script>");

            }
            conn.CloseConn();
        }


        private bool checkvalidation()
        {
            if (txtFullName.Text != string.Empty && txtEmail.Text != string.Empty && txtDOB.Text != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
    }
}