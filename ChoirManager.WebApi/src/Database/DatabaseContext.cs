using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;

namespace ChoirManager.WebApi.Database;
using ChoirManager.Core.CoreEntities;


public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly IEnumerable<IInterceptor> _interceptors;
    public DbSet<Choir> Choirs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<ChoirUser> ChoirUsers { get; set; }

    public DatabaseContext(DbContextOptions options, IConfiguration configuration, IEnumerable<IInterceptor> interceptors) : base(options)
    {
        _configuration = configuration;
        _interceptors = interceptors;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_interceptors.Any())
        {
            optionsBuilder.AddInterceptors(_interceptors);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasAlternateKey(key => key.Email);
    }
}