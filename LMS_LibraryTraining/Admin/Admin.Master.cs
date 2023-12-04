using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty((string)Session["Adminrole"]) && Session["Adminrole"].Equals("Admin"))
            {
                if (!IsPostBack)
                {
                    lblUserName.Text = Session["Adminfullname"].ToString();
                }
            }
            else
            {
                Response.Redirect("SignOut.aspx");
            }

        }
    }
}