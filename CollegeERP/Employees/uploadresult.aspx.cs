using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string pagename = Path.GetFileName(Request.PhysicalPath);
         if (Session["userid"] != null)
         {
             DBFunctions db = new DBFunctions();
             if (!IsPostBack)
             {
                 DropDownprogram.DataSource = db.getprogramslist();
                 DropDownprogram.Items.Add("--Select Programme--");
                 DropDownprogram.DataTextField = "ProgramName";
                 DropDownprogram.DataValueField = "ID";
                 DropDownprogram.DataBind();
             }
         }

         else
         {
             Response.Redirect("Login.aspx?Redirecturl=" + pagename);
         }
    }


    protected void DropDownprogram_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownCourse.Items.Clear();
        DBFunctions db = new DBFunctions();
        var programcrs=db.getprogramcourselist(int.Parse(DropDownprogram.SelectedValue));
        foreach (var crs in programcrs)
        {
            DropDownCourse.Items.Add(new ListItem(crs.Courses_tbl.Course,crs.CourseID.ToString()));
        }


    }
    protected void uplaodfile_Click(object sender, EventArgs e)
    {
        if(Resultfile.FileName==null)
        {

        }
        else
        {
            string filename = Path.GetFileName(Resultfile.PostedFile.FileName);
            string Extension = Path.GetExtension(Resultfile.PostedFile.FileName);

            long milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
            string orgPath = string.Empty;
            orgPath = Server.MapPath("~/Admin/Temp_UploadedFiles/" + filename);
            Resultfile.SaveAs(orgPath);

            System.Data.DataTable dt = Import_To_Grid(orgPath, Extension, "Yes");
            DBFunctions db = new DBFunctions();
            int grade = 1008; //None Grade For Mid Result
            foreach (System.Data.DataRow row in dt.Rows)
            {
                if (row[4].ToString().ToLower() != "mid")
                {
                    if (int.Parse(row[2].ToString()) >= 90)
                        grade = 1;//A Grade
                    else if (int.Parse(row[2].ToString()) >= 85 && int.Parse(row[2].ToString()) < 90)
                        grade = 2;//A- Grade
                    else if (int.Parse(row[2].ToString()) >= 80 && int.Parse(row[2].ToString()) < 85)
                        grade = 3;//B+ Grade
                    else if (int.Parse(row[2].ToString()) >= 70 && int.Parse(row[2].ToString()) < 80)
                        grade = 4;//B Grade
                    else if (int.Parse(row[2].ToString()) >= 60 && int.Parse(row[2].ToString()) < 70)
                        grade = 5;//B- Grade
                    else if (int.Parse(row[2].ToString()) >= 55 && int.Parse(row[2].ToString()) < 60)
                        grade = 6;//C+ Grade
                    else if (int.Parse(row[2].ToString()) >= 50 && int.Parse(row[2].ToString()) < 55)
                        grade = 7;//C Grade
                    else if (int.Parse(row[2].ToString()) >= 45 && int.Parse(row[2].ToString()) < 50)
                        grade = 8;
                    else if (int.Parse(row[2].ToString()) < 45)
                        grade = 9; //F Grade
                }
                Results_tbl result = new Results_tbl { CourseID = int.Parse(DropDownCourse.SelectedValue), MetricNo = row[0].ToString(), TotalMarks = int.Parse(row[1].ToString()), ObtainedMarks = int.Parse(row[2].ToString()), Year = row[3].ToString(), ExamType = row[4].ToString(), Semester = int.Parse(row[5].ToString()),GradeID=grade};
                //string marks = row[0].ToString();

                    db.addresults(result);
                    LabelUpload.Text = "Result Uploaded.";
                    LabelUpload.Visible = true;
                   AddmissionList_tbl student= db.getstudentinfoFromMetrcino(result.MetricNo);
                    
                if(grade!=9)
                {
                    db.updateenrollment(student.UserID.Value, result.CourseID.Value,2); //Pass
                }
                else
                {
                    db.updateenrollment(student.UserID.Value, result.CourseID.Value, 3); //Fail

                }
               
            }
            

        }
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

            conStr = String.Format(conStr, orgPath, p).Trim();

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
}