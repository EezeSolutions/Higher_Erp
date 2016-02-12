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
            set { HttpContext.Current.Session["UserID"] = value;  }
        }

        public static string UserName
        {
            get { return HttpContext.Current.Session["UserName"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["UserName"] = value.Replace("'","''"); }
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

        public static string procedurename_applicationsection
        {
            get { return HttpContext.Current.Session["procedurename_applicationsection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["procedurename_applicationsection"] = value.Replace("'", "''"); }
        }



        public static string programID_applicationSection
        {
            get { return HttpContext.Current.Session["programID_applicationSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["programID_applicationSection"] = value.Replace("'", "''"); }
        }
        public static string courseID_applicationSection
        {
            get { return HttpContext.Current.Session["courseID_applicationSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["courseID_applicationSection"] = value.Replace("'", "''"); }
        }
        public static string optionalCourse_applicationSection
        {
            get { return HttpContext.Current.Session["optionalCourse_applicationSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["optionalCourse_applicationSection"] = value.Replace("'", "''"); }
        }

        public static string totalRecords_applicationsection
        {
            get { return HttpContext.Current.Session["totalRecords_applicationsection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["totalRecords_applicationsection"] = value.Replace("'", "''"); }
        }

        public static DataTable ApplicationSectionDataTable
        {
            get
            {
                return HttpContext.Current.Session["ApplicationSectionDataTable"] as DataTable ?? new DataTable();

            }
            set
            {
                HttpContext.Current.Session["ApplicationSectionDataTable"] = value;
            }
        }



        public static string procedurename_admissionsection
        {
            get { return HttpContext.Current.Session["procedurename_admissionsection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["procedurename_admissionsection"] = value.Replace("'", "''"); }
        }


        public static string programName_admissionSection
        {
            get { return HttpContext.Current.Session["programName_admissionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["programName_admissionSection"] = value.Replace("'", "''"); }
        }
        public static string departmentName_admissionSection
        {
            get { return HttpContext.Current.Session["departmentName_admissionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["departmentName_admissionSection"] = value.Replace("'", "''"); }
        }
        public static string campusName_admissionSection
        {
            get { return HttpContext.Current.Session["campusName_admissionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["campusName_admissionSection"] = value.Replace("'", "''"); }
        }
        public static string AcceptanceFee_admissionSection
        {
            get { return HttpContext.Current.Session["AcceptanceFee_admissionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["AcceptanceFee_admissionSection"] = value.Replace("'", "''"); }
        }
        public static string Biomertics_admissionSection
        {
            get { return HttpContext.Current.Session["Biomertics_admissionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["Biomertics_admissionSection"] = value.Replace("'", "''"); }
        }

        public static string totalRecords_admissionsection
        {
            get { return HttpContext.Current.Session["totalRecords_admissionsection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["totalRecords_admissionsection"] = value.Replace("'", "''"); }
        }




        public static string procedurename_acceptancesection
        {
            get { return HttpContext.Current.Session["procedurename_acceptancesection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["procedurename_acceptancesection"] = value.Replace("'", "''"); }
        }


        public static string programName_acceptanceSection
        {
            get { return HttpContext.Current.Session["programName_acceptanceSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["programName_acceptanceSection"] = value.Replace("'", "''"); }
        }

        public static string totalRecords_acceptancesection
        {
            get { return HttpContext.Current.Session["totalRecords_acceptancesection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["totalRecords_acceptancesection"] = value.Replace("'", "''"); }
        }



        public static string procedurename_TransactionSection
        {
            get { return HttpContext.Current.Session["procedurename_TransactionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["procedurename_TransactionSection"] = value.Replace("'", "''"); }
        }


        public static string programName_TransactionSection
        {
            get { return HttpContext.Current.Session["programName_TransactionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["programName_TransactionSection"] = value.Replace("'", "''"); }
        }
        public static string payMethod_TransactionSection
        {
            get { return HttpContext.Current.Session["payMethod_TransactionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["payMethod_TransactionSection"] = value.Replace("'", "''"); }
        }

        public static string totalRecords_TransactionSection
        {
            get { return HttpContext.Current.Session["totalRecords_TransactionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["totalRecords_TransactionSection"] = value.Replace("'", "''"); }
        }

        public static string totalAmount_TransactionSection
        {
            get { return HttpContext.Current.Session["totalAmount_TransactionSection"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["totalAmount_TransactionSection"] = value.Replace("'", "''"); }
        }

        public static string applicationException
        {
            get { return HttpContext.Current.Session["applicationException"] as string ?? String.Empty; }
            set { HttpContext.Current.Session["applicationException"] = value.Replace("'", "''"); }
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