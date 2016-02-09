using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["admin"] != null)
         {
             if (!IsPostBack)
             {
                 getenrollapps();
             }
         }
         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }
    }


   
    protected void dropdownstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        coursetablelbl.Text = "";
        int flag = -1;
        DBFunctions db = new DBFunctions();
        var enrollapps = db.getenrollmentapplications();
        if (dropdownstatus.SelectedValue != "All")
        {
            foreach (Enroll_Course ec in enrollapps)
            {
                if (ec.Status == int.Parse(dropdownstatus.SelectedValue))
                {
                    flag = 1;
                    if (ec.Status == 1)
                        coursetablelbl.Text += "<tr><td>" + ec.Courses_tbl.Course + "</td><td>" + ec.Courses_tbl.Marks + "</td><td>" + ec.Courses_tbl.Fee + "</td><td>" + ec.Courses_tbl.Credit_Hours + "</td><td>" + ec.Candidate_tbl.Name + "</td><td>" + ec.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td><a class='btn btn-info' data-appid='" + ec.ID + ",1'>" + dropdownstatus.SelectedItem.Text + "</a></td></tr>";
                    else if (ec.Status == 0)
                    {
                        coursetablelbl.Text += "<tr><td>" + ec.Courses_tbl.Course + "</td><td>" + ec.Courses_tbl.Marks + "</td><td>" + ec.Courses_tbl.Fee + "</td><td>" + ec.Courses_tbl.Credit_Hours + "</td><td>" + ec.Candidate_tbl.Name + "</td><td>" + ec.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td><a class='btn btn-primary enroll' data-appid='" + ec.ID + ",1'>Enroll</a> <a class='btn btn-primary enroll' data-appid='" + ec.ID + ",-1'>Reject</a></td></tr>";

                    }
                    if (ec.Status == -1)
                        coursetablelbl.Text += "<tr><td>" + ec.Courses_tbl.Course + "</td><td>" + ec.Courses_tbl.Marks + "</td><td>" + ec.Courses_tbl.Fee + "</td><td>" + ec.Courses_tbl.Credit_Hours + "</td><td>" + ec.Candidate_tbl.Name + "</td><td>" + ec.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td><a class='btn btn-danger' data-appid='" + ec.ID + ",1'>" + dropdownstatus.SelectedItem.Text + "</a></td></tr>";

                }
            }
        }
        else
        {
            flag = 1;
            getenrollapps();
        }
        if(flag==-1)
        {
            coursetablelbl.Text = "<tr><td colspan=6>There is no " +dropdownstatus.SelectedItem.Text+ " Enrollment Application(s)</td></tr>";
        }
        
    }
    public void getenrollapps()
    {
        DBFunctions db = new DBFunctions();
        var enrollapps = db.getenrollmentapplications();

        foreach (Enroll_Course ec in enrollapps)
        {
            if (ec.Status == 0)
                //
                coursetablelbl.Text += "<tr><td>" + ec.Courses_tbl.Course + "</td><td>" + ec.Courses_tbl.Marks + "</td><td>" + ec.Courses_tbl.Fee + "</td><td>" + ec.Courses_tbl.Credit_Hours + "</td><td>" + ec.Candidate_tbl.Name + "</td><td>" + ec.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td><a class='btn btn-primary enroll' data-appid='" + ec.ID + ",1'>Enroll</a> <a class='btn btn-primary enroll' data-appid='" + ec.ID + ",-1'>Reject</a></td></tr>";
            else if (ec.Status == 1)
            {
                coursetablelbl.Text += "<tr><td>" + ec.Courses_tbl.Course + "</td><td>" + ec.Courses_tbl.Marks + "</td><td>" + ec.Courses_tbl.Fee + "</td><td>" + ec.Courses_tbl.Credit_Hours + "</td><td>" + ec.Candidate_tbl.Name + "</td><td>" + ec.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td><a class='btn btn-info' data-appid='" + ec.ID + ",1'>Enrolled</a> </td></tr>";

            }
            else if (ec.Status == -1)
                coursetablelbl.Text += "<tr><td>" + ec.Courses_tbl.Course + "</td><td>" + ec.Courses_tbl.Marks + "</td><td>" + ec.Courses_tbl.Fee + "</td><td>" + ec.Courses_tbl.Credit_Hours + "</td><td>" + ec.Candidate_tbl.Name + "</td><td>" + ec.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo + "</td><td><a class='btn btn-danger' data-appid='" + ec.ID + ",1'>Rejected</a> </td></tr>";

        }
    }


    [WebMethod]
    public static string Enroll(string appid, string status)
    {

        DBFunctions db = new DBFunctions();
        db.updateenrollment(int.Parse(appid), status);
        return "ss";
    }
}