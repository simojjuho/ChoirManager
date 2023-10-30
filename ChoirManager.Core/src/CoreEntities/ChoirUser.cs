using System;
using System.ComponentModel.DataAnnotations.Schema;
using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChoirManager.Core.CoreEntities;

[PrimaryKey(nameof(ChoirId), nameof(UserId))]
public class ChoirUser : IChoirUser
{
    [ForeignKey(nameof(Choir))]
    public Guid ChoirId { get; set; }
    [NotMapped]
    public IChoir Choir { get; set; }
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    [NotMapped]
    public User User { get; set; }
    public MembershipStatus MembershipStatus { get; set; }
    public UserRole UserRole { get; set; }
    public VoiceRegisterThree RegisterThreeFold { get; set; }
    public VoiceRegisterFour RegisterFourFold { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}