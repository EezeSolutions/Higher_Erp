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
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
    string UserID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        bool loggedStatus = false;
        DBFunctions db = new DBFunctions();
        string pagename = Path.GetFileName(Request.PhysicalPath);

        if (System.Web.HttpContext.Current.User == null)
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
        else
        {
            loggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (loggedStatus)
            {
                DatabaseFunctions d = new DatabaseFunctions();

                UserID = Membership.GetUser().ProviderUserKey.ToString();
                int stid = d.GetCandidateID(UserID);
                if (stid != -1)
                {
                    var chk = db.getLirarymember(stid);
                    backlink.Text = "<a href='#0' class='btn btn-primary' onclick='history.back()'>Back</a>";

                    if (chk == null)
                    {
                        searchcontrols.Visible = false;
                        pagingdiv.Visible = false;
                        tblbooks.Visible = false;
                        membermsg.Visible = true;
                        linkmemebrship.Visible = true;
                        membermsg.InnerText = "Your Do Not Have The Library Membership..!!";

                        //var stdent = db.getstdentinfo(stid);
                        //nametxt.Text = stdent.Candidate_tbl.Name;
                        //metricno.Text = stdent.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo;
                        //programme.Text = stdent.Program_tbl.ProgramName;
                        return;
                    }
                    else if (chk.Status == 0)
                    {
                        tblbooks.Visible = false;
                        searchcontrols.Visible = false;
                        pagingdiv.Visible = false;

                        membermsg.Visible = true;
                        //membershipform.Visible = false;
                        //membermsg.Visible = true;
                        membermsg.InnerText = "Your Request For Library Membership is Pending..!!";
                        return;
                    }

                    int pageStart = 1;
                    int pageEnd = 10;
                    if (Request.QueryString.ToString().Contains("page"))
                    {
                        page = Convert.ToInt32(Request.QueryString["page"].ToString());
                        pageEnd = pageSize * page;
                        pageStart = (pageEnd - pageSize) + 1;
                    }


                    // List<Book> ds = new List<Book>();



                    literalStart.Text = pageStart.ToString();
                    literalEnd.Text = pageEnd.ToString();

                    int tmpPageEnd = 0;
                    tmpPageEnd = pageEnd;

                    pageEnd = db.getBook_Count();



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
                    tmpUrl = "AvailableBooks.aspx?" + Request.QueryString.ToString();
                    if (tmpUrl.Contains("?page"))
                    {
                        tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
                    }

                    StringBuilder listingString = new StringBuilder();



                    loadBooks();



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
            }
        }
    }
    private void loadBooks()
    {
        DBFunctions db = new DBFunctions();
        List<Book> book = db.getbooklist(page - 1, pageSize); ;

        foreach (Book bks in book)
        {
            if (bks != null)
            {
                //<th>Book Name</th><th>Category</th><th>ISBN</th><th>Author</th><th>Quantity</th><th>Action</th></tr>
                programstbl.Text += "<tr><td>" + bks.Title + "</td><td>" + bks.Category + "</td><td>" + bks.ISBN + "</td><td>" + bks.Author + "</td><td>" + bks.Quantity + "</td><td>";

                //if (crs.Enable == true)
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

                //}
                //else
                //{

                //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

                //}
                if (bks.IssueBooks.OrderByDescending(x=>x.ID).FirstOrDefault() == null||bks.IssueBooks.OrderByDescending(x=>x.ID).FirstOrDefault().Status == 2)
                programstbl.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + bks.ID + ">Order</a></td></tr>";
                else if (bks.IssueBooks.OrderByDescending(x=>x.ID).FirstOrDefault().Status == 0 || bks.IssueBooks.FirstOrDefault().Status == 0)
                {
                    programstbl.Text += "<a href='#0' class='btn btn-info ' data-id=" + bks.ID + ">Pending</a></td></tr>";
               
                }
                else if (bks.IssueBooks.OrderByDescending(x=>x.ID).FirstOrDefault().Status == 1)
                {
                    programstbl.Text += "<a href='#0' class='btn btn-success ' data-id=" + bks.ID + ">Book Issued</a></td></tr>";

                }

                else if (bks.IssueBooks.OrderByDescending(x=>x.ID).FirstOrDefault().Status == -1)
                {
                    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + bks.ID + ">Order</a></td></tr>";

                }
            }
        }
    }
}