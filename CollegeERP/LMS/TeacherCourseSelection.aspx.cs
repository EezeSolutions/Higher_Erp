using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LMS_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if(Session["userid"]!=null)
        {
            if (!IsPostBack)
            {
                DBFunctions db = new DBFunctions();
                List<CourseTeacherAssignment_tbl> cr = db.getassigncourses(int.Parse(Session["userid"].ToString()));
                List<Courses_tbl> temp = new List<Courses_tbl>();
                
                //foreach (var cf in cr)
                //{
                //    temp = db.getcoursesList(int.Parse(cf.CourseID.ToString()));
                //}
                DropDownCourses.Items.Add("Select course");
                foreach (var cf in cr)
                {

                    int id = int.Parse(cf.CourseID.ToString());
                    temp = db.getcoursesList(id);
                    DropDownCourses.DataSource = temp;
                    DropDownCourses.DataTextField = "Course";
                    DropDownCourses.DataValueField = "ID";
                    DropDownCourses.DataBind();

                }
            }
            
        }

        else
        {
            Response.Redirect("../Login.aspx?Redirecturl=/LMS/" + pagename);
        }

    }
    protected void DropDownCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseid = int.Parse(DropDownCourses.SelectedValue);
        int userid = int.Parse(Session["userid"].ToString());
        Response.Redirect("UploadAssignments.aspx?course=" + courseid + "");
       
    }
}