using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChoirManager.Core.Abstractions.CoreEntities;

namespace ChoirManager.Core.CoreEntities;

public class Choir : IChoir
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly FoundedAt { get; set; }
    public List<ChoirUser> ChoirUsers { get; set; } = new List<ChoirUser>(); 
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}