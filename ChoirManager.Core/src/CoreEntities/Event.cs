using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Core.CoreEntities;

public class Event : IEvent
{
    public Guid Id { get; set; }
    public Guid ChoirId { get; set; }
    public Guid VenueId { get; set; }
    public EventType EventType { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime? EndingTime { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}