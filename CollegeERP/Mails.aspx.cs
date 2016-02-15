using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
        int pagesize = 15;
        int page = 1;
        int pagecount = 0;
        string UserID = "";
        int StudentID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagname = Path.GetFileName(Request.PhysicalPath);
        if (System.Web.HttpContext.Current.User != null)
        {
            bool LoggedStatus = false;
            LoggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (LoggedStatus)
            {
                UserID = Membership.GetUser().ProviderUserKey.ToString();
                DatabaseFunctions db = new DatabaseFunctions();
                StudentID = db.GetCandidateID(UserID);
                loadmails();
            }
            
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagname);
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        loadmails();
    }

    public void loadmails()
    {

        Inboxttbl.Text = "";
        string pagname = Path.GetFileName(Request.PhysicalPath);
        if (Request.QueryString["page"] != null)
        {
            page = int.Parse(Request.QueryString["page"]);
        }
        DBFunctions db = new DBFunctions();
        pagecount = (db.getadusermails_count(StudentID) + pagesize - 1) / pagesize;
        var mails = db.getusermails(page - 1, pagesize, StudentID);

        foreach (var mail in mails)
        {
            if (mail.Status == 1)
            {
                Inboxttbl.Text += "<tr class='read-mail read' data-mailid='" + mail.ID + "'>";
                if (mail.SenderID != null)
                    Inboxttbl.Text += " <td>" + mail.Candidate_tbl.Name + "</td>";
                else
                {
                    Inboxttbl.Text += " <td>Admin</td>";
                }
                Inboxttbl.Text += "  <td>" + mail.Subject + "</td><td>" + mail.Date.Value + "</td></tr>";
            }
            else if (mail.Status == 0)
            {
                Inboxttbl.Text += "<tr class='new-mail read' data-mailid='" + mail.ID + "'>";
                if (mail.SenderID != null)
                    Inboxttbl.Text += " <td>" + mail.Candidate_tbl.Name + "</td>";
                else
                {
                    Inboxttbl.Text += " <td>Admin</td>";
                }
                Inboxttbl.Text += "<td>" + mail.Subject + "</td><td>" + mail.Date.Value + "</td></tr>";

            }
        }
        if (pagecount > 1)
        {
            for (int i = 1; i <= pagecount; i++)
            {
                if (page != i)
                    Paging.Text += "<li class=''><a  href='" + pagname + "?page=" + i + "'>" + i + "</a></li>";
                else
                    Paging.Text += "<li><a style='background: #f0f0f0;'>" + i + "</a></li>";
            }
        }
    }
}