using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] != null)
        {
            DBFunctions db = new DBFunctions();

            List<Program_tbl> programs = db.getprogramslist();
            foreach (Program_tbl prg in programs)
            {
                programstbl.Text += "<tr><td>" + prg.ProgramName + "</td><td>" + prg.ProgrameType + "</td><td>" + prg.Department_tbl.Department + "</td><td>" + prg.ApplicationFee + "</td><td>" + prg.AcceptenceFee + "</td><td>";

                if (prg.Enable == true)
                {
                    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

                }
                else
                {
                    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

                }

                programstbl.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + prg.ID + ">Update</a></td></tr>";

            }
            DropDownDept.DataSource = db.getalldepartments();
            ListItem item = new ListItem();
            item.Text = "Select Department";
            item.Value = "";
            DropDownDept.Items.Add(item);
            DropDownDept.DataTextField = "Department";
            DropDownDept.DataValueField = "ID";
            DropDownDept.DataBind();

        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
    protected void btnaddprogramme_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        
        Program_tbl prgram = new Program_tbl { ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormCh.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date,AcceptenceFee=txtAcceptenceFee.Text,FormCh=txtFormCh.Text };

        db.addprogramme(prgram);
    }
}