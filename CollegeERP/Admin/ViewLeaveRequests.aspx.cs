using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    int page = 1;
    int pageSize = 10;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                loadleavrequests();
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);

        }
    }

    private void loadleavrequests()
    {
        int pageStart = 1;
        int pageEnd = 10;
        if (Request.QueryString.ToString().Contains("page"))
        {
            page = Convert.ToInt32(Request.QueryString["page"].ToString());
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        }
        literalStart.Text = pageStart.ToString();
        literalEnd.Text = pageEnd.ToString();
        DBFunctions db = new DBFunctions();
        int status = 0;
        List<Leave> leaves = new List<Leave>();
        if (Request.QueryString["status"] == null || Request.QueryString["status"] == "0")
        {

            leaves = db.getleaverequests(page - 1, pageSize, status);
            pageEnd = db.getleaves_count(0);
        }
else if(Request.QueryString["status"] == "All")
        {
            leaves = db.getleaverequests(page - 1, pageSize, 5);
            pageEnd = db.getemployee_count(status);
            DropDownstatus.SelectedValue = "All";
        }
        else
        {

            status = int.Parse(Request.QueryString["status"]);
            leaves = db.getleaverequests(page - 1, pageSize, status);
            pageEnd = db.getemployee_count(status);
            DropDownstatus.SelectedValue = status.ToString();

        }
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
        tmpUrl = "ViewLeaveRequests.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("?page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
        }

        StringBuilder listingString = new StringBuilder();

        rendeleaves(leaves);


        setpaging(pageEnd);
            
    }

    private void rendeleaves(List<Leave> leaves)
    {
        LeaveRequeststbl.Text = "";
        //<tr class="blue-background"><th>Employee Name</th><th>Department</th><th>Leave Type</th><th>Leave From</th><th>Leave To</th><th>Action</th></tr>
        foreach (var leav in leaves)
        {

            if (leav.Status == 0)

                LeaveRequeststbl.Text += "<tr><td>" + leav.Employee_tbl.Name + "</td><td>" + leav.Employee_tbl.Department_tbl.Department + "</td><td>" + leav.LeaveType + "</td><td>" + (leav.FromDate.Value.Subtract(leav.ToDate.Value).Days + 1) + "</td><td>" + leav.FromDate.Value.ToShortDateString() + "</td><td>" + leav.ToDate.Value.ToShortDateString() + "</td><td><a href='updateleacrequest.aspx?id=" + leav.ID + "&status=1' class='btn btn-primary'>Approve</a> <a href='updateleacrequest.aspx?id=" + leav.ID + "&status=-1' class='btn btn-danger'>Decline</a></td></tr>";
            else if (leav.Status == 1)
                LeaveRequeststbl.Text += "<tr><td>" + leav.Employee_tbl.Name + "</td><td>" + leav.Employee_tbl.Department_tbl.Department + "</td><td>" + leav.LeaveType + "</td><td>" + (leav.FromDate.Value.Subtract(leav.ToDate.Value).Days + 1) + "</td><td>" + leav.FromDate.Value.ToShortDateString() + "</td><td>" + leav.ToDate.Value.ToShortDateString() + "</td><td><a href='#0' class='btn btn-success'>Approved</a> </td></tr>";

            else if (leav.Status == -1)
                LeaveRequeststbl.Text += "<tr><td>" + leav.Employee_tbl.Name + "</td><td>" + leav.Employee_tbl.Department_tbl.Department + "</td><td>" + leav.LeaveType + "</td><td>" + (leav.FromDate.Value.Subtract(leav.ToDate.Value).Days + 1) + "</td><td>" + leav.FromDate.Value.ToShortDateString() + "</td><td>" + leav.ToDate.Value.ToShortDateString() + "</td><td><a href='#0' class='btn btn-danger'>Rejected</a> </td></tr>";

        }
    }

    private void setpaging(int pageEnd)
    {
        literalPaging.Text = "";
        if (pageEnd > 10)
        {
            StringBuilder paging = new StringBuilder();
            int counterPage = 1;
            int totalPages = 0;

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
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href='" + urlMain + "?page=" + i + " &status=" + DropDownstatus.SelectedValue + "'>" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href='" + urlMain + "?page=" + i + "&status=" + DropDownstatus.SelectedValue + "'>" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href='" + urlMain + "?page=" + i + " &status=" + DropDownstatus.SelectedValue + "'>" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href='" + urlMain + "?page=" + i + "&status=" + DropDownstatus.SelectedValue + "' >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href='" + urlMain + "?page=" + totalPages + "&status=" + DropDownstatus.SelectedValue + "' >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href='" + urlMain + "?page=" + i + "&status=" + DropDownstatus.SelectedValue + "' >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href='" + urlMain + "?page=" + i + "&status=" + DropDownstatus.SelectedValue + "' >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            literalPaging.Text = paging.ToString();
        }
    }

    protected void DropDownstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        List<Leave> leave = new List<Leave>();
        int pageStart = 1;
        int pageEnd = 10;
        if (DropDownstatus.SelectedValue != "All")
        {
            int deptid = int.Parse(DropDownstatus.SelectedValue);
            leave = db.getleaverequests(0,10,int.Parse(DropDownstatus.SelectedValue));
            rendeleaves(leave);
            pageEnd = db.getleaves_count(deptid);
        }
        else
        {
            leave = db.getleaverequests(0, 10, 5);
            rendeleaves(leave);
            pageEnd = db.getleaves_count(5);
        }
        //if (Request.QueryString.ToString().Contains("page"))
        //{
        //page = Convert.ToInt32(Request.QueryString["page"].ToString());
        // pageEnd = pageSize * page;
        int total = pageEnd;
        if (total != 0)
            pageStart = (pageSize * page - pageSize) + 1;
        else
            pageStart = 0;
        //    pageEnd = db.getemployee_count(0);
        //}

        literalStart.Text = pageStart.ToString();
        if (pageEnd > 10)
        {
            pageEnd = pageSize * page;

        }
        literalEnd.Text = pageEnd.ToString();
        literalTotal.Text = total.ToString();
        setpaging(total);
    }
    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }
}