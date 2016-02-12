using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


public class DBFunctions
{
    CollegeERPDBEntities db;
	public DBFunctions()
	{


	}
       public void addQuestion(string Question,string[] answers)
       {
           using (db = new CollegeERPDBEntities())
           {
               Questionaire_tbl qstn = new Questionaire_tbl { Question = Question };
               db.Questionaire_tbl.Add(qstn);
               db.SaveChanges();
               foreach (string ans in answers)
               {
                   Answers_tbl anss = new Answers_tbl { Q_ID = qstn.Q_ID, Answer = ans };
                   db.Answers_tbl.Add(anss);
                   db.SaveChanges();
               }
           }

       }

       public void AddCandidate(Candidate_tbl candidate)
       {
           db = new CollegeERPDBEntities();
           
               db.Candidate_tbl.Add(candidate);
               db.SaveChanges();

           
       }
       public void AddQuestionare(int UserID)
       {
           db = new CollegeERPDBEntities();
           
           AdminMails_tbl obj = new AdminMails_tbl {SenderID=UserID,Message="<a href=DownloadReport.aspx?senderid='"+UserID+"'>Download Questionair</a>",Subject="SuggestionRequest",Status=0,Date=DateTime.Now.Date};
           db.AdminMails_tbl.Add(obj);
           db.SaveChanges();
       }

       public void AddRegistrationNotice(Mails_tbl t)
       {
           db = new CollegeERPDBEntities();

           db.Mails_tbl.Add(t);
           db.SaveChanges();


       }
       public Candidate_tbl LoginChek(string username, string password)
       {
          db = new CollegeERPDBEntities();
       
               var candidate = db.Candidate_tbl.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
               
               return candidate;
        
       }

       public List<Program_tbl> getprogramslist()
       {
           db = new CollegeERPDBEntities();
           
               var programs = db.Program_tbl.ToList();
               return programs;
           
       }

    

       public List<FormSections_tbl> getformSectionlist()
       {
           using (db = new CollegeERPDBEntities())
           {
               var Sections = db.FormSections_tbl.ToList();
               return Sections;
           }
       }

       public void addFormField(Forms_tbl form,string [] options)
       {
           using (db = new CollegeERPDBEntities())
           {
               db.Forms_tbl.Add(form);
               db.SaveChanges();

               if(form.FormControl!="Text")
               {
                   foreach (string option in options)
                       db.ControlOptions_tbl.Add(new ControlOptions_tbl { FieldID=form.ID,optionvalue=option});
               }
                   db.SaveChanges();
           }


       }

    public List<Forms_tbl> getform(int programid)
       {
           using (db = new CollegeERPDBEntities())
           {
               var program = db.Forms_tbl.Where(x=>x.ProgrameID==programid).ToList();
               return program;
           }
       
       }

    public List<ControlOptions_tbl> getoptions(int fieldid)
    {
        using (db = new CollegeERPDBEntities())
        {
            var program = db.ControlOptions_tbl.Where(x => x.FieldID ==fieldid).ToList();
            return program;
        }
    }


    public List<Questionaire_tbl> getquestions(int page,int pagesize)
    {
        using (db = new CollegeERPDBEntities())
        {
            var Quest = db.Questionaire_tbl.OrderBy(x=>x.Q_ID).Skip(page * pagesize).Take(pagesize).ToList();
            return Quest;
        }
    }

    public int getquestioncount()
    {
        using (db = new CollegeERPDBEntities())
        {
            var Quest = db.Questionaire_tbl.ToList().Count;
            return Quest;
        }
    }

    public List<Answers_tbl> getanswers(int qid)
    {
        using (db = new CollegeERPDBEntities())
        {
            var Ans = db.Answers_tbl.Where(x=>x.Q_ID==qid).ToList();
            return Ans;
        }
    }

    public void addprogramme(Program_tbl program)
    {
        using (db = new CollegeERPDBEntities())
        {
            db.Program_tbl.Add(program);
            db.SaveChanges();
        }
    }

    public List<Department_tbl> getalldepartments()
    {
        using (db = new CollegeERPDBEntities())
        {
            return db.Department_tbl.ToList();
        }
    }

    public void disableeprogmme(int id)
    {
      
      db = new CollegeERPDBEntities();
      var progrm=  db.Program_tbl.Where(x=>x.ID==id).FirstOrDefault();
      progrm.Enable = false;
     // db.Program_tbl.Remove(progrm);
      db.SaveChanges();
      
    }
    public void Enableeprogmme(int id)
    {

        db = new CollegeERPDBEntities();
        var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        progrm.Enable = true;
       
        db.SaveChanges();

    }
    public Program_tbl getprogram(int id)
    {
        db = new CollegeERPDBEntities();
        var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();

        return progrm;
    }
    public void updateprogram(Program_tbl updateprog)
    {
        db = new CollegeERPDBEntities();

        db.Program_tbl.Attach(updateprog);
       // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        db.Entry(updateprog).State = EntityState.Modified;
        
        db.SaveChanges();
      
    }


    public List<States_tbl> getstates()
    {
        db = new CollegeERPDBEntities();
        return db.States_tbl.ToList();
    }
    public List<Areas_tbl> Getareas(int stid)
    {
        db = new CollegeERPDBEntities();
      return  db.Areas_tbl.Where(x=>x.State==stid).ToList();
    }

    public Program_tbl getstudentprogram(int candidateid)
    {
        db=new CollegeERPDBEntities();
        var program = db.AddmissionList_tbl.Where(x=>x.UserID==candidateid).FirstOrDefault().Program_tbl;

        return program;
    }

    public void Enrollcourse(Enroll_Course enroll)
    {
        db = new CollegeERPDBEntities();
        var ec = db.Enroll_Course.Where(x => x.Uid == enroll.Uid && x.CourseID == enroll.CourseID).FirstOrDefault();
        if (ec==null)
        {
            db.Enroll_Course.Add(enroll);
            db.SaveChanges();
           
        }
        else if(ec.Status==3)
        {
            ec.Status = 0; //Reenroll Course Request
            db.SaveChanges();
        }
       
       
      
        var candidate = db.Candidate_tbl.Where(x=>x.ID==enroll.Uid).FirstOrDefault();
        var course = db.Courses_tbl.Where(x=>x.ID==enroll.CourseID).FirstOrDefault();
        AdminMails_tbl mail = new AdminMails_tbl {Date=DateTime.Now.Date, Subject = "Course Enrollment Application", SenderID = enroll.Uid, Status = 0, Message =candidate.Name + " Wants to enroll in  " + course.Course + "<br/><br> <a href='EnrollmentAppications.aspx' class='btn btn-primary'>View Enrollment Application</a>" };
        addadminmail(mail);
    }

    public void createApplication(Applications_tbl application)
    {
        db = new CollegeERPDBEntities();
        db.Applications_tbl.Add(application);
        db.SaveChanges();
    }

    public List<Enroll_Course> getenrollmentapplications()
    {
        db = new CollegeERPDBEntities();
        return db.Enroll_Course.ToList();
    }
   public void updateenrollment(int appid,string status)
    {
        db = new CollegeERPDBEntities();
        Enroll_Course ec = db.Enroll_Course.Where(x => x.ID == appid).FirstOrDefault();
        ec.Status=int.Parse(status);
        db.SaveChanges();

       if(status=="1")
       {
           assigncouresefee(ec.Uid.Value, ec.CourseID.Value);
           Mails_tbl mail = new Mails_tbl { RecieverID = ec.Uid, Date = DateTime.Now.Date, Message = "Your Enrollment Application for " + ec.Courses_tbl.Course + " has been approved, Please Submit $"+ec.Courses_tbl.Fee, Status = 0, Subject = "Enrollment Applications" };
           addmail(mail);     
       }
       else if(status=="-1")
       {
           
           Mails_tbl mail = new Mails_tbl { RecieverID = ec.Uid, Date = DateTime.Now.Date, Message = "Your Enrollment Application for " + ec.Courses_tbl.Course + " has been Rejected", Status = 0, Subject = "Enrollment Applications" };
           addmail(mail);  
       }
    }

   public void assigncouresefee(int sid,int cid)
   {
       db = new CollegeERPDBEntities();
       db.CourseFee_tbl.Add(new CourseFee_tbl {StudentID=sid,CourseID=cid,Status=0});
       db.SaveChanges();
   }
   public int AddCreditHours(StudentSelectedCredit obj)
   {
       
       using (db = new CollegeERPDBEntities())
       {
           db.StudentSelectedCredits.Add(obj);
           db.SaveChanges();
       }
       return obj.ID;
   }

