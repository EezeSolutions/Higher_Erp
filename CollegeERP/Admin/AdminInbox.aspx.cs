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
        if (!IsPostBack)
        {
            loadmails();
        }
    }

    private void loadmails()
    {
        Inboxttbl.Text = "";
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] != null)
        {
            int pagesize = 15;
            int page = 1;
            int pagecount = 0;

            if (Request.QueryString["page"] != null)
            {
                page = int.Parse(Request.QueryString["page"]);
            }
            DBFunctions db = new DBFunctions();
            pagecount = (db.getadminmails_count() + pagesize - 1) / pagesize;
            var mails = db.getadminmails(page - 1, pagesize);

            foreach (var mail in mails)
            {
                if (mail.Status == 1)
                    Inboxttbl.Text += "<tr class='read-mail read' data-mailid='" + mail.ID + "'><td>" + mail.Candidate_tbl.Name + "</td><td>" + mail.Subject + "</td><td>" + mail.Date.Value + "</td></tr>";
                else if (mail.Status == 0)
                {
                    Inboxttbl.Text += "<tr class='new-mail read' data-mailid='" + mail.ID + "'><td>" + mail.Candidate_tbl.Name + "</td><td>" + mail.Subject + "</td><td>" + mail.Date.Value + "</td></tr>";

                }
            }
            if (pagecount > 1)
            {
                for (int i = 1; i <= pagecount; i++)
                {
                    if (page != i)
                        Paging.Text += "<li class=''><a style='background: #f0f0f0;' href='" + pagename + "?page=" + i + "'>" + i + "</a></li>";
                    else
                        Paging.Text += "<li><a>" + i + "</a></li>";
                }
            }


        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
    protected void timer1_Tick(object sender, EventArgs e)
    {
        loadmails();
    }
}