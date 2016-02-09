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
            setdateofbirth();
            setdepartment();
            setEmployeeType();
            loademployees();
            
        }
    }

    private void loademployees()
    {
       
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
      List<Employee_tbl> employees = new List<Employee_tbl>();
      if (Request.QueryString["dept"] == null || Request.QueryString["dept"]=="All")
      {
          
          employees = db.getallemployee(page - 1, pageSize, 0);
          pageEnd = db.getemployee_count(0);
      }
      else
      {

          int deptid = int.Parse(Request.QueryString["dept"]);
          employees = db.getallemployee(page - 1, pageSize, deptid);
          pageEnd = db.getemployee_count(deptid);
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
    protected void btnaddEmployee_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        DateTime dob=DateTime.Parse(dropdownyears.SelectedItem.Text+"-"+dropdownMonth.SelectedItem.Text+"-"+dropdownDay.SelectedItem.Text);
        Employee_tbl employee = new Employee_tbl { Name = EmpNametxt.Text, Qualification = Qualificationtxt.Text, PhoneNumber = phonetxt.Text, Gender = dropdownGender.SelectedValue, Deptid = int.Parse(DeptList.SelectedValue), DateOFBirth = dob.ToShortDateString(), Email = Emailtxt.Text, CNIC = CNICtxt.Text, Address = Addresstxt.Text, City = Citytxt.Text, BankAccountNumber = Accounttxt.Text, Bank = Banktxt.Text,Designation=Designationtxt.Text,EmployeeType=int.Parse(DropDownEmpType.SelectedValue),Username=usernametxt.Text,Password=Passwordtxt.Text,IsFirstTime=0 };
        employee = db.addEmployee(employee);
        employee.Department_tbl = db.getalldepartments().Where(x => x.ID == int.Parse(DeptList.SelectedValue)).FirstOrDefault();
        List<Employee_tbl> emp = new List<Employee_tbl>();
        emp.Add(employee);
        renderemployees(emp);
    }

    protected void setdateofbirth()
    {
        int j = 0;

        for (int i = 1985; i < 2015; i++)
        {

            dropdownyears.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }

        for (int i = 1; i < 32; i++)
        {

            dropdownDay.Items.Insert((i - 1), new ListItem(i.ToString(), i.ToString()));

        }
    }

    public void setdepartment()
    {
        DBFunctions db = new DBFunctions();
        DeptList.DataSource = db.getalldepartments();
        DeptList.DataTextField = "Department";
        DeptList.DataValueField = "ID";
        DeptList.DataBind();

        DropDowndepartment.DataSource = db.getalldepartments();
        DropDowndepartment.DataTextField = "Department";
        DropDowndepartment.DataValueField = "ID";
        DropDowndepartment.DataBind();
    }

    public void setEmployeeType()
    {
        DBFunctions db = new DBFunctions();
       DropDownEmpType.DataSource= db.GetEmployeeType();
       DropDownEmpType.DataTextField = "EmployeeType";
       DropDownEmpType.DataValueField = "ID";
       DropDownEmpType.DataBind();
    }

    public void renderemployees(List<Employee_tbl> employees)
    {
        Employeetbl.Text = "";
        foreach (var emp in employees)
        {
            Employeetbl.Text += "<tr><td>" + emp.Name + "</td><td>" + emp.Designation + "</td><td>" + emp.PhoneNumber + "</td><td>" + emp.Email + "</td><td>" + emp.Department_tbl.Department + "</td><td><a href='updateEmpolyee.aspx?empid=" + emp.ID + "' class='btn btn-primary' style='padding:5px;font-size:9px'>Update</a> <a href='Salaryinfo.aspx?empid=" + emp.ID + "' class='btn btn-primary' style='padding:5px;font-size:9px'>Salary</a></td></tr>";
        }
    }
    protected void DropDowndepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        List<Employee_tbl> emp=new List<Employee_tbl>();
            int pageStart = 1;
            int pageEnd = 10;
        if (DropDowndepartment.SelectedValue != "All")
        {
            int deptid = int.Parse(DropDowndepartment.SelectedValue);
            emp = db.getallemployee(0, 10,deptid);
            renderemployees(emp);
            pageEnd = db.getemployee_count(deptid);
        }
        else
        {
             emp = db.getallemployee(0, 10,0);
            renderemployees(emp);
            pageEnd = db.getemployee_count(0);
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
    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }
}