   public void UpdateCreditHours(StudentSelectedCredit t)
   {

       db = new CollegeERPDBEntities();
       db.StudentSelectedCredits.Attach(t);
       db.Entry(t).State = EntityState.Modified;
      
       db.SaveChanges();
   }

   public List<CourseFee_tbl> getstudentcoursefee(int sid)
   {
       db = new CollegeERPDBEntities();
       var cf=  db.CourseFee_tbl.Where(x=>x.StudentID==sid).ToList();
       return cf;
   }

   public List<StudentSelectedCredit> getStudentCredits(int sid)
   {
       db = new CollegeERPDBEntities();
       var cf = db.StudentSelectedCredits.Where(x => x.UserID == sid).ToList();
       return cf;
   }

   public List<Courses_tbl> getcourselist()
   {
       db = new CollegeERPDBEntities();

       var course = db.Courses_tbl.ToList();
       return course;

   }

   public List<DateSheet_tbl> getAllDateSheets()
   {
       db = new CollegeERPDBEntities();

       var datesheet = db.DateSheet_tbl.ToList();
       return datesheet;

   }

   public int addcourse(Courses_tbl course)
   {
       using (db = new CollegeERPDBEntities())
       {
           db.Courses_tbl.Add(course);
           db.SaveChanges();
       }
       return course.ID;
   }

   public void addTimeTable(TimeTable_tbl ttable)
   {
       using (db = new CollegeERPDBEntities())
       {
           db.TimeTable_tbl.Add(ttable);
           db.SaveChanges();
       }
   }

   public void addDateSheet(DateSheet_tbl DStable)
   {
       using (db = new CollegeERPDBEntities())
       {
           db.DateSheet_tbl.Add(DStable);
           db.SaveChanges();
       }
   }

   public DateSheet_tbl checkDateSheet(string examtype, string year, int courseid, string starttime, string endtime)
   {
       using (db = new CollegeERPDBEntities())
       {
           var datesheetFlag = db.DateSheet_tbl.Where(x => x.ExamType == examtype && x.Year == year && x.CourseID == courseid && x.StartTime == starttime && x.EndTime == endtime).FirstOrDefault();
           return datesheetFlag;
       }
   }

   public int getCourse_Count()
   {
       db = new CollegeERPDBEntities();
       var totalcourse = db.Courses_tbl.Count();
       return totalcourse;
   }

   public List<Courses_tbl> getcourselist(int page, int pagesize)
   {
       db = new CollegeERPDBEntities();
       return db.Courses_tbl.OrderBy(x=>x.ID).Skip((page-1) * pagesize).Take(pagesize).ToList();
       // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault
   }
   public int getDateSheet_Count()
   {
       db = new CollegeERPDBEntities();
       var totalcourse = db.DateSheet_tbl.Count();
       return totalcourse;
   }

   public List<DateSheet_tbl> getDateSheetlist(int pageStart, int pageEnd)
   {
       db = new CollegeERPDBEntities();
       List<DateSheet_tbl> temp = new List<DateSheet_tbl>();
       for (int i = pageStart; i <= pageEnd; i++)
       {
           if (db.DateSheet_tbl.Where(x => x.ID == i).FirstOrDefault() != null)
           {
               var course = db.DateSheet_tbl.Where(x => x.ID == i).FirstOrDefault();
               temp.Add(course);
           }
       }
       // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

       return temp;
   }

   public TimeTable_tbl checkTimeTable(int course, string starttime, string endtime, string day)
   {
       using (db = new CollegeERPDBEntities())
       {
           var datesheetFlag = db.TimeTable_tbl.Where(x => x.CourseID == course && x.StartTime == starttime && x.EndTime == endtime && x.Day == day ).FirstOrDefault();
           return datesheetFlag;
       }
   }

   public int getTimeTable_Count()
   {
       db = new CollegeERPDBEntities();
       var totalcourse = db.TimeTable_tbl.Count();
       return totalcourse;
   }

   public List<TimeTable_tbl> getTimeTablelist(int pageStart, int pageEnd)
   {
       db = new CollegeERPDBEntities();
       List<TimeTable_tbl> temp = new List<TimeTable_tbl>();
       for (int i = pageStart; i <= pageEnd; i++)
       {
           if (db.TimeTable_tbl.Where(x => x.ID == i).FirstOrDefault() != null)
           {
               var course = db.TimeTable_tbl.Where(x => x.ID == i).FirstOrDefault();
               temp.Add(course);
           }
       }
       // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

       return temp;
   }

   public DateSheet_tbl getDateSheet(int id)
   {
       db = new CollegeERPDBEntities();
       var ds = db.DateSheet_tbl.Where(x => x.ID == id).FirstOrDefault();

       return ds;
   }

   public void updateDateSheet(DateSheet_tbl updatedts)
   {
       db = new CollegeERPDBEntities();

       db.DateSheet_tbl.Attach(updatedts);
       // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
       db.Entry(updatedts).State = EntityState.Modified;

       db.SaveChanges();

   }

   public TimeTable_tbl getTimeTable(int id)
   {
       db = new CollegeERPDBEntities();
       var ds = db.TimeTable_tbl.Where(x => x.ID == id).FirstOrDefault();

       return ds;
   }

   public void updateTimeTable(TimeTable_tbl updatedts)
   {
       db = new CollegeERPDBEntities();

       db.TimeTable_tbl.Attach(updatedts);
       // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
       db.Entry(updatedts).State = EntityState.Modified;

       db.SaveChanges();

   }
   public Courses_tbl getcourses(int id)
   {
       db = new CollegeERPDBEntities();
       var course = db.Courses_tbl.Where(x => x.ID == id).FirstOrDefault();

       return course;
   }
   public void updatecourse(Courses_tbl updatecrs)
   {
       db = new CollegeERPDBEntities();

       db.Courses_tbl.Attach(updatecrs);
       // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
       db.Entry(updatecrs).State = EntityState.Modified;

       db.SaveChanges();

   }
   public void UpdateStudentsCredits()
   {
       db = new CollegeERPDBEntities();

       var Students=db.StudentSelectedCredits.ToList();
       Students.ForEach(a => a.SelectedCourseCount = 0);
       db.SaveChanges();

   }
   public void UpdateStudentSemester()
   {
       db = new CollegeERPDBEntities();

       var Students = db.StudentInfo_tbl.ToList();
       Students.ForEach(a => a.Semester = a.Semester+1);
       db.SaveChanges();

   }

   public List<TimeTable_tbl> gettimetable(int sid)
   {
       db = new CollegeERPDBEntities();
       var enrollcourse = db.Enroll_Course.Where(x=>x.Uid==sid&&x.Status==1).ToList();

       CollegeERPDBEntities db1 = new CollegeERPDBEntities();
       List<TimeTable_tbl> t=new List<TimeTable_tbl>();
       foreach(Enroll_Course ec in enrollcourse)
       {
           var time = db1.TimeTable_tbl.Where(x => x.CourseID == ec.CourseID).FirstOrDefault();
           if(time!=null)
           t.Add(time);
       }

       return t;
   }

   public List<DateSheet_tbl> getdatesheet(int id)
   {
       db = new CollegeERPDBEntities();
       var enrollcourses = db.Enroll_Course.Where(x=>x.Uid==id&&x.Status==1).ToList();
       List<DateSheet_tbl> ds = new List<DateSheet_tbl>();
       foreach(var en in enrollcourses)
       {
           var datesheet = db.DateSheet_tbl.Where(x=>x.CourseID==en.CourseID).FirstOrDefault();
           if(datesheet!=null)
           ds.Add(datesheet);
       }
       return ds;
   }


   public List<DiscussionTopics_tbl> getdiscussiontopics()
   {
       db = new CollegeERPDBEntities();
       return db.DiscussionTopics_tbl.OrderByDescending(x=>x.DateCreated).ToList();
   }
   public List<Discussions_tbl> getdiscussionbytopic(int topicid,int page,int pagesize)
   {
       db = new CollegeERPDBEntities();
       return db.Discussions_tbl.Where(x => x.TopicID == topicid).OrderByDescending(y => y.Date).Skip(page * pagesize).Take(pagesize).ToList();
   }
   public int getdiscussionbytopiccount(int topicid)
   {
       db = new CollegeERPDBEntities();
       return db.Discussions_tbl.Where(x => x.TopicID == topicid).ToList().Count;
   }


