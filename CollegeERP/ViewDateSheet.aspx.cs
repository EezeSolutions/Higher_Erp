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
        if (System.Web.HttpContext.Current.User != null)
        {
            loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (loggedStatus)
            {
                UserID = Membership.GetUser().ProviderUserKey.ToString();
                DatabaseFunctions d = new DatabaseFunctions();
                int uid = d.GetCandidateID(UserID);
                DBFunctions db = new DBFunctions();

                var datesheet = db.getdatesheet(uid);

                foreach (var ds in datesheet)
                {
                    Datesheettbl.Text += "<tr><td>" + ds.Courses_tbl.Course + "</td><td>" + ds.Year + "</td><td>" + ds.StartTime + "</td><td>" + ds.EndTime + "</td><td>" + ds.ExamType + "</td></tr>";
                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
}