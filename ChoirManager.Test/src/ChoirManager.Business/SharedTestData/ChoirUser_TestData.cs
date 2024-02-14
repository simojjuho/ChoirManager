using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Test.ChoirManager.Business.SharedTestData;

public static class ChoirUser_TestData
{
    public static ChoirUserGetDto ChoirUserGetDto =>
        new()
        {
            MembershipStatus = MembershipStatus.Pending,
            UserRole = UserRole.Member,
            RegisterThreeFold = VoiceRegisterThree.Unknown,
            RegisterFourFold = VoiceRegisterFour.Unknown
        };

    public static ChoirUserCreateDto ChoirUserCreateDto =>
        new()
        {
            ChoirName = "Kristalli",
            UserEmail = "new@user.fi"
        };

    public static ChoirUser ChoirUser =>
        new()
        {
            ChoirId = new Guid(),
            UserId = new Guid(),
            MembershipId = "Krist20234",
            MembershipStatus = MembershipStatus.Pending,
            UserRole = UserRole.Member,
            RegisterThreeFold = VoiceRegisterThree.Unknown,
            RegisterFourFold = VoiceRegisterFour.Unknown,
            CreatedAt = DateTimeOffset.Now.ToUniversalTime(),
            UpdatedAt = DateTimeOffset.Now.ToUniversalTime()
        };
}