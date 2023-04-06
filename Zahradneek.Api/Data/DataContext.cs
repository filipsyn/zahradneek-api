using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    private DbSet<User> Users => Set<User>();
}