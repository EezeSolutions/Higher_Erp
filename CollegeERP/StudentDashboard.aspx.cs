using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static string Userid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         
         bool loggedStatus = false;
         if (System.Web.HttpContext.Current.User != null)
         {
             DatabaseFunctions db = new DatabaseFunctions();
             loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
             if (loggedStatus)
             {
                 Userid = Membership.GetUser().ProviderUserKey.ToString();
                 //  loadprogrammes();
                

             }
             else
             {
                 Response.Redirect("Login.aspx");
             }
         }

    }
    [WebMethod(EnableSession = true)]
    public static string getinboxcount()
    {
        DBFunctions db = new DBFunctions();
        if(System.Web.HttpContext.Current.User != null){
            DatabaseFunctions d = new DatabaseFunctions();
            int check = d.GetCandidateID( Membership.GetUser().ProviderUserKey.ToString());
            if (check != -1)
            {
                return db.getstudentinboxcount(check).ToString();
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "0";
        }
        
        
    }
}