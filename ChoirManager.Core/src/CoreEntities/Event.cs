using System.ComponentModel.DataAnnotations;
using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Core.CoreEntities;

public class Event : IEvent
{
    [Key]
    public Guid Id { get; set; }
    public Guid ChoirId { get; set; }
    public Choir Choir { get; set; }
    public Guid VenueId { get; set; }
    public Venue Venue { get; set; }
    public EventType EventType { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime? EndingTime { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
}