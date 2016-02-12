<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
        <div class="panel-heading">Admission/Enrolment Management</div>
        <div class="panel-body">
          <div class="row">
            <div class="col-sm-4">
              <a href="AddDateSheet.aspx" class="main-links">
                <img src="../images/1-file-manager.jpg">
                <span>Add Date Sheet</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="AddNotices.aspx" class="main-links">
                <img src="../images/2-images.jpg">
                <span>Add Notice</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="AskedQuestions.aspx" class="main-links">
                <img src="../images/3-privacy.jpg">
                <span>Answer Question(s)</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="EnrollmentAppications.aspx" class="main-links">
                <img src="../images/4-disk-usage.jpg">
                <span>View Enrollment Application</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="AddTimeTable.aspx" class="main-links">
                <img src="../images/5-web-disk.jpg">
                <span>Add Time Table</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="ManageCourses.aspx" class="main-links">
                <img src="../images/6-ftp.jpg">
                <span>Manage Courses</span>
              </a>
            </div>
           <div class="col-sm-4">
              <a href="Applicantlist.aspx" class="main-links">
                <img src="../images/10-phpadmin.jpg">
                <span>Generate Merit List</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="ManagePrograms.aspx" class="main-links">
                <img src="../images/8-backup.jpg">
                <span>Manage Programmes</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="Admittedstudents.aspx" class="main-links">
                <img src="../images/9-backup-wizard.jpg">
                <span>View Admitted Student</span>
              </a>
            </div>
              <div class="col-sm-4">
              <a href="AssignCourseToEmplloyee.aspx" class="main-links">
                <img src="../images/9-backup-wizard.jpg">
                <span>Assign Course</span>
              </a>
            </div>
               <div class="col-sm-4">
              <a href="OfferCourses.aspx" class="main-links">
                <img src="../images/4-disk-usage.jpg">
                <span>Offer Course</span>
              </a>
            </div>
                             <div class="col-sm-4">
              <a href="RegistrationNotification.aspx" class="main-links">
                <img src="../images/4-disk-usage.jpg">
                <span>Notify Active Registration</span>
              </a>
            </div>
              <div class="col-sm-4">
              <a href="DownloadReport.aspx" class="main-links">
                <img src="../images/1-file-manager.jpg">
                <span>View Questionaire</span>
              </a>
            </div>
          </div>
        </div>
      </div>
      <div class="panel panel-default">
        <div class="panel-heading">Employees</div>
        <div class="panel-body">
          <div class="row">
           
          
            <div class="col-sm-4">
              <a href="ManageEmployee.aspx" class="main-links">
                <img src="../images/12-sqlbd.jpg">
                <span>Manage Employees</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="ViewLeaveRequests.aspx" class="main-links">
                <img src="../images/13-remotesql.jpg">
                <span>Leave Management</span>
              </a>
            </div>
              <div class="col-sm-4">
              <a href="ManageEmployeeSalary.aspx" class="main-links">
                <img src="../images/13-remotesql.jpg">
                <span>Manage Employee Salary</span>
              </a>
            </div>
          </div>
        </div>
      </div>
      <div class="panel panel-default">
        <div class="panel-heading">Hostels</div>
        <div class="panel-body">
          <div class="row">
            <div class="col-sm-4">
              <a href="../Hostel/ManageHostel.aspx" class="main-links">
                <img src="../images/14-domains.jpg">
                <span>Manage Hostel</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="../Hostel/RoomsList.aspx" class="main-links">
                <img src="../images/15-subdomain.jpg">
                <span>Manage Rooms</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="../Hostel/AddWarden.aspx" class="main-links">
                <img src="../images/16-aliasis.jpg">
                <span>Manage Warden</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="../Hostel/RoomRequests.aspx" class="main-links">
                <img src="../images/17-redirects.jpg">
                <span>View Room Requests</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="../Hostel/RoomLeaveRequests.aspx" class="main-links">
                <img src="../images/18-bns.jpg">
                <span>Room Leave Requests</span>
              </a>
            </div>
          </div>
        </div>
      </div>

       <div class="panel panel-default">
        <div class="panel-heading">Library</div>
        <div class="panel-body">
          <div class="row">
            <div class="col-sm-4">
              <a href="../Library/AddBooks.aspx" class="main-links">
                <img src="../images/14-domains.jpg">
                <span>Manage Books</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="../Library/MemberRequest.aspx" class="main-links">
                <img src="../images/15-subdomain.jpg">
                <span>Membership Requests</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="../Library/BookRequests.aspx" class="main-links">
                <img src="../images/16-aliasis.jpg">
                <span>Book Requests</span>
              </a>
            </div>
           
           
          </div>
        </div>
      </div>

    <script type="text/javascript">
      


    </script>
</asp:Content>

