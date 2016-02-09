using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RegistrationNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] != null)
        {
          
            if (!IsPostBack)
            {
                DBFunctions db = new DBFunctions();
                Mails_tbl obj = new Mails_tbl {Message = "Registration for the new courses has been started. <a href=\"../EnrollCourse.aspx\">Click Here</a> to register. ",Subject="Registration",Status=0,Date=DateTime.Now };
                db.AddRegistrationNotice(obj);
                db.UpdateStudentsCredits();
                db.UpdateStudentSemester();
            }
        }

        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
}