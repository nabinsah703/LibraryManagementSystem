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
    {
        DBConnect conn = new DBConnect();
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
            cmd.CommandType = CommandType.StoredProcedure;
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
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtmemberID.Text);
            DataTable dt = conn.Load_Data(cmd);

            if (dt.Rows.Count > 0)
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
            if (IsBookExist() && IsMemberExist())
            {
                if (IsIssueEntryExist())
                {
                    Response.Write("<script>alert('Book already Issued')</script>");
                }
                else
                {
                    BookIssue();

                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Member ID or Book ID')</script>");
            }

        }

        private void BookIssue()
        {
            cmd = new SqlCommand("sp_insertBookIssue", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtmemberID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_name", txtmembername.Text.Trim());
            cmd.Parameters.AddWithValue("@book_name", txtbookname.Text.Trim());
            cmd.Parameters.AddWithValue("@issue_date", txtissuedate.Text.Trim());
            cmd.Parameters.AddWithValue("@due_date", txtduedate.Text.Trim());
            if (conn.InsertUpdateData(cmd))
            {
                UpdateBookStock();
            }
            else
            {
                Response.Write("<script>alert('Book Not Issue!!!!!!!')</script>");
            }


        }

        private void UpdateBookStock()
        {
            cmd = new SqlCommand("sp_updateBookIssue", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            if (conn.InsertUpdateData(cmd))
            {
                BindGridData();
                Response.Write("<script>alert('Book Issue succcessfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error current sttock not updated')</script>");

            }
        }

        private bool IsIssueEntryExist()
        {
            cmd = new SqlCommand("sp_checkIssueExistorNot", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtmemberID.Text.Trim());

            DataTable dataTable = conn.Load_Data(cmd);
            if (dataTable.Rows.Count > 0) { return true; } else { return false; }
        }

        private bool IsBookExist()
        {
            cmd = new SqlCommand("sp_checkbookexist", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            DataTable dataTable = conn.Load_Data(cmd);
            if (dataTable.Rows.Count > 0) { return true; } else { return false; }
        }

        private bool IsMemberExist()
        {
            cmd = new SqlCommand("sp_getMemberById", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtmemberID.Text.Trim());
            DataTable dataTable = conn.Load_Data(cmd);
            if (dataTable.Rows.Count > 0) { return true; } else { return false; }
        }


        protected void btnreturnbook_Click(object sender, EventArgs e)
        {
            if (IsBookExist() && IsMemberExist())
            {
                if (IsIssueEntryExist())
                {
                    ReturnBook();
                    BindGridData();
                }
                else
                {
                    Response.Write("<script>alert('This Entry Does not Exist')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Member ID or Book ID')</script>");
            }

        }

        private void ReturnBook()
        {
            cmd = new SqlCommand("sp_returnbook_updatestock", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@member_id", txtmemberID.Text.Trim());
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());

            if (conn.InsertUpdateData(cmd))
            {
                Response.Write("<script>alert('Book Return succcessfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error current sttock not updated')</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType==DataControlRowType.DataRow)
                {
                    //check your condition here 
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