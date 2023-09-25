using ChoirManager.Core.Abstractions;

namespace ChoirManager.Core.CoreEntities;

public class Choir : IChoir
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime FoundedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}