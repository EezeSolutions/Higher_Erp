﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
        if (Request.QueryString["Redirecturl"] != null)
        {
            returnuurl = Request.QueryString["Redirecturl"];
            Message.Visible = true;
            Message.Text = "Please Login First";
        }
        else
        {
            DBFunctions db = new DBFunctions();
            Candidate_tbl candidate = db.LoginChek(username.Text, password.Text);
            if (Membership.ValidateUser(username.Text, password.Text))
            {
                FormsAuthentication.SetAuthCookie(username.Text, true);
                string UserID = "";
                bool LoggedStatus = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

                             MembershipUser mu = Membership.GetUser(username.Text);
                            UserID = mu.ProviderUserKey.ToString();
                            DatabaseFunctions d = new DatabaseFunctions();
                            int uid = d.GetCandidateID(UserID);
                            Session["username"] = username.Text;
                            Session["userid"] = uid;

                            Session["Name"] = candidate.Name;
                            Session["Image"] = candidate.Image;
                            Session["Role"] = "Student";
                            Session["email"] = candidate.Email;
                            Session["candidate"] = candidate;

                            if (returnuurl == "")
                            {
                                Response.Redirect("ProfilePage.aspx");
                            }
                            else
                            {
                                Response.Redirect(returnuurl);
                            }
                  
            }
            else
            {
                Message.Text = "Wrong Username or Password";
                Message.Visible = true;
            }
        }
    }
}