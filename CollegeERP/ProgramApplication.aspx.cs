using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramApplication : System.Web.UI.Page
{
    public int page = 0;
    public int questionperpage = 5;
    public int totalpages = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPrograms();
            loadquestions();

        }
    }
    void LoadPrograms()
    {
      
    }
    protected void ProgramsRegister_Click(object sender, EventArgs e)
    {

    }
    public void loadquestions()
    {
        DBFunctions db = new DBFunctions();
        int count = page * questionperpage + 1;
        int i = 0;
        totalpages = Math.Abs(db.getquestioncount() / 5);
        List<Questionaire_tbl> questions = db.getquestions(page, questionperpage);
        foreach (Questionaire_tbl question in questions)
        {
            Questionlbl.Text += " <div class='form-group'>";
            Questionlbl.Text += "<label style='font-weight:bold' for='Question_lbl' data-id='" + question.Q_ID + "' id='question" + count + "' >" + question.Question + "</label>";
            Questionlbl.Text += " </div>";
            Questionlbl.Text += "  <br /> <div class='form-group'><div class='radioButtonList'>";

            List<Answers_tbl> answers = db.getanswers(question.Q_ID);
            foreach (Answers_tbl ans in answers)
            {
                Questionlbl.Text += " <input  type='radio' class='btn btn-default' name='" + question.Q_ID + "' id='answer" + i + "' value='" + ans.Answer + "'><span class='answerslbl'> " + ans.Answer + "</span>";
                i++;
            }
            count++;
            Questionlbl.Text += "</div></div><br><br>";
            if (page >= totalpages - 1)
            {
                NextBtn.Visible = false;
                submitbtn.Visible = true;
            }
        }
       
    }


    


    [WebMethod]
    public static string submitquestions(string[] questions, string[] answers)
    {

        return "done";
    }


    protected void NextBtn_Click(object sender, EventArgs e)
    {
        Questionlbl.Text = "";

        page++;
        loadquestions();
    }
}