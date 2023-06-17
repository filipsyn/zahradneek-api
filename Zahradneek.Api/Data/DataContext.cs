using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Parcel> Parcels => Set<Parcel>();
    public DbSet<Coordinate> Coordinates => Set<Coordinate>();
    public DbSet<WaterLog> WaterLogs => Set<WaterLog>();
    public DbSet<News> News => Set<News>();
}