namespace ChoirManager.Core.Abstractions.QueryOptions;

public interface IQueryOptions
{
    int Page { get; set; }
    int PerPage { get; set; }
}