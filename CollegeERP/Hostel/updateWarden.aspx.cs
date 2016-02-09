using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hostel_Default : System.Web.UI.Page
{
    int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        id = int.Parse(Request.QueryString["Wardenid"]);
        if (!IsPostBack)
        {
            DBFunctions db = new DBFunctions();
            if (action == "update")
            {
                HostelWarden_tbl wrd = db.getWarden(id);
                wardenname.Text = wrd.Name;
               
                wardenphone.Text = wrd.Phone;
                email.Text = wrd.Email;
                
                DropDownHostel.DataSource = db.gethostellist();
                
                DropDownHostel.DataTextField = "Name";
                DropDownHostel.DataValueField = "ID";
                DropDownHostel.DataBind();



            }
            else
            {

            }
        }

    }
  
    protected void btnupdatewarden_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        // Program_tbl prgram = new Program_tbl { ID = id, ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormNum.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        HostelWarden_tbl htl = new HostelWarden_tbl { ID = id, Name = wardenname.Text, Phone = wardenphone.Text, Email = email.Text, HostelID = int.Parse(DropDownHostel.SelectedValue) };
        db.updateWarden(htl);
        Response.Redirect("AddWarden.aspx");
    }
}