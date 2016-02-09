﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            int stid = int.Parse(Session["userid"].ToString());

            DBFunctions db = new DBFunctions();
            backlink.Text = "<a href='#0' class='btn btn-primary' onclick='history.back()'>Back</a>";

            var chk = db.getLirarymember(stid);
            if (chk == null)
            {
                var stdent = db.getstdentinfo(stid);
                nametxt.Text = stdent.Candidate_tbl.Name;
                metricno.Text = stdent.Candidate_tbl.AddmissionList_tbl.FirstOrDefault().MetricNo;
                programme.Text = stdent.Program_tbl.ProgramName;
            }
            else
            {
                membershipform.Visible = false;
                membermsg.Visible = true;
                if(chk.Status==0){
                    membermsg.InnerText = "Your Request For Library Membership is Pending..!!";
                }

                else if(chk.Status==1)
                {
                    membermsg.InnerText = "You Already Have The Library Membership!!";

                }
            }
        }
        else
        {

        }
    }
    protected void Requestbtn_Click(object sender, EventArgs e)
    {
        DBFunctions db = new DBFunctions();
        int stid = int.Parse(Session["userid"].ToString());
        LibraryMember member = new LibraryMember { UserID = stid, Status = 0,JoinDate=DateTime.Now.Date };
        db.requestlibrarymembership(member);
    }
}