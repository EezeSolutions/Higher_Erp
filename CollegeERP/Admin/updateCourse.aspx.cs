using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
           string action = Request.QueryString["action"];
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["admin"] != null)
         {
             if (Request.QueryString["Courseid"] != null)
             {
                 id = int.Parse(Request.QueryString["Courseid"]);
                 if (!IsPostBack)
                 {
                     DBFunctions db = new DBFunctions();
                     if (action == "update")
                     {
                         checkbocprogamlist.DataSource = db.getprogramslist();
                         checkbocprogamlist.DataValueField = "ID";
                         checkbocprogamlist.DataTextField = "ProgramName";
                         checkbocprogamlist.DataBind();
                         
                         foreach(ListItem item in checkbocprogamlist.Items)
                         {
                             var check=db.getprogramcours(int.Parse(item.Value),id);
                             if (check != null)
                             {
                                 item.Selected = true;    
                             }
                         }
                         Courses_tbl course = db.getcourses(id);

                         coursename.Text = course.Course;
                         Feetxt.Text = course.Fee;
                         Markstxt.Text = course.Marks;
                         CourseCode.Text = course.CourseCode;
                         CreditHours.Text = course.Credit_Hours.ToString();


                     }
                     else
                     {

                     }
                 }
             }
             else
             {
                 Response.Redirect("ManageCourses.aspx");

             }
         }
         else
         {
             if(id!=-1)
             Response.Redirect("Login.aspx?Redirecturl=" + pagename + "?Courseid="+id+"&action=update");
             else
                 Response.Redirect("Login.aspx?Redirecturl="+pagename);

         }
    }


    protected void btnupdatecourse_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        //Program_tbl prgram = new Program_tbl { ID = id, ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormNum.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        Courses_tbl course = new Courses_tbl { ID = int.Parse(Request.QueryString["Courseid"]), Course = coursename.Text, Fee = Feetxt.Text, Marks = Markstxt.Text, CourseCode = CourseCode.Text, Credit_Hours = int.Parse(CreditHours.Text) };
        db.updatecourse(course);
        db.clearprogramcourses(int.Parse(Request.QueryString["Courseid"]));
        foreach (ListItem item in checkbocprogamlist.Items)
        {
            if (item.Selected)
            {
                ProgrammeCourses_tbl programcourse = new ProgrammeCourses_tbl { CourseID = int.Parse(Request.QueryString["Courseid"]), ProgramID = int.Parse(item.Value) };
                db.addprogrammecourse(programcourse);
            }

        }
            Response.Redirect("ManageCourses.aspx");
    }
}