using System;
using System.Collections.Generic;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.DTOs.ChoirDtos;

public class ChoirGetDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly FoundedAt { get; set; }
}