   public Discussions_tbl adddiscussion(Discussions_tbl dis)
   {
       db = new CollegeERPDBEntities();
       db.Discussions_tbl.Add(dis);
       db.SaveChanges();
       
       var topic= db.DiscussionTopics_tbl.Where(x=>x.ID==dis.TopicID).FirstOrDefault();
       topic.DateCreated = DateTime.Now;
       db.SaveChanges();
       return dis;
       
   }

   public List<Notices_tbl> getNoticelist(int pageStart, int pageEnd)
   {
       db = new CollegeERPDBEntities();
       List<Notices_tbl> temp = new List<Notices_tbl>();
       for (int i = pageStart; i <= pageEnd; i++)
       {
           if (db.Notices_tbl.Where(x => x.ID == i).FirstOrDefault() != null)
           {
               var course = db.Notices_tbl.Where(x => x.ID == i).FirstOrDefault();
               temp.Add(course);
           }
       }
       // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

       return temp;
   }

   public int getNotices_Count()
   {
       db = new CollegeERPDBEntities();
       var totalNotices = db.Notices_tbl.Count();
       return totalNotices;
   }
   public void addNotice(Notices_tbl nttable)
   {
       using (db = new CollegeERPDBEntities())
       {
           db.Notices_tbl.Add(nttable);
           db.SaveChanges();
       }
   }

   public Support_tbl loadQuestion(int id)
   {
       db = new CollegeERPDBEntities();
       var question = db.Support_tbl.Where(x => x.ID == id).FirstOrDefault();
       return question;
   }
   public void updatequestion(Support_tbl ques)
   {
       db = new CollegeERPDBEntities();

       db.Support_tbl.Attach(ques);
       // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
       db.Entry(ques).State = EntityState.Modified;

       db.SaveChanges();
       Mails_tbl mail = new Mails_tbl { RecieverID =ques.UserID, Date = DateTime.Now.Date, Message =ques.Answer, Status = 0, Subject = "Admin Answer" };
       addmail(mail);  

   }

   public List<Support_tbl> getQuestionlist(int pageSize, int page)
   {
       db = new CollegeERPDBEntities();
       return db.Support_tbl.OrderByDescending(x => x.ID).Skip(page*pageSize).Take(pageSize).ToList() ;
   }

   public int getQuestion_Count()
   {
       db = new CollegeERPDBEntities();
       var totalcourse = db.Support_tbl.Count();
       return totalcourse;
   }

   public int getQuestion_Count(int userid)
   {
       db = new CollegeERPDBEntities();
       var totalcourse = db.Support_tbl.Where(x => x.UserID == userid).Count();
       return totalcourse;
   }

   public List<Support_tbl> getQuestionlist(int userid, int pageStart, int pageEnd)
   {
       db = new CollegeERPDBEntities();
       return db.Support_tbl.Where(x=>x.UserID==userid).OrderByDescending(x => x.ID).Skip(pageStart * pageEnd).Take(pageEnd).ToList();
       //List<Support_tbl> temp = new List<Support_tbl>();
       //for (int i = pageStart; i <= pageEnd; i++)
       //{
       //    if (db.Support_tbl.Where(x => x.ID == i).FirstOrDefault() != null)
       //    {
       //        var question = db.Support_tbl.Where(x => x.ID == i && x.UserID == userid).FirstOrDefault();
       //        temp.Add(question);
       //    }
       //}
       //// var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

       //return temp;
   }

   public void addQuestion(Support_tbl DStable)
   {
       using (db = new CollegeERPDBEntities())
       {
           db.Support_tbl.Add(DStable);
           db.SaveChanges();
       }
       AdminMails_tbl mail = new AdminMails_tbl { SenderID = DStable.UserID, Message = DStable.Question + "<br><br><br><a class='btn btn-primary' href='AnswerQuestion.aspx?Questionid=" + DStable.ID + "&action=update'>Answer Question</a>", Status = 0,Date=DateTime.Now,Subject="Question" };
       addadminmail(mail);
   }

   public int adddiscussiontopic(DiscussionTopics_tbl topic)
   {
       db = new CollegeERPDBEntities();
       db.DiscussionTopics_tbl.Add(topic);
       db.SaveChanges();
       return topic.ID;
   }

   public DiscussionTopics_tbl gettopic(int topicid)
   {
       db = new CollegeERPDBEntities();
      return db.DiscussionTopics_tbl.Where(x=>x.ID==topicid).FirstOrDefault();
   }

    public Candidate_tbl getuserinfo(int uid){
        db=new CollegeERPDBEntities();
        return db.Candidate_tbl.Where(x=>x.ID==uid).FirstOrDefault();
    }
    public Candidate_tbl CheckExistingUsers(string name)
    {
        db = new CollegeERPDBEntities();
        return db.Candidate_tbl.Where(x => x.Username == name).FirstOrDefault();
    }

    public List<AdminMails_tbl> getadminmails(int page,int pagesize)
    {
        db = new CollegeERPDBEntities();
        return db.AdminMails_tbl.OrderByDescending(x => x.ID).Skip(page * pagesize).Take(pagesize).ToList();
    }

    public int getadminmails_count()
    {
        db = new CollegeERPDBEntities();
        return db.AdminMails_tbl.ToList().Count;
    }
    public AdminMails_tbl getadminmail(int mid)
    {
        db = new CollegeERPDBEntities();

        var mail = db.AdminMails_tbl.Where(x => x.ID == mid).FirstOrDefault();
        mail.Status = 1;
        db.SaveChanges();
        return mail;
    }

    public void addadminmail(AdminMails_tbl mail)
    {
        db = new CollegeERPDBEntities();
        db.AdminMails_tbl.Add(mail);
        db.SaveChanges();
    }


    public List<Mails_tbl> getusermails(int page, int pagesize,int userid)
    {
        string message = "Registration";
        db = new CollegeERPDBEntities();
        return db.Mails_tbl.Where(x=>x.RecieverID==userid || x.Subject==message).OrderByDescending(x => x.ID).Skip(page * pagesize).Take(pagesize).ToList();
    }

    public int getadusermails_count(int uid)
    {
        db = new CollegeERPDBEntities();
        return db.Mails_tbl.Where(x=>x.RecieverID==uid).ToList().Count;
    }


    public Mails_tbl getusermail(int mid)
    {
        db = new CollegeERPDBEntities();

        var mail = db.Mails_tbl.Where(x => x.ID == mid).FirstOrDefault();
        mail.Status = 1;
        db.SaveChanges();
        return mail;
    }
   

    public List<Candidate_tbl> getapplicantlist(int page,int pagesize)
    {
        db = new CollegeERPDBEntities();
        var candidates= db.Candidate_tbl.OrderByDescending(x=>x.CuttoffPoints).Skip(page*pagesize).Take(pagesize).ToList() ;
        return candidates;
    }

    public List<Candidate_tbl> generatemeritlist(int prgid)
    {
        db = new CollegeERPDBEntities();
        var candidates = db.Candidate_tbl.Where(x=>x.ProgrammeID==prgid).OrderByDescending(x => x.CuttoffPoints).Take(100).ToList();
        return candidates;
    }
    public List<Candidate_tbl> generatemeritlist2(int prgid)
    {
        db = new CollegeERPDBEntities();
        
        var candidates = db.Candidate_tbl.Where(x => x.ProgrammeID == prgid).OrderByDescending(x => x.CuttoffPoints).Take(100).ToList();
        return candidates;
    }
    public int getapplicant_count()
    {
        db = new CollegeERPDBEntities();
        var candidates = db.Candidate_tbl.ToList().Count;
        return candidates;
    }

    public List<Candidate_tbl> getcandidatesbyprogram(int prgid)
    {
        db = new CollegeERPDBEntities();
        string year = DateTime.Now.Year.ToString();
        return db.Candidate_tbl.Where(x => x.ProgrammeID == prgid && x.AdmissionYear == year).OrderByDescending(x => x.CuttoffPoints).ToList();
    }

