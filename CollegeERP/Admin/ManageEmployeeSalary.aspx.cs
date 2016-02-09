using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    int page = 1;
    int pageSize = 10;
    int totalRecords = 0;
    int totalPages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string pagename = Path.GetFileName(Request.PhysicalPath);
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx?Redirecturl=" + pagename);

        }
        if (!IsPostBack)
        {
            loademployeespays();
            setdepartment();
        }
    }
    protected void Addbtn_Click(object sender, EventArgs e)
    {

    }

   public void loademployeespays(){

       int pageStart = 1;
       int pageEnd = 10;
       if (Request.QueryString.ToString().Contains("page"))
       {
           page = Convert.ToInt32(Request.QueryString["page"].ToString());
           pageEnd = pageSize * page;
           pageStart = (pageEnd - pageSize) + 1;
       }
       literalStart.Text = pageStart.ToString();
       literalEnd.Text = pageEnd.ToString();
       DBFunctions db = new DBFunctions();
       List<EmployeePay_tbl> employees = new List<EmployeePay_tbl>();
       if (Request.QueryString["dept"] == null || Request.QueryString["dept"] == "All")
       {

           employees = db.getallemployee_pay(page - 1, pageSize,0);
           pageEnd = db.getemployeePay_count(0);
       }
       else
       {

           int deptid = int.Parse(Request.QueryString["dept"]);
           employees = db.getallemployee_pay(page - 1, pageSize,deptid);
           pageEnd = db.getemployeePay_count(deptid);
           DropDowndepartment.SelectedValue = deptid.ToString();

       }
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
       tmpUrl = "ManageEmployees.aspx?" + Request.QueryString.ToString();
       if (tmpUrl.Contains("?page"))
       {
           tmpUrl = tmpUrl.Remove(tmpUrl.IndexOf("?page"));
       }

       StringBuilder listingString = new StringBuilder();

       renderemployees(employees);


       setpaging(pageEnd);
           
    }

   public void renderemployees(List<EmployeePay_tbl> employees)
   {
       Employeetbl.Text = "";
       foreach (var emp in employees)
       {
           Employeetbl.Text += "<tr><td>" + emp.Employee_tbl.Name + "</td><td>" + emp.Employee_tbl.Department_tbl.Department + "</td><td>" + emp.BasicSalary + "</td><td>" + emp.MedicalAllownce + "</td><td>" + emp.TransportAllownce + "</td><td>" + emp.HouseRent + "</td><td>" + emp.overtime + "</td><td> <a href='Salaryinfo.aspx?empid=" + emp.EmployeeID + "' class='btn btn-primary' style='padding:5px;font-size:9px'>Update Salary</a></td></tr>";
       }
   }

   private void setpaging(int pageEnd)
   {
       literalPaging.Text = "";
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
                       newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href='" + urlMain + "?page=" + i + " &dept=" + DropDowndepartment.SelectedValue + "'>" + i + "</a></li>";
                   }
                   else
                   {
                       newPageString += "<li><a href='" + urlMain + "?page=" + i + "&dept=" + DropDowndepartment.SelectedValue + "'>" + i + "</a></li>";
                   }

               }
               else if (i == totalPages)
               {
                   if (page == i)
                   {
                       newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href='" + urlMain + "?page=" + i + " &dept=" + DropDowndepartment.SelectedValue + "'>" + i + "</a></li>";
                   }
                   else
                   {
                       newPageString += "<li><a  href='" + urlMain + "?page=" + i + "&dept=" + DropDowndepartment.SelectedValue + "' >" + i + "</a></li>";
                   }
                   newPageString += "<li><a aria-label=\"Last\" href='" + urlMain + "?page=" + totalPages + "&dept=" + DropDowndepartment.SelectedValue + "' >&gt;&gt;</a></li>";
               }
               else
               {
                   if (page == i)
                   {
                       newPageString += "<li><a style=\"color:#000000;background: #f0f0f0;\" href='" + urlMain + "?page=" + i + "&dept=" + DropDowndepartment.SelectedValue + "' >" + i + "</a></li>";
                   }
                   else
                   {
                       newPageString += "<li><a href='" + urlMain + "?page=" + i + "&dept=" + DropDowndepartment.SelectedValue + "' >" + i + "</a></li>";
                   }
               }
               counterPage++;
               paging.Append(newPageString);
           }

           literalPaging.Text = paging.ToString();
       }
   }
   protected void DropDowndepartment_SelectedIndexChanged(object sender, EventArgs e)
   {
       DBFunctions db = new DBFunctions();
       List<EmployeePay_tbl> emp = new List<EmployeePay_tbl>();
       int pageStart = 1;
       int pageEnd = 10;
       if (DropDowndepartment.SelectedValue != "All")
       {
           int deptid = int.Parse(DropDowndepartment.SelectedValue);
           emp = db.getallemployee_pay(0, 10, deptid);
           renderemployees(emp);
           pageEnd = db.getemployeePay_count(deptid);
       }
       else
       {
           emp = db.getallemployee_pay(0, 10, 0);
           renderemployees(emp);
           pageEnd = db.getemployeePay_count(0);
       }
       //if (Request.QueryString.ToString().Contains("page"))
       //{
       //page = Convert.ToInt32(Request.QueryString["page"].ToString());
       // pageEnd = pageSize * page;
       int total = pageEnd;
       pageStart = (pageSize * page - pageSize) + 1;
       //    pageEnd = db.getemployee_count(0);
       //}

       literalStart.Text = pageStart.ToString();
       if (pageEnd > 10)
       {
           pageEnd = pageSize * page;

       }
       literalEnd.Text = pageEnd.ToString();
       literalTotal.Text = total.ToString();
       setpaging(total);
   }

   public void setdepartment()
   {
       DBFunctions db = new DBFunctions();
      

       DropDowndepartment.DataSource = db.getalldepartments();
       DropDowndepartment.DataTextField = "Department";
       DropDowndepartment.DataValueField = "ID";
       DropDowndepartment.DataBind();
   }
   protected void dashboardbtn_Click(object sender, EventArgs e)
   {
       Response.Redirect("AdminDashboard.aspx");
   }
}