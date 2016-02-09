<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentDashboard.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="panel panel-default">
        <div class="panel-heading">Admission/Enrolment Management</div>
        <div class="panel-body">
          <div class="row">
            <div class="col-sm-4">
              <a href="EnrollCourse.aspx" class="main-links">
                <img src="images/1-file-manager.jpg">
                <span>Enroll Courses</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="ViewTimeTable.aspx" class="main-links">
                <img src="images/2-images.jpg">
                <span>View Time Table</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="ViewDateSheet.aspx" class="main-links">
                <img src="images/3-privacy.jpg">
                <span>View Date Sheet</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="ViewCourseFee.aspx" class="main-links">
                <img src="images/4-disk-usage.jpg">
                <span>View Course Fee</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="AskQuestion.aspx" class="main-links">
                <img src="images/5-web-disk.jpg">
                <span>Ask Question</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="DiscussionTopic.aspx" class="main-links">
                <img src="images/6-ftp.jpg">
                <span>Join Discussion</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="images/7-ftp-connection.jpg">
                <span>Ftp Connections</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="images/8-backup.jpg">
                <span>Backup</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="images/9-backup-wizard.jpg">
                <span>Backup Wizards</span>
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
              <a href="Hostel/ViewRoom.aspx" class="main-links">
                <img src="images/10-phpadmin.jpg">
                <span>View Available Rooms</span>
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
              <a href="Library/AvailableBooks.aspx" class="main-links">
                <img src="images/14-domains.jpg">
                <span>View Available Books</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="Library/RequestMemberShip.aspx" class="main-links">
                <img src="images/15-subdomain.jpg">
                <span>Request Membership</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="LMS/CourseSelection.aspx" class="main-links">
                <img src="images/16-aliasis.jpg">
                <span>LMS</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="images/17-redirects.jpg">
                <span>Redirects</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="images/18-bns.jpg">
                <span>Simple Zone Editor</span>
              </a>
            </div>


          </div>
        </div>
      </div>
</asp:Content>

