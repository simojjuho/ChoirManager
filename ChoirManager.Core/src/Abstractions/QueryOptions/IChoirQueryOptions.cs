namespace ChoirManager.Core.Abstractions.QueryOptions;

public interface IChoirQueryOptions : IQueryOptions
{
    string Filter { get; set; }
    bool GroupDesc { get; set; }
}