using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBConnect conn = new DBConnect();
        SqlCommand cmd;
        static int actual_stock, current_stock, issued_books;
        static string filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindBookData();
                AutoGenerate();
                Bind_Author_Publisher();
            }

        }

        private void Bind_Author_Publisher()
        {
            cmd = new SqlCommand("sp_getAuthorList", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            ddlauthor.DataSource = conn.Load_Data(cmd);
            ddlauthor.DataValueField = "author_name";
            ddlauthor.DataBind();
            ddlauthor.Items.Insert(0, new ListItem("---select---"));

            cmd = new SqlCommand("sp_getPublisherList", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            ddlpublishername.DataSource = conn.Load_Data(cmd);
            ddlpublishername.DataValueField = "publisher_name";
            ddlpublishername.DataBind();
            ddlpublishername.Items.Insert(0, new ListItem("---select---"));

        }

        protected void btnbookadd_Click(object sender, EventArgs e)
        {
            if (checkDuplicationBook())
            {
                Response.Write("<script>alert('Book Already Exists')</script>");
            }
            else
            {
                AddBook();
            }
        }

        private bool checkDuplicationBook()
        {

            cmd = new SqlCommand("sp_getBookByID", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtbookid.Text);
            DataTable dt2 = new DataTable();
            dt2 = conn.Load_Data(cmd);

            if (dt2.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }

        protected void btnbookupdate_Click(object sender, EventArgs e)
        {
            if (checkDuplicationBook())
            {
                UpdateBook();
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID')</script>");

            }

        }

        protected void btnbookdelete_Click(object sender, EventArgs e)
        {
            if (checkDuplicationBook())
            {
                DeleteBook();
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID')</script>");

            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            SearchBook();

        }

        private void DeleteBook()
        {
            cmd = new SqlCommand("sp_Insert_update_delete_bookInventory", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statementType", "Delete");
            cmd.Parameters.AddWithValue("@book_id", txtbookid.Text);

            if (conn.InsertUpdateData(cmd))
            {
                Response.Write("<script>alert('Book Deleted succcessfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Book Not Deleted!!!!!!')</script>");
            }
            ClearControl();
            AutoGenerate();
            BindBookData();


        }
        private void BindBookData()
        {
            cmd = new SqlCommand("sp_Insert_update_delete_bookInventory", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statementType", "Select");
            cmd.Parameters.AddWithValue("@book_id", txtbookid.Text);
            GridView1.DataSource = conn.Load_Data(cmd);
            GridView1.DataBind();
        }
        public void AddParameter()
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtbookid.Text);
            cmd.Parameters.AddWithValue("@book_name", txtbookname.Text);
            cmd.Parameters.AddWithValue("@author_name", ddlauthor.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_name", ddlpublishername.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_date", txtpublishdate.Text);
            cmd.Parameters.AddWithValue("@language", ddllanguage.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@edition", txtedition.Text);
            cmd.Parameters.AddWithValue("@book_cost", txtbookcost.Text);
            cmd.Parameters.AddWithValue("@no_of_pages", txtpages.Text);
            cmd.Parameters.AddWithValue("@book_description", txtbookdescription.Text);
            cmd.Parameters.AddWithValue("@actual_stock", txtactualstock.Text);
            cmd.Parameters.AddWithValue("@current_stock", txtcurrentstock.Text);

        }
        private void AddBook()
        {
            //fetch data from list box
            string genres = "";
            foreach (int i in ListBoxGenre.GetSelectedIndices())
            {
                genres += ListBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);
            // save image in file path
            string filepath = "~/book_img/images.jpg";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/book_img/" + filename));
            filepath = "~/book_img/" + filename;

            cmd = new SqlCommand("sp_Insert_update_delete_bookInventory", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            AddParameter();
            cmd.Parameters.AddWithValue("@statementType", "Insert");
            cmd.Parameters.AddWithValue("@genre", genres);
            cmd.Parameters.AddWithValue("@book_img_lin", filepath);

            if (conn.InsertUpdateData(cmd))
            {
                Response.Write("<script>alert('Added succcessfully')</script>");
                ClearControl();
                AutoGenerate();
                BindBookData();



            }
            else
            {
                Response.Write("<script>alert('Not Added succcessfully')</script>");
            }
        }

        private void UpdateBook()
        {
            int a_stock = Convert.ToInt32(txtactualstock.Text.Trim());
            int c_stock = Convert.ToInt32(txtcurrentstock.Text.Trim());

            if (a_stock == actual_stock)
            {
            }
            else
            {
                if (a_stock < actual_stock)
                {
                    Response.Write("<script>alert('Actual stock value can't be less than issued books')</script>");
                    return;
                }
                else
                {
                    current_stock = actual_stock - issued_books;
                    txtcurrentstock.Text = c_stock + "";
                }
            }
            //fetch data from list box
            string genres = "";
            foreach (int i in ListBoxGenre.GetSelectedIndices())
            {
                genres += ListBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);


            // save image in file path
            string f_path = "~/book_img/images.jpg";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

            if (filename == "" || filename == null)
            {
                f_path = filepath;
            }
            else
            {
                FileUpload1.SaveAs(Server.MapPath("~/book_img/" + filename));
                f_path = "~/book_img/" + filename;
            }

            cmd = new SqlCommand("sp_Insert_update_delete_bookInventory", conn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@statementType", "Update");
            cmd.Parameters.AddWithValue("@book_id", txtbookid.Text);
            cmd.Parameters.AddWithValue("@book_name", txtbookname.Text);
            cmd.Parameters.AddWithValue("@genre", genres);
            cmd.Parameters.AddWithValue("@author_name", ddlauthor.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_name", ddlpublishername.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publisher_date", txtpublishdate.Text);
            cmd.Parameters.AddWithValue("@language", ddllanguage.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@edition", txtedition.Text);
            cmd.Parameters.AddWithValue("@book_cost", txtbookcost.Text);
            cmd.Parameters.AddWithValue("@no_of_pages", txtpages.Text);
            cmd.Parameters.AddWithValue("@book_description", txtbookdescription.Text);
            cmd.Parameters.AddWithValue("@actual_stock", a_stock.ToString());
            cmd.Parameters.AddWithValue("@current_stock", c_stock.ToString());
            cmd.Parameters.AddWithValue("@book_img_lin", f_path);

            if (conn.InsertUpdateData(cmd))
            {
                Response.Write("<script>alert('Book Updated succcessfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Book Not Updated!!!!!!')</script>");
            }
            BindBookData();
            ClearControl();
            AutoGenerate();
        }

        public void AutoGenerate()
        {
            try
            {
                int r;
                conn.OpenConn();
                cmd = new SqlCommand("select max(book_id) as ID from book_master_tbl", conn.GetConnection());
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string d = rdr[0].ToString();
                    if (d == "")
                    {
                        txtbookid.Text = "101";
                    }
                    else
                    {
                        r = Convert.ToInt32(rdr[0].ToString());
                        r = r + 1;
                        txtbookid.Text = r.ToString();
                    }
                    //txtbookid.ReadOnly = true;
                }
                conn.CloseConn();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }
        private void ClearControl()
        {
            txtissuebook.Text = txtbookname.Text = txtbookdescription.Text = txtactualstock.Text = txtcurrentstock.Text = txtedition.Text = txtpages.Text = txtpublishdate.Text = txtbookcost.Text = string.Empty;
            ddlauthor.SelectedIndex = ddlpublishername.SelectedIndex = -1;
            FileUpload1.PostedFile.InputStream.Dispose();
            imgPhoto.ImageUrl = "../LogoIcon/books_library_1767.ico";
            ListBoxGenre.ClearSelection();

        }

        private void SearchBook()
        {
            cmd = new SqlCommand("sp_getBookByID", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtbookid.Text);
            DataTable dt2 = new DataTable();
            dt2 = conn.Load_Data(cmd);

            if (dt2.Rows.Count > 0)
            {
                txtbookname.Text = dt2.Rows[0]["book_name"].ToString();
                txtpublishdate.Text = dt2.Rows[0]["publisher_date"].ToString();
                txtedition.Text = dt2.Rows[0]["edition"].ToString();
                txtbookcost.Text = dt2.Rows[0]["book_cost"].ToString().Trim();
                txtpages.Text = dt2.Rows[0]["no_of_pages"].ToString().Trim();
                txtactualstock.Text = dt2.Rows[0]["actual_stock"].ToString().Trim();
                txtcurrentstock.Text = dt2.Rows[0]["current_stock"].ToString().Trim();
                txtbookdescription.Text = dt2.Rows[0]["book_description"].ToString();
                txtissuebook.Text = "" + (Convert.ToInt32(dt2.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt2.Rows[0]["current_stock"].ToString()));

                ddllanguage.SelectedValue = dt2.Rows[0]["language"].ToString().Trim();
                ddlauthor.SelectedValue = dt2.Rows[0]["author_name"].ToString().Trim();
                ddlpublishername.SelectedValue = dt2.Rows[0]["publisher_name"].ToString().Trim();

                ListBoxGenre.ClearSelection();
                string[] genre = dt2.Rows[0]["genre"].ToString().Trim().Split(',');
                for (int i = 0; i < genre.Length; i++)
                {
                    for (int j = 0; j < ListBoxGenre.Items.Count; j++)
                    {
                        if (ListBoxGenre.Items[j].ToString() == genre[i])
                        {
                            ListBoxGenre.Items[j].Selected = true;
                        }
                    }
                }

                actual_stock = Convert.ToInt32(dt2.Rows[0]["actual_stock"].ToString().Trim());
                current_stock = Convert.ToInt32(dt2.Rows[0]["current_stock"].ToString().Trim());
                issued_books = actual_stock - current_stock;
                filepath = dt2.Rows[0]["book_img_lin"].ToString();

                if (filepath != "" || filepath != null)
                {
                    imgPhoto.ImageUrl = filepath;
                }
            }
            else
            {
                ClearControl();
                Response.Write("<script>alert('No Book Record found!!!!!!')</script>");
            }
        }
    }
}