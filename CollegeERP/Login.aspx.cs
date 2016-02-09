﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Redirecturl"] != null)
        {
            
            Message.Visible = true;
            Message.Text = "Please Login First";
        }

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string returnuurl = "";
        if (Request.QueryString["Redirecturl"]!=null)
        {
            returnuurl = Request.QueryString["Redirecturl"];
            Message.Visible = true;
            Message.Text = "Please Login First";
        }
        DBFunctions db=new DBFunctions();
        Candidate_tbl candidate=db.LoginChek(username.Text, password.Text);
        if (candidate != null)
        {
            if (candidate.Status == 1)
            {


                Session["username"] = username.Text;
                Session["userid"] = candidate.ID;
                Session["Metricno"] = candidate.AddmissionList_tbl.FirstOrDefault().MetricNo;
                Session["Name"] = candidate.Name;
                Session["Image"] = candidate.Image;
                Session["Role"] = "Student";
                Session["email"] = candidate.Email;
                Session["candidate"] = candidate;
                if (returnuurl == "")

                    Response.Redirect("StudentDashboard.aspx");
                else
                {
                    Response.Redirect(returnuurl);
                }
            }
            else
            {
                Session["username"] = username.Text;
                Session["userid"] = candidate.ID;
                Session["Role"] = "Guest";
                if (returnuurl == "")
                    Response.Redirect("ProgramApplication.aspx");
                else
                {
                    Response.Redirect(returnuurl);
                }
            }
        }
        else
        {
            Message.Text = "Wrong Username or Password";
            Message.Visible = true;
        }
    }
}