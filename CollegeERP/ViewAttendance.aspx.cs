using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);

        if (Session["userid"] != null)
        {

            getattendance();
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }

    private void getattendance()
    {
        DBFunctions db = new DBFunctions();
        attendancelbl.Text = "<tr class='blue-background'><th>Course</th><th>Absents</th><th>Presents</th><th>percentage</th><th></th></tr>";
        int stdid = int.Parse(Session["userid"].ToString());
        var attendance = db.getattendance(stdid);

        foreach (IGrouping<int, Attendance_tbl> attendanceGroup in attendance)
        {
            int present = attendanceGroup.Where(x => x.Attendance == "1").ToList().Count;
            int absent = attendanceGroup.Where(x => x.Attendance == "0").ToList().Count;
            double prectge = Math.Round((present/(float)attendanceGroup.Count())*100.0,2);
            attendancelbl.Text += "<tr><td>" + attendanceGroup.FirstOrDefault().Courses_tbl.Course + "</td><td>" + absent + "</td><td>" + present + "</td><td>"+prectge+"%</td><td><a href='detailedattendance.aspx?courseid="+attendanceGroup.Key+"' class='btn btn-default' >View Detail</a></td></tr>";
        }
    }
}