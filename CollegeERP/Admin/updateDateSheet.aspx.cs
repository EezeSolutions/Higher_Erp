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
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] != null)
        {
            string action = Request.QueryString["action"];
            id = int.Parse(Request.QueryString["Datesheetid"]);
            if (!IsPostBack)
            {
                DBFunctions db = new DBFunctions();
                if (action == "update")
                {
                    CourseList.DataSource = db.getcourselist();
                    CourseList.DataValueField = "ID";
                    CourseList.DataTextField = "Course";
                    CourseList.DataBind();
                    // Courses_tbl course = db.getcourses(id);
                    DateSheet_tbl ds = db.getDateSheet(id);
                    ExamTypeList.SelectedValue = ds.ExamType;
                    StartTime.Text = ds.StartTime;
                    EndTime.Text = ds.EndTime;


                }
                else
                {

                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
    protected void updateDateSheetBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        // Program_tbl prgram = new Program_tbl { ID = id, ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormNum.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        DateSheet_tbl datesheet = new DateSheet_tbl { ID = id, ExamType = ExamTypeList.SelectedValue, Year = DateTime.Now.Year.ToString(), CourseID = int.Parse(CourseList.SelectedValue), StartTime = StartTime.Text, EndTime = EndTime.Text };
        db.updateDateSheet(datesheet);
        Response.Redirect("AddDateSheet.aspx");
    }


}