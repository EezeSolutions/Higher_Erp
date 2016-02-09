using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Redirecturl"] != null)
        {
            
            Message.Visible = true;
            Message.Text = "Please Login First";
        }

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string returnuurl = "";
        if (Request.QueryString["Redirecturl"]!=null)
        {
            returnuurl = Request.QueryString["Redirecturl"];
            Message.Visible = true;
            Message.Text = "Please Login First";
        }
        if (username.Text == ConfigurationSettings.AppSettings["adminuser"] && ConfigurationSettings.AppSettings["adminpass"] == password.Text)
        {
            Session["admin"] = username.Text;
            Session["Role"] = "Admin"; 
            if(returnuurl=="")
            Response.Redirect("AdminDashboard.aspx");
            else
            {
                Response.Redirect(returnuurl);
            }
        }
        else
        {
            Message.Text = "Wrong Username or Password";
            Message.Visible = true;
        }
    }
}