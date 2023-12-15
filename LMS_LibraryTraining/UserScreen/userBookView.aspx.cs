using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining.UserScreen
{
    public partial class userBookView : System.Web.UI.Page
    {

        DBConnect conn = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                BindGridData();
            }

        }

        private void BindGridData()
        {
            cmd = new SqlCommand("sp_Insert_update_delete_bookInventory", conn.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            GridView1.DataSource = conn.Load_Data(cmd);
            GridView1.DataBind();
        }
    }
}