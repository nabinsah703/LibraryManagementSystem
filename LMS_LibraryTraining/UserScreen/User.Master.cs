using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_LibraryTraining.UserScreen
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] != null && Session["role"].Equals("user"))
            {
                if (!IsPostBack)
                {
                    lblUserName.Text = Session["fullname"].ToString();
                }
            }
            else
            {
                Response.Redirect("SignOut.aspx");
            }
        }
    }
}