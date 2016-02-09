using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["empid"] != null)
            {
                setdateofbirth();
                setdepartment();
                setEmployeeType();
                int empid = int.Parse(Request.QueryString["empid"]);
                DBFunctions db = new DBFunctions();
                Employee_tbl emp = db.getemployee(empid);
                EmpNametxt.Text = emp.Name;
                Qualificationtxt.Text = emp.Qualification;
                phonetxt.Text = emp.PhoneNumber;
                dropdownGender.SelectedValue = emp.Gender;
                DeptList.SelectedValue = emp.Deptid.ToString();
                string[] dob = emp.DateOFBirth.Split('/');
                dropdownDay.SelectedValue = dob[0];
                dropdownMonth.SelectedValue = dob[1];
                dropdownyears.SelectedValue = dob[2];
                Emailtxt.Text = emp.Email;
                CNICtxt.Text = emp.CNIC;
                Addresstxt.Text = emp.Address;
                Citytxt.Text = emp.City;
                Accounttxt.Text = emp.BankAccountNumber;
                Banktxt.Text = emp.Bank;
                Designationtxt.Text = emp.Designation;
                DropDownEmpType.SelectedValue = emp.EmployeeType.ToString();

            }
        }
    }
    protected void btnupdateEmployee_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        DateTime dob = DateTime.Parse(dropdownyears.SelectedItem.Text + "-" + dropdownMonth.SelectedItem.Text + "-" + dropdownDay.SelectedItem.Text);
        Employee_tbl employee = new Employee_tbl {ID=int.Parse(Request.QueryString["empid"]), Name = EmpNametxt.Text, Qualification = Qualificationtxt.Text, PhoneNumber = phonetxt.Text, Gender = dropdownGender.SelectedValue, Deptid = int.Parse(DeptList.SelectedValue), DateOFBirth = dob.ToShortDateString(), Email = Emailtxt.Text, CNIC = CNICtxt.Text, Address = Addresstxt.Text, City = Citytxt.Text, BankAccountNumber = Accounttxt.Text, Bank = Banktxt.Text, Designation = Designationtxt.Text, EmployeeType = int.Parse(DropDownEmpType.SelectedValue) };
        db.updateEmployee(employee);

        Response.Redirect("ManageEmployee.aspx");
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
    }

    public void setEmployeeType()
    {
        DBFunctions db = new DBFunctions();
        DropDownEmpType.DataSource = db.GetEmployeeType();
        DropDownEmpType.DataTextField = "EmployeeType";
        DropDownEmpType.DataValueField = "ID";
        DropDownEmpType.DataBind();
    }
}