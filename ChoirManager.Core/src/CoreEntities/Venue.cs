using ChoirManager.Core.Abstractions;

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
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}