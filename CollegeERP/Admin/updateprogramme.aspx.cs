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
            id = int.Parse(Request.QueryString["programmeid"]);
            if (!IsPostBack)
            {

                DBFunctions db = new DBFunctions();

                if (action == "Disable")
                {
                    db.disableeprogmme(id);
                    Response.Redirect("ManagePrograms.aspx");
                }
                else if (action == "Enable")
                {
                    db.Enableeprogmme(id);
                    Response.Redirect("ManagePrograms.aspx");
                }
                else if (action == "update")
                {
                    DropDownDept.DataSource = db.getalldepartments();
                    DropDownDept.DataValueField = "ID";
                    DropDownDept.DataTextField = "Department";
                    DropDownDept.DataBind();
                    Program_tbl program = db.getprogram(id);
                    DropDownDept.SelectedValue = program.DeptID.ToString();
                    ProgrammeNametxt.Text = program.ProgramName;
                    dropdownSecondChoise.SelectedValue = program.SecondChoice.ToString();
                    Cuttofpointstxt.Text = program.CutoffPoints;
                    dropdownCampus.SelectedValue = program.HasCampus.ToString();
                    txtApplicationFee.Text = program.ApplicationFee;
                    txtAcceptenceFee.Text = program.AcceptenceFee;
                    txtFormCh.Text = program.FormCh;
                    txtFormNum.Text = program.FormNumber;
                    dropdownPrograms.SelectedValue = program.ProgramType;
                    dropdownJamb.SelectedValue = program.HasJambData.ToString();
                    dropdownOlevel.SelectedValue = program.HasOlevelResult.ToString();
                    dropdownPreviousRecord.SelectedValue = program.HasPreviousRecord.ToString();
                    dropdownBioData.SelectedValue = program.HasBioDataSection.ToString();
                    dropdownCbtSchedule.SelectedValue = program.HasCBTSchedule.ToString();

                }

                else if (action == "viewdetail")
                {

                }

            }
        }

        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }


    protected void btnaddprogramme_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        Program_tbl prgram = new Program_tbl { ID = id, ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormNum.Text, ProgramType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        db.updateprogram(prgram);
        Response.Redirect("ManagePrograms.aspx");

    }
}