using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Filters;
using Zahradneek.Api.Authorization;
using Zahradneek.Api.Authorization.Handlers;
using Zahradneek.Api.Authorization.Requirements;
using Zahradneek.Api.Data;
using Zahradneek.Api.Repositories.CoordinateRepository;
using Zahradneek.Api.Repositories.NewsRepository;
using Zahradneek.Api.Repositories.ParcelRepository;
using Zahradneek.Api.Repositories.UserRepository;
using Zahradneek.Api.Repositories.WaterLogRepository;
using Zahradneek.Api.Services.AuthService;
using Zahradneek.Api.Services.CoordinateService;
using Zahradneek.Api.Services.NewsService;
using Zahradneek.Api.Services.ParcelService;
using Zahradneek.Api.Services.UserService;
using Zahradneek.Api.Services.WaterLogService;

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
        builder.Services.AddProblemDetails();
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
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard authorization header using the Bearer scheme",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            }
        );
        builder.Services.AddSwaggerGenNewtonsoftSupport();
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseMySQL(connectionString: GetConnectionString(builder))
        );
        builder.Services.AddHealthChecks();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Token").Value!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(AuthorizationPolicies.ParcelOwnerOrAdmin, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.Requirements.Add(new ParcelOwnerOrAdminRequirement());
            });

            options.AddPolicy(AuthorizationPolicies.SelfOrAdmin, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.Requirements.Add(new SelfOrAdminRequirement());
            });

            //TODO: Add policies
        });

        // Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IParcelRepository, ParcelRepository>();
        builder.Services.AddScoped<ICoordinateRepository, CoordinateRepository>();
        builder.Services.AddScoped<IWaterLogRepository, WaterLogRepository>();
        builder.Services.AddScoped<INewsRepository, NewsRepository>();

        // Services
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IParcelService, ParcelService>();
        builder.Services.AddScoped<ICoordinateService, CoordinateService>();
        builder.Services.AddScoped<IWaterLogService, WaterLogService>();
        builder.Services.AddScoped<INewsService, NewsService>();

        // Policy handlers
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IAuthorizationHandler, ParcelOwnerOrAdminAuthorizationHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, SelfOrAdminAuthorizationHandler>();
        //TODO: Register policy handlers


        return builder;
    }

    private static string GetConnectionString(WebApplicationBuilder builder)
    {
        var connectionStringBuilder =
            // new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("ZahradneekPg"));
            new MySqlConnectionStringBuilder(builder.Configuration.GetConnectionString("ZahradneekMySQL"));
        return connectionStringBuilder.ConnectionString;
    }
}