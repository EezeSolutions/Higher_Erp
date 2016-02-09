

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
   static string QuestionareContent = ""; 
   public int page = 0;
   public int questionperpage = 5;
   public int totalpages = 0;
   static int UserID = 0;
   protected void Page_Load(object sender, EventArgs e)
   {
       string pagename = Path.GetFileName(Request.PhysicalPath);
       ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
       scriptManager.RegisterPostBackControl(this.submitbtn);
       if (Session["userid"] != null)
       {
           if (!IsPostBack)
           {
               UserID = Convert.ToInt16(Session["userid"].ToString());
               loadquestions();

           }
       }
       else
       {
           Response.Redirect("Login.aspx?Redirecturl=" + pagename);
       }
     
   }

    public void loadquestions()
    {
        DBFunctions db = new DBFunctions();
        int count = page*questionperpage+1;
        int i = 0;
        totalpages= Math.Abs(db.getquestioncount()/5);
        List<Questionaire_tbl> questions = db.getquestions(page,questionperpage);
        foreach(Questionaire_tbl question in questions)
        {
            Questionlbl.Text += " <div id='check2' class='form-group'>";
    Questionlbl.Text+="<label style='font-weight:bold' for='Question_lbl' data-id='"+question.Q_ID+"' id='question"+count+"' >"+question.Question+"</label>";
       Questionlbl.Text+=" </div>";
       Questionlbl.Text += "  <br /> <div class='form-group'><div class='radioButtonList'>";
      
      List<Answers_tbl> answers = db.getanswers(question.Q_ID);
            foreach(Answers_tbl ans in answers)
            {
                Questionlbl.Text += " <input  type='radio' class='btn btn-default' name='" + question.Q_ID + "' id='answer" + i + "' value='" + ans.Answer + "'><span class='answerslbl'> " + ans.Answer + "</span>";
                i++;
            }
            count++;
        Questionlbl.Text += "</div></div><br><br>";
            if(page>=totalpages-1)
            {
                NextBtn.Visible = false;
                submitbtn.Visible = true;
            }
        }

    }


    protected void NextBtn_Click(object sender, EventArgs e)
    {
        Questionlbl.Text = "";
        
        page++;
        loadquestions();
    }


    [WebMethod]
    public static string submitquestions(string[] questions,string[] answers)
    {
        //QuestionareContent = questions;
        for (int i = 0; i < questions.Length;i++)
        {
           // Applicantlist.Text += "<tr><td>" + app.Name + "</td><td>" + app.HomeAdress + "," + app.Areas_tbl.Area + "," + app.States_tbl.State + "</td><td>" + app.CuttoffPoints + "</td><td>" + app.Program_tbl.ProgramName + "</td><td>" + app.Gender + "</td><td>" + app.Email + "</td><td>" + app.Phone + "</td><td></td></tr>";
            QuestionareContent = "<tr><td>"+QuestionareContent + "</td></tr>" +"<tr><td>"+questions[i]+"</td></tr></br>"+"<tr><td>"+answers[i]+"</td></tr>";
            
        }

            return "";
    }
    protected void submitbtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        string html = System.IO.File.ReadAllText(Server.MapPath("QuestionarePage.html"));
        Byte[] bytes;
        html = html.Replace("{QuestionsList}",QuestionareContent);


        
        using (var ms = new MemoryStream())
        {
            var doc = new Document();
            doc = new Document(PageSize.A4, 30, 30, 30, 30);

            var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
            doc.Open();
            doc.NewPage();

            var example_html = html;
            using (var htmlWorker = new HTMLWorker(doc))
            {
                using (var sr = new StringReader(example_html))
                {
                    htmlWorker.Parse(sr);
                }
            }
            doc.Close();
            bytes = ms.ToArray();
            
           
        }
        long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;



        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + UserID + "_Quesions.pdf");
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.BinaryWrite(bytes);
         
        db.AddQuestionare(UserID);  
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Close();
       
    }
}