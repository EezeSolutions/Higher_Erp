using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["admin"] != null)
         {
             if (Request.QueryString["mailid"] != null)
             {
                 int mailid = int.Parse(Request.QueryString["mailid"]);
                 DBFunctions db = new DBFunctions();
                 var mail = db.getadminmail(mailid);
                 fromlbl.Text = mail.Candidate_tbl.Name;
                 subjectlbl.Text = mail.Subject;
                 Messagelbl.Text = mail.Message;
             }
         }
         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }
    }
}