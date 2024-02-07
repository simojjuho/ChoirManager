using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.WebApi.Database;

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
    
    static DatabaseContext()
    {
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_interceptors.Any())
        {
            optionsBuilder
                .AddInterceptors(_interceptors);
        }
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(property => property.Email);
        modelBuilder.Entity<Choir>()
            .HasIndex(property => property.Name);
        modelBuilder.Entity<ChoirUser>()
            .HasAlternateKey(e => e.MembershipId)
            .HasName("choir_user_membership_alt_key");
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                if (property.ClrType == typeof(Guid) && property.Name == "Id")
                {
                    property.SetValueGeneratorFactory((_, __) => new SequentialGuidValueGenerator());
                }
            }
        }
    }
}