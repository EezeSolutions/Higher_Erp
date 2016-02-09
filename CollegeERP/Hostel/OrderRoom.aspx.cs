using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hostel_Default : System.Web.UI.Page
{
    int id = -1;
    string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
     string pagename = Path.GetFileName(Request.PhysicalPath);
     if (Request.QueryString["action"] != null && Request.QueryString["Roomid"] != null)
     {
          action = Request.QueryString["action"];
          id = int.Parse(Request.QueryString["Roomid"]);
     }
     if (Session["userid"] != null)
     {

         DBFunctions db = new DBFunctions();
         if (action == "order")
         {
             HostelRoom_tbl room = db.getRoomById(id);
             hostelname.Text = room.Hostel_tbl.Name;
             price.Text = room.Price.ToString();
             capacity.Text = room.Capacity.ToString();
             description.Text = room.RoomDescription;
             status.Visible = false;
             btnorderroom.Visible = true;
         }
         else if (action == "reorder")
         {
             HostelRoom_tbl room = db.getRoomById(id);
             hostelname.Text = room.Hostel_tbl.Name;
             price.Text = room.Price.ToString();
             capacity.Text = room.Capacity.ToString();
             description.Text = room.RoomDescription;
             btnReorder.Visible = true;
         }
         else if (action == "Leave")
         {
             HostelRoom_tbl room = db.getRoomById(id);
             hostelname.Text = room.Hostel_tbl.Name;
             price.Text = room.Price.ToString();
             capacity.Text = room.Capacity.ToString();
             description.Text = room.RoomDescription;
             //btnReorder.Visible = true;
             btnLeaveroom.Visible = true;
         }
         else if (action == "pending")
         {
             HostelRoom_tbl room = db.getRoomById(id);
             hostelname.Text = room.Hostel_tbl.Name;
             price.Text = room.Price.ToString();
             capacity.Text = room.Capacity.ToString();
             description.Text = room.RoomDescription;
             status.Visible = true;
             status.InnerText = "Your order is Pending";

             btnorderroom.Visible = false;
         }
         else if (action == "Accepted")
         {
             HostelRoom_tbl room = db.getRoomById(id);
             hostelname.Text = room.Hostel_tbl.Name;
             price.Text = room.Price.ToString();
             capacity.Text = room.Capacity.ToString();
             description.Text = room.RoomDescription;
             status.Visible = true;
             status.InnerText = "Your order has been accepted";
             btnorderroom.Visible = false;
         }
         else if (action == "reject")
         {
             HostelRoom_tbl room = db.getRoomById(id);
             hostelname.Text = room.Hostel_tbl.Name;
             price.Text = room.Price.ToString();
             capacity.Text = room.Capacity.ToString();
             description.Text = room.RoomDescription;
             status.Visible = true;
             status.InnerText = "Your order is rejected";
             btnorderroom.Visible = false;
         }
         else
         {

         }
     }
        else
     {
         action = Request.QueryString["action"];
         id = int.Parse(Request.QueryString["Roomid"]);

         Response.Redirect("../Login.aspx?Redirecturl=Hostel/" + pagename + "?action=" + action + "&Roomid=" + id);
     }
    }
    protected void btnorderroom_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        StudentRoom_Mapping room = new StudentRoom_Mapping { RomID = id, StudentID = int.Parse(Session["userid"].ToString()), Status = 0 };
        db.placeorder(room);
        Response.Redirect("ViewRoom.aspx");
    }
    protected void btnReorder_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        StudentRoom_Mapping room = new StudentRoom_Mapping { RomID = id, StudentID = int.Parse(Session["userid"].ToString()), Status = 0 };
        db.reorderroom(room);
        Response.Redirect("ViewRoom.aspx");

    }
    protected void btnLeaveroom_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        StudentRoom_Mapping room = new StudentRoom_Mapping { RomID = id, StudentID = int.Parse(Session["userid"].ToString()), Status = 0 };
        db.leaveroom(room);
        Response.Redirect("ViewRoom.aspx");
    }
}