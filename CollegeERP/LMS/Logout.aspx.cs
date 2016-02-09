using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] != null)
        {
            string usertype = Session["Role"].ToString();
            Session.RemoveAll();

            if (usertype == "Employee")
                Response.Redirect("../Employees/Login.aspx");
            else if (usertype == "Student")
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }
        }
    }
}