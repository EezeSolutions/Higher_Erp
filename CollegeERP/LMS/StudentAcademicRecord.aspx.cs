
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LMS_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                int uid=int.Parse(Session["userid"].ToString());
                double credithours=0;
                double totalcredithours = 0;
                double pints = 0;
                double totalpints = 0;
                double cgpa = 0;
                double gpa = 0;
                DBFunctions db = new DBFunctions();
                string Metricno= Session["Metricno"].ToString();
                var record= db.getstudentAcademicRecord(Metricno);

                foreach (var rec in record)
                {
                    
                    Recordlbl.Text += "<h1 style='padding:5px;font-weight:bold'>Semester "+rec.FirstOrDefault().Semester+"</h1><br /><br />";
                    Recordlbl.Text += "<table class='table table-responsive'>";
                    Recordlbl.Text += "<tr class='blue-background' align='center'><th>Course</th><th>Total Marks</th><th>Obtained Marks</th><th>Crdit Hour</th><th> Grade</th><th>Points</th><th>Remarks</th></tr>";
                       
                    foreach (var r in rec)
                    {
                        pints += r.Courses_tbl.Credit_Hours.Value * r.Grades_tbl.Gradepoints.Value;
                        totalpints += r.Courses_tbl.Credit_Hours.Value * r.Grades_tbl.Gradepoints.Value;
                        credithours += r.Courses_tbl.Credit_Hours.Value;
                        totalcredithours += r.Courses_tbl.Credit_Hours.Value;
                        Recordlbl.Text += "<tr><td>" + r.Courses_tbl.Course + "</td><td>" + r.Courses_tbl.Marks + "</td><td>" + r.ObtainedMarks + "</td><td>" + r.Courses_tbl.Credit_Hours + "</td><td>" + r.Grades_tbl.Grade + "</td><td>" + r.Grades_tbl.Gradepoints + "</td>";
                        if (r.GradeID == 9)
                            Recordlbl.Text += "<td style='color:red'>Reapear*</td></tr>";
                        else
                            Recordlbl.Text += "<td style='color:Green'>Pass</td></tr>";

                    }
                    gpa = pints / credithours;
                    cgpa = totalpints / totalcredithours;
                    pints = 0;
                    credithours = 0;
                    Recordlbl.Text += "</table><p class='col-lg-offset-9 col-lg-3' style='font-weight:bold;font-size:12px'>GPA: " + gpa + " | CGPA:"+cgpa+"</p><br><hr><br>";
                }
             
            }
            else
            {
                Response.Redirect("../Login.aspx?Redirecturl=LMS/" + pagename);
            }
        }
      
    }
    protected void Print_btn_Click(object sender, EventArgs e)
    {
        string html = System.IO.File.ReadAllText(Server.MapPath("StudentRecord.html"));
        DBFunctions db = new DBFunctions();
        string Metricno = Session["Metricno"].ToString();
        var record = db.getstudentAcademicRecord(Metricno);
        string studentrecordhtml = "";
        int uid = int.Parse(Session["userid"].ToString());
        double credithours = 0;
        double totalcredithours = 0;
        double pints = 0;
        double totalpints = 0;
        double cgpa = 0;
        double gpa = 0;
        var studentinf = db.getstdentinfo(uid);
        foreach (var rec in record)
        {

            studentrecordhtml += "<h4 style='padding:5px;font-weight:bold;text-align:left'>Semester " + rec.FirstOrDefault().Semester + "</h4><br /><br />";
          studentrecordhtml +="<table align='center' cellpadding='0' style='border:none; padding:3px;' cellspacing='0' border='1' width='100%' class='table table-responsive'>";
           studentrecordhtml +="<tr bgcolor='#293a4a' style='color: FFF;border:none class='blue-background' align='center'><th>Course</th><th>Total Marks</th><th>Obtained Marks</th><th>Crdit Hour</th><th> Grade</th><th>Points</th><th>Remarks</th></tr>";

            foreach (var r in rec)
            {
                pints += r.Courses_tbl.Credit_Hours.Value * r.Grades_tbl.Gradepoints.Value;
                totalpints += r.Courses_tbl.Credit_Hours.Value * r.Grades_tbl.Gradepoints.Value;
                credithours += r.Courses_tbl.Credit_Hours.Value;
                totalcredithours += r.Courses_tbl.Credit_Hours.Value;
                studentrecordhtml += "<tr><td>" + r.Courses_tbl.Course + "</td><td>" + r.Courses_tbl.Marks + "</td><td>" + r.ObtainedMarks + "</td><td>" + r.Courses_tbl.Credit_Hours + "</td><td>" + r.Grades_tbl.Grade + "</td><td>" + r.Grades_tbl.Gradepoints + "</td>";
                if (r.GradeID == 9)
                    studentrecordhtml += "<td style='color:red'>Reapear*</td></tr>";
                else
                    studentrecordhtml += "<td style='color:Green'>Pass</td></tr>";

            }
            gpa = pints / credithours;
            cgpa = totalpints / totalcredithours;
            pints = 0;
            credithours = 0;
            studentrecordhtml += "</table><p class='col-lg-offset-9 col-lg-3' style='font-weight:bold;font-size:9px;text-align:right'>GPA: " + gpa + " | CGPA:" + cgpa + "</p><br><br>";
        }

    
        Byte[] bytes;
        html = html.Replace("{CollegeName}","College");

        html = html.Replace("{Programme}", studentinf.Program_tbl.ProgramName);
        html = html.Replace("{Name}", studentinf.Candidate_tbl.Name);
        html = html.Replace("{MetricNo}", Metricno);
        html = html.Replace("{Batch}", studentinf.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().Batches_table.BatchYear.ToString());
       
        html = html.Replace("{Record}", studentrecordhtml);
        using (var ms = new MemoryStream())
        {
            var doc = new Document();
            doc = new Document(PageSize.A4, 30, 30, 30, 30);

            var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
            doc.Open();
            doc.NewPage();

            var example_html = html;
            using (var htmlWorker = new HTMLWorker(doc))
            {
                using (var sr = new StringReader(example_html))
                {
                    htmlWorker.Parse(sr);
                }
            }
            doc.Close();
            bytes = ms.ToArray();
        }
        long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;



        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + milliseconds + "MeritList.pdf");
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.BinaryWrite(bytes);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Close();
    }
}