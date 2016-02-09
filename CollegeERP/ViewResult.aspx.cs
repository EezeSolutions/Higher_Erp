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
    { string pagename = Path.GetFileName(Request.PhysicalPath);

    if (Session["userid"] != null)
    {
       

    }
    else
    {
        Response.Redirect("Login.aspx?Redirecturl=" + pagename);
    }
    }


    public void showresult()
    {
        Resultlbl.Text = "<tr class='blue-background'><th>Course</th><th>Total Marks</th><th>Obtained</th><th>Grade</th></tr>";
                
        int total = 0;
        DBFunctions db = new DBFunctions();
        int stdid = int.Parse(Session["userid"].ToString());
        var result = db.getresult(stdid,dropdownterm.SelectedValue);
        //<th>Course</th><th>Total Marks</th><th>Obtained</th><th>Grade</th>
        foreach (var r in result)
        {
            Resultlbl.Text += "<tr><td>" + r.Courses_tbl.Course + "</td><td>" + r.TotalMarks + "</td><td>" + r.ObtainedMarks + "</td>";
            total += r.ObtainedMarks.Value;
            if (r.ObtainedMarks >= 90)
                Resultlbl.Text += "<td>A</td></tr>";
            else if (r.ObtainedMarks >= 85 && r.ObtainedMarks < 90)
                Resultlbl.Text += "<td>A-</td></tr>";
            else if (r.ObtainedMarks >= 80 && r.ObtainedMarks < 85)
                Resultlbl.Text += "<td>B+</td></tr>";
            else if (r.ObtainedMarks >= 70 && r.ObtainedMarks < 80)
                Resultlbl.Text += "<td>B</td></tr>";
            else if (r.ObtainedMarks >= 60 && r.ObtainedMarks < 70)
                Resultlbl.Text += "<td>B-</td></tr>";
            else if (r.ObtainedMarks >= 55 && r.ObtainedMarks < 60)
                Resultlbl.Text += "<td>C+</td></tr>";
            else if (r.ObtainedMarks >= 45 && r.ObtainedMarks < 55)
                Resultlbl.Text += "<td>C</td></tr>";

        }
        Totalmarkslbl.Text = "<b class='h5'>Total marks: </b>" + total;
    }
    protected void dropdownterm_SelectedIndexChanged(object sender, EventArgs e)
    {
        Resultlbl.Text ="";
        showresult();
    }
}