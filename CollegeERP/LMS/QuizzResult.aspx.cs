using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LMS_Default : System.Web.UI.Page
{
    int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        id = int.Parse(Request.QueryString["Quizzid"]);
        int stdid = int.Parse(Session["userid"].ToString());
        if (!IsPostBack)
        {
            DBFunctions db = new DBFunctions();
            if (action == "update")
            {
                List<Student_Quizz_Mapping_tbl> sq = db.getstudentquizzes(id,stdid);
                TotalMarks.Text = sq.FirstOrDefault().Quizz_tbl.Total_Marks.ToString();
                ObtainedMarks.Text = sq.FirstOrDefault().Mark_Obtained.ToString();
                


            }
            else
            {

            }
        }
    }
}