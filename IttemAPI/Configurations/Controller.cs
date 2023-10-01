using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace IttemAPI.Configurations;

public static class Controller
{
    public static IServiceCollection ConfigureController(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddFluentValidation(c =>
            {
                //c.RegisterValidatorsFromAssemblyContaining<TrainingValidator>();
                c.ValidatorOptions.DefaultClassLevelCascadeMode = CascadeMode.Stop;
            });

        services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        return services;
    }
}