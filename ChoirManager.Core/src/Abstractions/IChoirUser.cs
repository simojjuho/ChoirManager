using ChoirManager.Core.Enums;

namespace ChoirManager.Core.Abstractions;

public interface IChoirUser : ITimeProps
{
    Guid ChoirId { get; set; }
    Guid UserId { get; set; }
    MembershipStatus MembershipStatus { get; set; }
    UserRole UserRole { get; set; }
}