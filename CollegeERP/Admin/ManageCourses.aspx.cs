using System;
using System.Collections.Generic;
using System.Data;
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

                DataSet dss = new DataSet();
                List<Courses_tbl> ds = new List<Courses_tbl>();
                ds = db.getcourselist(page, pageSize);


                literalStart.Text = pageStart.ToString();
                literalEnd.Text = pageEnd.ToString();

                int tmpPageEnd = 0;
                tmpPageEnd = pageEnd;

                pageEnd = db.getCourse_Count();



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
                tmpUrl = "ManageCourses.aspx?" + Request.QueryString.ToString();
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



                CheckBoxPrgramlist.DataSource = db.getprogramslist();
                CheckBoxPrgramlist.DataTextField = "ProgramName";
                CheckBoxPrgramlist.DataValueField = "ID";
                CheckBoxPrgramlist.DataBind();
            }
            if (IsPostBack)
            {
                nameDiv.Attributes.Add("class","show");
            }

        }
        else
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);
        }
    }
    //public void setteachers()
    //{
    //    DBFunctions db = new DBFunctions();
    //    var progrm = db.getprogram(int.Parse(DropDownDept.SelectedValue));
    //    DropDownTeachers.DataSource = db.getallemployee(0, db.getemployee_count(progrm.DeptID.Value), progrm.DeptID.Value);
    //    DropDownTeachers.DataTextField = "Name";
    //    DropDownTeachers.DataValueField = "ID";
    //    DropDownTeachers.DataBind();
    //}
    private void loadCourse(List<Courses_tbl> ds)
    {
        List<Courses_tbl> courses = ds;
        
        foreach (Courses_tbl crs in courses)
        {
            if (crs != null)
            {
                programstbl.Text += "<tr><td>" + crs.Course + "</td><td>" + crs.CourseCode + "</td><td>" + crs.Credit_Hours + "</td><td>" + crs.Fee + "</td><td>  " + crs.Marks + " </td><td>";

               var progrms= crs.ProgrammeCourses_tbl;
               int count = progrms.Count;
               int counter = 1;
                foreach (var prgm in progrms)
                {
                    programstbl.Text += prgm.Program_tbl.ProgramName ;
                    if(counter<count)
                    {
                        programstbl.Text += ",";
                    }
                    counter++;
                }
                programstbl.Text += "</td>";


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
    protected void btnaddprogramme_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
       var checkcourse= db.getcourselist().Where(x => x.CourseCode == CourseCode.Text).FirstOrDefault();
       if (checkcourse == null)
       {
           //Program_tbl prgram = new Program_tbl { ProgramName = ProgrammeNametxt.Text, SecondChoice = int.Parse(dropdownSecondChoise.SelectedValue), HasCampus = int.Parse(dropdownCampus.SelectedValue), ApplicationFee = txtApplicationFee.Text, FormNumber = txtFormCh.Text, ProgrameType = dropdownPrograms.SelectedValue, HasJambData = int.Parse(dropdownJamb.SelectedValue), HasBioDataSection = int.Parse(dropdownBioData.SelectedValue), HasPreviousRecord = int.Parse(dropdownPreviousRecord.SelectedValue), HasCBTSchedule = int.Parse(dropdownCbtSchedule.SelectedValue), HasOlevelResult = int.Parse(dropdownOlevel.SelectedValue), Enable = true, DeptID = int.Parse(DropDownDept.SelectedValue), CutoffPoints = Cuttofpointstxt.Text, DateCreated = DateTime.Now.Date, AcceptenceFee = txtAcceptenceFee.Text, FormCh = txtFormCh.Text };
           Courses_tbl course = new Courses_tbl { Course = coursename.Text, Fee = Feetxt.Text, Marks = Markstxt.Text, Credit_Hours = int.Parse(CreditHours.Text), CourseCode = CourseCode.Text };
           int cid = db.addcourse(course);
           foreach (ListItem chck in CheckBoxPrgramlist.Items)
           {
               if (chck.Selected)
               {
                   ProgrammeCourses_tbl prgcrs = new ProgrammeCourses_tbl { ProgramID = int.Parse(chck.Value), CourseID = cid };
                   db.addprogrammecourse(prgcrs);
               }
           }
           messagae.Text = "Course Successfully Added";
           messagae.Visible = true;
          // Response.Redirect("ManageCourses.aspx");
       }
       else
       {
           messagae.Text = "Course Code Already Exist";
           messagae.Visible = true;
       }
    }

    protected void DropDownDept_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }
}