using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class LMS_Default : System.Web.UI.Page
{
    int pages = 1;
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
    public static int aid=-1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
         if(Session["Role"]!="Student")
         {
             Response.Redirect("../Login.aspx");
         }
        if (!IsPostBack)
        {
        DBFunctions db = new DBFunctions();
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["userid"]==null)
        {
            Response.Redirect("../Login.aspx?Redirecturl=" + pagename);
        }
        string tabs = "";
        if (Request.QueryString["tab"] != null)
            tabs = Request.QueryString["tab"];

        if (Request.QueryString["course"] != null)
        {
            if (Request.QueryString.ToString().Contains("page"))
            {
                pages = Convert.ToInt32(Request.QueryString["page"].ToString());
            }


            int courseid = int.Parse(Request.QueryString["course"]);
            int userid = int.Parse(Session["userid"].ToString());

            List<Results_tbl> ds = new List<Results_tbl>();
            ds = db.getresultbyids(courseid, userid);

            loadResult(ds);
            if (tabs == "")
            {
                loadattendance(1);
                loadcourseassignments(1);
                loadCourseVideos(1);
                loadLectures(1);
                loadBooks();
                loadQuizz(1);

            }
            if (tabs == "Attendance")
            {
                loadattendance(pages);
                loadcourseassignments(1);

                loadCourseVideos(1);
                loadLectures(1);
                loadBooks();
                loadQuizz(1);
            }
            if (tabs == "assignments")
            {
                loadcourseassignments(pages);
                loadattendance(1);
                loadCourseVideos(1);
                loadLectures(1);
                loadBooks();
                loadQuizz(1);

            }
            if (tabs == "videos")
            {
                loadCourseVideos(pages);
                loadattendance(1);
                loadcourseassignments(1);

                loadLectures(1);
                loadBooks();
                loadQuizz(1);
            }
            if (tabs == "lectures")
            {
                loadattendance(1);
                loadLectures(pages);
                loadcourseassignments(1);
                loadCourseVideos(1);

                loadBooks();
                loadQuizz(1);
            }
            if (tabs == "books")
            {
                loadBooks();
                loadcourseassignments(1);
                loadCourseVideos(1);
                loadLectures(1);
                loadattendance(1);
                loadQuizz(1);
            }
            if (tabs == "quizz")
            {
                loadQuizz(pages);
                loadcourseassignments(1);
                loadCourseVideos(1);
                loadLectures(1);
                loadBooks();
                loadattendance(1);
            }

        }
            

        }
        
    }
    private void loadattendance(int page)
    {
        int courseid = int.Parse(Request.QueryString["course"]);
        int userid = int.Parse(Session["userid"].ToString());

        DBFunctions db = new DBFunctions();

        int pageStart = 1;
        int pageEnd = 10;
      
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        

        List<Attendance_tbl> ad = new List<Attendance_tbl>();
        ad = db.getattendancebyids(courseid, userid, page - 1, pageSize);
        //List<HostelWarden_tbl> ds = new List<HostelWarden_tbl>();
        // ds = db.getwardenlist(page-1, pageSize);


        literalStart.Text = pageStart.ToString();
        literalEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getAttendancebyid_Count(courseid, userid);



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
        tmpUrl = "ShowCourseDetail.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("&page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&page"));
        }

        //*************************
        

        //*********

        //StringBuilder listingString = new StringBuilder();

        if (ad != null)
        {
            loadAttendance(ad);
        }


        if (pageEnd > 10)
        {
            StringBuilder paging = new StringBuilder();
            int counterPage = 1;
            int totalPages = 1;

            totalPages = (pageEnd / 10) + 1;
            string urlMain = string.Empty;
            urlMain = Request.Url.ToString();
            if (urlMain.Contains("&page"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("&page"));
            }
            //**********************
           if(urlMain.Contains("tab"))
           {
               urlMain = urlMain.Remove(urlMain.IndexOf("&tab"));
           }

            //**********************

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href='" + urlMain + "&tab=Attendance' >&lt;&lt;</a></li>";
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=Attendance\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=Attendance\" >" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=Attendance\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href=\"" + urlMain + "&page=" + i + "&tab=Attendance\" >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "&page=" + totalPages + "&tab=Attendance\" >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=Attendance\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=Attendance\" >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            literalPaging.Text = paging.ToString();
        }
    }
    private void loadQuizz(int page)
    {
        int pageStart = 1;
        int pageEnd = 10;
        int crsid = int.Parse(Request.QueryString["course"]);
        int stdid = int.Parse(Session["userid"].ToString());
        DBFunctions db = new DBFunctions();

       
           
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        
        List<Quizz_tbl> quizz = db.getcoursquizzes(page - 1, pageSize, crsid);
        //List<Student_Quizz_Mapping_tbl> quizz = db.getstudentquizzes(page - 1, pageSize, stdid);
        quizzstart.Text = pageStart.ToString();
        quizzEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getcoursequizzes_count(crsid);
        //pageEnd = db.getStudentquizzes_count(stdid);



        if (pageEnd > 10)
        {
            quizztotal.Text = pageEnd.ToString();

            int pagett = 0;
            pagett = Convert.ToInt16(quizzEnd.Text);

            if (pagett > pageEnd)
            {
                quizzEnd.Text = pageEnd.ToString();
            }

        }
        else
        {
            if (pageEnd == 0)
            {
                quizzstart.Text = "";
            }
            quizztotal.Text = pageEnd.ToString();
            quizzEnd.Text = pageEnd.ToString();
        }


        string tmpUrl = string.Empty;
        //tmpUrl = "UploadAssignment.aspx?tab=Lectures&";
        tmpUrl = "ShowCourseDetail.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("&page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&page"));

        }

        StringBuilder listingString = new StringBuilder();

        if (quizz != null)
        {
            foreach (var qz in quizz)
            {

                QuizzLabel.Text += "<tr><td>" + qz.Courses_tbl.Course + "</td><td>" + qz.QuizzTitle + "</td><td>" + qz.Total_Marks + "</td><td>" + qz.Quizz_date + "</td><td>";
                QuizzLabel.Text += "<a href='#0' class='btn btn-primary btn-action-quizz update' data-id=" + qz.ID + ">Details</a></td></tr>";

            }
        }


        if (pageEnd > 10)
        {
            StringBuilder paging = new StringBuilder();
            int counterPage = 1;
            int totalPages = 1;

            totalPages = (pageEnd / 10) + 1;
            string urlMain = string.Empty;

            urlMain = Request.Url.ToString();
            if (urlMain.Contains("&page"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("&page"));
            }

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href='" + urlMain + "tab=quizz' >&lt;&lt;</a></li>";
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=quizz\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=quizz\" >" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=quizz\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href=\"" + urlMain + "&page=" + i + "&tab=quizz\" >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "&page=" + totalPages + "&tab=quizz\" >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=quizz\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=quizz\" >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            quizzpaging.Text = paging.ToString();
        }

        //end of paging
    }

    private void loadcourseassignments(int page)
    {
        int crsid = int.Parse(Request.QueryString["course"]);
        DBFunctions db = new DBFunctions();

        List<Assignments_tbl> asgtms = db.getcourseassignments(crsid, page - 1, pageSize);
        int pageStart = 1;
        int pageEnd = 10;
      
           
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
      

        //List<Attendance_tbl> ad = new List<Attendance_tbl>();
        //ad = db.getattendancebyids(courseid, userid, page - 1, pageSize);
        ////List<HostelWarden_tbl> ds = new List<HostelWarden_tbl>();
        // ds = db.getwardenlist(page-1, pageSize);


        assignmentstart.Text = pageStart.ToString();
        assignmentEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getAssignment_Count(crsid);



        if (pageEnd > 10)
        {
            assignmenttotal.Text = pageEnd.ToString();

            int pagett = 0;
            pagett = Convert.ToInt16(assignmentEnd.Text);

            if (pagett > pageEnd)
            {
                assignmentEnd.Text = pageEnd.ToString();
            }

        }
        else
        {
            if (pageEnd == 0)
            {
                assignmentstart.Text = "";
            }
            assignmenttotal.Text = pageEnd.ToString();
            assignmentEnd.Text = pageEnd.ToString();
        }


        string tmpUrl = string.Empty;
        tmpUrl = "ShowCourseDetail.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("&page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&page"));
        }

        StringBuilder listingString = new StringBuilder();

        if (asgtms != null)
        {
            loadAssignments(asgtms);
        }


        if (pageEnd > 10)
        {
            StringBuilder paging = new StringBuilder();
            int counterPage = 1;
            int totalPages = 1;

            totalPages = (pageEnd / 10) + 1;
            string urlMain = string.Empty;
            urlMain = Request.Url.ToString();
            if (urlMain.Contains("&page"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("&page"));
            }

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href='" + urlMain + "&tab=assignments' >&lt;&lt;</a></li>";
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=assignments\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=assignments\" >" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=assignments\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href=\"" + urlMain + "&page=" + i + "&tab=assignments\" >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "&page=" + totalPages + "&tab=assignments\" >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=assignments\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=assignments\" >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            Assignmentpaging.Text = paging.ToString();
        }
       
    }

    private void loadCourseVideos(int page)
    {
       
        int pageSize = 9;
        int pageStart = 1;
        int pageEnd = 9;
        int crsid = int.Parse(Request.QueryString["course"]);
        DBFunctions db = new DBFunctions();

        
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        

        List<Video_Lecture_tbl> vid = db.getcoursevideos(page - 1, pageSize, crsid);
        literalVideostart.Text = pageStart.ToString();
        literalVideoEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getcoursevideos_count(crsid);



        if (pageEnd > 9)
        {
            literalvideototal.Text = pageEnd.ToString();

            int pagett = 0;
            pagett = Convert.ToInt16(literalVideoEnd.Text);

            if (pagett > pageEnd)
            {
                literalVideoEnd.Text = pageEnd.ToString();
            }

        }
        else
        {
            if (pageEnd == 0)
            {
                literalVideostart.Text = "";
            }
            literalvideototal.Text = pageEnd.ToString();
            literalVideoEnd.Text = pageEnd.ToString();
        }


        string tmpUrl = string.Empty;
        //tmpUrl = "UploadAssignment.aspx?tab=Lectures&";
        tmpUrl = "UploadAssignment.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("&page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&page"));

        }

        StringBuilder listingString = new StringBuilder();

        if (vid != null)
        {
            foreach (var video in vid)
            {


                videolbl.Text += " <div class='item  col-xs-4 col-lg-4'>";
                videolbl.Text += "<div class='thumbnail'>";
                videolbl.Text += "<a href='#' class='playVideo' data-video='" + video.VideoPath + "'><img class='group list-group-image' src='Videos/Thumbnails/" + video.Thumbnails + "' alt='' /><div class='playimage'></div></a>";
                videolbl.Text += "<div class='caption'>";
                videolbl.Text += "<h4 class='group inner list-group-item-heading'>" + video.Video_Title + "</h4>";
                videolbl.Text += "<p class='group inner list-group-item-text'>" + video.Description + "</p>";
                videolbl.Text += " <div class='row'>";
                videolbl.Text += "<a href='Download.ashx?file=" + video.VideoPath + "&location=Videos' class='btn btn-success'>Download</a>";

                videolbl.Text += "</div></div></div></div>";


            }
        }


        if (pageEnd > 9)
        {
            StringBuilder paging = new StringBuilder();
            int counterPage = 1;
            int totalPages = 1;

            totalPages = (pageEnd / 9) + 1;
            string urlMain = string.Empty;

            urlMain = Request.Url.ToString();
            if (urlMain.Contains("&page"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("&page"));
            }

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href='" + urlMain + "&tab=videos' >&lt;&lt;</a></li>";
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=videos\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=videos\" >" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=videos\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href=\"" + urlMain + "&page=" + i + "&tab=videos\" >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "&page=" + totalPages + "&tab=videos\" >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=videos\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=videos\" >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            literalvideopaging.Text = paging.ToString();
        }

        //end of paging

    }

    private void loadBooks()
    {
        int crsid = int.Parse(Request.QueryString["course"]);
        DBFunctions db = new DBFunctions();

        List<Reference_Books_tbl> bks = db.getcoursebooks(crsid);

        foreach (var book in bks)
        {
            bookLabel.Text += "<tr><td>" + book.Reference_Book + "</td><td>" + book.Courses_tbl.Course + "</td><td><a href='Download.ashx?file=" + book.Book_path + "&location=Books'>" + book.Book_path + "</a></td><td>" + book.Description + "</td></tr>";
        }
    }

    private void loadLectures(int page)
    {
        int crsid = int.Parse(Request.QueryString["course"]);
        DBFunctions db = new DBFunctions();

        //code mfor paging

        int pageStart = 1;
        int pageEnd = 10;
        
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        

        List<Lecture_Notes_tbl> lect = db.getcourselectures(crsid, page - 1, pageSize);
        //ad = db.getattendancebyids(courseid, userid, page - 1, pageSize);
        //List<HostelWarden_tbl> ds = new List<HostelWarden_tbl>();
        // ds = db.getwardenlist(page-1, pageSize);


        lecturestart.Text = pageStart.ToString();
        lectureEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getlectures_Count(crsid);



        if (pageEnd > 10)
        {
            lecturetotal.Text = pageEnd.ToString();

            int pagett = 0;
            pagett = Convert.ToInt16(lectureEnd.Text);

            if (pagett > pageEnd)
            {
                lectureEnd.Text = pageEnd.ToString();
            }

        }
        else
        {
            if (pageEnd == 0)
            {
                lecturestart.Text = "";
            }
            lecturetotal.Text = pageEnd.ToString();
            lectureEnd.Text = pageEnd.ToString();
        }


        string tmpUrl = string.Empty;
        //tmpUrl = "UploadAssignment.aspx?tab=Lectures&";
        tmpUrl = "ShowCourseDetail.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("&page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&page"));

        }

        StringBuilder listingString = new StringBuilder();

        if (lect != null)
        {
            loadLectureList(lect);
        }


        if (pageEnd > 10)
        {
            StringBuilder paging = new StringBuilder();
            int counterPage = 1;
            int totalPages = 1;

            totalPages = (pageEnd / 10) + 1;
            string urlMain = string.Empty;

            urlMain = Request.Url.ToString();
            if (urlMain.Contains("&page"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("&page"));
            }

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href='" + urlMain + "&tab=lectures' >&lt;&lt;</a></li>";
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=lectures\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=lectures\" >" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=lectures\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href=\"" + urlMain + "&page=" + i + "&tab=lectures\" >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "&page=" + totalPages + "&tab=lectures\" >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=lectures\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=lectures\" >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            lecturepaging.Text = paging.ToString();
        }

        //end of paging

        
    }

    private void loadLectureList(List<Lecture_Notes_tbl> lect)
    {
        foreach (var lec in lect)
        {
            lectureLabel.Text += "<tr><td>" + lec.Lecture_Title + "</td><td>" + lec.Courses_tbl.Course + "</td><td><a href='Download.ashx?file=" + lec.Lecture_Path + "&location=Lectures'>" + lec.Lecture_Path + "</a></td><td>" + lec.LectureDate.Value.ToShortDateString() + "</td></tr>";
        }
    }

    private void loadAssignments(List<Assignments_tbl> assign)
    {

        foreach (var asgmt in assign)
        {
        int studenID=int.Parse(Session["userid"].ToString());

            if (asgmt != null)
            {
                assignmentLable.Text += "<tr><td>" + asgmt.Assignment_Title + "</td><td>" + asgmt.marks + "</td><td><a href='Download.ashx?file=" + asgmt.Assignment_Path + "&location=Assignment'>" + asgmt.Assignment_Path + "</a></td><td>" + asgmt.DueDate.Value.ToShortDateString() + "</td><td>";
               if(asgmt.DueDate.Value.Date<DateTime.Now.Date)
               {
                   assignmentLable.Text += "<a type='button' class='btn btn-danger'>Date Expired</a>";
                
                   if (asgmt.Assignment_Result_tbl.Count == 0)
                    {
                        if (asgmt.SubmittedAssignments_tbl.Where(x => x.StudentID == studenID && x.AssignmentID == asgmt.ID).FirstOrDefault() == null)
                            assignmentLable.Text += " <a type='button' class='btn btn-danger'   data-id=" + asgmt.ID + ">Not Submitted</a></td></tr>";
              
                       else

                        assignmentLable.Text += " <a type='button' class='btn btn-success '   data-id=" + asgmt.ID + ">Submitted</a></td></tr>";
                    }
                    else
                    {
                        assignmentLable.Text += " <a href='ViewAssignmentResult.aspx?Aid="+asgmt.ID+"' target='_new' class='btn btn-success'>View Result</a></td></tr>";
                    }
               }
               
               else
               {

               
                if (asgmt.SubmittedAssignments_tbl.Where(x => x.StudentID == studenID &&x.AssignmentID==asgmt.ID).FirstOrDefault()==null)
                assignmentLable.Text += "<a type='button' data-toggle='modal' data-target='#myModal' class='btn btn-primary btn-action update' data-id=" + asgmt.ID + ">Submit Assignment</a></td></tr>";
                else
                {
                    if (asgmt.Assignment_Result_tbl.Count == 0)
                    {


                        assignmentLable.Text += " <a type='button' class='btn btn-success '   data-id=" + asgmt.ID + ">Submitted</a></td></tr>";
                    }
                    
                }
               }
            }
        }
    }

    private void loadAttendance(List<Attendance_tbl> ad)
    {
        foreach (Attendance_tbl res in ad)
        {
            if (res != null)
            {
                attendancelbl.Text += "<tr><td>" + res.Courses_tbl.Course + "</td>";
                if(res.Attendance=="1")
                    attendancelbl.Text += "<td style='color:green'>P</td>";
                else{
             attendancelbl.Text +=   "<td style='color:red'>A</td>";

                }
                attendancelbl.Text +=  "<td>" + res.Date.Value.ToShortDateString() + "</td></tr>";

                //if (crs.Enable == true)
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

                //}
                //else
                //{

                //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

                //}

               // attendancelbl.Text += "<a href='#0' class='btn btn-primary btn-action update' data-id=" + res.ID + ">Details</a></td></tr>";

            }
        }
    }

    private void loadResult(List<Results_tbl> ds)
    {
        foreach (Results_tbl res in ds)
        {
            if (res != null)
            {
                programstbl.Text += "<tr><td>" + res.Courses_tbl.Course+ "</td><td>" + res.ObtainedMarks + "</td><td>" + res.TotalMarks + "</td><td>" + res.Year + "</td><td>"+res.Semester+"</td><td>"+res.Grades_tbl.Grade+"</td></tr>";

                //if (crs.Enable == true)
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + prg.ID + ">Disable</a> ";

                //}
                //else
                //{

                //    programstbl.Text += "<a href='#0' class='btn btn-primary btn-action Enable' data-id=" + prg.ID + ">Enable</a> ";

                //}

             

            }
        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {

        string filePath = (sender as LinkButton).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }
    protected void Submitbtn_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Session["asgmtid"].ToString());
        int studenID=int.Parse(Session["userid"].ToString());
        string file = "";
        if (FileUpload1.FileName != null)
        {
            file = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/LMS/SubmittedAssignments/"+file));
        }

        SubmittedAssignments_tbl sasgmt = new SubmittedAssignments_tbl { StudentID = studenID, AssignmentID = id, AssginmentFile = file, Status = 0,SubmitDate=DateTime.Now.Date};
        DBFunctions db = new DBFunctions();
        db.submitassignment(sasgmt);
        Response.Redirect("ShowCourseDetail.aspx?course=" + Request.QueryString["course"] + "&tab=assignments");
        
    }


    [WebMethod(EnableSession = true)]
    public static void setasgmt(string asgmtid)
    {
        aid = int.Parse(asgmtid);
        HttpContext.Current.Session["asgmtid"] = aid.ToString();

    }
}