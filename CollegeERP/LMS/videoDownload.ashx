<%@ WebHandler Language="C#" Class="videoDownload" %>

using System;
using System.Web;

public class videoDownload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string file = context.Request.QueryString["file"];
        string path = "~/LMS/Videos/";
        if (!string.IsNullOrEmpty(file) && System.IO.File.Exists(context.Server.MapPath(path + file)))
        {
            context.Response.Clear();
            context.Response.ContentType = "application/octet-stream";
            //I have set the ContentType to "application/octet-stream" which cover any type of file
            context.Response.AddHeader("content-disposition", "attachment;filename=" + System.IO.Path.GetFileName(path + file));
            context.Response.WriteFile(context.Server.MapPath(path + file));
            //here you can do some statistic or tracking
            //you can also implement other business request such as delete the file after download

        }
        else
        {
            context.Response.ContentType = "text/plain";

        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}