using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.Commands.Assessment.CreateAssessment;
using Services.Commands.Attendance.CreateAttendance;
using Services.Commands.Class.CreateClass;
using Services.Commands.Company.CreateCompany;
using Services.Commands.Function.CreateFunction;
using Services.Commands.Instructor.CreateInstructor;
using Services.Commands.Polo.CreatePolo;
using Services.Commands.Student.CreateStudent;

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

        services.AddScoped<CreateInstructorCommandHandler>();
        services.AddScoped<CreateClassCommandHandler>();
        services.AddScoped<CreateCompanyCommandHandler>();
        services.AddScoped<CreatePoloCommandHandler>();
        services.AddScoped<CreateFunctionCommandHandler>();
        services.AddScoped<CreateStudentCommandHandler>();
        services.AddScoped<CreateAttendanceCommandHandler>();
        services.AddScoped<CreateAssessmentCommandHandler>();

        return services;
    }
}