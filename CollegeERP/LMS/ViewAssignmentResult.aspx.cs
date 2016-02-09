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
        
        id = int.Parse(Request.QueryString["Aid"]);
        int stdid = int.Parse(Session["userid"].ToString());
        if (!IsPostBack)
        {
            DBFunctions db = new DBFunctions();
            
                List<Assignment_Result_tbl> aresult = db.getstudentassignmentresult(id,stdid);
                TotalMarks.Text = aresult.FirstOrDefault().Assignments_tbl.marks.ToString();
                ObtainedMarks.Text = aresult.FirstOrDefault().Assignment_Marks.ToString();
                


        }
            else
            {

            }
        }
    
    
}