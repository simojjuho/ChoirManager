namespace ChoirManager.Core.Abstractions;

public interface IVenue : IWithId
{
    string Name { get; set; }
    string StreetAddress { get; set; }
    string ZipCode { get; set; }
    string Town { get; set; }
    string ContactName { get; set; }
    string ContactPhoneNumber { get; set; }
}