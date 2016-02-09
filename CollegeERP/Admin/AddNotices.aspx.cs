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
              DBFunctions db = new DBFunctions();

              int pageStart = 1;
              int pageEnd = 10;
              if (Request.QueryString.ToString().Contains("page"))
              {
                  page = Convert.ToInt32(Request.QueryString["page"].ToString());
                  pageEnd = pageSize * page;
                  pageStart = (pageEnd - pageSize) + 1;
              }


              List<Notices_tbl> ds = new List<Notices_tbl>();
              ds = db.getNoticelist(pageStart, pageEnd);


              literalStart.Text = pageStart.ToString();
              literalEnd.Text = pageEnd.ToString();

              int tmpPageEnd = 0;
              tmpPageEnd = pageEnd;

              pageEnd = db.getNotices_Count();



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
                  loadNotices(ds);
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
                  // CourseList.DataSource = db.getcourselist();
                  NoticTypeList.Items.Add("Test");
                  NoticTypeList.DataTextField = "Course";
                  NoticTypeList.DataValueField = "ID";
                  NoticTypeList.DataBind();
              }
          }
          else
          {
              Response.Redirect("Login.aspx?Redirecturl=" + pagename);
          }
       
    }

private void loadNotices(List<Notices_tbl> ds)
{
 	List<Notices_tbl> notices = ds;
        foreach (Notices_tbl crs in notices)
        {
            if (crs != null)
            {
                programstbl.Text += "<tr><td>" + crs.NoticeType + "</td><td>" + crs.Date.ToShortDateString() + "</td><td>";
                //if (crs.Status == 0)
                //{
                //    programstbl.Text += "<a href='#0' class='btn btn-danger btn-action Disable' data-id=" + crs.ID + ">Disable</a> ";
                //}

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
    
    protected void NoticeBtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        Notices_tbl nt = new Notices_tbl { Notice = NoticeMsg.Text, NoticeType = NoticTypeList.SelectedItem.ToString() };
        db.addNotice(nt);
        Response.Redirect("AddNotices.aspx");
    }
}