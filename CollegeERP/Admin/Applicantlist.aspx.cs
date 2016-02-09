using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    int pagesize = 15;
    int page = 1;
    int pagecount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagname = Path.GetFileName(Request.PhysicalPath);
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["admin"] != null)
         {
             if (!IsPostBack)
             {
                 DBFunctions db = new DBFunctions();
                 Dropdownprogramme.Items.Add(new System.Web.UI.WebControls.ListItem("All Programmes", "All"));
                 Dropdownprogramme.DataSource = db.getprogramslist();
                 Dropdownprogramme.DataTextField = "ProgramName";
                 Dropdownprogramme.DataValueField = "ID";

                 Dropdownprogramme.DataBind();


                 if (Request.QueryString["page"] != null)
                 {
                     page = int.Parse(Request.QueryString["page"]);
                 }
                 var applicants = db.getapplicantlist(page - 1, pagesize);
                 loadcandidates(applicants);

             }
         }
         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }

        

    }
    protected void GenerateList_Click(object sender, EventArgs e)
    {
        
        string pagname = Path.GetFileName(Request.PhysicalPath);
        int pagesize = 15;
        int page = 1;
        int pagecount = 0;
        DBFunctions db = new DBFunctions();
        if (Request.QueryString["page"] != null)
        {
            page = int.Parse(Request.QueryString["page"]);
        }
        List<Candidate_tbl> applicants;
        if (Dropdownprogramme.SelectedValue != "All")
        {
            Printmeritlist.Visible = true;
            Applicantlist.Text = "";
            Paging.Text = "";
            applicants = db.generatemeritlist(int.Parse(Dropdownprogramme.SelectedValue));
        }
        else
        {
            ErrorMessagelbl.Text="Please Select A Programe First..!!";
            return;
        }
       // applicants = applicants.OrderBy(x=>x.CuttoffPoints).Skip(page*pagesize).Take(pagesize).ToList();
        pagecount = (db.getapplicant_count() + pagesize - 1) / pagesize;
        foreach (var app in applicants)
        {
            //<tr class="blue-background"><th>Name</th><th>Address</th><th>Cut Off Points</th><th>Programme</th><th>Gender</th><th>Email</th><th>Phone</th><th>Status</th><th>Action</th></tr>

            Applicantlist.Text += "<tr><td>" + app.Name + "</td><td>" + app.HomeAdress + "," + app.Areas_tbl.Area + "," + app.States_tbl.State + "</td><td>" + app.CuttoffPoints + "</td><td>" + app.Program_tbl.ProgramName + "</td><td>" + app.Gender + "</td><td>" + app.Email + "</td><td>" + app.Phone + "</td><td></td></tr>";

        }
        //if (pagecount > 1)
        //{
        //    for (int i = 1; i <= pagecount; i++)
        //    {
        //        if (page != i)
        //            Paging.Text += "<li class=''><a style='background: #f0f0f0;' href='" + pagname + "?page=" + i + "'>" + i + "</a></li>";
        //        else
        //            Paging.Text += "<li><a>" + i + "</a></li>";
        //    }
        //}
    }
    protected void Printmeritlist_Click(object sender, EventArgs e)
    {
        string html = System.IO.File.ReadAllText(Server.MapPath("MeritList.html"));
       DBFunctions db = new DBFunctions();
       string candidtes = "";
       var applicants = db.generatemeritlist(int.Parse(Dropdownprogramme.SelectedValue));
       CollegeERPDBEntities db1 = new CollegeERPDBEntities();
       var result1 = db1.Candidate_tbl.Join(db1.Batches_table,
                     c => c.ID,
                     a => a.ID,
                     (c, a) => new { a.ID }).ToList();
       
       foreach (var app in applicants)
       {
           //<tr class="blue-background"><th>Name</th><th>Address</th><th>Cut Off Points</th><th>Programme</th><th>Gender</th><th>Email</th><th>Phone</th><th>Status</th><th>Action</th></tr>
           int Year = Convert.ToInt16(app.AdmissionYear);

           candidtes += "<tr><td>" + app.Name + "</td><td>" + app.CuttoffPoints + "</td><td>" + app.Gender + "</td><td>" + app.Email + "</td><td>" + app.Phone + "</td></tr>";

       }
        
       db.addadmssion(applicants);
       Byte[] bytes;

       html = html.Replace("{Programme}", applicants.FirstOrDefault().Program_tbl.ProgramName);
       html = html.Replace("{year}", DateTime.Now.Year.ToString());
     html=  html.Replace("{CandidateList}", candidtes);
       using (var ms = new MemoryStream())
       {
           var doc = new Document();
           doc = new Document(PageSize.A4, 30, 30, 30, 30);

           var writer = PdfWriter.GetInstance(doc, ms);
           doc.Open();
           doc.NewPage();

           var example_html = html;
           using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
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
       HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + milliseconds +"MeritList.pdf");
       HttpContext.Current.Response.Buffer = true;
       HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
       HttpContext.Current.Response.BinaryWrite(bytes);
       HttpContext.Current.Response.End();
       HttpContext.Current.Response.Close();
    }

    public void loadcandidates(List<Candidate_tbl> applicants)
    {
        string pagname = Path.GetFileName(Request.PhysicalPath);
        ErrorMessagelbl.Text = "";
        DBFunctions db = new DBFunctions();
        pagecount = (db.getapplicant_count() + pagesize - 1) / pagesize;
        foreach (var app in applicants)
        {
            //<tr class="blue-background"><th>Name</th><th>Address</th><th>Cut Off Points</th><th>Programme</th><th>Gender</th><th>Email</th><th>Phone</th><th>Status</th><th>Action</th></tr>

            Applicantlist.Text += "<tr><td>" + app.Name + "</td><td>" + app.HomeAdress + "," + app.Areas_tbl.Area + "," + app.States_tbl.State + "</td><td>" + app.CuttoffPoints + "</td><td>" + app.Program_tbl.ProgramName + "</td><td>" + app.Gender + "</td><td>" + app.Email + "</td><td>" + app.Phone + "</td><td></td></tr>";

        }
        if (pagecount > 1)
        {
            for (int i = 1; i <= pagecount; i++)
            {
                if (page != i)
                    Paging.Text += "<li class=''><a style='background: #f0f0f0;' href='" + pagname + "?page=" + i + "?meritlist=1'>" + i + "</a></li>";
                else
                    Paging.Text += "<li><a>" + i + "</a></li>";
            }
        }
    }
    protected void Dropdownprogramme_SelectedIndexChanged(object sender, EventArgs e)
    {
        Applicantlist.Text = "";
        DBFunctions db = new DBFunctions();
        if (Dropdownprogramme.SelectedValue != "All")
        {
            var applicants = db.getcandidatesbyprogram(int.Parse(Dropdownprogramme.SelectedValue));
            loadcandidates(applicants);
        }
        else
        {
            var applicants = db.getapplicantlist(page - 1, pagesize);
            loadcandidates(applicants);
        }
    }
}