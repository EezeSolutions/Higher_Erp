using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Default : System.Web.UI.Page
{
    int page = 1;
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
       
    protected void Page_Load(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();




        int pageStart = 1;
        int pageEnd = 10;
        if (Request.QueryString.ToString().Contains("page"))
        {
            page = Convert.ToInt32(Request.QueryString["page"].ToString());
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        }


        List<IssueBook> ds = new List<IssueBook>();
        ds = db.getIssuebooklist(page-1, pageSize);


        literalStart.Text = pageStart.ToString();
        literalEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getbookRequest_Count();



        if (pageEnd > 10)
        {
            literalTotal.Text = pageEnd.ToString();

            int pagett = 0;
            pagett = Convert.ToInt16(literalEnd.Text);

            if (pagett > pageEnd)
            {
                literalEnd.Text = pageEnd.ToString();
            }

        }
        else
        {
            if (pageEnd == 0)
            {
                literalStart.Text = "";
            }
            literalTotal.Text = pageEnd.ToString();
            literalEnd.Text = pageEnd.ToString();
        }


        string tmpUrl = string.Empty;
        tmpUrl = "BookRequests.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("?page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
        }

        StringBuilder listingString = new StringBuilder();

        if (ds != null)
        {
            loadBooks(ds);
        }


        if (pageEnd > 10)
        {
            StringBuilder paging = new StringBuilder();
            int counterPage = 1;
            int totalPages = 1;

            totalPages = (pageEnd / 10) + 1;
            string urlMain = string.Empty;
            urlMain = Request.Url.ToString();
            if (urlMain.Contains("?page"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("?page"));
            }

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href=\"" + urlMain + "\" >&lt;&lt;</a></li>";
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "?page=" + i + "\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "?page=" + i + "\" >" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "?page=" + i + "\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href=\"" + urlMain + "?page=" + i + "\" >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "?page=" + totalPages + "\" >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "?page=" + i + "\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "?page=" + i + "\" >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            literalPaging.Text = paging.ToString();
        }

    }

    private void loadBooks(List<IssueBook> ds)
    {
        List<IssueBook> book = ds;

        foreach (IssueBook bks in book)
        {
            if (bks != null)
            {
                //<th>Book Name</th><th>Category</th><th>ISBN</th><th>Available Books</th><th>Student Name</th><th>Action
                programstbl.Text += "<tr><td>" + bks.Book.Title + "</td><td>" + bks.Book.Category + "</td><td>" + bks.Book.ISBN + "</td><td>" + bks.Book.Quantity + "</td><td>" + bks.LibraryMember.Candidate_tbl.Name + "</td><td>";

                //if (crs.Enable == true)
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

                //}
                //else
                //{

                //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

                //}
                if (bks.Status == 0)
                {
                    programstbl.Text += "<a href='updatebookrequest.aspx?id=" + bks.ID + "&action=Accept' class='btn btn-success btn-action update' data-id=" + bks.BookID + ">Accept</a> ";
                    programstbl.Text += "<a href='updatebookrequest.aspx?id=" + bks.ID + "&action=Reject' class='btn btn-primary btn-action update' data-id=" + bks.BookID + ">Reject</a></td></tr>";
                }
                else if(bks.Status==1)
                {
                    programstbl.Text += "<a href='#0' class='btn btn-success btn-action update' data-id=" + bks.BookID + " style='padding:5px;font-size:12px;'>Accepted</a> <a href='Returnbook.aspx?id=" + bks.ID + "' class='btn btn-default' style='padding:5px; font-size:12px;'>Return Book</a> ";
                 
                }
                else if (bks.Status == -1)
                {
                    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action update' data-id=" + bks.BookID + ">Rejected</a> ";

                }
                else if(bks.Status==2)
                {
                    programstbl.Text += "<a href='#0' class='btn btn-info btn-action update' data-id=" + bks.BookID + " style='padding:5px;font-size:10px'>Returned On "+bks.ReturnDate.Value.ToShortDateString()+"</a> ";

                }
            }
        }
    }
    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/AdminDashboard.aspx");

    }
}