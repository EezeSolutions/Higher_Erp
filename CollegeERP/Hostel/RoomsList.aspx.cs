using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

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
        if (!IsPostBack)
        {
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
                DropDownHostel.DataSource = db.gethostellist();
                DropDownHostel.DataTextField = "Name";
                DropDownHostel.DataValueField = "ID";
                DropDownHostel.DataBind();
                
            
        }
    }

    private void loadRooms(List<HostelRoom_tbl> ds)
    {
        foreach (HostelRoom_tbl hstl in ds)
        {
            if (hstl != null)
            {
                //<th>Book Name</th><th>Category</th><th>ISBN</th><th>Author</th><th>Quantity</th><th>Action</th></tr>
                roomtbl.Text += "<tr><td>"+hstl.RoomNo+"</td><td>" + hstl.Hostel_tbl.Name + "</td><td>" + hstl.Price + "</td><td>" + hstl.Capacity + "</td><td>";

                //if (crs.Enable == true)
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

                //}
                //else
                //{

                //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

                //}

                roomtbl.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + hstl.ID + ">Update</a></td></tr>";

            }
        }
    }
    protected void btnaddroom_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        //Program_tbl prgram = new Program_tbl { ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormCh.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
        HostelRoom_tbl room = new HostelRoom_tbl {RoomNo=int.Parse(RoomNo.Text), HostelID=int.Parse(DropDownHostel.SelectedValue),Price=int.Parse(price.Text),Capacity=int.Parse(capacity.Text),RoomDescription=description.Text};
        db.addroom(room);
        Response.Redirect("RoomsList.aspx");
    }
    protected void DropDownHostel_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int hstlid = int.Parse(DropDownHostel.SelectedValue);
        int roomno = db.getnextroomno(hstlid);
        RoomNo.Text = roomno.ToString();
    }
    [WebMethod]

    public static string getnextroomno(string hstlid)
    {
        DBFunctions db = new DBFunctions();
       
        int roomno = db.getnextroomno(int.Parse(hstlid));
       // RoomNo.Text = roomno.ToString();
        return roomno.ToString(); 
    }

    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/AdminDashboard.aspx");
    }
}