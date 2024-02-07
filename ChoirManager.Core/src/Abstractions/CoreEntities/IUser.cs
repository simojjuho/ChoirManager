using ChoirManager.Core.Enums;

namespace ChoirManager.Core.Abstractions.CoreEntities;

public interface IUser : IWithId
{
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string Email { get; set; }
    string? PhoneNumber { get; set; }
    ProfileStatus Status { get; set; }
    string? VerificationToken { get; set; }
}