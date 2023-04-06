using Microsoft.EntityFrameworkCore;
using Npgsql;
using Zahradneek.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Retrieving connection string
var connectionStringBuilder =
    new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("ZahradneekPg"));
var connectionString = connectionStringBuilder.ConnectionString;

// Registering services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString: connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();