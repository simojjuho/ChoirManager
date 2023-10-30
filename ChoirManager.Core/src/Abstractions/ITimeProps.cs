using System;

namespace ChoirManager.Core.Abstractions;

public interface ITimeProps
{
    DateTimeOffset CreatedAt { get; set; }
    DateTimeOffset UpdatedAt { get; set; }
}