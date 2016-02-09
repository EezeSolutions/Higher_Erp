using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Web.Services;


public partial class LMS_Default : System.Web.UI.Page
{
    int pages = 1;
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
    public static int aid = -1;

  
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Role"] != "Employee")
        {
            Response.Redirect("../Employees/Login.aspx");
        }
        if (!IsPostBack)
        {
           
         //   Assgnmentduedate.SelectedDate = DateTime.Now.Date;




            string tabs = "";
            if (Request.QueryString["tab"] != null)
                tabs = Request.QueryString["tab"];
            DueDate.SelectedDate = DateTime.Now.Date;
         

            if (Request.QueryString["course"] != null)
            {


                if (Request.QueryString.ToString().Contains("page"))
                {
                    pages = Convert.ToInt32(Request.QueryString["page"].ToString());
                }
                Calendar1.SelectedDate = DateTime.Now.Date;
                QuizzCalendar.SelectedDate = DateTime.Now.Date;
                if (tabs == "")
                {
                    loadcoursesassignments(1);
                    loadcoursevideos(1);
                    loadLectures(1);
                    loadBooks();
                    loadQuizz(1);

                }
                if (tabs == "assignments")
                {
                    loadcoursesassignments(pages);
                    
                    loadcoursevideos(1);
                    loadLectures(1);
                    loadBooks();
                    loadQuizz(1);

                }
                if (tabs == "videos")
                {
                    loadcoursevideos(pages);

                    loadcoursesassignments(1);
                 
                    loadLectures(1);
                    loadBooks();
                    loadQuizz(1);
                }
                if (tabs == "Lectures" )
                {

                    loadLectures(pages);
                    loadcoursesassignments(1);
                    loadcoursevideos(1);
                    
                    loadBooks();
                    loadQuizz(1);
                }
                if (tabs == "books")
                {
                    loadBooks();
                    loadcoursesassignments(1);
                    loadcoursevideos(1);
                    loadLectures(1);
                   
                    loadQuizz(1);
                }
                if (tabs == "quizz" )
                {
                    loadQuizz(pages);
                    loadcoursesassignments(1);
                    loadcoursevideos(1);
                    loadLectures(1);
                    loadBooks();
                    
                }
            }
            
        }

    }

    private void loadQuizz(int page)
    {
        
        int pageStart = 1;
        int pageEnd = 10;
        int crsid = int.Parse(Request.QueryString["course"]);

        DBFunctions db = new DBFunctions();

  
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
     

        List<Quizz_tbl> quizz = db.getcoursquizzes(page - 1, pageSize, crsid);
        quizzstart.Text = pageStart.ToString();
        quizzEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getcoursequizzes_count(crsid);



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
        tmpUrl = "UploadAssignment.aspx?" + Request.QueryString.ToString();
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
                QuizzLabel.Text += "<a href='QuizzesResultList.aspx?Qzid="+qz.ID+"' target='_new' class='btn btn-primary ' >View Result</a></td></tr>";
        
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
        tmpUrl = "UploadAssignment.aspx?" + Request.QueryString.ToString();
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

            urlMain = Request.Url.ToString() ;
            if (urlMain.Contains("&page"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("&page"));
            }

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href='" + urlMain + "&tab=Lectures'>&lt;&lt;</a></li>";
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=Lectures\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=Lectures\" >" + i + "</a></li>";
                    }

                }
                else if (i == totalPages)
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=Lectures\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a  href=\"" + urlMain + "&page=" + i + "&tab=Lectures\" >" + i + "</a></li>";
                    }
                    newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "&page=" + totalPages + "&tab=Lectures\" >&gt;&gt;</a></li>";
                }
                else
                {
                    if (page == i)
                    {
                        newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "&tab=Lectures\" >" + i + "</a></li>";
                    }
                    else
                    {
                        newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "&tab=Lectures\" >" + i + "</a></li>";
                    }
                }
                counterPage++;
                paging.Append(newPageString);
            }

            lecturePaging.Text = paging.ToString();
        }

        //end of paging

        
    }

    private void loadLectureList(List<Lecture_Notes_tbl> lect)
    {
        foreach (var lec in lect)
        {
            lecturelbl.Text += "<tr><td>" + lec.Lecture_Title + "</td><td>" + lec.Courses_tbl.Course + "</td><td><a href='Download.ashx?file=" + lec.Lecture_Path + "&location=Lectures'>" + lec.Lecture_Path + "</a></td><td>" + lec.LectureDate.Value.ToShortDateString() + "</td></tr>";
        }
    }

    private void loadcoursevideos(int page)
    {
       
        int pageStart = 1;
        int pageEnd = 9;
        int crsid = int.Parse(Request.QueryString["course"]);
        DBFunctions db = new DBFunctions();
        
       
            pageEnd = (pageSize-1) * page;
            pageStart = (pageEnd - (pageSize-1)) + 1;
        

        List<Video_Lecture_tbl> vid = db.getcoursevideos(page - 1, pageSize-1, crsid);
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
                videolbl.Text += "<a  class='playVideo' data-video='" + video.VideoPath + "'><img class='group list-group-image' src='Videos/Thumbnails/"+video.Thumbnails+"' alt='' /><div class='playimage'></div></a>";
                videolbl.Text += "<div class='caption'>";
                videolbl.Text += "<h4 class='group inner list-group-item-heading video-title-list' >" + video.Video_Title + "</h4>";
                videolbl.Text += "<p class='group inner list-group-item-text'>" + video.Description + "</p>";
                videolbl.Text += " <div class='row'>";
                videolbl.Text += "<a href='Download.ashx?file="+video.VideoPath+"&location=Videos' class='btn btn-success'>Download</a>";

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

    private void loadcoursesassignments(int page)
    {
        //assignment paging start
        int crsid = int.Parse(Request.QueryString["course"]);
        DBFunctions db = new DBFunctions();

        
        int pageStart = 1;
        int pageEnd = 10;
       
            pageEnd = pageSize * page;
            pageStart = (pageEnd - pageSize) + 1;
        

        //List<Attendance_tbl> ad = new List<Attendance_tbl>();
        //ad = db.getattendancebyids(courseid, userid, page - 1, pageSize);
        ////List<HostelWarden_tbl> ds = new List<HostelWarden_tbl>();
        // ds = db.getwardenlist(page-1, pageSize);
        List<Assignments_tbl> asgtms = db.getcourseassignments(crsid, page - 1, pageSize);

        literalStart.Text = pageStart.ToString();
        literalEnd.Text = pageEnd.ToString();

        int tmpPageEnd = 0;
        tmpPageEnd = pageEnd;

        pageEnd = db.getAssignment_Count(crsid);



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
        tmpUrl = "UploadAssignments.aspx?" + Request.QueryString.ToString();
        if (tmpUrl.Contains("&page"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&page"));
        }

        //*****************
        if (tmpUrl.Contains("&tab"))
        {
            tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&tab"));
        }
        //*******

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

            if (urlMain.Contains("&tab"))
            {
                urlMain = urlMain.Remove(urlMain.IndexOf("&tab"));
            }

            for (int i = 1; i <= totalPages; i++)
            {
                string newPageString = string.Empty;


                if (i == 1)
                {

                    newPageString = "<li><a aria-label=\"First\"  href=\"" + urlMain + "&tab=assignments\" >&lt;&lt;</a></li>";
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

            literalPaging.Text = paging.ToString();
        }


        //paging end



        

        
    }

    private void loadAssignments(List<Assignments_tbl> asgtms)
    {
        foreach (var asgmt in asgtms)
        {
            assignmentLable.Text += "<tr><td>" + asgmt.Assignment_Title + "</td><td>" + asgmt.marks + "</td><td><a href='Download.ashx?file=" + asgmt.Assignment_Path + "&location=Assignment'>" + asgmt.Assignment_Path + "</a></td><td>" + asgmt.DueDate.Value.ToShortDateString() + "</td><td>";
            if (asgmt.Assignment_Result_tbl.FirstOrDefault() == null)
            {
                if (DateTime.Now.Date > asgmt.DueDate)
                    assignmentLable.Text += "<a href='ViewSubmittedAssignment.aspx?Asid="+asgmt.ID+"' target='_new' class='btn btn-success btn-action' >Submitted Assignments</a><a href='#0' class='btn btn-info btn-action assignmentresult' data-id='" + asgmt.ID + "' data-toggle='modal' data-target='#UploadResultAsssignment'>Upload Result</a></td></tr>";
                else
                assignmentLable.Text += "<a href='#0' class='btn btn-primary btn-action updateasgmt' data-toggle='modal' data-target='#UpdateModal' data-id='" + asgmt.ID + "'>Update</a> <a href='#0' class='btn btn-info btn-action assignmentresult' data-id='" + asgmt.ID + "' data-toggle='modal' data-target='#UploadResultAsssignment'>Upload Result</a></td></tr>";
            }
            else
            {
                assignmentLable.Text += "<a href='AssignmentResult.aspx?Asid="+asgmt.ID+"' target='_new' class='btn btn-primary btn-action '>View Result</a></td></tr>";
            }
           }
    }


    
    protected void uploadAssignment_Click(object sender, EventArgs e)
    {
        string filename = "";
        if(AssignmentUpload.FileName!="")
        {
            filename = AssignmentUpload.FileName;
            AssignmentUpload.SaveAs(Server.MapPath("~/LMS/Assignment/"+filename));
        }
        else
        {
            
            return;
        }
        Assignments_tbl asgmt = new Assignments_tbl { CourseID = int.Parse(Request.QueryString["course"]), Assignment_Path = filename, DueDate = DueDate.SelectedDate, marks = int.Parse(Markstxt.Text), Status = 0, Assignment_Title = AssignmentTitle.Text };
        DBFunctions db = new DBFunctions();
        db.addassignment(asgmt);
       
        Response.Redirect("UploadAssignments.aspx?course=" + Request.QueryString["course"] + "&tab=assignments");
    }
    
    protected void lectureouploadbtn_Click(object sender, EventArgs e)
    {
       string filename = "";
       if (LectureUpload.FileName != null)
        {
            filename = LectureUpload.FileName;
            LectureUpload.SaveAs(Server.MapPath("~/LMS/Lectures/" + filename));
        }
       DateTime dt = Calendar1.SelectedDate;
       string lectretitle = LectureTitle.Text;
       Lecture_Notes_tbl lecture = new Lecture_Notes_tbl { Lecture_Title = lectretitle, Lecture_Path = filename, CourseID = int.Parse(Request.QueryString["course"]),LectureDate=dt };
       DBFunctions db = new DBFunctions();
       db.addlectures(lecture);
       Response.Redirect("UploadAssignments.aspx?course=" + Request.QueryString["course"] + "&tab=Lectures");

    }
    protected void Uploadvideobtn_Click(object sender, EventArgs e)
    {

        
        string filename = "";
        if (Videoupload.FileName != null)
        {
            filename = Videoupload.FileName;
            Videoupload.SaveAs(Server.MapPath("~/LMS/Videos/" + filename));
        }

        //ThumbCreator.CreateThumb(Server.MapPath("~/LMS/Videos/" + filename),"testthumb",10.0);
       // return;
        string Thumbnail = DateTime.Now.Millisecond+"_thumbnail1.png";



        string duration = GetThumbnail("Videos/" + filename, "Videos/Thumbnails/" + Thumbnail);
        string title = videoTitle.Text;
        string desc = Description.Text;
        int crsid = int.Parse(Request.QueryString["course"]);

        Video_Lecture_tbl videolect= new Video_Lecture_tbl {VideoPath=filename,Duration=duration,Thumbnails=Thumbnail,CourseID=crsid,Description=desc,Video_Title=title,AddDate=DateTime.Now.Date };
        DBFunctions db = new DBFunctions();
        db.addvideos(videolect);
        Response.Redirect("UploadAssignments.aspx?course=" + Request.QueryString["course"] + "&tab=videos");
    }
    protected void BookUploadBtn_Click(object sender, EventArgs e)
    {
        string filename = "";
        if (BookUpload.FileName != null)
        {
            filename = BookUpload.FileName;
            BookUpload.SaveAs(Server.MapPath("~/LMS/Books/" + filename));
        }
        int crsid = int.Parse(Request.QueryString["course"]);
        string booktitle = bookTitle.Text;
        Reference_Books_tbl rbs = new Reference_Books_tbl { CourseID = crsid, Reference_Book = booktitle, Description = bookdescription.Text,Book_path=filename };
        DBFunctions db = new DBFunctions();
        db.addbooks(rbs);
        Response.Redirect("UploadAssignments.aspx?course=" + Request.QueryString["course"] + "&tab=books");
    }
    protected void Quizzbtn_Click(object sender, EventArgs e)
    {
        if (QuizzUpload.FileName == null)
        {

        }
        else
        {
            string filename = Path.GetFileName(QuizzUpload.PostedFile.FileName);
            string Extension = Path.GetExtension(QuizzUpload.PostedFile.FileName);

            long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
            string orgPath = string.Empty;
            orgPath = Server.MapPath("~/LMS/QuizzResult/" + filename);
            QuizzUpload.SaveAs(orgPath);
            
            System.Data.DataTable dt = Import_To_Grid(orgPath, Extension, "Yes");
            DBFunctions db = new DBFunctions();

            int crsid = int.Parse(Request.QueryString["course"]);

            Quizz_tbl qtbl = new Quizz_tbl { CourseID = crsid, QuizzTitle = quizzTitle.Text, Total_Marks = int.Parse(quizzmarks.Text), Quizz_date = QuizzCalendar.SelectedDate.Date };
           int qid=db.addquizzresult(qtbl);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string stdids = row[0].ToString();
                string marks = row[1].ToString();
                Student_Quizz_Mapping_tbl sqm = new Student_Quizz_Mapping_tbl {QuizzID=qid,StudentID=int.Parse(stdids),Mark_Obtained=int.Parse(marks) };
                //Results_tbl result = new Results_tbl { CourseID = int.Parse(DropDownCourse.SelectedValue), MetricNo = row[0].ToString(), TotalMarks = int.Parse(row[1].ToString()), ObtainedMarks = int.Parse(row[2].ToString()), Year = row[3].ToString(), ExamType = row[4].ToString() };
                db.quizzmarksinsertion(sqm);
            }
            Response.Redirect("UploadAssignments.aspx?course=" + crsid + "&tab=quizz");


        }
    }


    public static string GetThumbnail(string video, string thumbnail)
    {


        // var cmd = "ffmpeg  -itsoffset -1  -i " + '"' + video + '"' + " -vcodec mjpeg -vframes 1 -an -f rawvideo -s 320x240 " + '"' + thumbnail + '"';
        //var arg=  cmd;
        //////    var arg=HttpContext.Current.Server.MapPath("ffmpeg ")+" "+ cmd;
        //    var startInfo = new ProcessStartInfo
        //        {
        //            WindowStyle = ProcessWindowStyle.Normal,
        //            FileName = "cmd.exe",
        //            Arguments = arg


        //        };
        //var process = new Process
        //{

        //    StartInfo = startInfo
        //};
        //    process.StartInfo.UseShellExecute = true; 
        //Process.Start("cmd.exe", arg);
        StreamReader reader;
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        startInfo.FileName = "cmd.exe";
        startInfo.WorkingDirectory = HttpContext.Current.Server.MapPath("");
        startInfo.Arguments = "/C ffmpeg  -itsoffset -1  -i " + video + " -vcodec mjpeg -vframes 4 -an -f rawvideo -s 320x240 " + thumbnail;
        //startInfo.Arguments = "/C ffmpeg  -i " + video + " -vcodec mjpeg -ss 00:04:30 -t 1 -s 320x240 " + thumbnail;
        process.StartInfo = startInfo;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();
        reader = process.StandardError;
        // process.WaitForExit();
        String result = reader.ReadToEnd();
        String duration = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);

        return duration;
    }



    private System.Data.DataTable Import_To_Grid(string orgPath, string Extension, string p)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        try
        {
            string conStr = "";


            switch (Extension)
            {

                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, orgPath, p);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();



            cmdExcel.Connection = connExcel;



            //Get the name of First Sheet

            connExcel.Open();

            System.Data.DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            connExcel.Close();
        }
        catch (Exception ex)
        {
            throw;
        }

        return dt;
    }
    protected void UplaodAsgmtresult_Click(object sender, EventArgs e)
    {
        if (AssignmentResultUplaod.FileName == null)
        {

        }
        else
        {
            string filename = Path.GetFileName(AssignmentResultUplaod.PostedFile.FileName);
            string Extension = Path.GetExtension(AssignmentResultUplaod.PostedFile.FileName);

            long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
            string orgPath = string.Empty;
            orgPath = Server.MapPath("~/LMS/AssignmentResults/" + filename);
            AssignmentResultUplaod.SaveAs(orgPath);

            System.Data.DataTable dt = Import_To_Grid(orgPath, Extension, "Yes");
            DBFunctions db = new DBFunctions();
            int assinmentId = int.Parse(Session["asgmtid"].ToString());
            int crsid = int.Parse(Request.QueryString["course"]);

          
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string stdids = row[0].ToString();
                string marks = row[1].ToString();
              
                Assignment_Result_tbl assresult = new Assignment_Result_tbl { AssignmentID = assinmentId, StudentiID = int.Parse(stdids), Assignment_Marks = int.Parse(marks) };
                //Results_tbl result = new Results_tbl { CourseID = int.Parse(DropDownCourse.SelectedValue), MetricNo = row[0].ToString(), TotalMarks = int.Parse(row[1].ToString()), ObtainedMarks = int.Parse(row[2].ToString()), Year = row[3].ToString(), ExamType = row[4].ToString() };
                db.addassignmentresult(assresult);
            }
            Response.Redirect("UploadAssignments.aspx?course=" + crsid + "&tab=assignments");


        }
    }
    protected void UpdateAsignment_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        string filename = "";
        if(FileAssignmentupdate.FileName!="")
        {
            filename=FileAssignmentupdate.FileName;
            FileAssignmentupdate.SaveAs(Server.MapPath("~/LMS/Assignment/" + filename));
        }
        db.updateassugnment(int.Parse(Session["asgmtid"].ToString()), Updateasgmttitle.Text, int.Parse(updateasgmtmarks.Text), Assgnmentduedate.SelectedDate, filename);
        Assgnmentduedate.Visible = false;
        Response.Redirect("UploadAssignments.aspx?course=" + Request.QueryString["course"] + "&tab=assignments");
    }
    [WebMethod(EnableSession=true)]
    public static string setasgmt(string asgmtid)
    {
        HttpContext.Current.Session["asgmtid"] = asgmtid;
        int aid = int.Parse(asgmtid);
        DBFunctions db = new DBFunctions();
        Assignments_tbl asgmt= db.getasssignement(aid);
        
        return asgmt.ID+","+asgmt.Assignment_Title+","+asgmt.marks+","+asgmt.DueDate.Value.ToShortDateString();
    }
    [WebMethod(EnableSession = true)]
    public static void setasgmtid(string asgmtid)
    {
        HttpContext.Current.Session["asgmtid"] = asgmtid;

       
    }
    protected void changedatebtn_Click(object sender, EventArgs e)
    {
        if (Assgnmentduedate.Visible!=true)
        Assgnmentduedate.Visible = true;
        else
        {
            Assgnmentduedate.Visible = false;
        }
        Assgnmentduedate.SelectedDate = DateTime.Parse(duedateupdatelbl.Value).Date;
        Assgnmentduedate.VisibleDate = Assgnmentduedate.SelectedDate;

    }
}