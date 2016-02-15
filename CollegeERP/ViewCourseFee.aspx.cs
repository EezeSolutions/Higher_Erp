using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string UserID = string.Empty;
    bool loggedStatus = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        
        if(System.Web.HttpContext.Current.User != null)
        {
            UserID = Membership.GetUser().ProviderUserKey.ToString();
            loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if(loggedStatus)
            {
                getcoursesfee();
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
     
    }


    public void getcoursesfee()
    {
        DatabaseFunctions d = new DatabaseFunctions();
        int sid= d.GetCandidateID(UserID);
        DBFunctions db = new DBFunctions();
       var coursefeelist= db.getstudentcoursefee(sid);
        foreach(var cf in coursefeelist)
        {
            if(cf.Status==0)
            coursefeetbl.Text += "<tr><td>"+cf.Courses_tbl.Course+"</td><td>"+cf.Courses_tbl.Marks+"</td><td>"+cf.Courses_tbl.Fee+"</td><td><a href=#0 class='btn btn-danger'>Unpaid</a></td><td><a hred='#0' class='btn btn-primary'>Pay</a></td></tr>";
            else if(cf.Status==1)
            {
                coursefeetbl.Text += "<tr><td>" + cf.Courses_tbl.Course + "</td><td>" + cf.Courses_tbl.Marks + "</td><td>" + cf.Courses_tbl.Fee + "</td><td><a href=#0 class='btn btn-info'>paid</a></td></tr>";
           
            }
        }

    }
}