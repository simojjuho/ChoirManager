using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Business.DTOs.UserDtos;
using ChoirManager.Core.Enums;

namespace ChoirManager.Business.DTOs.ChoirUserDtos;

public class ChoirUserUpdateDto
{
    public MembershipStatus MembershipStatus { get; set; }
    public UserRole UserRole { get; set; }
    public VoiceRegisterThree RegisterThreeFold { get; set; }
    public VoiceRegisterFour RegisterFourFold { get; set; }
}