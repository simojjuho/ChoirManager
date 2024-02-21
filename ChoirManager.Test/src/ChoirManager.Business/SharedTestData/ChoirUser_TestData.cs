using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Test.ChoirManager.Business.SharedTestData;

public static class ChoirUserTestData
{
    public static ChoirUserGetDto ChoirUserGetDto =>
        new()
        {
            MembershipId = "Kris24-5367-453",
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

    public static ChoirUserUpdateDto ChoirUserWithUpdate =>
        new()
        {
            MembershipStatus = MembershipStatus.Active,
            UserRole = UserRole.Leader,
            RegisterThreeFold = VoiceRegisterThree.Bass,
            RegisterFourFold = VoiceRegisterFour.BassOne
        };
}