using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace General
{
    /// <summary>
    /// Summary description for Session
    /// </summary>
    public class Session
    {
        public Session()
        {
        }

        /// <summary>Gets or sets user id from session</summary>
        /// <remarks>Author: Ehsan kayani</remarks>



        public static string UserID
        {
            get { return HttpContext.Current.Session["UserID"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["UserID"] = value; }
        }

        public static string UserName
        {
            get { return HttpContext.Current.Session["UserName"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["UserName"] = value.Replace("'", "''"); }
        }


        public static string programID
        {
            get { return HttpContext.Current.Session["programID"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["programID"] = value.Replace("'", "''"); }
        }

        public static string totalAmount
        {
            get { return HttpContext.Current.Session["totalAmount"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["totalAmount"] = value.Replace("'", "''"); }
        }

        public static string Course1
        {
            get { return HttpContext.Current.Session["Course1"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["Course1"] = value.Replace("'", "''"); }
        }

        public static string Course1ID
        {
            get { return HttpContext.Current.Session["Course1ID"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["Course1ID"] = value.Replace("'", "''"); }
        }

        public static string Course2
        {
            get { return HttpContext.Current.Session["Course2"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["Course2"] = value.Replace("'", "''"); }
        }

        public static string Course2ID
        {
            get { return HttpContext.Current.Session["Course2ID"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["Course2ID"] = value.Replace("'", "''"); }
        }

        public static string Campus
        {
            get { return HttpContext.Current.Session["Campus"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["Campus"] = value.Replace("'", "''"); }
        }

        public static string OptionalCourse
        {
            get { return HttpContext.Current.Session["OptionalCourse"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["OptionalCourse"] = value.Replace("'", "''"); }
        }



        public enum SessionName { UserID, UserName }
        public static void SetNull()
        {

            if (HttpContext.Current.Session["UserPermissions"] != null)
                HttpContext.Current.Session["UserPermissions"] = null;

            if (HttpContext.Current.Session["StudentType"] != null)
                HttpContext.Current.Session["StudentType"] = null;

            if (HttpContext.Current.Session["tableName_Payment"] != null)
                HttpContext.Current.Session["tableName_Payment"] = null;

            if (HttpContext.Current.Session["SemesterID"] != null)
                HttpContext.Current.Session["SemesterID"] = null;

            if (HttpContext.Current.Session["AcademicYearID"] != null)
                HttpContext.Current.Session["AcademicYearID"] = null;
            if (HttpContext.Current.Session["DepartmentID"] != null)
                HttpContext.Current.Session["DepartmentID"] = null;
            if (HttpContext.Current.Session["Semester"] != null)
                HttpContext.Current.Session["Semester"] = null;


            if (HttpContext.Current.Session["UserID"] != null)
                HttpContext.Current.Session["UserID"] = null;

            if (HttpContext.Current.Session["UserName"] != null)
                HttpContext.Current.Session["UserName"] = null;

            if (HttpContext.Current.Session["userType"] != null)
                HttpContext.Current.Session["userType"] = null;

            if (HttpContext.Current.Session["Department"] != null)
                HttpContext.Current.Session["Department"] = null;

            if (HttpContext.Current.Session["AcademicYear"] != null)
                HttpContext.Current.Session["AcademicYear"] = null;




        }

    }
}