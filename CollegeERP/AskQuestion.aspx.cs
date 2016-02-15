using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    int page = 1;
    int pageSize = 5;
    int totalRecords = 0;
    int totalPages = 0;
    string UserID = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        DBFunctions db = new DBFunctions();
        bool LoggedStatus = false;
        if (System.Web.HttpContext.Current.User != null)
        {
            LoggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (LoggedStatus)
            {
                UserID = Membership.GetUser().ProviderUserKey.ToString();
                int pageStart = 1;
                int pageEnd = 5;
                if (Request.QueryString.ToString().Contains("page"))
                {
                    page = Convert.ToInt32(Request.QueryString["page"].ToString());
                    pageEnd = pageSize * page;
                    pageStart = (pageEnd - pageSize) + 1;
                }


                List<Support_tbl> ds = new List<Support_tbl>();
                DatabaseFunctions d = new DatabaseFunctions();
                int userid = d.GetCandidateID(UserID);
                ds = db.getQuestionlist(userid, page - 1, pageSize);


                literalStart.Text = pageStart.ToString();
                literalEnd.Text = pageEnd.ToString();

                int tmpPageEnd = 0;
                tmpPageEnd = pageEnd;

                pageEnd = db.getQuestion_Count(userid);



                if (pageEnd > 5)
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
                tmpUrl = "AddDateSheet.aspx?" + Request.QueryString.ToString();
                if (tmpUrl.Contains("?page"))
                {
                    tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
                }

                StringBuilder listingString = new StringBuilder();

                if (ds != null)
                {
                    loadQuestion(ds);
                }


                if (pageEnd > 5)
                {
                    StringBuilder paging = new StringBuilder();
                    int counterPage = 1;
                    int totalPages = 1;

                    totalPages = (pageEnd / 5) + 1;
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
            else
            {
                Response.Redirect("Login.aspx?Redirecturl=" + pagename);
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }

    private void loadQuestion(List<Support_tbl> ds)
    {
        List<Support_tbl> question = ds;

        foreach (var crs in question)
        {
            programstbl.Text += "<div class='comment-name'><span class='h3'>Question: </span><span class='h4'>" + crs.Question + "</span></div><br>";
           if(crs.Answer!=null)
            programstbl.Text += "<p class='blockquote comment'> <span class='h3'>Answer:</span> " + crs.Answer + "</p><br>";
            else
               programstbl.Text += "<p class='blockquote comment'> <span class='h3'>Answer:</span> No Answer yet..!!</p><br>";

            programstbl.Text += "<p class='caption'>" + crs.Date + "</p><br><hr>";
        }
        //foreach (Support_tbl crs in question)
        //{
        //    if (crs != null)
        //    {
        //        programstbl.Text += "<tr><td>" + crs.Question + "</td><td>" + crs.Date + "</td>";
        //        if (crs.Answer == null)
        //        {
        //            programstbl.Text += "<td><a href='#0' class='btn btn-danger btn-action Disable' data-id=" + crs.ID + ">Pending</a></td><td>";
        //        }
        //        else
        //        {
        //            programstbl.Text += "<td><a href='#0' class='btn btn-success btn-action Disable' data-id=" + crs.ID + ">View Details</a></td><td>";
        //        }
        //        //if (crs.Enable == true)
        //        //{
        //        //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

        //        //}
        //        //else
        //        //{
        //        //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

        //        //}

        //        programstbl.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + crs.ID + ">Update</a></td></tr>";
        //    }
        //}
    }
    protected void QuestionBtn_Click(object sender, EventArgs e)
    {
       
        DBFunctions db = new DBFunctions();
        DatabaseFunctions d = new DatabaseFunctions();
        Support_tbl spt = new Support_tbl { UserID = d.GetCandidateID(UserID), Question = SenderQuestion.Text, Date = DateTime.Now,Status=0 };
        db.addQuestion(spt);
        Response.Redirect("AskQuestion.aspx");
    }
}