using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          string pagename = Path.GetFileName(Request.PhysicalPath);

          if (Session["userid"] != null)
          {
              int uid = int.Parse(Session["userid"].ToString());
              DBFunctions db = new DBFunctions();
              Candidate_tbl candidate = db.getuserinfo(uid);
              namelbl.Text = candidate.Name;
              imglbl.Text = "<img src='images/" + candidate.Image + "' class='img-circle img-responsive'>";
                  programmelbl.Text = candidate.Program_tbl.ProgramName;
                  deptlbl.Text = candidate.Program_tbl.Department_tbl.Department;
              if (candidate.Applications_tbl.FirstOrDefault() != null)
              {
                  semesterlbl.Text = candidate.StudentInfo_tbl.FirstOrDefault().Semester.ToString();
                  metriclbl.Text = candidate.AddmissionList_tbl.FirstOrDefault().MetricNo;
              }
              else
              {

                  semesterlbl.Text = "Will be Assign After Admission";
                  metriclbl.Text = "Will be Assign After Admission";
                 
              }
                  Doblbl.Text = candidate.DateofBirth;
              Genderlbl.Text = candidate.Gender;
              Addresslbl.Text = candidate.HomeAdress;
              Emaillbl.Text = candidate.Email;
              phonenumberlbl.Text = candidate.Phone;
              statelbl.Text = candidate.States_tbl.State;
              arealbl.Text = candidate.Areas_tbl.Area;
              


          }
          else
          {
              Response.Redirect("Login.aspx?Redirecturl=" + pagename);
          }

    }
}