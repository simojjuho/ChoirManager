using ChoirManager.Core.Abstractions;
using ChoirManager.Core.Enums;

namespace ChoirManager.Core.CoreEntities;

public class ChoirUser : IChoirUser
{
    public Guid ChoirId { get; set; }
    public Guid UserId { get; set; }
    public MembershipStatus MembershipStatus { get; set; }
    public UserRole UserRole { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}