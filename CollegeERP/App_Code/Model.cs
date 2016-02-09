﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class AddmissionList_tbl
{
    public int ID { get; set; }
    public Nullable<int> ProgrameID { get; set; }
    public Nullable<int> UserID { get; set; }
    public Nullable<int> Status { get; set; }
    public string route { get; set; }
    public string MetricNo { get; set; }
    public string Password { get; set; }
    public Nullable<int> BatchID { get; set; }
    public Nullable<System.DateTime> DateCreated { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual Batches_table Batches_table { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
}

public partial class AddmissionLog_tbl
{
    public int ID { get; set; }
    public int userID { get; set; }
    public string ActionBy { get; set; }
    public int ApplcationID { get; set; }
    public string Action { get; set; }
    public Nullable<System.DateTime> Date { get; set; }
    public int ProgramID { get; set; }

    public virtual Applications_tbl Applications_tbl { get; set; }
    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
}

public partial class AdminMails_tbl
{
    public int ID { get; set; }
    public Nullable<int> SenderID { get; set; }
    public string Message { get; set; }
    public string Subject { get; set; }
    public Nullable<int> Status { get; set; }
    public Nullable<System.DateTime> Date { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class Answers_tbl
{
    public int A_ID { get; set; }
    public string Answer { get; set; }
    public Nullable<int> Q_ID { get; set; }

    public virtual Questionaire_tbl Questionaire_tbl { get; set; }
}

public partial class Applications_tbl
{
    public Applications_tbl()
    {
        this.Screening_tbl = new HashSet<Screening_tbl>();
        this.AddmissionLog_tbl = new HashSet<AddmissionLog_tbl>();
    }

    public int ID { get; set; }
    public Nullable<int> UserID { get; set; }
    public Nullable<int> ProgrameID { get; set; }
    public string Application_Type { get; set; }
    public string CutoffPoints { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual ICollection<Screening_tbl> Screening_tbl { get; set; }
    public virtual ICollection<AddmissionLog_tbl> AddmissionLog_tbl { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
}

public partial class Areas_tbl
{
    public Areas_tbl()
    {
        this.Candidate_tbl = new HashSet<Candidate_tbl>();
    }

    public int ID { get; set; }
    public string Area { get; set; }
    public string Description { get; set; }
    public Nullable<int> State { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual States_tbl States_tbl { get; set; }
    public virtual ICollection<Candidate_tbl> Candidate_tbl { get; set; }
}

public partial class Assignment_Result_tbl
{
    public int ID { get; set; }
    public Nullable<int> AssignmentID { get; set; }
    public Nullable<int> StudentiID { get; set; }
    public Nullable<int> Assignment_Marks { get; set; }

    public virtual Assignments_tbl Assignments_tbl { get; set; }
    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class Assignments_tbl
{
    public Assignments_tbl()
    {
        this.Assignment_Result_tbl = new HashSet<Assignment_Result_tbl>();
        this.SubmittedAssignments_tbl = new HashSet<SubmittedAssignments_tbl>();
    }

    public int ID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public string Assignment_Title { get; set; }
    public string Assignment_Path { get; set; }
    public Nullable<System.DateTime> DueDate { get; set; }
    public Nullable<int> Status { get; set; }
    public Nullable<int> marks { get; set; }

    public virtual ICollection<Assignment_Result_tbl> Assignment_Result_tbl { get; set; }
    public virtual ICollection<SubmittedAssignments_tbl> SubmittedAssignments_tbl { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Attendance_tbl
{
    public int ID { get; set; }
    public Nullable<int> StudentID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public string Attendance { get; set; }
    public Nullable<System.DateTime> Date { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Batches_table
{
    public Batches_table()
    {
        this.AddmissionList_tbl = new HashSet<AddmissionList_tbl>();
        this.OfferedCourses_tbl = new HashSet<OfferedCourses_tbl>();
    }

    public int ID { get; set; }
    public Nullable<int> BatchYear { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual ICollection<AddmissionList_tbl> AddmissionList_tbl { get; set; }
    public virtual ICollection<OfferedCourses_tbl> OfferedCourses_tbl { get; set; }
}

public partial class Book
{
    public Book()
    {
        this.IssueBooks = new HashSet<IssueBook>();
    }

    public int ID { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string ISBN { get; set; }
    public Nullable<int> Quantity { get; set; }
    public string Author { get; set; }
    public string Edition { get; set; }
    public string Description { get; set; }

    public virtual ICollection<IssueBook> IssueBooks { get; set; }
}

public partial class Candidate_tbl
{
    public Candidate_tbl()
    {
        this.AddmissionList_tbl = new HashSet<AddmissionList_tbl>();
        this.AdminMails_tbl = new HashSet<AdminMails_tbl>();
        this.Applications_tbl = new HashSet<Applications_tbl>();
        this.Attendance_tbl = new HashSet<Attendance_tbl>();
        this.ChatRomMessage_tbl = new HashSet<ChatRomMessage_tbl>();
        this.Discussions_tbl = new HashSet<Discussions_tbl>();
        this.Enroll_Course = new HashSet<Enroll_Course>();
        this.LibraryMembers = new HashSet<LibraryMember>();
        this.Mails_tbl = new HashSet<Mails_tbl>();
        this.Mails_tbl1 = new HashSet<Mails_tbl>();
        this.Screening_tbl = new HashSet<Screening_tbl>();
        this.StudentAcceptanceFee_tbl = new HashSet<StudentAcceptanceFee_tbl>();
        this.StudentRoom_Mapping = new HashSet<StudentRoom_Mapping>();
        this.StudentInfo_tbl = new HashSet<StudentInfo_tbl>();
        this.Assignment_Result_tbl = new HashSet<Assignment_Result_tbl>();
        this.Student_Quizz_Mapping_tbl = new HashSet<Student_Quizz_Mapping_tbl>();
        this.SubmittedAssignments_tbl = new HashSet<SubmittedAssignments_tbl>();
        this.AddmissionLog_tbl = new HashSet<AddmissionLog_tbl>();
        this.CourseFee_tbl = new HashSet<CourseFee_tbl>();
        this.Support_tbl = new HashSet<Support_tbl>();
        this.StudentSelectedCredits = new HashSet<StudentSelectedCredit>();
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
    public string DateofBirth { get; set; }
    public string HomeAdress { get; set; }
    public Nullable<int> LocalGovtArea { get; set; }
    public Nullable<int> Stateoforigin { get; set; }
    public string Image { get; set; }
    public Nullable<int> ProgrammeID { get; set; }
    public Nullable<double> CuttoffPoints { get; set; }
    public Nullable<int> Status { get; set; }
    public string AdmissionYear { get; set; }

    public virtual ICollection<AddmissionList_tbl> AddmissionList_tbl { get; set; }
    public virtual ICollection<AdminMails_tbl> AdminMails_tbl { get; set; }
    public virtual ICollection<Applications_tbl> Applications_tbl { get; set; }
    public virtual Areas_tbl Areas_tbl { get; set; }
    public virtual ICollection<Attendance_tbl> Attendance_tbl { get; set; }
    public virtual States_tbl States_tbl { get; set; }
    public virtual ICollection<ChatRomMessage_tbl> ChatRomMessage_tbl { get; set; }
    public virtual ICollection<Discussions_tbl> Discussions_tbl { get; set; }
    public virtual ICollection<Enroll_Course> Enroll_Course { get; set; }
    public virtual ICollection<LibraryMember> LibraryMembers { get; set; }
    public virtual ICollection<Mails_tbl> Mails_tbl { get; set; }
    public virtual ICollection<Mails_tbl> Mails_tbl1 { get; set; }
    public virtual ICollection<Screening_tbl> Screening_tbl { get; set; }
    public virtual ICollection<StudentAcceptanceFee_tbl> StudentAcceptanceFee_tbl { get; set; }
    public virtual ICollection<StudentRoom_Mapping> StudentRoom_Mapping { get; set; }
    public virtual ICollection<StudentInfo_tbl> StudentInfo_tbl { get; set; }
    public virtual ICollection<Assignment_Result_tbl> Assignment_Result_tbl { get; set; }
    public virtual ICollection<Student_Quizz_Mapping_tbl> Student_Quizz_Mapping_tbl { get; set; }
    public virtual ICollection<SubmittedAssignments_tbl> SubmittedAssignments_tbl { get; set; }
    public virtual ICollection<AddmissionLog_tbl> AddmissionLog_tbl { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
    public virtual ICollection<CourseFee_tbl> CourseFee_tbl { get; set; }
    public virtual ICollection<Support_tbl> Support_tbl { get; set; }
    public virtual ICollection<StudentSelectedCredit> StudentSelectedCredits { get; set; }
}

public partial class ChatRomMessage_tbl
{
    public int ID { get; set; }
    public Nullable<int> UserID { get; set; }
    public string Message { get; set; }
    public System.DateTime Date { get; set; }
    public string Status { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class ControlOptions_tbl
{
    public int ID { get; set; }
    public Nullable<int> FieldID { get; set; }
    public string optionvalue { get; set; }

    public virtual Forms_tbl Forms_tbl { get; set; }
}

public partial class CourseFee_tbl
{
    public Nullable<int> CourseID { get; set; }
    public Nullable<int> StudentID { get; set; }
    public int ID { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual StudentInfo_tbl StudentInfo_tbl { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class Courses_tbl
{
    public Courses_tbl()
    {
        this.Assignments_tbl = new HashSet<Assignments_tbl>();
        this.Attendance_tbl = new HashSet<Attendance_tbl>();
        this.CourseFee_tbl = new HashSet<CourseFee_tbl>();
        this.CourseTeacherAssignment_tbl = new HashSet<CourseTeacherAssignment_tbl>();
        this.DateSheet_tbl = new HashSet<DateSheet_tbl>();
        this.Enroll_Course = new HashSet<Enroll_Course>();
        this.Lecture_Notes_tbl = new HashSet<Lecture_Notes_tbl>();
        this.ProgrammeCourses_tbl = new HashSet<ProgrammeCourses_tbl>();
        this.Quizz_tbl = new HashSet<Quizz_tbl>();
        this.Reference_Books_tbl = new HashSet<Reference_Books_tbl>();
        this.Results_tbl = new HashSet<Results_tbl>();
        this.TimeTable_tbl = new HashSet<TimeTable_tbl>();
        this.Video_Lecture_tbl = new HashSet<Video_Lecture_tbl>();
        this.OfferedCourses_tbl = new HashSet<OfferedCourses_tbl>();
    }

    public int ID { get; set; }
    public string Course { get; set; }
    public string Fee { get; set; }
    public string Marks { get; set; }
    public Nullable<int> Credit_Hours { get; set; }
    public string CourseCode { get; set; }

    public virtual ICollection<Assignments_tbl> Assignments_tbl { get; set; }
    public virtual ICollection<Attendance_tbl> Attendance_tbl { get; set; }
    public virtual ICollection<CourseFee_tbl> CourseFee_tbl { get; set; }
    public virtual ICollection<CourseTeacherAssignment_tbl> CourseTeacherAssignment_tbl { get; set; }
    public virtual ICollection<DateSheet_tbl> DateSheet_tbl { get; set; }
    public virtual ICollection<Enroll_Course> Enroll_Course { get; set; }
    public virtual ICollection<Lecture_Notes_tbl> Lecture_Notes_tbl { get; set; }
    public virtual ICollection<ProgrammeCourses_tbl> ProgrammeCourses_tbl { get; set; }
    public virtual ICollection<Quizz_tbl> Quizz_tbl { get; set; }
    public virtual ICollection<Reference_Books_tbl> Reference_Books_tbl { get; set; }
    public virtual ICollection<Results_tbl> Results_tbl { get; set; }
    public virtual ICollection<TimeTable_tbl> TimeTable_tbl { get; set; }
    public virtual ICollection<Video_Lecture_tbl> Video_Lecture_tbl { get; set; }
    public virtual ICollection<OfferedCourses_tbl> OfferedCourses_tbl { get; set; }
}

public partial class CourseTeacherAssignment_tbl
{
    public int ID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public Nullable<int> TeacherID { get; set; }

    public virtual Employee_tbl Employee_tbl { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class DateSheet_tbl
{
    public int ID { get; set; }
    public string ExamType { get; set; }
    public string Year { get; set; }
    public Nullable<int> CourseID { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Deductions_tbl
{
    public int ID { get; set; }
    public string DeductionType { get; set; }
    public Nullable<int> DeductionAmount { get; set; }
    public Nullable<int> EmployeeID { get; set; }
}

public partial class Department_tbl
{
    public Department_tbl()
    {
        this.StudentInfo_tbl = new HashSet<StudentInfo_tbl>();
        this.Employee_tbl = new HashSet<Employee_tbl>();
        this.Program_tbl = new HashSet<Program_tbl>();
    }

    public int ID { get; set; }
    public string Department { get; set; }

    public virtual ICollection<StudentInfo_tbl> StudentInfo_tbl { get; set; }
    public virtual ICollection<Employee_tbl> Employee_tbl { get; set; }
    public virtual ICollection<Program_tbl> Program_tbl { get; set; }
}

public partial class Discounts_tbl
{
    public int ID { get; set; }
    public Nullable<int> StudentID { get; set; }
    public string DiscountType { get; set; }
    public string Discount { get; set; }

    public virtual StudentInfo_tbl StudentInfo_tbl { get; set; }
}

public partial class Discussions_tbl
{
    public int ID { get; set; }
    public string Discission { get; set; }
    public Nullable<int> TopicID { get; set; }
    public Nullable<int> userID { get; set; }
    public System.DateTime Date { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual DiscussionTopics_tbl DiscussionTopics_tbl { get; set; }
}

public partial class DiscussionTopics_tbl
{
    public DiscussionTopics_tbl()
    {
        this.Discussions_tbl = new HashSet<Discussions_tbl>();
    }

    public int ID { get; set; }
    public string Topic { get; set; }
    public Nullable<System.DateTime> DateCreated { get; set; }

    public virtual ICollection<Discussions_tbl> Discussions_tbl { get; set; }
}

public partial class Employee_tbl
{
    public Employee_tbl()
    {
        this.EmployeePay_tbl = new HashSet<EmployeePay_tbl>();
        this.CourseTeacherAssignment_tbl = new HashSet<CourseTeacherAssignment_tbl>();
        this.Leaves = new HashSet<Leave>();
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public string Qualification { get; set; }
    public Nullable<int> Deptid { get; set; }
    public string Address { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Nullable<int> EmployeeType { get; set; }
    public string DateOFBirth { get; set; }
    public string CNIC { get; set; }
    public string BankAccountNumber { get; set; }
    public string Bank { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string Designation { get; set; }
    public Nullable<int> IsFirstTime { get; set; }

    public virtual Department_tbl Department_tbl { get; set; }
    public virtual EmployeeType_tbl EmployeeType_tbl { get; set; }
    public virtual ICollection<EmployeePay_tbl> EmployeePay_tbl { get; set; }
    public virtual ICollection<CourseTeacherAssignment_tbl> CourseTeacherAssignment_tbl { get; set; }
    public virtual ICollection<Leave> Leaves { get; set; }
}

public partial class EmployeePay_tbl
{
    public int ID { get; set; }
    public Nullable<int> EmployeeID { get; set; }
    public Nullable<int> BasicSalary { get; set; }
    public Nullable<double> MedicalAllownce { get; set; }
    public Nullable<double> HouseRent { get; set; }
    public Nullable<int> overtime { get; set; }
    public Nullable<int> TransportAllownce { get; set; }

    public virtual Employee_tbl Employee_tbl { get; set; }
}

public partial class EmployeeType_tbl
{
    public EmployeeType_tbl()
    {
        this.Employee_tbl = new HashSet<Employee_tbl>();
    }

    public int ID { get; set; }
    public string EmployeeType { get; set; }

    public virtual ICollection<Employee_tbl> Employee_tbl { get; set; }
}

public partial class Enroll_Course
{
    public Nullable<int> CourseID { get; set; }
    public Nullable<int> Uid { get; set; }
    public int ID { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Forms_tbl
{
    public Forms_tbl()
    {
        this.ControlOptions_tbl = new HashSet<ControlOptions_tbl>();
    }

    public int ID { get; set; }
    public string Field { get; set; }
    public string DataType { get; set; }
    public Nullable<int> SectionID { get; set; }
    public Nullable<int> ProgrameID { get; set; }
    public string FormControl { get; set; }

    public virtual ICollection<ControlOptions_tbl> ControlOptions_tbl { get; set; }
    public virtual FormSections_tbl FormSections_tbl { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
}

public partial class FormSections_tbl
{
    public FormSections_tbl()
    {
        this.Forms_tbl = new HashSet<Forms_tbl>();
    }

    public int ID { get; set; }
    public string Section { get; set; }

    public virtual ICollection<Forms_tbl> Forms_tbl { get; set; }
}

public partial class Grades_tbl
{
    public Grades_tbl()
    {
        this.Results_tbl = new HashSet<Results_tbl>();
    }

    public int ID { get; set; }
    public string Grade { get; set; }
    public Nullable<double> Gradepoints { get; set; }

    public virtual ICollection<Results_tbl> Results_tbl { get; set; }
}

public partial class Hostel_tbl
{
    public Hostel_tbl()
    {
        this.HostelWarden_tbl = new HashSet<HostelWarden_tbl>();
        this.HostelRoom_tbl = new HashSet<HostelRoom_tbl>();
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public virtual ICollection<HostelWarden_tbl> HostelWarden_tbl { get; set; }
    public virtual ICollection<HostelRoom_tbl> HostelRoom_tbl { get; set; }
}

public partial class HostelRoom_tbl
{
    public HostelRoom_tbl()
    {
        this.StudentRoom_Mapping = new HashSet<StudentRoom_Mapping>();
    }

    public int ID { get; set; }
    public Nullable<int> HostelID { get; set; }
    public Nullable<int> Price { get; set; }
    public Nullable<int> Capacity { get; set; }
    public string RoomDescription { get; set; }
    public Nullable<int> RoomNo { get; set; }

    public virtual Hostel_tbl Hostel_tbl { get; set; }
    public virtual ICollection<StudentRoom_Mapping> StudentRoom_Mapping { get; set; }
}

public partial class HostelWarden_tbl
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Nullable<int> HostelID { get; set; }

    public virtual Hostel_tbl Hostel_tbl { get; set; }
}

public partial class IssueBook
{
    public int ID { get; set; }
    public Nullable<int> MemberID { get; set; }
    public Nullable<int> BookID { get; set; }
    public Nullable<System.DateTime> IssueDate { get; set; }
    public Nullable<System.DateTime> DueDate { get; set; }
    public Nullable<int> Status { get; set; }
    public Nullable<System.DateTime> ReturnDate { get; set; }

    public virtual Book Book { get; set; }
    public virtual LibraryMember LibraryMember { get; set; }
}

public partial class Leave
{
    public int ID { get; set; }
    public Nullable<int> EmployeeID { get; set; }
    public string LeaveType { get; set; }
    public string Reason { get; set; }
    public Nullable<System.DateTime> FromDate { get; set; }
    public Nullable<System.DateTime> ToDate { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual Employee_tbl Employee_tbl { get; set; }
}

public partial class Lecture_Notes_tbl
{
    public int ID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public string Lecture_Title { get; set; }
    public string Lecture_Path { get; set; }
    public Nullable<System.DateTime> LectureDate { get; set; }

    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class LibraryMember
{
    public LibraryMember()
    {
        this.IssueBooks = new HashSet<IssueBook>();
    }

    public int ID { get; set; }
    public Nullable<int> UserID { get; set; }
    public Nullable<System.DateTime> JoinDate { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual ICollection<IssueBook> IssueBooks { get; set; }
}

public partial class Mails_tbl
{
    public int ID { get; set; }
    public Nullable<int> SenderID { get; set; }
    public Nullable<int> RecieverID { get; set; }
    public string Message { get; set; }
    public string Subject { get; set; }
    public Nullable<int> Status { get; set; }
    public Nullable<System.DateTime> Date { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual Candidate_tbl Candidate_tbl1 { get; set; }
}

public partial class Notices_tbl
{
    public int ID { get; set; }
    public string Notice { get; set; }
    public string NoticeType { get; set; }
    public System.DateTime Date { get; set; }
    public int Status { get; set; }
}

public partial class OfferedCourses_tbl
{
    public int ID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public Nullable<int> BatchID { get; set; }
    public Nullable<int> Semester { get; set; }
    public Nullable<int> Status { get; set; }
    public Nullable<int> ProgrammeID { get; set; }

    public virtual Batches_table Batches_table { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
}

public partial class Program_tbl
{
    public Program_tbl()
    {
        this.AddmissionList_tbl = new HashSet<AddmissionList_tbl>();
        this.AddmissionLog_tbl = new HashSet<AddmissionLog_tbl>();
        this.Applications_tbl = new HashSet<Applications_tbl>();
        this.Candidate_tbl = new HashSet<Candidate_tbl>();
        this.Forms_tbl = new HashSet<Forms_tbl>();
        this.StudentAcceptanceFee_tbl = new HashSet<StudentAcceptanceFee_tbl>();
        this.StudentInfo_tbl = new HashSet<StudentInfo_tbl>();
        this.ProgrammeCourses_tbl = new HashSet<ProgrammeCourses_tbl>();
        this.OfferedCourses_tbl = new HashSet<OfferedCourses_tbl>();
    }

    public int ID { get; set; }
    public string FormNumber { get; set; }
    public string ApplicationFee { get; set; }
    public string AcceptenceFee { get; set; }
    public string ProgrameType { get; set; }
    public string ProgramName { get; set; }
    public Nullable<bool> Enable { get; set; }
    public Nullable<int> SecondChoice { get; set; }
    public Nullable<int> DeptID { get; set; }
    public string CutoffPoints { get; set; }
    public Nullable<int> HasJambData { get; set; }
    public Nullable<int> HasBioDataSection { get; set; }
    public Nullable<int> HasOlevelResult { get; set; }
    public Nullable<int> HasPreviousRecord { get; set; }
    public Nullable<int> HasCBTSchedule { get; set; }
    public Nullable<int> HasCampus { get; set; }
    public Nullable<System.DateTime> DateCreated { get; set; }
    public string FormCh { get; set; }
    public Nullable<int> Semesters { get; set; }

    public virtual ICollection<AddmissionList_tbl> AddmissionList_tbl { get; set; }
    public virtual ICollection<AddmissionLog_tbl> AddmissionLog_tbl { get; set; }
    public virtual ICollection<Applications_tbl> Applications_tbl { get; set; }
    public virtual ICollection<Candidate_tbl> Candidate_tbl { get; set; }
    public virtual Department_tbl Department_tbl { get; set; }
    public virtual ICollection<Forms_tbl> Forms_tbl { get; set; }
    public virtual ICollection<StudentAcceptanceFee_tbl> StudentAcceptanceFee_tbl { get; set; }
    public virtual ICollection<StudentInfo_tbl> StudentInfo_tbl { get; set; }
    public virtual ICollection<ProgrammeCourses_tbl> ProgrammeCourses_tbl { get; set; }
    public virtual ICollection<OfferedCourses_tbl> OfferedCourses_tbl { get; set; }
}

public partial class ProgrammeCourses_tbl
{
    public int ID { get; set; }
    public Nullable<int> ProgramID { get; set; }
    public Nullable<int> CourseID { get; set; }

    public virtual Program_tbl Program_tbl { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Questionaire_tbl
{
    public Questionaire_tbl()
    {
        this.Answers_tbl = new HashSet<Answers_tbl>();
    }

    public int Q_ID { get; set; }
    public string Question { get; set; }

    public virtual ICollection<Answers_tbl> Answers_tbl { get; set; }
}

public partial class Quizz_tbl
{
    public Quizz_tbl()
    {
        this.Student_Quizz_Mapping_tbl = new HashSet<Student_Quizz_Mapping_tbl>();
    }

    public int ID { get; set; }
    public string QuizzTitle { get; set; }
    public Nullable<System.DateTime> Quizz_date { get; set; }
    public Nullable<int> Total_Marks { get; set; }
    public Nullable<int> CourseID { get; set; }

    public virtual ICollection<Student_Quizz_Mapping_tbl> Student_Quizz_Mapping_tbl { get; set; }
    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Reference_Books_tbl
{
    public int ID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public string Reference_Book { get; set; }
    public string Description { get; set; }
    public string Book_path { get; set; }

    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Results_tbl
{
    public int ID { get; set; }
    public string MetricNo { get; set; }
    public Nullable<int> CourseID { get; set; }
    public Nullable<int> TotalMarks { get; set; }
    public Nullable<int> ObtainedMarks { get; set; }
    public string Year { get; set; }
    public string ExamType { get; set; }
    public Nullable<int> Semester { get; set; }
    public int GradeID { get; set; }

    public virtual Courses_tbl Courses_tbl { get; set; }
    public virtual Grades_tbl Grades_tbl { get; set; }
}

public partial class Screening_tbl
{
    public int Id { get; set; }
    public Nullable<int> AppID { get; set; }
    public string Result { get; set; }
    public Nullable<int> userID { get; set; }

    public virtual Applications_tbl Applications_tbl { get; set; }
    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class States_tbl
{
    public States_tbl()
    {
        this.Areas_tbl = new HashSet<Areas_tbl>();
        this.Candidate_tbl = new HashSet<Candidate_tbl>();
    }

    public int ID { get; set; }
    public string State { get; set; }
    public string Description { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual ICollection<Areas_tbl> Areas_tbl { get; set; }
    public virtual ICollection<Candidate_tbl> Candidate_tbl { get; set; }
}

public partial class Student_Quizz_Mapping_tbl
{
    public int ID { get; set; }
    public Nullable<int> StudentID { get; set; }
    public Nullable<int> QuizzID { get; set; }
    public Nullable<int> Mark_Obtained { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual Quizz_tbl Quizz_tbl { get; set; }
}

public partial class StudentAcceptanceFee_tbl
{
    public Nullable<int> Userid { get; set; }
    public Nullable<int> ProgramID { get; set; }
    public int ID { get; set; }
    public int Status { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
}

public partial class StudentInfo_tbl
{
    public StudentInfo_tbl()
    {
        this.CourseFee_tbl = new HashSet<CourseFee_tbl>();
        this.Discounts_tbl = new HashSet<Discounts_tbl>();
    }

    public int ID { get; set; }
    public Nullable<int> UserId { get; set; }
    public string StudentLevel { get; set; }
    public string AcadamicYear { get; set; }
    public string FeeDiscount { get; set; }
    public Nullable<int> ProgramID { get; set; }
    public Nullable<int> DeptID { get; set; }
    public Nullable<int> Semester { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual ICollection<CourseFee_tbl> CourseFee_tbl { get; set; }
    public virtual Department_tbl Department_tbl { get; set; }
    public virtual ICollection<Discounts_tbl> Discounts_tbl { get; set; }
    public virtual Program_tbl Program_tbl { get; set; }
}

public partial class StudentRoom_Mapping
{
    public int ID { get; set; }
    public int RomID { get; set; }
    public Nullable<int> StudentID { get; set; }
    public Nullable<int> Status { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
    public virtual HostelRoom_tbl HostelRoom_tbl { get; set; }
}

public partial class StudentSelectedCredit
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public Nullable<int> SelectedCourseCount { get; set; }
    public Nullable<System.DateTime> DateCreated { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class SubmittedAssignments_tbl
{
    public int ID { get; set; }
    public Nullable<int> AssignmentID { get; set; }
    public Nullable<int> StudentID { get; set; }
    public string AssginmentFile { get; set; }
    public Nullable<int> Status { get; set; }
    public Nullable<System.DateTime> SubmitDate { get; set; }

    public virtual Assignments_tbl Assignments_tbl { get; set; }
    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class Support_tbl
{
    public int ID { get; set; }
    public Nullable<int> UserID { get; set; }
    public string Question { get; set; }
    public Nullable<int> Status { get; set; }
    public string Answer { get; set; }
    public Nullable<System.DateTime> Date { get; set; }

    public virtual Candidate_tbl Candidate_tbl { get; set; }
}

public partial class sysdiagram
{
    public string name { get; set; }
    public int principal_id { get; set; }
    public int diagram_id { get; set; }
    public Nullable<int> version { get; set; }
    public byte[] definition { get; set; }
}

public partial class TimeTable_tbl
{
    public int ID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Day { get; set; }
    public string Teacher { get; set; }

    public virtual Courses_tbl Courses_tbl { get; set; }
}

public partial class Video_Lecture_tbl
{
    public int ID { get; set; }
    public Nullable<int> CourseID { get; set; }
    public string Video_Title { get; set; }
    public string VideoPath { get; set; }
    public string Thumbnails { get; set; }
    public string Duration { get; set; }
    public string Description { get; set; }
    public Nullable<System.DateTime> AddDate { get; set; }

    public virtual Courses_tbl Courses_tbl { get; set; }
}
