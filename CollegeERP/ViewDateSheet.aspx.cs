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

        if (Session["userid"] != null)
        {
            int uid = int.Parse(Session["userid"].ToString());
            DBFunctions db = new DBFunctions();

            var datesheet = db.getdatesheet(uid);

            foreach(var ds in datesheet){
                Datesheettbl.Text += "<tr><td>"+ds.Courses_tbl.Course+"</td><td>"+ds.Year+"</td><td>"+ds.StartTime+"</td><td>"+ds.EndTime+"</td><td>"+ds.ExamType+"</td></tr>";
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
}