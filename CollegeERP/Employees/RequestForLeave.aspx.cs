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
        int empid = 7;
        if (!IsPostBack)
        {
            setdate();
            DBFunctions db = new DBFunctions();
            var employee=db.getemployee(empid);
            EmpNametxt.Text = employee.Name;
        }
    }


    protected void setdate()
    {
        int j = 0;

        for (int i = DateTime.Now.Year; i < 2017; i++)
        {

            dropdownyears.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            dropdownfromyear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
            j++;
        }

        for (int i = 1; i < 32; i++)
        {

            dropdownDay.Items.Insert((i - 1), new ListItem(i.ToString(), i.ToString()));
            dropdownfromday.Items.Insert((i - 1), new ListItem(i.ToString(), i.ToString()));
        }
        dropdownfromday.SelectedValue = DateTime.Now.Day.ToString();
        dropdownDay.SelectedValue = DateTime.Now.Day.ToString();
        dropdownMonth.SelectedValue = DateTime.Now.Month.ToString();
        dropdownfrommonth.SelectedValue = DateTime.Now.Month.ToString();
    }
    protected void btnrequestleave_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int empid=7;
        DateTime from=DateTime.Parse(dropdownfromyear.SelectedValue+"-"+dropdownfrommonth.SelectedValue+"-"+dropdownfromday.SelectedValue);
        DateTime to=DateTime.Parse(dropdownyears.SelectedValue+"-"+dropdownMonth.SelectedValue+"-"+dropdownDay.SelectedValue);
        Leave leave = new Leave { EmployeeID = empid, LeaveType = LeaveType.SelectedValue, Reason = Reason.Text, FromDate = from, ToDate = to,Status=0 };
        db.sendleaverequest(leave);

    }
}