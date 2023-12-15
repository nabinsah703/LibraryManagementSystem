using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining.UserScreen
{
    public partial class UserPayment : System.Web.UI.Page
    {
        DBConnect conn = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Redirect("~/SignOut.aspx");

            }
            else
            {
                if (!this.IsPostBack)
                {
                    BindGridData();
                }
            }
        }
        private void BindGridData()
        {
            cmd = new SqlCommand("sp_FineDetails", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@member_id", Session["mid"].ToString());
            GridView1.DataSource = conn.Load_Data(cmd);
            GridView1.DataBind();
        }
    }
}