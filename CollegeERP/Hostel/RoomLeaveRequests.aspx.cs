using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hostel_Default : System.Web.UI.Page
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


        List<StudentRoom_Mapping> ds = new List<StudentRoom_Mapping>();
        ds = db.getleaveroomrequestlist(page-1,pageSize);


        literalStart.Text = pageStart.ToString();
        literalEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getLevetRoomRequest_Count();



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
        tmpUrl = "RoomRequest.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("?page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
        }

        StringBuilder listingString = new StringBuilder();

        if (ds != null)
        {
            loadRoomsRequest(ds);
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

    private void loadRoomsRequest(List<StudentRoom_Mapping> ds)
    {
        foreach (StudentRoom_Mapping hstl in ds)
        {
            if (hstl != null)
            {
                if (hstl.Status == 1)
                {
                    roomtbl.Text += "<tr><td>" + hstl.HostelRoom_tbl.RoomNo + "</td><td>" + hstl.HostelRoom_tbl.Hostel_tbl.Name + "</td><td>" + hstl.Candidate_tbl.Name + "</td><td>" + hstl.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().Department_tbl.Department + "</td><td>" + hstl.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().AcadamicYear + "</td><td>";

                    roomtbl.Text += "<a href='#0' class='btn btn-success btn-action accepted' data-id=" + hstl.ID + ">Accepted</a></td></tr>";
                }
                else if (hstl.Status == -1)
                {
                    roomtbl.Text += "<tr><td>"+hstl.HostelRoom_tbl.RoomNo+"</td><td>" + hstl.HostelRoom_tbl.Hostel_tbl.Name + "</td><td>" + hstl.Candidate_tbl.Name + "</td><td>" + hstl.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().Department_tbl.Department + "</td><td>" + hstl.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().AcadamicYear + "</td><td>";

                    roomtbl.Text += "<a href='#0' class='btn btn-danger btn-action rejected' data-id=" + hstl.ID + ">Rejected</a></td></tr>";
                }
                else
                {
                    roomtbl.Text += "<tr><td>" + hstl.HostelRoom_tbl.RoomNo + "</td><td>" + hstl.HostelRoom_tbl.Hostel_tbl.Name + "</td><td>" + hstl.Candidate_tbl.Name + "</td><td>" + hstl.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().Department_tbl.Department + "</td><td>" + hstl.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().AcadamicYear + "</td><td>";

                    roomtbl.Text += "<a href='#0' class='btn btn-primary btn-action acceptleaveroom' data-id=" + hstl.ID + ">Confirm</a></td></tr> ";
                }



            }
        }
    }
    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/AdminDashboard.aspx");

    }
}