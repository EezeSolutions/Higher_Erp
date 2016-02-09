using System;
using System.Collections.Generic;
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
        if (Session["admin"] == null)
        {
            if (Request.QueryString["empid"] != null)
            {
                Response.Redirect("Login.aspx?Redirecturl=" + pagename + "?empid" + Request.QueryString["empid"]);
            }
            else {
                Response.Redirect("Login.aspx?Redirecturl=" + pagename);
            }
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["empid"] != null)
            {
                string previouspage = Request.UrlReferrer.ToString();
                int empid = int.Parse(Request.QueryString["empid"]);
                DBFunctions db = new DBFunctions();
                EmployeePay_tbl emp = db.getemplyeepayinfo(empid);
                if (emp != null)
                {
                    EmpNametxt.Text = emp.Employee_tbl.Name;
                    DeptList.Text = emp.Employee_tbl.Department_tbl.Department;
                    basicsalary.Text = emp.BasicSalary.ToString();
                    MedicalAllownce.Text = emp.MedicalAllownce.ToString();
                    TransportAllownce.Text = emp.TransportAllownce.ToString();
                    HouseRent.Text = emp.HouseRent.ToString();
                    Overtime.Text = emp.overtime.ToString();
                }
                else
                {
                    message.Visible = true;
                    message.InnerHtml = "There is No Salary Info For This Employee!!";
                    var employee = db.getemployee(empid);
                    EmpNametxt.Text = employee.Name;
                    DeptList.Text = employee.Department_tbl.Department;

                }
                backlink.Text = "<a href=#0' onclick='history.back()' class='btn btn-info'>Back</a>";

            }
        }
    }
    protected void EditSalary_Click(object sender, EventArgs e)
    {
        basicsalary.ReadOnly=false;
                MedicalAllownce.ReadOnly=false;
                TransportAllownce.ReadOnly=false;
                HouseRent.ReadOnly=false;
                Overtime.ReadOnly = false;
                Update.Visible = true;
                EditSalary.Visible = false;
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int empid = int.Parse(Request.QueryString["empid"]);
        var emp = db.getemplyeepayinfo(empid);
        if (emp != null)
        {
            int payid = emp.ID;
            EmployeePay_tbl pay = new EmployeePay_tbl { ID = payid, EmployeeID = int.Parse(Request.QueryString["empid"]), BasicSalary = int.Parse(basicsalary.Text), HouseRent = int.Parse(HouseRent.Text), MedicalAllownce = int.Parse(MedicalAllownce.Text), overtime = int.Parse(Overtime.Text), TransportAllownce = int.Parse(TransportAllownce.Text) };
            db.updatepay(pay);
        }
        else
        {
            EmployeePay_tbl pay = new EmployeePay_tbl {  EmployeeID = int.Parse(Request.QueryString["empid"]), BasicSalary = int.Parse(basicsalary.Text), HouseRent = int.Parse(HouseRent.Text), MedicalAllownce = int.Parse(MedicalAllownce.Text), overtime = int.Parse(Overtime.Text), TransportAllownce = int.Parse(TransportAllownce.Text) };
            db.addemployeePay(pay);
        }
        Response.Redirect("Salaryinfo.aspx?empid="+empid);
    }
}