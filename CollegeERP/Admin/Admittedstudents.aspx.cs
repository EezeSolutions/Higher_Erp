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
        if (Session["admin"] != null)
        {
            //<th>Name</th><th>programme</th><th>Metric #</th><th>Semester</th><th>Acadamic Year</th><th>Fee Discount</th>
            DBFunctions db = new DBFunctions();
            if (!IsPostBack)
            {
                setprogrammes();

                var students = db.getadmittedstudents();
                loadstudents(students);
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }

    private void loadstudents(List<StudentInfo_tbl> students)
    {
        foreach (var std in students)
        {
            Studentslbl.Text += "<tr><td>" + std.Candidate_tbl.Name + "</td><td>" + std.Program_tbl.ProgramName + "</td><td>" + std.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td>" + std.Semester + "</td><td>" + std.AcadamicYear + "</td><td>" + std.FeeDiscount + "</td><td><a href='Updatestudent.aspx?stdid="+std.UserId+"' class='btn btn-primary'>Update</a></td></tr>";
        }

    }

    
    private void setprogrammes()
    {
        DBFunctions db = new DBFunctions();
        dropdownprogramme.DataSource = db.getprogramslist();
        dropdownprogramme.DataTextField = "ProgramName";
        dropdownprogramme.DataValueField = "ID";
        dropdownprogramme.Items.Add("All");
        dropdownprogramme.DataBind();
    }
    protected void dropdownprogramme_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        Studentslbl.Text = "";
        List<StudentInfo_tbl> students;
        if (dropdownprogramme.SelectedItem.Text == "All")
        {
            students = db.getadmittedstudents();
        }
        else
        {
            students = db.getadmittedstudents().Where(x => x.ProgramID == int.Parse(dropdownprogramme.SelectedValue)).ToList();
        }
        loadstudents(students);
    }
}