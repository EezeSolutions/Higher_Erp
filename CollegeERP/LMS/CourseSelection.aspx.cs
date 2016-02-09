using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LMS_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userid"]!=null)
        {
            if (!IsPostBack)
            {
                DBFunctions db = new DBFunctions();
                List<Enroll_Course> cr = db.getcourselist(int.Parse(Session["userid"].ToString()));
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

    }
    protected void DropDownCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseid = int.Parse(DropDownCourses.SelectedValue);
        int userid = int.Parse(Session["userid"].ToString());
        Response.Redirect("ShowCourseDetail.aspx?course=" + courseid + "");
       
    }
}