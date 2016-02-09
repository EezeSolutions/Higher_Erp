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
             DBFunctions db = new DBFunctions();
             setprogrammes();
             if (!IsPostBack)
             {
                 if (Request.QueryString["stdid"] != null)
                 {
                     setdateofbirth();
                     setstates();
                     int stdid = int.Parse(Request.QueryString["stdid"]);
                     var student = db.getstdentinfo(stdid);
                     StudentName.Text = student.Candidate_tbl.Name;
                     MetricNo.Text = student.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo;
                     DropDownProgram.SelectedValue = student.ProgramID.ToString();
                     Semester.Text = student.Semester.ToString();
                     Ayear.Text = student.AcadamicYear.ToString();
                     FeeDiscount.Text = student.FeeDiscount;
                     txtHomeaddress.Text = student.Candidate_tbl.HomeAdress;
                     Emailtxt.Text = student.Candidate_tbl.Email;
                     Phonetxt.Text = student.Candidate_tbl.Phone;
                     dropdownSto.SelectedValue = student.Candidate_tbl.Stateoforigin.ToString();
                     dropdownDay.SelectedValue = student.Candidate_tbl.DateofBirth.Split('-')[0];
                     dropdownMonth.SelectedValue = student.Candidate_tbl.DateofBirth.Split('-')[1];
                     dropdownyears.SelectedValue = student.Candidate_tbl.DateofBirth.Split('-')[2];
                     setareas();
                     dropdownLocalGovtarea.SelectedValue = student.Candidate_tbl.LocalGovtArea.ToString();

                 }
             }
         }

         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }
    }

    public void setareas()
    {
        DBFunctions db = new DBFunctions();
        dropdownLocalGovtarea.DataSource = db.Getareas(int.Parse(dropdownSto.SelectedItem.Value));
        dropdownLocalGovtarea.DataTextField = "Area";
        dropdownLocalGovtarea.DataValueField = "ID";
        dropdownLocalGovtarea.DataBind();
    }
    private void setprogrammes()
    {
        DBFunctions db = new DBFunctions();
        DropDownProgram.DataSource = db.getprogramslist();
        DropDownProgram.DataTextField = "ProgramName";
        DropDownProgram.DataValueField = "ID";
    
        DropDownProgram.DataBind();
    }
    protected void btnupdatestudent_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
   
        db.updatestudtent(int.Parse(Request.QueryString["stdid"]),StudentName.Text,int.Parse(DropDownProgram.SelectedValue),int.Parse(Semester.Text),FeeDiscount.Text,txtHomeaddress.Text, int.Parse(dropdownSto.SelectedValue),int.Parse(dropdownLocalGovtarea.SelectedValue),Emailtxt.Text,dropdownDay.SelectedItem.Text + "-" + dropdownMonth.SelectedItem.Text + "-" + dropdownyears.SelectedItem.Text,Phonetxt.Text);
        Response.Redirect("Admittedstudents.aspx");
    }
    protected void dropdownSto_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        if (dropdownSto.SelectedItem.Value == "")
        {
            return;
        }
        dropdownLocalGovtarea.DataSource = db.Getareas(int.Parse(dropdownSto.SelectedItem.Value));
        dropdownLocalGovtarea.DataTextField = "Area";
        dropdownLocalGovtarea.DataValueField = "ID";
        dropdownLocalGovtarea.DataBind();
    }

    protected void setdateofbirth()
    {
        int j = 0;

        for (int i = 1985; i < 2015; i++)
        {

            dropdownyears.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }

        for (int i = 1; i < 32; i++)
        {

            dropdownDay.Items.Insert((i - 1), new ListItem(i.ToString(), i.ToString()));

        }
    }


    protected void setstates()
    {

        DBFunctions db = new DBFunctions();
        dropdownSto.DataSource = db.getstates();
        dropdownSto.DataTextField = "State";
        dropdownSto.DataValueField = "ID";
        dropdownSto.DataBind();

    }
}