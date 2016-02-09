using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Default : System.Web.UI.Page
{
    int id = -1;
    int userid = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["userid"] != null)
        {
            string action = Request.QueryString["action"];
            id = int.Parse(Request.QueryString["Bookid"]);
            DBFunctions db = new DBFunctions();
            Book st = new Book();
            st = db.loadBook(id);
            if (!IsPostBack)
            {

                bookname.Text = st.Title;
                category.Text = st.Category;
                daIsbnNo.Text = st.ISBN;



            }
        }
        else
        {
            Response.Redirect("../Login.aspx?Redirecturl=" +"Library/"+ pagename+"?Bookid="+Request.QueryString["Bookid"]+"&action=update");

        }
       
    }
    protected void OrderBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int uid = int.Parse(Session["userid"].ToString());
        int mid = db.getmemberid(uid);
        IssueBook ib = new IssueBook {MemberID=mid,BookID=id,Status=0};
        db.placeOrder(ib);
        Response.Redirect("AvailableBooks.aspx");
    }
}