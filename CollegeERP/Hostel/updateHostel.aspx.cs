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
        id = int.Parse(Request.QueryString["Hostelid"]);
        if (!IsPostBack)
        {
            DBFunctions db = new DBFunctions();
            if (action == "update")
            {
                Hostel_tbl hostel = db.getHostel(id);
                hostelname.Text = hostel.Name;
                hosteladdress.Text = hostel.Address;
                phoneNo.Text = hostel.Phone;
                email.Text = hostel.Email;
                


            }
            else
            {

            }
        }

    }
    protected void btnupdatehostel_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        // Program_tbl prgram = new Program_tbl { ID = id, ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormNum.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        Hostel_tbl htl = new Hostel_tbl {ID=id, Name = hostelname.Text, Address = hosteladdress.Text, Phone = phoneNo.Text, Email = email.Text };
        db.updateHostel(htl);
        Response.Redirect("ManageHostel.aspx");
    }
}