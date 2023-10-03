﻿using System.Text;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Auth;
using Services.Commands.Assessment.CreateAssessment;
using Services.Commands.Attendance.CreateAttendance;
using Services.Commands.Class.CreateClass;
using Services.Commands.Company.CreateCompany;
using Services.Commands.Function.CreateFunction;
using Services.Commands.Instructor.CreateInstructor;
using Services.Commands.Polo.CreatePolo;
using Services.Commands.Student.CreateStudent;
using Services.Commands.Student.DeleteStudent;
using Services.Queries.Assessment.GetAssessment;
using Services.Queries.Attendance.GetAttendance;
using Services.Queries.Class.GetClass;
using Services.Queries.Company.GetCompany;
using Services.Queries.Function.GetFunction;
using Services.Queries.Instructor.GetInstructor;
using Services.Queries.Login;
using Services.Queries.Polo.GetPolo;
using Services.Queries.Student.GetStudent;

namespace IttemAPI.Configurations;

public static class Service
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IttemContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));

        #region CORS

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        #endregion

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<CreateInstructorCommandHandler>();
        services.AddScoped<CreateClassCommandHandler>();
        services.AddScoped<CreateCompanyCommandHandler>();
        services.AddScoped<CreatePoloCommandHandler>();
        services.AddScoped<CreateFunctionCommandHandler>();
        services.AddScoped<CreateStudentCommandHandler>();
        services.AddScoped<CreateAttendanceCommandHandler>();
        services.AddScoped<CreateAssessmentCommandHandler>();

        services.AddScoped<DeleteStudentCommandHandler>();

        services.AddScoped<LoginQueryHandler>();

        services.AddScoped<GetAssessmentQueryHandler>();
        services.AddScoped<GetAttendanceQueryHandler>();
        services.AddScoped<GetClassQueryHandler>();
        services.AddScoped<GetCompanyQueryHandler>();
        services.AddScoped<GetFunctionQueryHandler>();
        services.AddScoped<GetInstructorQueryHandler>();
        services.AddScoped<GetPoloQueryHandler>();
        services.AddScoped<GetStudentQueryHandler>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        return services;
    }
}