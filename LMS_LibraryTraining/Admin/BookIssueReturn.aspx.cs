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
    
    public partial class BookIssueReturn : System.Web.UI.Page
    {DBConnect conn = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridData();
            }

        }

        private void BindGridData()
        {
            cmd = new SqlCommand("sp_getIssueBookByID", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@book_id",txtmemberID );
            GridView1.DataSource = conn.Load_Data(cmd);
            GridView1.DataBind();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                GetMemberName();
                GetBookName();
            }
            else
            {
                Response.Write("<script>alert('Wron Member/Book ID, please provide valid ID')</script>");
            }
        }

        private void GetBookName()
        {

            cmd = new SqlCommand("sp_getBookByID", conn.GetConnection());
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text);
            DataTable dt = conn.Load_Data(cmd);

            if (dt.Rows.Count > 0)
            {
                txtbookname.Text = dt.Rows[0]["book_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID')</script>");
            }

        }

        private void GetMemberName()
        {
            cmd = new SqlCommand("sp_getMemberById", conn.GetConnection());
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtmemberID.Text);
            DataTable dt = conn.Load_Data(cmd);

            if(dt.Rows.Count > 0)
            {
                txtmembername.Text = dt.Rows[0]["full_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Wrong member ID')</script>");
            }
        }

        protected void btnissuebook_Click(object sender, EventArgs e)
        {

        }

        protected void btnreturnbook_Click(object sender, EventArgs e)
        {

        }
    }
}