using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int ID = int.Parse(Request.QueryString["id"]);
                string action = Request.QueryString["action"];
                DBFunctions db = new DBFunctions();
                if (action == "Reject")
                {
                    
                    db.updatebookrequest(ID, DateTime.Now.Date, -1);
                    Response.Redirect("BookRequests.aspx");
                    return;
                }
                var request = db.getBookRequest(ID);
                BookTitle.Text = request.Book.Title;
                Issueto.Text = request.LibraryMember.Candidate_tbl.Name;
                IssueDate.Text = DateTime.Now.ToShortDateString();
            }
            for (int i = 1; i < 32; i++)
            {

                dropdownDay.Items.Insert((i - 1), new ListItem(i.ToString(), i.ToString()));

            }
            dropdownDay.SelectedValue = DateTime.Now.Day.ToString();
            dropdownMonth.SelectedValue = DateTime.Now.Month.ToString();
        }
    }

    protected void btnIssuebook_Click(object sender, EventArgs e)
    {
      int ID = int.Parse(Request.QueryString["id"]);
      string duedate = dropdownMonth.Text + "-" + dropdownDay.Text+"-" + DateTime.Now.Year;
      DateTime ddate = DateTime.Parse(duedate);
        if(DateTime.Now.Date<=ddate)
        {
      DBFunctions db = new DBFunctions();
      db.updatebookrequest(ID,ddate,1);
      Response.Redirect("BookRequests.aspx");

        }
        else
        {
            datemessage.Visible = true;
        }


    }
}