    public void addadmssion(List<Candidate_tbl> candidatelist)
    {
        db = new CollegeERPDBEntities();
        int prgid=-1;
foreach(var cand in candidatelist)
{
    
    string matricno=DateTime.Now.Year+"-"+cand.Program_tbl.ProgramName+"-"+cand.ID;
    var std = db.AddmissionList_tbl.Where(x=>x.UserID==cand.ID).FirstOrDefault();
    var info = db.StudentInfo_tbl.Where(x => x.UserId == cand.ID).FirstOrDefault();
    
    if(std==null&&info==null){
       StudentInfo_tbl student = new StudentInfo_tbl { ProgramID = cand.ProgrammeID, StudentLevel = "ND1", UserId = cand.ID, Semester = 0, DeptID = cand.Program_tbl.DeptID, FeeDiscount = "0", AcadamicYear = DateTime.Now.Year.ToString() };
    StudentAcceptanceFee_tbl accfee = new StudentAcceptanceFee_tbl { ProgramID = cand.ProgrammeID, Userid = cand.ID, Status = 0 };
    Mails_tbl mail = new Mails_tbl { RecieverID = cand.ID, Message ="Acceptence Fee Of "+ cand.Program_tbl.AcceptenceFee + " Has Been Assigned to You <br> Please Submit This Fees with in One Week", Subject = "Acceptence Fee", Date = DateTime.Now,Status=0 };
    addmail(mail);
        db.StudentInfo_tbl.Add(student);
        int Year = Convert.ToInt16(student.AcadamicYear);
        Batches_table temp = db.Batches_table.Where(x => x.BatchYear == Year).FirstOrDefault();
        AddmissionList_tbl admission = new AddmissionList_tbl { ProgrameID = cand.ProgrammeID, Status = 0, route = "Merit", UserID = cand.ID, MetricNo = matricno, Password = cand.Password,BatchID=temp.ID };

    db.AddmissionList_tbl.Add(admission);
    db.StudentAcceptanceFee_tbl.Add(accfee);
       

    prgid = cand.ProgrammeID.Value;
}
    var candidates = db.Candidate_tbl.Where(x => x.ProgrammeID == prgid).OrderByDescending(x => x.CuttoffPoints).Skip(100).ToList();
       foreach(var c in candidates)
       {
           c.Status = -1;
       }
       var addmittedcandidates = db.Candidate_tbl.Where(x => x.ProgrammeID == prgid).OrderByDescending(x => x.CuttoffPoints).Take(100).ToList();
       foreach (var c in addmittedcandidates)
       {
           c.Status = 1;
       }
}
        
db.SaveChanges();
    }

    public void addmail(Mails_tbl mail)
    {
        db = new CollegeERPDBEntities();
        db.Mails_tbl.Add(mail);
        db.SaveChanges();

    }

    public List<StudentInfo_tbl> getadmittedstudents()
    {
        db = new CollegeERPDBEntities();
      return  db.StudentInfo_tbl.ToList();
    }

    public StudentInfo_tbl getstdentinfo(int stdid)
    {
        db = new CollegeERPDBEntities();
        return db.StudentInfo_tbl.Where(x=>x.UserId==stdid).FirstOrDefault();

    }
    //txtHomeaddress.Text, int.Parse(dropdownSto.SelectedValue),int.Parse(dropdownLocalGovtarea.SelectedValue),Emailtxt.Text,dropdownDay.SelectedItem.Text + "-" + dropdownMonth.SelectedItem.Text + "-" + dropdownyears.SelectedItem.Text,Phonetxt.Text
    public void updatestudtent(int stdid,string Name,int prid,int semester,string feediscount,string address,int sto,int area,string email,string dob,string phone)
    {
         db = new CollegeERPDBEntities();
        var student= db.StudentInfo_tbl.Where(x=>x.UserId==stdid).FirstOrDefault();
        student.ProgramID = prid;
        student.Semester = semester;
        student.FeeDiscount = feediscount;
        student.Candidate_tbl.Name = Name;
        student.Candidate_tbl.ProgrammeID = prid;
        student.Candidate_tbl.HomeAdress = address;
        student.Candidate_tbl.LocalGovtArea = area;
        student.Candidate_tbl.Stateoforigin = sto;
        student.Candidate_tbl.Email = email;
        student.Candidate_tbl.Phone = phone;
        student.Candidate_tbl.DateofBirth = dob;
        db.SaveChanges();
    }

    public int addresults(Results_tbl result)
    {
        db = new CollegeERPDBEntities();
        db.Results_tbl.Add(result);
        db.SaveChanges();
        return result.ID;
    }

    public List<Results_tbl> getresult(int stdid,string term)
    {

        db = new CollegeERPDBEntities();
        var metricno=db.AddmissionList_tbl.Where(x=>x.UserID==stdid).FirstOrDefault().MetricNo;
        string year = DateTime.Now.Year.ToString();
        return db.Results_tbl.Where(x => x.MetricNo == metricno && x.Year==year && x.ExamType==term).ToList();
        
    }

    public List<Enroll_Course> getenrolledstudents(int crsid)
    {
        db = new CollegeERPDBEntities();
       return db.Enroll_Course.Where(x=>x.CourseID==crsid&&x.Status==1).ToList();
    }

    public void addattendance(Attendance_tbl attendance)
    {
        db = new CollegeERPDBEntities();
        DateTime date = DateTime.Now.Date;
        var check = db.Attendance_tbl.Where(x => x.Date == date && x.StudentID == attendance.StudentID&&x.CourseID==attendance.CourseID).FirstOrDefault();
        if(check==null)
        {
            
        db.Attendance_tbl.Add(attendance);
        db.SaveChanges();
        }
    }


    public bool checkattendance(int courseid)
    {
        db = new CollegeERPDBEntities();
        DateTime date=DateTime.Now.Date;
        var check = db.Attendance_tbl.Where(x=>x.CourseID==courseid && x.Date==date).FirstOrDefault();

        return (check == null);
            
    }

    public IEnumerable<IGrouping<int, Attendance_tbl>> getattendance(int stdid)
    {
        db = new CollegeERPDBEntities();
        return db.Attendance_tbl.Where(x=>x.StudentID==stdid).GroupBy(x=>x.CourseID.Value);
    }

    public List<Attendance_tbl> getattdance_course(int courseid)
    {
        db = new CollegeERPDBEntities();
        return db.Attendance_tbl.Where(x => x.CourseID == courseid).ToList();
    }

    public void addbook(Book book)
    {
        using (db = new CollegeERPDBEntities())
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
    }

    public void placeOrder(IssueBook book)
    {
        using (db = new CollegeERPDBEntities())
        {
            db.IssueBooks.Add(book);
            db.SaveChanges();
            AdminMails_tbl amail = new AdminMails_tbl { SenderID = book.LibraryMember.UserID, Message = book.LibraryMember.Candidate_tbl.Name + " has Requested for " + book.Book.Title, Date = DateTime.Now.Date, Subject = "Book Request", Status = 0 };
            addadminmail(amail);        
        }
    }

    public List<IssueBook> getIssuebooklist(int page, int pageSize)
    {
        db = new CollegeERPDBEntities();
        List<IssueBook> temp = db.IssueBooks.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
        
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return temp;
    }

    public List<LibraryMember> getmemberrequestlist(int page, int pageSize)
    {
        db = new CollegeERPDBEntities();
     
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return db.LibraryMembers.Where(x=>x.Status==0).OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
    }

    public List<Book> getbooklist(int page, int pagesize)
    {
        db = new CollegeERPDBEntities();
        List<Book> temp = db.Books.OrderBy(x=>x.ID).Skip(page*pagesize).Take(pagesize).ToList();
        
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return temp;
    }

    public int getBook_Count()
    {
        db = new CollegeERPDBEntities();
        var totalbook = db.Books.Count();
        return totalbook;
    }

    public int getRequest_Count()
    {
        db = new CollegeERPDBEntities();
        var totalrequest = db.LibraryMembers.Where(x => x.Status == 0).Count();
        return totalrequest;
    }

    public int getbookRequest_Count()
    {
        db = new CollegeERPDBEntities();
        var totalrequest = db.IssueBooks.Count();
        return totalrequest;
    }

    public Book loadBook(int id)
    {
        db = new CollegeERPDBEntities();
        var book = db.Books.Where(x => x.ID == id).FirstOrDefault();
        return book;
    }

    public void updatebook(Book books)
    {
        db = new CollegeERPDBEntities();

        db.Books.Attach(books);
        // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        db.Entry(books).State = EntityState.Modified;

        db.SaveChanges();
    }

