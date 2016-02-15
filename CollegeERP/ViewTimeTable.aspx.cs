using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        string UserID = string.Empty;
        bool loggedStatus = false;
        if(System.Web.HttpContext.Current.User != null)
        {
            loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if(loggedStatus)
            {
                UserID = Membership.GetUser().ProviderUserKey.ToString();
                DatabaseFunctions d = new DatabaseFunctions();
                int uid = d.GetCandidateID(UserID);
                DBFunctions db = new DBFunctions();
                var timetable = db.gettimetable(uid);
                foreach (var t in timetable)
                {
                    timetabletbl.Text += "<tr ><td>" + t.Courses_tbl.Course + "</td><td>" + t.Day + "</td><td>" + t.Teacher + "</td><td>" + t.StartTime + "</td><td>" + t.EndTime + "</td></tr>";
                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename); Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
}