using ChoirManager.Core.Abstractions;
using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Core.QueryOptions;

public class ChoirQueryOptions : IChoirQueryOptions
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string Filter { get; set; }
    public bool GroupDesc { get; set; }
}