    public int getmemberid(int uid)
    {
        db = new CollegeERPDBEntities();
        return db.LibraryMembers.Where(x => x.UserID == uid).FirstOrDefault().ID;
    }

    public IssueBook getBookRequest(int id)
    {
        db = new CollegeERPDBEntities();
        return db.IssueBooks.Where(x => x.ID == id).FirstOrDefault();
    }

    public void updatebookrequest(int id,DateTime duedate,int status)
    {
        db = new CollegeERPDBEntities();
        var book= db.IssueBooks.Where(x=>x.ID==id).FirstOrDefault();
        if (status == 1)
        {
            book.DueDate = duedate;
            book.IssueDate = DateTime.Now.Date;
            book.Book.Quantity -= 1;
        }
        else
        {
            book.DueDate = null;
            book.IssueDate = null;
        }
        book.Status = status;
        db.SaveChanges();
    }

    public List<IssueBook> getstudentissuedbooks(int uid)
    {
        db = new CollegeERPDBEntities();
        int mid=db.LibraryMembers.Where(x => x.UserID == uid).FirstOrDefault().ID;
        return db.IssueBooks.Where(x => x.MemberID == mid && x.Status==1).ToList();
    }

    public void returnbook(int reqid)
    {
        db = new CollegeERPDBEntities();
        var req= db.IssueBooks.Where(x=>x.ID==reqid).FirstOrDefault();
        req.Book.Quantity += 1;
        req.Status = 2;
        req.ReturnDate = DateTime.Now.Date;
        db.SaveChanges();
    }

    public List<EmployeeType_tbl> GetEmployeeType()
    {
        db = new CollegeERPDBEntities();
        return db.EmployeeType_tbl.ToList();
    }

    public Employee_tbl addEmployee(Employee_tbl Employee)
    {
        db = new CollegeERPDBEntities();
        db.Employee_tbl.Add(Employee);
        db.SaveChanges();
        return Employee;
    }

    public List<Employee_tbl> getallemployee(int page,int pagesize,int deptid)
    {
        db=new CollegeERPDBEntities();
        if(deptid==0)
        return db.Employee_tbl.OrderBy(x=>x.ID).Skip(page*pagesize).Take(pagesize).ToList();
    else
            return db.Employee_tbl.Where(c=>c.Deptid==deptid).OrderBy(x => x.ID).Skip(page * pagesize).Take(pagesize).ToList();

    }


    public int getemployee_count(int deptid)
    {
        db=new CollegeERPDBEntities();
        if(deptid==0)
        return db.Employee_tbl.ToList().Count;    
        return db.Employee_tbl.Where(x=>x.Deptid==deptid).ToList().Count;
    }


    public Employee_tbl getemployee(int empid)
    {
        db = new CollegeERPDBEntities();
        return db.Employee_tbl.Where(x => x.ID == empid).FirstOrDefault();
    }

    public void updateEmployee(Employee_tbl employee)
    {
        db = new CollegeERPDBEntities();

        db.Employee_tbl.Attach(employee);
        // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        db.Entry(employee).State = EntityState.Modified;

        db.SaveChanges();
    }

    public EmployeePay_tbl getemplyeepayinfo(int empid)
    {
        db = new CollegeERPDBEntities();
        EmployeePay_tbl emp = db.EmployeePay_tbl.Where(c => c.EmployeeID == empid).FirstOrDefault();
        return emp;
    }

    public void updatepay(EmployeePay_tbl pay)
    {
        db = new CollegeERPDBEntities();

        db.EmployeePay_tbl.Attach(pay);
        // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        db.Entry(pay).State = EntityState.Modified;

        db.SaveChanges();
       
    }


    public List<EmployeePay_tbl> getallemployee_pay(int page,int pageSize,int deptid)
    {
        db = new CollegeERPDBEntities();
        if(deptid==0)
            return db.EmployeePay_tbl.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
       else
            return db.EmployeePay_tbl.Where(x=>x.Employee_tbl.Deptid==deptid).OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();

      
    }

    public int getemployeePay_count(int deptid)
    {
        db = new CollegeERPDBEntities();
        if (deptid == 0)
            return db.EmployeePay_tbl.ToList().Count;
        else
            return db.EmployeePay_tbl.Where(x => x.Employee_tbl.Deptid == deptid).ToList().Count;
    }

    public int addemployeePay(EmployeePay_tbl pay)
    {
        db = new CollegeERPDBEntities();
        db.EmployeePay_tbl.Add(pay);
        db.SaveChanges();
        return pay.ID;
    }

    public StudentRoom_Mapping getRoomRequestById(int id)
    {
        db = new CollegeERPDBEntities();
        var hostel = db.StudentRoom_Mapping.Where(x => x.ID == id).FirstOrDefault();
        return hostel;
    }

    public HostelRoom_tbl getRoom(int id)
    {
        db = new CollegeERPDBEntities();
        var room = db.HostelRoom_tbl.Where(x => x.ID == id).FirstOrDefault();
        return room;
    }

    public HostelWarden_tbl getWarden(int id)
    {
        db = new CollegeERPDBEntities();
        var hostel = db.HostelWarden_tbl.Where(x => x.ID == id).FirstOrDefault();
        return hostel;
    }

    public StudentRoom_Mapping checkOrderList(int p1, int p2)
    {
        db = new CollegeERPDBEntities();
        var hostel = db.StudentRoom_Mapping.Where(x => x.RomID == p1 && x.StudentID == p2).FirstOrDefault();
        return hostel;
    }

    public void updateorder(int id, int status)
    {
        db = new CollegeERPDBEntities();

        var room = db.StudentRoom_Mapping.Where(x => x.ID == id).FirstOrDefault();
        if (status == 1)
        {
            room.HostelRoom_tbl.Capacity -= 1;
            room.Status = status;
            db.SaveChanges();
            Mails_tbl amail = new Mails_tbl { RecieverID = room.StudentID, Message = "your Request for Room No." + room.HostelRoom_tbl.RoomNo + " in " + room.HostelRoom_tbl.Hostel_tbl.Name + " Hostel has been approved", Date = DateTime.Now.Date, Subject = "Room Request", Status = 0 };
            addmail(amail);
           

        }
        if (status == -1)
        {
            room.Status = status;
            db.SaveChanges();
       
            Mails_tbl amail = new Mails_tbl { RecieverID = room.StudentID, Message = "your Request for Room No." + room.HostelRoom_tbl.RoomNo + " in " + room.HostelRoom_tbl.Hostel_tbl.Name + " Hostel has been Rejected", Date = DateTime.Now.Date, Subject = "Room Request", Status = 0 };
            addmail(amail);
       }
       if(status==5)
       {
           room.HostelRoom_tbl.Capacity += 1;
           db.StudentRoom_Mapping.Remove(room);
           db.SaveChanges();

           Mails_tbl amail = new Mails_tbl { RecieverID = room.StudentID, Message = "your Request for leaving Room No." + room.HostelRoom_tbl.RoomNo + " in " + room.HostelRoom_tbl.Hostel_tbl.Name + " Hostel has been Approved", Date = DateTime.Now.Date, Subject = "Room Leave Request", Status = 0 };
           addmail(amail);
           return;
       }
       //room.Status = status;
       //db.SaveChanges();

    }

    public Hostel_tbl getHostel(int id)
    {
        db = new CollegeERPDBEntities();
        var hostel = db.Hostel_tbl.Where(x => x.ID == id).FirstOrDefault();
        return hostel;
    }

    public HostelRoom_tbl getRoomById(int id)
    {
        db = new CollegeERPDBEntities();
        var hostel = db.HostelRoom_tbl.Where(x => x.ID == id).FirstOrDefault();
        return hostel;
    }

    public void addhostel(Hostel_tbl hstl)
    {
        using (db = new CollegeERPDBEntities())
        {
            db.Hostel_tbl.Add(hstl);
            db.SaveChanges();
        }
    }

    public void addwarden(HostelWarden_tbl hstl)
    {
        using (db = new CollegeERPDBEntities())
        {
            db.HostelWarden_tbl.Add(hstl);
            db.SaveChanges();
        }
    }

