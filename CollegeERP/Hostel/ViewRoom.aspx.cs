using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hostel_Default : System.Web.UI.Page
{
    int page = 1;
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
    string UserID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        string pagename = Path.GetFileName(Request.PhysicalPath);

        if (System.Web.HttpContext.Current.User != null)
        {
                UserID = Membership.GetUser().ProviderUserKey.ToString();
                bool LoggedStatus = false;
                LoggedStatus = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
                if (LoggedStatus)
                {
                    if (!IsPostBack)
                    {



                        int pageStart = 1;
                        int pageEnd = 10;
                        if (Request.QueryString.ToString().Contains("page"))
                        {
                            page = Convert.ToInt32(Request.QueryString["page"].ToString());
                            pageEnd = pageSize * page;
                            pageStart = (pageEnd - pageSize) + 1;
                        }


                        List<HostelRoom_tbl> ds = new List<HostelRoom_tbl>();
                        ds = db.getroomslist(page - 1, pageSize);


                        literalStart.Text = pageStart.ToString();
                        literalEnd.Text = pageEnd.ToString();

                        int tmpPageEnd = 0;
                        tmpPageEnd = pageEnd;

                        pageEnd = db.getRoom_Count();



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
                        tmpUrl = "AddWarden.aspx?" + Request.QueryString.ToString();
                        if (tmpUrl.Contains("?page"))
                        {
                            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
                        }

                        StringBuilder listingString = new StringBuilder();

                        if (ds != null)
                        {
                            loadRooms(ds);
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
                }
                else
                {
                    Response.Redirect("../Login.aspx?Redirecturl=Hostel/" + pagename);
                }
        }
        else
        {
            Response.Redirect("../Login.aspx?Redirecturl=Hostel/" + pagename);
        }
    }

    private void loadRooms(List<HostelRoom_tbl> ds)
    {
        DBFunctions db = new DBFunctions();
        DatabaseFunctions d = new DatabaseFunctions();
        int stid = d.GetCandidateID(UserID);
        if (stid != -1)
        {

            var chkorder = db.chechroomrequest(stid);
            foreach (HostelRoom_tbl hstl in ds)
            {
                if (hstl != null)
                {
                    var chk = db.checkOrderList(hstl.ID, stid);

                    if (chk != null)
                    {
                        if (chk.Status == 0)
                        {
                            roomtbl.Text += "<tr><td>" + hstl.RoomNo + "</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";
                            roomtbl.Text += "<a href='#0' class='btn btn-warning btn-action pending' data-id=" + hstl.ID + ">Pending</a></td></tr>";
                        }
                        else if (chk.Status == -1)
                        {
                            if (chkorder == null)
                            {
                                roomtbl.Text += "<tr><td>" + hstl.RoomNo + "</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";
                                roomtbl.Text += "<a href='#0' class='btn btn-danger btn-action reject' data-id=" + hstl.ID + ">Rejected</a> <a href='#0' class='btn btn-primary btn-action reorder' data-id=" + hstl.ID + ">Reorder</a></td></tr>";
                            }
                            else
                            {
                                roomtbl.Text += "<tr><td>" + hstl.RoomNo + "</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";
                                roomtbl.Text += "</td></tr>";

                            }
                        }
                        else if (chk.Status == 1)
                        {
                            roomtbl.Text += "<tr><td>" + hstl.RoomNo + "</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";
                            roomtbl.Text += "<a href='#0' class='btn btn-success btn-action Accepted' data-id=" + hstl.ID + ">Accepted</a> <a href='#0' class='btn btn-default btn-action Leave' data-id=" + hstl.ID + ">Leave Room</a></td></tr>";
                        }
                        else if (chk.Status == 2)
                        {
                            roomtbl.Text += "<tr><td>" + hstl.RoomNo + "</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";
                            roomtbl.Text += "<a href='#0' class='btn btn-success Accepted' data-id=" + hstl.ID + ">Leave Room Request Sent</a> </td></tr>";
                        }
                    }
                    else if (hstl.Capacity == 0)
                    {
                        roomtbl.Text += "<tr><td>" + hstl.RoomNo + "</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";
                        roomtbl.Text += "<a href='#0' class='btn btn-danger' data-id=" + hstl.ID + ">Booking Closed</a></td></tr>";
                    }
                    else
                    {
                        roomtbl.Text += "<tr><td>" + hstl.RoomNo + "</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";
                        if (chkorder == null)
                            roomtbl.Text += "<a href='#0' class='btn btn-primary btn-action order' data-id=" + hstl.ID + ">Order</a></td></tr>";
                        else
                        {
                            roomtbl.Text += "</td></tr>";
                        }
                    }
                }
            }
        }
    }
}