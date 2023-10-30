using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Core.CoreEntities;

public class User : IUser
{
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public ProfileStatus Status { get; set; }
    [NotMapped]
    public List<ChoirUser> ChoirUsers { get; set; }
    public string? VerificationToken { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
}