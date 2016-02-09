using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
            setdepartment();
        }
    }
    protected void DropDowndepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        if(DropDowndepartment.SelectedValue==""){
            return;
        }
        int deptid=int.Parse(DropDowndepartment.SelectedValue);
           var programs = db.getprogramslist().Where(x => x.DeptID == deptid).ToList();
        Program_tbl prgrm=new Program_tbl{ProgramName="Select Programme"};
        programs.Add(prgrm);
        DropDownprogramme.DataSource = programs.OrderBy(x=>x.ID);
        DropDownprogramme.DataTextField = "ProgramName";
        DropDownprogramme.DataValueField = "ID";
        DropDownprogramme.DataBind();

        DropDownteacher.DataSource = db.getallemployee(0, db.getemployee_count(deptid), deptid);
        DropDownteacher.DataTextField = "Name";
        DropDownteacher.DataValueField = "ID";
        DropDownteacher.DataBind();
    }

    public void setdepartment()
    {
        DBFunctions db = new DBFunctions();

        DropDowndepartment.DataSource = db.getalldepartments();
        DropDowndepartment.DataTextField = "Department";
        DropDowndepartment.DataValueField = "ID";
        DropDowndepartment.DataBind();

       
    }

    protected void DropDownprogramme_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        DropDownCourse.Items.Clear();
      //  DBFunctions db = new DBFunctions();
        var programcrs = db.getprogramcourselist(int.Parse(DropDownprogramme.SelectedValue));
        foreach (var crs in programcrs)
        {
            DropDownCourse.Items.Add(new ListItem(crs.Courses_tbl.Course,crs.CourseID.ToString()));
        }
    }

    protected void BtnSumit_Click(object sender, EventArgs e)
    {
        mesg.Visible = false;
        DBFunctions db = new DBFunctions();
        int empid = int.Parse(DropDownteacher.SelectedValue);
        int crsid = int.Parse(DropDownCourse.SelectedValue);
        CourseTeacherAssignment_tbl assigncourse = new CourseTeacherAssignment_tbl { CourseID = crsid, TeacherID = empid };
        int flag= db.assignteachercourse(assigncourse);
        if (flag==2)
        {
            mesg.Visible = true;
                      //<p class="alert alert-danger col-lg-offset-3 col-lg-9" runat="server" id="mesg" visible="false"></p>
            mesg.Text = "<p class='alert alert-danger col-lg-offset-3 col-lg-6'> The Course of "+DropDownCourse.SelectedItem.Text+" is already assigned to "+DropDownteacher.SelectedItem.Text+"</p>";
        }
        else if(flag==1)
        {
            mesg.Visible = true;

            mesg.Text = "<p class='alert alert-info col-lg-offset-3 col-lg-6'> The Course of " + DropDownCourse.SelectedItem.Text + " is Successfuly assigned to " + DropDownteacher.SelectedItem.Text + "</p>";

        }

        else if (flag == -1)
        {
            mesg.Visible = true;

            mesg.Text = "<p class='alert alert-danger col-lg-offset-3 col-lg-6'> The Course of " + DropDownCourse.SelectedItem.Text + " is already assigned to another teacher</p>";

        }
    }
}