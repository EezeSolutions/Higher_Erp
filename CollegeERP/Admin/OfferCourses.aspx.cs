using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);

        }

        if (!IsPostBack)
        {

            DBFunctions db = new DBFunctions();
           Programlist.DataSource= db.getprogramslist();
           Programlist.DataTextField = "ProgramName";
           Programlist.DataValueField = "ID";
           Programlist.DataBind();


           Batchlist.DataSource = db.getactivebatchlist();
           Batchlist.DataTextField = "BatchYear";
           Batchlist.DataValueField = "ID";
           Batchlist.DataBind();


      

        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        coursestbl.Text = "";
        DBFunctions db = new DBFunctions();
        var crslist = db.getprogramcourselist(int.Parse(Programlist.SelectedValue));
        int i = 0;
        foreach (var ccrs in crslist)
        {
            if (ccrs.Courses_tbl.OfferedCourses_tbl.Where(x => x.BatchID == int.Parse(Batchlist.SelectedValue)).FirstOrDefault() == null)
            {
                coursestbl.Text += "<tr><td>" + ccrs.Courses_tbl.Course + "</td><td>" + ccrs.Courses_tbl.Fee + "</td><td>" + ccrs.Courses_tbl.Marks + "</td><td>" + ccrs.Courses_tbl.Credit_Hours + "</td><td id='corsesdiv'><input type='checkbox' class='coursecheck' id='course" + i + "'  data-toggle='toggle' data-on='Offer' data-off='Not Offered' data-onstyle='success' data-offstyle='danger' data-id=" + ccrs.CourseID + "></td></tr>";

                i++;
            }
        }
        offercourse.Visible = true;

    }
    protected void Programlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        offercourse.Visible = false;
        coursestbl.Text = "";
        Semesterlist.Items.Clear();
        Semesterlist.Items.Add(new ListItem("Select Semester", ""));
        DBFunctions db=new DBFunctions();
          int semesters= db.getprogram(int.Parse(Programlist.SelectedValue)).Semesters.Value;
          for(int i=1;i<=semesters;i++)
          {
              Semesterlist.Items.Add(new ListItem(i.ToString(),i.ToString()));
          }
    }


    [WebMethod]
    public static string Offercourses(string[] courses, string semester, string batch, string progid)
    {
        DBFunctions db= new DBFunctions();
        foreach(var course in courses)
        {
            OfferedCourses_tbl offer = new OfferedCourses_tbl { Semester = int.Parse(semester), BatchID = int.Parse(batch), CourseID = int.Parse(course), Status = 0, ProgrammeID = int.Parse(progid) };
            db.offercourse(offer);
        }
        return "done";
    }

}