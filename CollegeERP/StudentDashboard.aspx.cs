using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["userid"] != null)
         {
         }
         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }

    }
    [WebMethod(EnableSession = true)]
    public static string getinboxcount()
    {
        DBFunctions db = new DBFunctions();
        if(HttpContext.Current.Session["userid"]==null){
            return "0";
        }
        //return db.getstudentinboxcount(int.Parse(HttpContext.Current.Session["userid"].ToString())).ToString();
        return "";
    }
}