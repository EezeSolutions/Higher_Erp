﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class CollegeERPDBEntities : DbContext
{
    public CollegeERPDBEntities()
        : base("name=CollegeERPDBEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<AddmissionList_tbl> AddmissionList_tbl { get; set; }

    public virtual DbSet<AdminMails_tbl> AdminMails_tbl { get; set; }

    public virtual DbSet<Answers_tbl> Answers_tbl { get; set; }

    public virtual DbSet<Applications_tbl> Applications_tbl { get; set; }

    public virtual DbSet<Areas_tbl> Areas_tbl { get; set; }

    public virtual DbSet<Attendance_tbl> Attendance_tbl { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Candidate_tbl> Candidate_tbl { get; set; }

    public virtual DbSet<ChatRomMessage_tbl> ChatRomMessage_tbl { get; set; }

    public virtual DbSet<ControlOptions_tbl> ControlOptions_tbl { get; set; }

    public virtual DbSet<CourseFee_tbl> CourseFee_tbl { get; set; }

    public virtual DbSet<DateSheet_tbl> DateSheet_tbl { get; set; }

    public virtual DbSet<Deductions_tbl> Deductions_tbl { get; set; }

    public virtual DbSet<Department_tbl> Department_tbl { get; set; }

    public virtual DbSet<Discounts_tbl> Discounts_tbl { get; set; }

    public virtual DbSet<Discussions_tbl> Discussions_tbl { get; set; }

    public virtual DbSet<DiscussionTopics_tbl> DiscussionTopics_tbl { get; set; }

    public virtual DbSet<EmployeePay_tbl> EmployeePay_tbl { get; set; }

    public virtual DbSet<EmployeeType_tbl> EmployeeType_tbl { get; set; }

    public virtual DbSet<Enroll_Course> Enroll_Course { get; set; }

    public virtual DbSet<Forms_tbl> Forms_tbl { get; set; }

    public virtual DbSet<FormSections_tbl> FormSections_tbl { get; set; }

    public virtual DbSet<IssueBook> IssueBooks { get; set; }

    public virtual DbSet<LibraryMember> LibraryMembers { get; set; }

    public virtual DbSet<Mails_tbl> Mails_tbl { get; set; }

    public virtual DbSet<Notices_tbl> Notices_tbl { get; set; }

    public virtual DbSet<Screening_tbl> Screening_tbl { get; set; }

    public virtual DbSet<States_tbl> States_tbl { get; set; }

    public virtual DbSet<StudentAcceptanceFee_tbl> StudentAcceptanceFee_tbl { get; set; }

    public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

    public virtual DbSet<TimeTable_tbl> TimeTable_tbl { get; set; }

    public virtual DbSet<Hostel_tbl> Hostel_tbl { get; set; }

    public virtual DbSet<HostelWarden_tbl> HostelWarden_tbl { get; set; }

    public virtual DbSet<StudentRoom_Mapping> StudentRoom_Mapping { get; set; }

    public virtual DbSet<StudentInfo_tbl> StudentInfo_tbl { get; set; }

    public virtual DbSet<HostelRoom_tbl> HostelRoom_tbl { get; set; }

    public virtual DbSet<Employee_tbl> Employee_tbl { get; set; }

    public virtual DbSet<CourseTeacherAssignment_tbl> CourseTeacherAssignment_tbl { get; set; }

    public virtual DbSet<Assignment_Result_tbl> Assignment_Result_tbl { get; set; }

    public virtual DbSet<Assignments_tbl> Assignments_tbl { get; set; }

    public virtual DbSet<Lecture_Notes_tbl> Lecture_Notes_tbl { get; set; }

    public virtual DbSet<Quizz_tbl> Quizz_tbl { get; set; }

    public virtual DbSet<Reference_Books_tbl> Reference_Books_tbl { get; set; }

    public virtual DbSet<Student_Quizz_Mapping_tbl> Student_Quizz_Mapping_tbl { get; set; }

    public virtual DbSet<SubmittedAssignments_tbl> SubmittedAssignments_tbl { get; set; }

    public virtual DbSet<Video_Lecture_tbl> Video_Lecture_tbl { get; set; }

    public virtual DbSet<Batches_table> Batches_table { get; set; }

    public virtual DbSet<Results_tbl> Results_tbl { get; set; }

    public virtual DbSet<AddmissionLog_tbl> AddmissionLog_tbl { get; set; }

    public virtual DbSet<Program_tbl> Program_tbl { get; set; }

    public virtual DbSet<ProgrammeCourses_tbl> ProgrammeCourses_tbl { get; set; }

    public virtual DbSet<Courses_tbl> Courses_tbl { get; set; }

    public virtual DbSet<OfferedCourses_tbl> OfferedCourses_tbl { get; set; }

    public virtual DbSet<Grades_tbl> Grades_tbl { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<Support_tbl> Support_tbl { get; set; }

    public virtual DbSet<StudentSelectedCredit> StudentSelectedCredits { get; set; }

    public virtual DbSet<Questionaire_tbl> Questionaire_tbl { get; set; }

}

