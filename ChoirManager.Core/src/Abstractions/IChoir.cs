namespace ChoirManager.Core.Abstractions;

public interface IChoir : IWithId
{
    string Name { get; set; }
    string Location { get; set; }
    DateTime FoundedAt { get; set; }
}