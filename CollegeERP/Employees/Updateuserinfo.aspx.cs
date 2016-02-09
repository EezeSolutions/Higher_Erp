using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employees_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["userid"] != null)
        {
            int empid = int.Parse(Session["userid"].ToString());
            DBFunctions db = new DBFunctions();
            var employee = db.getemployee(empid);
            Usernametxt.Text = employee.Username;
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);

        }

    }
    protected void btnaupdate_Click(object sender, EventArgs e)
    {
        int empid = int.Parse(Session["userid"].ToString());
        DBFunctions db = new DBFunctions();
        db.updateuserinfo(empid,Usernametxt.Text,Password.Text);
        Response.Redirect("EmployeeDashboard.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int empid = int.Parse(Session["userid"].ToString());
        DBFunctions db = new DBFunctions();
        db.updateuserinfo(empid, "", "");
        Response.Redirect("EmployeeDashboard.aspx");

    }
}