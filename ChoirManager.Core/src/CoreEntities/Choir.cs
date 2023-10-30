using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChoirManager.Core.Abstractions.CoreEntities;

namespace ChoirManager.Core.CoreEntities;

public class Choir : IChoir
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly FoundedAt { get; set; }
    [NotMapped]
    public List<ChoirUser> ChoirUsers { get; set; } 
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
}