using System;
using System.Collections.Generic;
using System.IO;
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
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                for (int i = 1; i <= 31; i++)
                {
                    dropdownDate.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                for (int i = 1; i <= 12; i++)
                {
                    DropDownMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }


                DBFunctions db = new DBFunctions();

                int pageStart = 1;
                int pageEnd = 10;
                if (Request.QueryString.ToString().Contains("page"))
                {
                    page = Convert.ToInt32(Request.QueryString["page"].ToString());
                    pageEnd = pageSize * page;
                    pageStart = (pageEnd - pageSize) + 1;
                }


                List<DateSheet_tbl> ds = new List<DateSheet_tbl>();
                ds = db.getDateSheetlist(pageStart, pageEnd);


                literalStart.Text = pageStart.ToString();
                literalEnd.Text = pageEnd.ToString();

                int tmpPageEnd = 0;
                tmpPageEnd = pageEnd;

                pageEnd = db.getDateSheet_Count();



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
                    loadDateSheet(ds);
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



                CourseList.DataSource = db.getcourselist();
                CourseList.Items.Add("----------");
                CourseList.DataTextField = "Course";
                CourseList.DataValueField = "ID";
                CourseList.DataBind();
            }
        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
       
    }

    private void loadDateSheet(List<DateSheet_tbl> ds)
    {
        List<DateSheet_tbl> datesheet = ds;
        foreach (DateSheet_tbl crs in datesheet)
        {
            if (crs != null)
            {
                programstbl.Text += "<tr><td>" + crs.ExamType + "</td><td>" + crs.Year + "</td><td>" + crs.Courses_tbl.Course + "</td><td>" + crs.StartTime + "</td><td>" + crs.EndTime + "</td><td>";

                //if (crs.Enable == true)
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

                //}
                //else
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

                //}

                programstbl.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + crs.ID + ">Update</a></td></tr>";
            }
        }
    }
    protected void DateSheetBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        string examtype = ExamTypeList.SelectedValue;
        string year = DateTime.Now.Year.ToString();
        int courseid = int.Parse(CourseList.SelectedValue);
        string starttime = StartTime.Text;
        string endtime = EndTime.Text;
        DateSheet_tbl dsFlag=db.checkDateSheet(examtype, year, courseid, starttime, endtime);
        if (dsFlag != null)
        {
            Span1.InnerText = "DateSheet Already Exist";
        }
        else
        {

            //Program_tbl prgram = new Program_tbl { ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormCh.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
            DateSheet_tbl DStable = new DateSheet_tbl { ExamType = ExamTypeList.SelectedValue, Year = dropdownDate.SelectedValue+"-" +DropDownMonth.SelectedValue+"-"+DateTime.Now.Year.ToString(), CourseID = int.Parse(CourseList.SelectedValue), StartTime = StartTime.Text, EndTime = EndTime.Text, };
            db.addDateSheet(DStable);
            Response.Redirect("AddDateSheet.aspx");
        }
    }
}