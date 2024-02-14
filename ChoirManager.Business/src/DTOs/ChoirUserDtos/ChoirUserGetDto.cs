using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Business.DTOs.UserDtos;
using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Business.DTOs.ChoirUserDtos;

public class ChoirUserGetDto
{
    public string MembershipId { get; set; }
    public MembershipStatus MembershipStatus { get; set; }
    public UserRole UserRole { get; set; }
    public VoiceRegisterThree RegisterThreeFold { get; set; }
    public VoiceRegisterFour RegisterFourFold { get; set; }
}