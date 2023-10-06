using ChoirManager.Core.Abstractions;
using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Core.QueryOptions;

public class ChoirQueryOptions : IQueryOptions
{
    public int Page { get; set; }
    public int PerPage { get; set; }
}