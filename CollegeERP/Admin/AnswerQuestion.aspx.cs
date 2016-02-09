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
    int userid = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] != null)
        {
            string action = Request.QueryString["action"];
            id = int.Parse(Request.QueryString["Questionid"]);
            DBFunctions db = new DBFunctions();
            Support_tbl st = new Support_tbl();
            st = db.loadQuestion(id);
            if (!IsPostBack)
            {

                SenderQuestion.Text = st.Question;
                answerText.Text = st.Answer;

                date.Text = st.Date.ToString();
            }
            userid = st.UserID.Value;
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
    protected void AnswerBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        // Program_tbl prgram = new Program_tbl { ID = id, ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormNum.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        Support_tbl answer = new Support_tbl { ID = id,UserID=userid, Question = SenderQuestion.Text, Answer=answerText.Text,Date=DateTime.Now,Status=1 };
        db.updatequestion(answer);
        Response.Redirect("AskedQuestions.aspx");
    }
}