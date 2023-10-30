using System;
using System.Collections.Generic;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Core.Abstractions.CoreEntities;

public interface IChoir : IWithId
{
    string Name { get; set; }
    string Location { get; set; }
    DateOnly FoundedAt { get; set; }
    public List<ChoirUser> ChoirUsers { get; set; }
}