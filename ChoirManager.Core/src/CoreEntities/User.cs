using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Core.CoreEntities;

public class User : IUser
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public ProfileStatus Status { get; set; }
    public string? VerificationToken { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}