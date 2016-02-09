using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["admin"] != null)
         {
         }
         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }

    }

    [WebMethod]
    public static string AddQuestion(string question, string[] answers)
    {
        DBFunctions db = new DBFunctions();
        db.addQuestion(question, answers);

        return "Added";
    }
}