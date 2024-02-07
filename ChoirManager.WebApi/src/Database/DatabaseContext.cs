using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.Enums;

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
        modelBuilder.Entity<User>()
            .Property(e => e.Status)
            .HasConversion(
                v => v.ToString(),
                v => (ProfileStatus)Enum.Parse(typeof(ProfileStatus), v)
                );
        modelBuilder.Entity<ChoirUser>()
            .Property(e => e.UserRole)
            .HasConversion(
                v => v.ToString(),
                v => (UserRole)Enum.Parse(typeof(UserRole), v)
            );
        modelBuilder.Entity<ChoirUser>()
            .Property(e => e.MembershipStatus)
            .HasConversion(
                v => v.ToString(),
                v => (MembershipStatus)Enum.Parse(typeof(MembershipStatus), v)
            );
        modelBuilder.Entity<ChoirUser>()
            .Property(e => e.RegisterThreeFold)
            .HasConversion(
                v => v.ToString(),
                v => (VoiceRegisterThree)Enum.Parse(typeof(VoiceRegisterThree), v)
            );
        modelBuilder.Entity<ChoirUser>()
            .Property(e => e.RegisterFourFold)
            .HasConversion(
                v => v.ToString(),
                v => (VoiceRegisterFour)Enum.Parse(typeof(VoiceRegisterFour), v)
            );
        modelBuilder.Entity<Event>()
            .Property(e => e.EventType)
            .HasConversion(
                v => v.ToString(),
                v => (EventType)Enum.Parse(typeof(EventType), v)
            );

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