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
        //detailedattendance

        if (Request.QueryString["courseid"] != null)
        {
            getattandance();       
        }
    }

    private void getattandance()
    {
        DBFunctions db = new DBFunctions();
        int courseid = int.Parse(Request.QueryString["courseid"]);
        var attendance = db.getattdance_course(courseid);
        attendancelbl.Text = "<tr class='blue-background'><th>Course</th><th>Attendance</th><th>Date</th></tr>";
        foreach (var at in attendance)
        {
            attendancelbl.Text += "<tr><td>" + at.Courses_tbl.Course + "</td>";
            if(at.Attendance=="1")   
            attendancelbl.Text += " <td>Present</td>";
            else{
                            attendancelbl.Text += " <td>Absent</td>";
            }
            attendancelbl.Text +="<td>"+at.Date.Value.ToShortDateString()+"</td></tr>";

        }
    }


}