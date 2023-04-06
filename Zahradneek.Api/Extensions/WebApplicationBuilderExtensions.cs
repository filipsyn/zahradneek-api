using Microsoft.EntityFrameworkCore;
using Npgsql;
using Zahradneek.Api.Data;

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
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(connectionString: GetConnectionString(builder))
        );

        return builder;
    }

    private static string GetConnectionString(WebApplicationBuilder builder)
    {
        var connectionStringBuilder =
            new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("ZahradneekPg"));
        return connectionStringBuilder.ConnectionString;
    }
}