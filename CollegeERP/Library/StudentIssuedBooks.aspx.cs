using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {

                getissuedbooks();
            }
            else
            {
                Response.Redirect("../Login.aspx?Redirecturl=Library/" + pagename);
            }
        }
    }

    private void getissuedbooks()
    {
        DBFunctions db = new DBFunctions();
        int uid= int.Parse(Session["userid"].ToString());
        var books = db.getstudentissuedbooks(uid);
        loadbooks(books);
       
    }
    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int uid = int.Parse(Session["userid"].ToString());
        var books = db.getstudentissuedbooks(uid).Where(x => x.Book.ISBN.Contains(SearchButton.Text)).ToList();
        
        loadbooks(books);
    }

    public void loadbooks(List<IssueBook> books)
    {
        issuebookstbl.Text = "";
        foreach (var book in books)
        {
            int diff = book.DueDate.Value.Date.Subtract(DateTime.Now.Date).Days;
            if (diff <= 3)
                issuebookstbl.Text += "<tr class='alert-danger'><td>" + book.Book.Title + "</td><td>" + book.Book.Category + "</td><td>" + book.Book.ISBN + "</td><td>" + book.IssueDate.Value.ToShortDateString() + "</td><td>" + book.DueDate.Value.ToShortDateString() + "</td><td><a href='#0' class='btn btn-default'></a></td></tr>";

            else
            {
                issuebookstbl.Text += "<tr><td>" + book.Book.Title + "</td><td>" + book.Book.Category + "</td><td>" + book.Book.ISBN + "</td><td>" + book.IssueDate.Value.ToShortDateString() + "</td><td>" + book.DueDate.Value.ToShortDateString() + "</td><td><a href='#0' class='btn btn-default'></a></td></tr>";

            }
        }
    }
}