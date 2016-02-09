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
        id = int.Parse(Request.QueryString["Roomid"]);
        if (!IsPostBack)
        {
            DBFunctions db = new DBFunctions();
            if (action == "update")
            {
                HostelRoom_tbl room = db.getRoom(id);
                price.Text = room.Price.ToString();
                capacity.Text = room.Capacity.ToString();
                description.Text = room.RoomDescription;

                DropDownHostel.DataSource = db.gethostellist();

                DropDownHostel.DataTextField = "Name";
                DropDownHostel.DataValueField = "ID";
                DropDownHostel.DataBind();

            }
            else
            {

            }
        }

    }
    protected void btnupdateroom_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();

        HostelRoom_tbl htl = new HostelRoom_tbl {ID=id, HostelID = int.Parse(DropDownHostel.SelectedValue), Price = int.Parse(price.Text), Capacity = int.Parse(capacity.Text), RoomDescription = description.Text };
        db.updateRoom(htl);
        Response.Redirect("RoomsList.aspx");
    }
}