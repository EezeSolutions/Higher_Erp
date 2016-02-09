using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hostel_Default : System.Web.UI.Page
{
    int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        id = int.Parse(Request.QueryString["Requestid"]);
        DBFunctions db = new DBFunctions();
        if (action == "accept")
        {
            StudentRoom_Mapping room = db.getRoomRequestById(id);
            hostelname.Text = room.HostelRoom_tbl.Hostel_tbl.Name;
            price.Text = room.HostelRoom_tbl.Price.ToString();
            capacity.Text = room.HostelRoom_tbl.Capacity.ToString();
            dept.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().Department_tbl.Department;
            acadamicYear.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().AcadamicYear;
            studentname.Text = room.Candidate_tbl.Name;
            btnacceptorderroom.Visible = true;

        }
        //else if(action=="accepted")
        //{
        //    StudentRoom_Mapping room = db.getRoomRequestById(id);
        //    hostelname.Text = room.HostelRoom_tbl.Hostel_tbl.Name;
        //    price.Text = room.HostelRoom_tbl.Price.ToString();
        //    capacity.Text = room.HostelRoom_tbl.Capacity.ToString();
        //    dept.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().Department_tbl.Department;
        //    acadamicYear.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().AcadamicYear;
        //    studentname.Text = room.Candidate_tbl.Name;
            
        //}
        else if (action == "reject")
        {
            StudentRoom_Mapping room = db.getRoomRequestById(id);
            hostelname.Text = room.HostelRoom_tbl.Hostel_tbl.Name;
            price.Text = room.HostelRoom_tbl.Price.ToString();
            capacity.Text = room.HostelRoom_tbl.Capacity.ToString();
            dept.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().Department_tbl.Department;
            acadamicYear.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().AcadamicYear;
            studentname.Text = room.Candidate_tbl.Name;
            //btnacceptorderroom.Visible = false;
            btnrejectroom.Visible = true;
        }
        else if (action == "acceptleaveroom")
        {
            StudentRoom_Mapping room = db.getRoomRequestById(id);
            hostelname.Text = room.HostelRoom_tbl.Hostel_tbl.Name;
            price.Text = room.HostelRoom_tbl.Price.ToString();
            capacity.Text = room.HostelRoom_tbl.Capacity.ToString();
            dept.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().Department_tbl.Department;
            acadamicYear.Text = room.Candidate_tbl.StudentInfo_tbl.FirstOrDefault().AcadamicYear;
            studentname.Text = room.Candidate_tbl.Name;
            //btnacceptorderroom.Visible = false;
            Acceptbtns.Visible = true;
        }
        else
        {

        }
    }
    protected void btnacceptorderroom_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        
        //StudentRoom_Mapping room = new StudentRoom_Mapping { ID = id, RomID = int.Parse(room_id.Text), StudentID = int.Parse(std_id.Text), Status = 1 };
        db.updateorder(id,1);
        Response.Redirect("RoomRequests.aspx");
    }

    protected void btnrejectroom_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        db.updateorder(id, -1);
        Response.Redirect("RoomRequests.aspx");
    }
    protected void Acceptbtns_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        db.updateorder(id, 5);
        Response.Redirect("RoomRequests.aspx");
    }
}