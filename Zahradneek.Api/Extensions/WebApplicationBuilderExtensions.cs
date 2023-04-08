using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Npgsql;
using Zahradneek.Api.Data;
using Zahradneek.Api.Repositories.UserRepository;
using Zahradneek.Api.Services.UserService;

namespace Zahradneek.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Extension method where services are registered in one place without cluttering Program.cs
    /// </summary>
    /// <param name="builder">An instance of WebApplicationBuilder to which all of the services will be registered</param>
    /// <returns>An instance of builder with registered services</returns>
    /// <remarks>
    /// Because this is an extension method, the call of this method is as if this method was part of
    /// WebApplicationBuilder class.
    /// <code>
    /// var builder = WebApplicationBuilder();
    /// builder.RegisterServices();
    /// </code>
    /// </remarks>
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Zahradneek API",
                    Description = "👨🏻‍🌾 Server-side application for managing garden settlement",
                });
                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });
            }
        );
        builder.Services.AddSwaggerGenNewtonsoftSupport();
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(connectionString: GetConnectionString(builder))
        );
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        // Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // Services
        builder.Services.AddScoped<IUserService, UserService>();

        return builder;
    }

    private static string GetConnectionString(WebApplicationBuilder builder)
    {
        var connectionStringBuilder =
            new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("ZahradneekPg"));
        return connectionStringBuilder.ConnectionString;
    }
}