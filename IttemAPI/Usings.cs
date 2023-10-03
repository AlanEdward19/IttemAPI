#region Services

global using Services.Auth;
global using Services.Commands.Assessment.CreateAssessment;
global using Services.Commands.Attendance.CreateAttendance;
global using Services.Commands.Class.CreateClass;
global using Services.Commands.Company.CreateCompany;
global using Services.Commands.Function.CreateFunction;
global using Services.Commands.Instructor.CreateInstructor;
global using Services.Commands.Polo.CreatePolo;
global using Services.Commands.Student.CreateStudent;
global using Services.Commands.Student.DeleteStudent;
global using Services.Queries.Assessment.GetAssessment;
global using Services.Queries.Attendance.GetAttendance;
global using Services.Queries.Class.GetClass;
global using Services.Queries.Company.GetCompany;
global using Services.Queries.Function.GetFunction;
global using Services.Queries.Instructor.GetInstructor;
global using Services.Queries.Login;
global using Services.Queries.Polo.GetPolo;
global using Services.Queries.Student.GetStudent;
global using Services.Commands.Assessment.DeleteAssessment;

#endregion

#region Domain

global using Domain.Interfaces;

#endregion

#region Infrastructure

global using Infrastructure.Context;

#endregion