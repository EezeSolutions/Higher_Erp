using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

public partial class LMS_Default : System.Web.UI.Page
{
    int page = 1;
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack) { 
        if (Request.QueryString["Asid"] != null)
        {
            int aid = int.Parse(Request.QueryString["Asid"]);
            DBFunctions db = new DBFunctions();



            int pageStart = 1;
            int pageEnd = 10;
            if (Request.QueryString.ToString().Contains("page"))
            {
                page = Convert.ToInt32(Request.QueryString["page"].ToString());
                pageEnd = pageSize * page;
                pageStart = (pageEnd - pageSize) + 1;
            }

            List<SubmittedAssignments_tbl> AssList = db.getsubmittedassignments(aid, page - 1, pageSize);
            // ds = db.getwardenlist(page-1, pageSize);


            literalStart.Text = pageStart.ToString();
            literalEnd.Text = pageEnd.ToString();

            int tmpPageEnd = 0;
            tmpPageEnd = pageEnd;

            pageEnd = db.SubmittedAssignmentsCount(aid);



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
            tmpUrl = "ViewSubmittedAssignment.aspx?" + Request.QueryString.ToString();
            if (tmpUrl.Contains("&page"))
            {
                tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("&page"));
            }

            //*************************


            //*********

            StringBuilder listingString = new StringBuilder();

            if (AssList != null)
            {

                if (AssList != null)
                {
                    foreach (var subassgn in AssList)
                    {

                        submittedAsstbl.Text += "<tr><td>" + subassgn.Assignments_tbl.Courses_tbl.Course + "</td><td>" + subassgn.Assignments_tbl.Assignment_Title + "</td><td>" + subassgn.Assignments_tbl.marks + "</td><td>" + subassgn.Candidate_tbl.Name + "</td><td>";
                        submittedAsstbl.Text +="<a href='#'>"  + subassgn.AssginmentFile + "</a></td>";

                    }
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
                //**********************


                //**********************

                for (int i = 1; i <= totalPages; i++)
                {
                    string newPageString = string.Empty;


                    if (i == 1)
                    {

                        newPageString = "<li><a aria-label=\"First\"  href=\"" + urlMain + "\" >&lt;&lt;</a></li>";
                        if (page == i)
                        {
                            newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "\" >" + i + "</a></li>";
                        }
                        else
                        {
                            newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "\" >" + i + "</a></li>";
                        }

                    }
                    else if (i == totalPages)
                    {
                        if (page == i)
                        {
                            newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "\" >" + i + "</a></li>";
                        }
                        else
                        {
                            newPageString += "<li><a  href=\"" + urlMain + "&page=" + i + "\" >" + i + "</a></li>";
                        }
                        newPageString += "<li><a aria-label=\"Last\" href=\"" + urlMain + "&page=" + totalPages + "\" >&gt;&gt;</a></li>";
                    }
                    else
                    {
                        if (page == i)
                        {
                            newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href=\"" + urlMain + "&page=" + i + "\" >" + i + "</a></li>";
                        }
                        else
                        {
                            newPageString += "<li><a href=\"" + urlMain + "&page=" + i + "\" >" + i + "</a></li>";
                        }
                    }
                    counterPage++;
                    paging.Append(newPageString);
                }

                AssignmentPaging.Text = paging.ToString();
            }

        }
            }
    }
    protected void Downloadzip_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int aid = int.Parse(Request.QueryString["Asid"]);
        List<SubmittedAssignments_tbl> AssList = db.getsubmittedassignments(aid, 0, db.SubmittedAssignmentsCount(aid));
     


      //  string sPath = Server.MapPath("~") + "DownloadFolder";

        string sPath = Server.MapPath("~/LMS/SubmittedAssignments/") + "";
        string zipfile=DateTime.Now.Ticks +"_Assignment.zip";
        string zipFullPath = Server.MapPath("~/LMS/DownloadedAssingments/") +zipfile;

        ZipOutputStream zipOut = new ZipOutputStream(File.Create(zipFullPath));

        foreach (var asg in AssList)
        {
            string fName = sPath + asg.AssginmentFile;
            FileInfo fi = new FileInfo(fName);

            ZipEntry entry = new ZipEntry(fi.Name);

            FileStream sReader = File.OpenRead(fName);

            byte[] buff = new byte[Convert.ToInt32(sReader.Length)];

            sReader.Read(buff, 0, (int)sReader.Length);

            entry.DateTime = fi.LastWriteTime;

            entry.Size = sReader.Length;

            sReader.Close();

            zipOut.PutNextEntry(entry);

            zipOut.Write(buff, 0, buff.Length);

        }

        zipOut.Finish();

        zipOut.Close();
   
         Response.Redirect("Download.ashx?file=" + zipfile + "&location=DownloadedAssingments", false);
    }
}