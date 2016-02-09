using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;
public partial class Admin_Default : System.Web.UI.Page
{
    public int studetncount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["userid"] != null)
         {
             if (!IsPostBack)
             {
                 DBFunctions db = new DBFunctions();
                 int userid = int.Parse(Session["userid"].ToString());
                 List<CourseTeacherAssignment_tbl> courses= db.getassigncourses(userid);
                 List<Courses_tbl> crslist=new List<Courses_tbl>();
                 Courses_tbl tempcours = new Courses_tbl { Course = "Select Course" };
                 crslist.Add(tempcours);
                 foreach(var crs in courses)
                 {
                     crslist.Add(crs.Courses_tbl);
                 }
                 Dropdowncrs.DataSource =crslist.OrderBy(x=>x.ID);
                 Dropdowncrs.DataValueField = "ID";
                 Dropdowncrs.DataTextField = "Course";
                 Dropdowncrs.DataBind();
             }
         }
         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }
    }
    protected void Dropdowncrs_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        //studentslbl.Text = "";
        if(!db.checkattendance(int.Parse(Dropdowncrs.SelectedValue))){

            studentslbl.Text = "<p class='alert-danger'>Today's Attedance for this course is already entered!!</p>";
            return;
        }
        var enrolledstudents = db.getenrolledstudents(int.Parse(Dropdowncrs.SelectedValue));
       studentslbl.Text = "<tr class='blue-background'><th>Student Name</th><th>Metric #</th><th>Attendance</th></tr>";
       if (enrolledstudents.Count == 0)
       {
           studentslbl.Text = "<br><br>No Student Is Enrolled in this Course";
           return;
       }
       else
       {
           studetncount = enrolledstudents.Count;
           int i = 0;
        foreach(var es in enrolledstudents)
        {
            studentslbl.Text += "<tr><td>" + es.Candidate_tbl.Name + "</td><td>" + es.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td><input type='checkbox' id='attendance" + i + "' checked data-toggle='toggle' data-on='Present' data-off='Absent' data-onstyle='success' data-offstyle='danger' data-stdid=" + es.Uid + "></td></tr>";

            i++;
        }


       }
    }
    [WebMethod]
    public static string AddAttendance(string[] student, string[] attendance, string courseid)
    {
        DBFunctions db = new DBFunctions();
        var studenattendance = student.Zip(attendance, (s, a) => new { student = s, attendance = a });
        foreach(var sa in studenattendance)
        {
            
            Attendance_tbl stad = new Attendance_tbl { CourseID = int.Parse(courseid), StudentID = int.Parse(sa.student), Attendance = sa.attendance,Date=DateTime.Now};
            db.addattendance(stad);
        }
        return "done";
    }
}