    public void placeorder(StudentRoom_Mapping hstl)
    {
        using (db = new CollegeERPDBEntities())
        {
            db.StudentRoom_Mapping.Add(hstl);
            db.SaveChanges();
            var candidate = db.Candidate_tbl.Where(x => x.ID == hstl.StudentID).FirstOrDefault();
            var hstlroom = db.HostelRoom_tbl.Where(x => x.ID == hstl.RomID).FirstOrDefault();
            AdminMails_tbl amail = new AdminMails_tbl { SenderID = hstl.StudentID, Message = candidate.Name + " has Requested for Room No." + hstlroom.RoomNo + " in " + hstlroom.Hostel_tbl.Name + " Hostel <br><br> <a href='../Hostel/RoomRequests.aspx' class='btn btn-primary'>View Room Requests</a>", Date = DateTime.Now.Date, Subject = "Room Request", Status = 0 };
            addadminmail(amail);  
        }
    }

    public void addroom(HostelRoom_tbl hstl)
    {
        using (db = new CollegeERPDBEntities())
        {
            db.HostelRoom_tbl.Add(hstl);
            db.SaveChanges();
        }
    }


    public List<Hostel_tbl> gethostellist(int pageStart, int pageEnd)
    {
        db = new CollegeERPDBEntities();
        List<Hostel_tbl> temp = new List<Hostel_tbl>();
        for (int i = pageStart; i <= pageEnd; i++)
        {
            if (db.Hostel_tbl.Where(x => x.ID == i).FirstOrDefault() != null)
            {
                var books = db.Hostel_tbl.Where(x => x.ID == i).FirstOrDefault();
                temp.Add(books);
            }
        }
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return temp;
    }


    public List<HostelWarden_tbl> getwardenlist(int page, int pageSize)
    {
        db = new CollegeERPDBEntities();
        List<HostelWarden_tbl> temp = db.HostelWarden_tbl.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return temp;
    }

    public List<HostelRoom_tbl> getroomslist(int page, int pageSize)
    {
        db = new CollegeERPDBEntities();
        List<HostelRoom_tbl> temp = db.HostelRoom_tbl.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return temp;
    }

    public List<StudentRoom_Mapping> getroomsRequest(int page, int pageSize)
    {
        db = new CollegeERPDBEntities();
        List<StudentRoom_Mapping> temp = db.StudentRoom_Mapping.Where(x=>x.Status!=2).OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return temp;
    }

    public List<Hostel_tbl> gethostellist()
    {
        db = new CollegeERPDBEntities();
        List<Hostel_tbl> temp = db.Hostel_tbl.ToList();
        // var course = db.Courses_tbl.Where(x => x.ID>=pageStart && x.ID<=pageEnd).FirstOrDefault();

        return temp;
    }

    public int getHostel_Count()
    {
        db = new CollegeERPDBEntities();
        var totalhostel = db.Hostel_tbl.Count();
        return totalhostel;
    }

    public int getwarden_Count()
    {
        db = new CollegeERPDBEntities();
        var warden = db.HostelWarden_tbl.Count();
        return warden;
    }

    public int getRoom_Count()
    {
        db = new CollegeERPDBEntities();
        var warden = db.HostelRoom_tbl.Count();
        return warden;
    }

    public int getRoomRequest_Count()
    {
        db = new CollegeERPDBEntities();
        var warden = db.StudentRoom_Mapping.Where(x=>x.Status!=2).Count();
        return warden;
    }

    public void updateHostel(Hostel_tbl hstl)
    {
        db = new CollegeERPDBEntities();

        db.Hostel_tbl.Attach(hstl);
        // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        db.Entry(hstl).State = EntityState.Modified;

        db.SaveChanges();

    }

    public void updateWarden(HostelWarden_tbl hstl)
    {
        db = new CollegeERPDBEntities();

        db.HostelWarden_tbl.Attach(hstl);
        // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        db.Entry(hstl).State = EntityState.Modified;

        db.SaveChanges();

    }

    public void updateRoom(HostelRoom_tbl hstl)
    {
        db = new CollegeERPDBEntities();

        db.HostelRoom_tbl.Attach(hstl);
        // var progrm = db.Program_tbl.Where(x => x.ID == id).FirstOrDefault();
        db.Entry(hstl).State = EntityState.Modified;

        db.SaveChanges();

    }


    public int getnextroomno(int hstlid)
    {
        db = new CollegeERPDBEntities();
        var rom= db.HostelRoom_tbl.Where(x => x.HostelID == hstlid).OrderByDescending(x => x.RoomNo).FirstOrDefault();
        if (rom == null)
        {
            return 1;
        }
        else
            return rom.RoomNo.Value + 1;
    }

    public StudentRoom_Mapping chechroomrequest(int stid)
    {
        db = new CollegeERPDBEntities();

        return db.StudentRoom_Mapping.Where(x => x.StudentID == stid && x.Status!=-1).FirstOrDefault();
    }

    public void reorderroom(StudentRoom_Mapping room)
    {
        db = new CollegeERPDBEntities();
        var stdroom = db.StudentRoom_Mapping.Where(x => x.RomID == room.RomID && x.StudentID == room.StudentID).FirstOrDefault();
        stdroom.Status = 0;
        db.SaveChanges();
        var candidate = db.Candidate_tbl.Where(x => x.ID == room.StudentID).FirstOrDefault();
        var hstlroom = db.HostelRoom_tbl.Where(x => x.ID == room.RomID).FirstOrDefault();
        AdminMails_tbl amail = new AdminMails_tbl { SenderID = room.StudentID, Message = candidate.Name + " has Requested for Room No." + hstlroom.RoomNo + " in " + hstlroom.Hostel_tbl.Name + " Hostel <br><br> <a href='../Hostel/RoomRequests.aspx' class='btn btn-primary'>View Room Requests</a>", Date = DateTime.Now.Date, Subject = " Room Request", Status = 0 };
        addadminmail(amail);
    }

    public void leaveroom(StudentRoom_Mapping room)
    {
        db = new CollegeERPDBEntities();
        var stdroom = db.StudentRoom_Mapping.Where(x => x.RomID == room.RomID && x.StudentID == room.StudentID).FirstOrDefault();
        stdroom.Status = 2;
        db.SaveChanges();
        var candidate = db.Candidate_tbl.Where(x => x.ID == room.StudentID).FirstOrDefault();
        var hstlroom = db.HostelRoom_tbl.Where(x => x.ID == room.RomID).FirstOrDefault();
        AdminMails_tbl amail = new AdminMails_tbl { SenderID = room.StudentID, Message = candidate.Name + " has Requested for Leaving Room No." + hstlroom.RoomNo + " in " + hstlroom.Hostel_tbl.Name + " Hostel <br><br> <a href='../Hostel/RoomLeaveRequests.aspx' class='btn btn-primary'>View Room Requests</a> ", Date = DateTime.Now.Date, Subject = "Leave Room Request", Status = 0 };
        addadminmail(amail);
    }

    public int getLevetRoomRequest_Count()
    {
        db = new CollegeERPDBEntities();
        return db.StudentRoom_Mapping.Where(x => x.Status == 2).Count();
    }

    public List<StudentRoom_Mapping> getleaveroomrequestlist(int page, int pageSize)
    {
        db = new CollegeERPDBEntities();
        List<StudentRoom_Mapping> temp = db.StudentRoom_Mapping.Where(x=>x.Status==2).OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
        return temp;
    }

    public void sendleaverequest(Leave leave)
    {
        db=new CollegeERPDBEntities();
        db.Leaves.Add(leave);
        db.SaveChanges();
    }

    public List<Leave> getleaverequests(int page,int pageSize,int status)
    {
        db = new CollegeERPDBEntities();
        if(status==5)
            return db.Leaves.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
        else
             return db.Leaves.Where(x => x.Status == status).OrderByDescending(x=>x.ID).Skip(page*pageSize).Take(pageSize).ToList();
    }

    public int getleaves_count(int status)
    {
        db = new CollegeERPDBEntities();
        if(status==5)
        {
            return db.Leaves.Count();

        }
        else
            return db.Leaves.Where(x => x.Status == status).Count();
 
    }

    public void updateleaverequest(int id, int status)
    {
        db = new CollegeERPDBEntities();
        var leave = db.Leaves.Where(x => x.ID == id).FirstOrDefault();
        leave.Status = status;
        db.SaveChanges();
    }

