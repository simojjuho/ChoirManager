using ChoirManager.Core.Abstractions;
using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Core.QueryOptions;

public class QueryOptions : IQueryOptions
{
    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 10;
    public bool OrderDesc { get; set; }
}