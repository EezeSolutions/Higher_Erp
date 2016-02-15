using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public static int Credits = 0;
    public static int TotalCredits = 0;
    string Userid = "";
    static int uid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            string pagename = Path.GetFileName(Request.PhysicalPath);
            bool loggedStatus = false;
            if (System.Web.HttpContext.Current.User != null)
            {
                if (!IsPostBack)
                {
                    loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
                    if (loggedStatus)
                    {
                        DBFunctions db = new DBFunctions();
                        DatabaseFunctions d = new DatabaseFunctions();
                        Userid = Membership.GetUser().ProviderUserKey.ToString();
                        uid = d.GetCandidateID(Userid);
                        //  loadprogrammes();

                        StudentInfo_tbl temp = db.getstdentinfo(uid);

                        StudentSelectedCredit obj = db.getStudentCredits(uid).FirstOrDefault();
                        if (obj != null)
                        {
                            Credits = Convert.ToInt16(obj.SelectedCourseCount);
                        }

                        getcourses();

                    }
                    else
                    {
                        Response.Redirect("Login.aspx?Redirecturl=" + pagename);
                    }
                }
            }
      //  dropdownCourse.DataSource=
    }

    [WebMethod(EnableSession=true)]
    public static string Enroll(string cid){
        int id = int.Parse(cid);
        int uid = int.Parse(HttpContext.Current.Session["userid"].ToString());
        DBFunctions db = new DBFunctions();
        Enroll_Course enroll = new Enroll_Course { CourseID = id, Uid = uid,Status=0 };
        db.Enrollcourse(enroll);
        return "ss";
    
    }

    [WebMethod]
    public static string EnrollCourse(string[] cid, int credithours)
    {
        string result = "";
        
        DBFunctions db = new DBFunctions();
        for (int i = 0; i < cid.Length;i++)
        {
            Enroll_Course enroll = new Enroll_Course { CourseID = Convert.ToInt16(cid[i]), Uid = uid, Status = 0 };
            db.Enrollcourse(enroll);
        }
        StudentSelectedCredit obj = db.getStudentCredits(uid).FirstOrDefault();
        if (obj == null)
        {
            StudentSelectedCredit temp = new StudentSelectedCredit();
            temp.UserID = uid;
            temp.SelectedCourseCount = credithours;
            int check = -1;
            check = db.AddCreditHours(temp);
            if (check != 1)
            {
                result = "Success";
            }
        }
        else
        {

            StudentSelectedCredit temp = new StudentSelectedCredit();
            temp.UserID = uid;
            temp.SelectedCourseCount = credithours;
            temp.ID = obj.ID;
            db.UpdateCreditHours(temp);
        }
       return result;
    }


    protected void dropdownstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        int flag = -1;
        int candidate = uid;
        coursetablelbl.Text = "";
        DBFunctions db = new DBFunctions();

        List<OfferedCourses_tbl> courses = db.getstudenoffercourses(candidate);
        Heading.Text = "<b class='heading'>Offered Courses for Programme " + db.getstudentprogram(candidate).ProgramName + "</b><br><br>";
        if (dropdownstatus.SelectedItem.Text == "All")
        {
            flag = 1;

            getcourses();
            return;
        }
        foreach (var c in courses)
        {
            Enroll_Course ec = c.Courses_tbl.Enroll_Course.Where(x => x.Uid == candidate).FirstOrDefault();
            if (dropdownstatus.SelectedItem.Text == "New")
            {
                flag = 1;
                if (ec == null) //status=3 for fail course
                {
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-primary enroll' data-courseid='" + c.CourseID + "' >Enroll</a></td></tr>";
                }
            }
                
            else if (ec!=null && ec.Status == int.Parse(dropdownstatus.SelectedValue))
            {
                flag = 1;
                if (ec.Status == 0)
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-info' data-courseid='" + c.CourseID + "' >Pending </a></td></tr>";
                else if (ec.Status == 1)
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-default' data-courseid='" + c.CourseID + "' >Already Enrolled </a></td></tr>";
                else if (ec.Status == -1)
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-danger' data-courseid='" + c.CourseID + "' >Rejected </a></td></tr>";
                else if (ec.Status == 3) //status=3 for fail course
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-danger enroll' data-courseid='" + c.CourseID + "' >ReEnroll</a></td></tr>";

            }
        }
        if (flag == -1)
        {
            coursetablelbl.Text = "<tr><td colspan=6>There is no " + dropdownstatus.SelectedItem.Text + " Couese(s)</td></tr>";
        }
    }

    public void getcourses()
    {
        DatabaseFunctions d = new DatabaseFunctions();
        int User = d.GetCandidateID(Userid);
        int candidate = User;
        DBFunctions db = new DBFunctions();

        List<OfferedCourses_tbl> courses = db.getstudenoffercourses(candidate);
        Heading.Text = "<b class='heading'>Offered Courses for Programme " + db.getstudentprogram(candidate).ProgramName + "</b><br><br>";
        foreach (var c in courses)
        {
            Enroll_Course ec = c.Courses_tbl.Enroll_Course.Where(x => x.Uid == candidate).FirstOrDefault();
            if (ec == null) 
            {
                coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' id='Check_"+c.CourseID+"'+ class='btn btn-primary enroll' data-courseid='" + c.CourseID + "' data-credithours='"+c.Courses_tbl.Credit_Hours+"' >Enroll</a></td></tr>";
            }
            else
            {
                if (ec.Status == 0)
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-info' data-courseid='" + c.CourseID + "' >Pending </a></td></tr>";
                else if (ec.Status == 1)
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-default' data-courseid='" + c.CourseID + "' >Already Enrolled </a></td></tr>";
                else if (ec.Status == -1)
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' class='btn btn-danger' data-courseid='" + c.CourseID + "' >Rejected </a></td></tr>";
                else if (ec.Status == 3) //status=3 for fail course
                    coursetablelbl.Text += "<tr><td>" + c.Courses_tbl.Course + "</td><td>" + c.Courses_tbl.Marks + "</td><td>" + c.Courses_tbl.Fee + "</td><td>" + c.Courses_tbl.Credit_Hours + "</td><td>" + c.Courses_tbl.CourseCode + "</td><td><a href='#0' id='Check_" + c.CourseID + "'+ class='btn btn-danger enroll' data-courseid='" + c.CourseID + "' data-credithours='" + c.Courses_tbl.Credit_Hours + "' >ReEnroll</a></td></tr>";
            }
        }

    
    }



}