    public void requestlibrarymembership(LibraryMember member)
    {
        db = new CollegeERPDBEntities();
        db.LibraryMembers.Add(member);
        db.SaveChanges();
        var candidate = db.Candidate_tbl.Where(x => x.ID == member.UserID).FirstOrDefault();
     // var course = db.Courses_tbl.Where(x => x.ID == member.CourseID).FirstOrDefault();
      
        AdminMails_tbl mail = new AdminMails_tbl { Date = DateTime.Now.Date, Subject = "Library Membership Request", SenderID =member.UserID, Status = 0, Message = candidate.Name + " Requested Library Membership.  <br/><br> <a href='../Library/MemberRequest.aspx' class='btn btn-primary'>View Membership Requests</a>" };
        addadminmail(mail);

    }

    public LibraryMember getLirarymember(int stid)
    {
        db = new CollegeERPDBEntities();
        return db.LibraryMembers.Where(x => x.UserID == stid).FirstOrDefault();

    }

    public Employee_tbl getemployeinfo(string username, string password)
    {
        db = new CollegeERPDBEntities();
        return db.Employee_tbl.Where(x=>x.Username==username&& x.Password==password).FirstOrDefault();
    }

    public void updateuserinfo(int empid, string username, string password)
    {
        db = new CollegeERPDBEntities();
        var emp= db.Employee_tbl.Where(x=>x.ID==empid).FirstOrDefault();
        if (username!=""&&password!=""){
        emp.Username = username;
        emp.Password = password;
        }

        emp.IsFirstTime = 1;
        db.SaveChanges();
    }

    public void UpdateUserSemester(int uid)
    {
        db = new CollegeERPDBEntities();
        var stdnt = db.StudentInfo_tbl.Where(x => x.UserId == uid).FirstOrDefault();
        
        stdnt.Semester += 1;
        db.SaveChanges();
    }

    public int assignteachercourse(CourseTeacherAssignment_tbl assigncourse)
    {
        db = new CollegeERPDBEntities();

        var check = db.CourseTeacherAssignment_tbl.Where(x => x.TeacherID == assigncourse.TeacherID && x.CourseID == assigncourse.CourseID).FirstOrDefault();
        if (check != null)
            return 2;
        else{
        check = db.CourseTeacherAssignment_tbl.Where(x =>  x.CourseID == assigncourse.CourseID).FirstOrDefault();
        if(check!=null)
        return -1;
        }
        db.CourseTeacherAssignment_tbl.Add(assigncourse);
        db.SaveChanges();
        return 1;
    }

    public List<CourseTeacherAssignment_tbl> getassigncourses(int userid)
    {
        db = new CollegeERPDBEntities();
        return db.CourseTeacherAssignment_tbl.Where(x => x.TeacherID == userid).ToList();
    }

    public void updatecourseassignment(CourseTeacherAssignment_tbl ca)
    {
        db = new CollegeERPDBEntities();
        var crsasgmt = db.CourseTeacherAssignment_tbl.Where(x => x.CourseID == ca.CourseID).FirstOrDefault();
        if (crsasgmt == null)
        {
            assignteachercourse(ca);
            return;
        }
        crsasgmt.TeacherID = ca.TeacherID;
        db.SaveChanges();

    }

    public List<CourseTeacherAssignment_tbl> getteacherassignedcourses(int page,int pageSize,int teacherid)
    {
        db = new CollegeERPDBEntities();
       return db.CourseTeacherAssignment_tbl.Where(x => x.TeacherID == teacherid).OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
    }

    public int getteacherassignedcourses_count(int teacherid)
    {
        db = new CollegeERPDBEntities();
        return db.CourseTeacherAssignment_tbl.Where(x => x.TeacherID == teacherid).ToList().Count;
    }


    public List<Assignments_tbl> getcourseassignments(int crsid, int page, int pagesize)
    {

        db = new CollegeERPDBEntities();
        return db.Assignments_tbl.OrderByDescending(x => x.ID).Skip(page * pagesize).Take(pagesize).Where(x => x.CourseID == crsid).ToList();
    }


    public List<Reference_Books_tbl> getcoursebooks(int crsid)
    {

        db = new CollegeERPDBEntities();
        return db.Reference_Books_tbl.Where(x => x.CourseID == crsid).ToList();
    }
    public void addvideos(Video_Lecture_tbl vid)
    {
        db = new CollegeERPDBEntities();
        db.Video_Lecture_tbl.Add(vid);
        db.SaveChanges();
    }

    public List<Video_Lecture_tbl> getcoursevideos(int page, int pageSize, int crsid)
    {
        db = new CollegeERPDBEntities();
        return db.Video_Lecture_tbl.Where(x => x.CourseID == crsid).OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
    }

