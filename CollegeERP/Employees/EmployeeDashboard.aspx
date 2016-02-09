<%@ Page Title="" Language="C#" MasterPageFile="~/Employees/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDashboard.aspx.cs" Inherits="Employees_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel panel-default">
        <div class="panel-heading">Attendance/Results</div>
        <div class="panel-body">
          <div class="row">
            <div class="col-sm-4">
              <a href="Attendance.aspx" class="main-links">
                <img src="../images/1-file-manager.jpg">
                <span>Add Attendace</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="uploadresult.aspx" class="main-links">
                <img src="../images/2-images.jpg">
                <span>Upload Result</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="ViewAssignedCourse.aspx" class="main-links">
                <img src="../images/3-privacy.jpg">
                <span>View Assigned Courses</span>
              </a>
            </div>
         
              <div class="col-sm-4">
              <a href="../LMS/TeacherCourseSelection.aspx" class="main-links">
                <img src="../images/12-sqlbd.jpg">
                <span>LMS</span>
              </a>
            </div>
           
       
         
          </div>
        </div>
      </div>
      <div class="panel panel-default">
        <div class="panel-heading">Leaves</div>
        <div class="panel-body">
          <div class="row">
            <div class="col-sm-4">
              <a href="RequestForLeave.aspx" class="main-links">
                <img src="../images/10-phpadmin.jpg">
                <span>Request For Leave</span>
              </a>
            </div>
          
        
     
              
          </div>
        </div>
      </div>
      <div class="panel panel-default">
        <div class="panel-heading">Domains</div>
        <div class="panel-body">
          <div class="row">
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="../images/14-domains.jpg">
                <span>Addon Domains</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="../images/15-subdomain.jpg">
                <span>Subdomains</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="../images/16-aliasis.jpg">
                <span>Aliases</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="../images/17-redirects.jpg">
                <span>Redirects</span>
              </a>
            </div>
            <div class="col-sm-4">
              <a href="#" class="main-links">
                <img src="../images/18-bns.jpg">
                <span>Simple Zone Editor</span>
              </a>
            </div>
          </div>
        </div>
      </div>
</asp:Content>

