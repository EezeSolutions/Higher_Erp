using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        id = int.Parse(Request.QueryString["Questionid"]);
        if (!IsPostBack)
        {
            DBFunctions db = new DBFunctions();
            Support_tbl st = new Support_tbl();
            st=db.loadQuestion(id);
            SenderQuestion.Text = st.Question;
            answer.Text = st.Answer;
            date.Text = st.Date.ToString();
        }
    }
}