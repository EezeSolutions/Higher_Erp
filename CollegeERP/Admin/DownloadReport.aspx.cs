using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    int page = 1;
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
    static string temp1="";
    public static int Count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            loadQuestionaire();
        }

    }

    private void loadQuestionaire()
    {

        DBFunctions db = new DBFunctions();

        //code mfor paging

        int pageStart = 1;
        int pageEnd = 10;

        pageEnd = pageSize * page;
        pageStart = (pageEnd - pageSize) + 1;

        if (Request.QueryString.ToString().Contains("page"))
        {
            page = Convert.ToInt32(Request.QueryString["page"].ToString());
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        }

        List<UploadedQuestionaire> ques = db.getquestionairlist(page - 1, pageSize);
        //ad = db.getattendancebyids(courseid, userid, page - 1, pageSize);
        //List<HostelWarden_tbl> ds = new List<HostelWarden_tbl>();
        // ds = db.getwardenlist(page-1, pageSize);


        literalStart.Text = pageStart.ToString();
        literalEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        //pageEnd = db.getlectures_Count(crsid);

        pageEnd = db.getquestionaire_Count();


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
        tmpUrl = "DownloadReport.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("?page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
        }

        StringBuilder listingString = new StringBuilder();

        if (ques != null)
        {
            ListAllQuestionaire(ques);
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
            temp1 = literalPaging.Text;
        }
    }

    private void ListAllQuestionaire(List<UploadedQuestionaire> ques)
    {
        int i = 1;
        questionairelbl.Text="<table class=\"table table-responsive table-hover\"><tr class=\"blue-background\"><th>SenderID</th><th>File</th><th>Comments</th><th>Action</th></tr>";
        foreach (var lec in ques)
        {
            questionairelbl.Text += "<tr id='" + i + "'><td id='sender_" + i + "' >" + lec.SenderID + "</td><td><a href='Questionaire/" + lec.filepath + "' target='new'>" + lec.filepath + "</a></td><td><input type='text' class='form-control input-lg' id=Text_" + lec.SenderID + "></input> </td><td><a id='SubmitComments' class='btn btn-success' onclick='SaveComments(" + lec.SenderID + ");'>Send Messages</a></td></tr>";

            i++;
        }

        questionairelbl.Text += "</table>";
        Count = i;
    }

    [WebMethod]
    public static string SubmitCommentsToStudents(int UserIDs, string Comments, int page)
    {
        DBFunctions db = new DBFunctions();

        db.UpdateSuggestionStatus(UserIDs);

        Mails_tbl temp = new Mails_tbl { RecieverID = UserIDs, Message = Comments, Subject = "SuggestionRequest", Status = 0, Date = DateTime.Now };
        db.addmail(temp);

        List<UploadedQuestionaire> ques = db.getquestionairlist(page-1, 10);


        return ListAllQuestionaire_2(ques) + "?" + temp1;
    }


    private static string ListAllQuestionaire_2(List<UploadedQuestionaire> ques)
    {
        int i = 1;
        StringBuilder sb = new StringBuilder();
        sb.Append("<table class=\"table table-responsive table-hover\"><tr class=\"blue-background\"><th>SenderID</th><th>File</th><th>Comments</th><th>Action</th></tr>");
        foreach (var lec in ques)
        {
            sb.Append("<tr id='" + i + "'><td id='sender_" + i + "' >" + lec.SenderID + "</td><td><a href='Questionaire/" + lec.filepath + "' target='new'>" + lec.filepath + "</a></td><td><input type='text' class='form-control input-lg' id=Text_" + lec.SenderID + "></input> </td><td><a id='SubmitComments' class='btn btn-success' onclick='SaveComments(" + lec.SenderID + ");'>Send Messages</a></td></tr>");
            i++;
        }
        sb.Append("</table>");
        return sb.ToString();
    }
}