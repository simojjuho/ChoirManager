using ChoirManager.Core.Abstractions.CoreEntities;

namespace ChoirManager.Core.CoreEntities;

public class Venue : IVenue
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
    public string Town { get; set; }
    public string ContactName { get; set; }
    public string ContactPhoneNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now.ToUniversalTime();
}