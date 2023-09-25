using ChoirManager.Core.Enums;

namespace ChoirManager.Core.Abstractions;

public interface IEvent : IWithId
{
    Guid ChoirId { get; set; }
    Guid VenueId { get; set; }
    EventType EventType { get; set; }
    DateTime StartingTime { get; set; }
    DateTime? EndingTime { get; set; }
    string? Description { get; set; }
}