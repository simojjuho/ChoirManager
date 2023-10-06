using System;

namespace ChoirManager.Core.Abstractions.CoreEntities;

public interface IChoir : IWithId
{
    string Name { get; set; }
    string Location { get; set; }
    DateOnly FoundedAt { get; set; }
}