    public List<Quizz_tbl> getcoursquizzes(int page, int pageSize, int crsid)
    {
        db = new CollegeERPDBEntities();
        return db.Quizz_tbl.Where(x => x.CourseID == crsid).OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize).ToList();
    }

    public List<Student_Quizz_Mapping_tbl> getstudentquizzes(int qid, int stdid)
    {
        db = new CollegeERPDBEntities();
        return db.Student_Quizz_Mapping_tbl.Where(x => x.QuizzID == qid && x.StudentID == stdid).ToList();
    }

    public int getcoursevideos_count(int crsid)
    {
        db = new CollegeERPDBEntities();
        return db.Video_Lecture_tbl.Where(x => x.CourseID == crsid).Count();
    }

    public int getcoursequizzes_count(int crsid)
    {
        db = new CollegeERPDBEntities();
        return db.Quizz_tbl.Where(x => x.CourseID == crsid).Count();
    }

    public int getStudentquizzes_count(int stdid)
    {
        db = new CollegeERPDBEntities();
        return db.Student_Quizz_Mapping_tbl.Where(x => x.StudentID == stdid).Count();
    }

    public void submitassignment(SubmittedAssignments_tbl sasgmt)
    {
        db = new CollegeERPDBEntities();
        db.SubmittedAssignments_tbl.Add(sasgmt);
        db.SaveChanges();
    }

    public SubmittedAssignments_tbl getsubmittedassignment(int asgmtid, int stid)
    {

        db = new CollegeERPDBEntities();
        return db.SubmittedAssignments_tbl.Where(x => x.AssignmentID == asgmtid && x.StudentID == stid).FirstOrDefault();


    }

    public void addlectures(Lecture_Notes_tbl lecture)
    {
        db = new CollegeERPDBEntities();
        db.Lecture_Notes_tbl.Add(lecture);
        db.SaveChanges();
    }

    public void addbooks(Reference_Books_tbl rbs)
    {
        db = new CollegeERPDBEntities();
        db.Reference_Books_tbl.Add(rbs);
        db.SaveChanges();
    }

    public List<Lecture_Notes_tbl> getcourselectures(int crsid, int page, int pagesize)
    {
        db = new CollegeERPDBEntities();
        return db.Lecture_Notes_tbl.OrderByDescending(x => x.ID).Skip(page * pagesize).Take(pagesize).Where(x => x.CourseID == crsid).ToList();
    }
    public int getlectures_Count(int courseid)
    {
        db = new CollegeERPDBEntities();
        var atten = db.Lecture_Notes_tbl.Where(x => x.CourseID == courseid).Count();
        return atten;
    }

    public int getAssignment_Count(int crsid)
    {
        db = new CollegeERPDBEntities();
        var assign = db.Assignments_tbl.Where(x => x.CourseID == crsid).Count();
        return assign;
    }

    public int addquizzresult(Quizz_tbl qtbl)
    {
        db = new CollegeERPDBEntities();
        db.Quizz_tbl.Add(qtbl);
        db.SaveChanges();
        return qtbl.ID;
    }

    public void quizzmarksinsertion(Student_Quizz_Mapping_tbl sqm)
    {
        db = new CollegeERPDBEntities();
        db.Student_Quizz_Mapping_tbl.Add(sqm);
        db.SaveChanges();
    }

    public Assignments_tbl getasssignement(int aid)
    {
        db = new CollegeERPDBEntities();
        return db.Assignments_tbl.Where(x => x.ID == aid).FirstOrDefault();
    }

    public void updateassugnment(int id, string title, int marks, DateTime duedate, string filename)
    {
        db = new CollegeERPDBEntities();
        Assignments_tbl asggmt = db.Assignments_tbl.Where(x => x.ID == id).FirstOrDefault();
        asggmt.DueDate = duedate;
        asggmt.Assignment_Title = title;
        asggmt.marks = marks;
        if (filename != "")
        {
            asggmt.Assignment_Path = filename;
        }
        db.SaveChanges();
    }

    public void addassignmentresult(Assignment_Result_tbl assresult)
    {
        db = new CollegeERPDBEntities();
        db.Assignment_Result_tbl.Add(assresult);
        db.SaveChanges();
    }

    public List<Assignment_Result_tbl> getassignmentresult(int aid, int page, int pagesize)
    {
        db = new CollegeERPDBEntities();
        return db.Assignment_Result_tbl.Where(x => x.AssignmentID == aid).OrderBy(x => x.ID).Skip(page * pagesize).Take(pagesize).ToList();
    }
    public int assignmentresultcount(int aid)
    {
        db = new CollegeERPDBEntities();
        return db.Assignment_Result_tbl.Where(x => x.AssignmentID == aid).Count();

    }

    public List<Student_Quizz_Mapping_tbl> getQuizzeslistresult(int Qzid, int page, int pagesize)
    {
        db = new CollegeERPDBEntities();
        return db.Student_Quizz_Mapping_tbl.Where(x => x.QuizzID == Qzid).OrderBy(x => x.ID).Skip(page * pagesize).Take(pagesize).ToList();

    }
    public int Quizzesresultcount(int Qzid)
    {
        db = new CollegeERPDBEntities();
        return db.Student_Quizz_Mapping_tbl.Where(x => x.QuizzID == Qzid).Count();

    }

    public List<Assignment_Result_tbl> getstudentassignmentresult(int id, int stdid)
    {
        db = new CollegeERPDBEntities();
        return db.Assignment_Result_tbl.Where(x => x.AssignmentID == id && x.StudentiID == stdid).ToList();
    }

    public List<SubmittedAssignments_tbl> getsubmittedassignments(int aid, int p, int pageSize)
    {
        db = new CollegeERPDBEntities();
        return db.SubmittedAssignments_tbl.Where(x => x.AssignmentID == aid).ToList();
    }
    public int SubmittedAssignmentsCount(int aid)
    {
        db = new CollegeERPDBEntities();
        return db.SubmittedAssignments_tbl.Where(x => x.AssignmentID == aid).Count();

    }


    public List<Courses_tbl> getcoursesList(int id)
    {

        db = new CollegeERPDBEntities();
        List<Courses_tbl> course = db.Courses_tbl.Where(x => x.ID == id).ToList();

        return course;

    }

    public List<Results_tbl> getresultbyids(int courseid, int userid)
    {
        db = new CollegeERPDBEntities();
        var mno = db.AddmissionList_tbl.Where(x => x.UserID == userid).FirstOrDefault().MetricNo;
        return db.Results_tbl.Where(x => x.CourseID == courseid && x.MetricNo == mno).ToList();

    }

    public List<Attendance_tbl> getattendancebyids(int courseid, int userid, int page, int pagesize)
    {
        db = new CollegeERPDBEntities();
        return db.Attendance_tbl.Where(x => x.CourseID == courseid && x.StudentID == userid).OrderByDescending(x => x.ID).Skip(page * pagesize).Take(pagesize).ToList();
    }
    public int getAttendancebyid_Count(int courseid, int userid)
    {
        db = new CollegeERPDBEntities();
        var atten = db.Attendance_tbl.Where(x => x.CourseID == courseid && x.StudentID == userid).Count();
        return atten;
    }

    public void addassignment(Assignments_tbl asgmt)
    {
        db = new CollegeERPDBEntities();
        db.Assignments_tbl.Add(asgmt);
        db.SaveChanges();
    }

    public List<Enroll_Course> getcourselist(int userid)
    {
        db = new CollegeERPDBEntities();

        List<Enroll_Course> course = db.Enroll_Course.Where(x => x.Uid == userid).ToList();
        //.Courses_tbl.Course.ToList()
        return course;

    }


    public List<Batches_table> getactivebatchlist()
    {
        db = new CollegeERPDBEntities();
        return db.Batches_table.Where(x => x.Status == 0).ToList();
    }

    public void offercourse(OfferedCourses_tbl offer)
    {
        db = new CollegeERPDBEntities();
        db.OfferedCourses_tbl.Add(offer);
        db.SaveChanges();
    }

    public List<ProgrammeCourses_tbl> getprogramcourselist(int p)
    {
        db = new CollegeERPDBEntities();
       return  db.ProgrammeCourses_tbl.Where(x=>x.ProgramID==p).ToList();
    }

    public void addprogrammecourse(ProgrammeCourses_tbl prgcrs)
    {
        db = new CollegeERPDBEntities();
        db.ProgrammeCourses_tbl.Add(prgcrs);
        db.SaveChanges();
    }

    public object getprogramcours(int p, int id)
    {
          db = new CollegeERPDBEntities();
          return db.ProgrammeCourses_tbl.Where(x => x.ProgramID == p && x.CourseID == id).FirstOrDefault();
    }

    public void clearprogramcourses(int p)
    {
        db = new CollegeERPDBEntities();
       var offcors= db.ProgrammeCourses_tbl.Where(x => x.CourseID == p).ToList();
       foreach (var offcor in offcors)
       {
           db.ProgrammeCourses_tbl.Remove(offcor);
       }
       db.SaveChanges();
    }

    public List<OfferedCourses_tbl> getstudenoffercourses(int candidate)
    {
        db = new CollegeERPDBEntities();
        var student = db.AddmissionList_tbl.Where(x=>x.UserID==candidate).FirstOrDefault();

        return db.OfferedCourses_tbl.Where(x => x.BatchID == student.BatchID&&x.ProgrammeID==student.ProgrameID).ToList();
    }

    public int getadmininboxcount()
    {
        db = new CollegeERPDBEntities();
        return db.AdminMails_tbl.Where(x => x.Status == 0).Count();
    }

    public void acceptRequest(int reqid)
    {
        db = new CollegeERPDBEntities();
        var member= db.LibraryMembers.Where(x => x.ID == reqid).FirstOrDefault();
        member.Status = 1;
        member.JoinDate = DateTime.Now.Date;
        db.SaveChanges();
        Mails_tbl mail = new Mails_tbl { RecieverID =member.UserID, Date = DateTime.Now.Date, Message = "Your Liberary Membership Request has been approved", Status = 0, Subject = "Liberary Membership" };
        addmail(mail); 
    }

    public int getstudentinboxcount(int userid)
    {
        db = new CollegeERPDBEntities();
        return db.Mails_tbl.Where(x => x.RecieverID == userid && x.Status == 0 || x.Subject=="Registration" && x.Status==0).Count();
    }

    public AddmissionList_tbl getstudentinfoFromMetrcino(string p)
    {
        db=new CollegeERPDBEntities();
        return db.AddmissionList_tbl.Where(x => x.MetricNo == p).FirstOrDefault();
    }

    public void updateenrollment(int stid, int crsid,int status)
    {
        db = new CollegeERPDBEntities();
        var ec= db.Enroll_Course.Where(x=>x.CourseID==crsid&&x.Uid==stid).FirstOrDefault();
        ec.Status = status;
        db.SaveChanges();
    }

    public IEnumerable<IGrouping<int, Results_tbl>> getstudentAcademicRecord(string Metricno)
    {
        db = new CollegeERPDBEntities();
        return db.Results_tbl.Where(x=>x.MetricNo==Metricno&&x.ExamType=="Final").GroupBy(x=>x.Semester.Value);
    }
    public object checkquestionaireexist(int UserID)
    {
        db = new CollegeERPDBEntities();
        return db.UploadedQuestionaires.Where(x => x.SenderID == UserID && x.Status==0).FirstOrDefault();
    }
    public void AddQuestionare(UploadedQuestionaire obj)
    {
        db = new CollegeERPDBEntities();
        db.UploadedQuestionaires.Add(obj);
        db.SaveChanges();


    }
    public List<UploadedQuestionaire> getquestionairlist(int page, int pagesize)
    {
        db = new CollegeERPDBEntities();
        return db.UploadedQuestionaires.OrderByDescending(x => x.ID).Skip(page * pagesize).Take(pagesize).Where(x => x.Status == 0).ToList();
    }
    public int getquestionaire_Count()
    {
        db = new CollegeERPDBEntities();
        var tatalques = db.UploadedQuestionaires.Where(x=>x.Status==0).Count();
        return tatalques;
    }
    public void UpdateSuggestionStatus(int UserID)
    {
        db = new CollegeERPDBEntities();
        UploadedQuestionaire usr = db.UploadedQuestionaires.Where(x => x.SenderID == UserID && x.Status == 0).FirstOrDefault();
        
            usr.Status = 1;
        db.SaveChanges();
    }
}