using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for SingleSessionEnforcement
/// </summary>
public class SingleSessionEnforcement : IHttpModule
{
    public SingleSessionEnforcement()
    {
        // No construction needed
    }

    private void OnPostAuthenticate(Object sender, EventArgs e)
    {
        Guid sessionToken;

        HttpApplication httpApplication = (HttpApplication)sender;
        HttpContext httpContext = httpApplication.Context;

        // Check user's session token
        if (httpContext.User.Identity.IsAuthenticated)
        {
            FormsAuthenticationTicket authenticationTicket =
                ((FormsIdentity)httpContext.User.Identity).Ticket;

            if (authenticationTicket.UserData != "")
            {
                sessionToken = new Guid(authenticationTicket.UserData);
            }
            else
            {
                // No authentication ticket found so logout this user
                // Should never hit this code
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            MembershipUser currentUser = Membership.GetUser(authenticationTicket.Name);

            // May want to add a conditional here so we only check
            // if the user needs to be checked. For instance, your business
            // rules for the application may state that users in the Admin
            // role are allowed to have multiple sessions
            Guid storedToken = new Guid(currentUser.Comment);

            if (sessionToken != storedToken)
            {
                // Stored session does not match one in authentication
                // ticket so logout the user
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }

    public void Dispose()
    {
        // Nothing to dispose
    }

    public void Init(HttpApplication context)
    {
        context.PostAuthenticateRequest += new EventHandler(OnPostAuthenticate);
    }
}