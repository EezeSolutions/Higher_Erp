﻿using System;
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
                 DBFunctions db = new DBFunctions();

                 int pageStart = 1;
                 int pageEnd = 10;
                 if (Request.QueryString.ToString().Contains("page"))
                 {
                     page = Convert.ToInt32(Request.QueryString["page"].ToString());
                     pageEnd = pageSize * page;
                     pageStart = (pageEnd - pageSize) + 1;
                 }


                 List<TimeTable_tbl> ds = new List<TimeTable_tbl>();
                 ds = db.getTimeTablelist(pageStart, pageEnd);


                 literalStart.Text = pageStart.ToString();
                 literalEnd.Text = pageEnd.ToString();

                 int tmpPageEnd = 0;
                 tmpPageEnd = pageEnd;

                 pageEnd = db.getTimeTable_Count();



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
                 tmpUrl = "AddTimeTable.aspx?" + Request.QueryString.ToString();
                 if (tmpUrl.Contains("?page"))
                 {
                     tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
                 }

                 StringBuilder listingString = new StringBuilder();

                 if (ds != null)
                 {
                     loadCourse(ds);
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

                 if (!IsPostBack)
                 {
                     CourseList.DataSource = db.getcourselist();
                     CourseList.Items.Add("----------");
                     CourseList.DataTextField = "Course";
                     CourseList.DataValueField = "ID";
                     CourseList.DataBind();
                 }

             }
         }
             else
             {
                 Response.Redirect("Login.aspx?Redirecturl=" + pagename);
             }
        
       
    }

    private void loadCourse(List<TimeTable_tbl> ds)
    {
        List<TimeTable_tbl> timetable = ds;
        foreach (TimeTable_tbl crs in timetable)
        {
            if(crs !=null)
            {


                programstbl.Text += "<tr><td>" + crs.Courses_tbl.Course + "</td><td>" + crs.StartTime + "</td><td>" + crs.EndTime + "</td><td>" + crs.Day + "</td>";
                if(crs.Courses_tbl.CourseTeacherAssignment_tbl.FirstOrDefault()!=null)
                programstbl.Text+="<td>" + crs.Courses_tbl.CourseTeacherAssignment_tbl.FirstOrDefault().Employee_tbl.Name + "</td>";
                else
                {
                    programstbl.Text += "<td>No Teacher Assigned</td>";

                }
            //if (crs.Enable == true)
            //{
            //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

            //}
            //else
            //{
            //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

            //}

                programstbl.Text += "<td><a href='#0' class='btn btn-primary btn-action update' data-id=" + crs.ID + ">Update</a></td></tr>";
            }
        }
       
    }

    protected void TimeTableBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int course = int.Parse(CourseList.SelectedValue);
        string starttime = STime.Text;
        string endtime = ETime.Text;
        string day = DropDownDay.SelectedValue;
        
        TimeTable_tbl dsFlag = db.checkTimeTable(course,starttime,endtime,day);
        if (dsFlag != null)
        {
            Span1.InnerText = "TimeTable Already Exist";
        }
        else
        {

            //Program_tbl prgram = new Program_tbl { ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormCh.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
            TimeTable_tbl ttable = new TimeTable_tbl { CourseID = int.Parse(CourseList.SelectedValue), StartTime = STime.Text, EndTime = ETime.Text, Day = DropDownDay.SelectedItem.ToString(), Teacher = "" };
            db.addTimeTable(ttable);
        }

        Response.Redirect("AddTimeTable.aspx");
    }
}