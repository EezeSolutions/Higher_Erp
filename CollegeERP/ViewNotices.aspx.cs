using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
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


        List<Notices_tbl> ds = new List<Notices_tbl>();
        ds = db.getNoticelist(pageStart, pageEnd);


        literalStart.Text = pageStart.ToString();
        literalEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getNotices_Count();



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
        tmpUrl = "AddDateSheet.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("?page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
        }

        StringBuilder listingString = new StringBuilder();

        if (ds != null)
        {
            loadNotices(ds);
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

    private void loadNotices(List<Notices_tbl> ds)
    {
        List<Notices_tbl> notices = ds;
        foreach (Notices_tbl d in notices)
        {
            discusion.Text += "<div class='comment-name'><img src='images/NoticeImg.jpg' height='50px' width='50px'> <span class='h4 '>" + d.NoticeType + "</span></div><br>";
            discusion.Text += "<p class='blockquote comment'> " + d.Notice + "</p><br>";
            discusion.Text += "<p class='caption'>" + d.Date + "</p><br><hr>";
            //discusion.Text.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + d.ID + ">V</a></td></tr>";
            
        }
        //discusion.Text += "<div class='comment-name'><img src='images/NoticeImg.jpg' height='50px' width='50px'> <span class='h4 '>Exam</span></div><br>";
        //discusion.Text += "<p class='blockquote comment'> test notice</p><br>";
        //discusion.Text += "<p class='caption'>" + DateTime.Now + "</p><br><hr>";
    }
}