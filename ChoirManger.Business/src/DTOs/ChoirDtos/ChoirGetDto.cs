using System;
using System.Collections.Generic;
using ChoirManager.Core.CoreEntities;
using ChoirManger.Business.DTOs.ChoirUserDtos;

namespace ChoirManger.Business.DTOs.ChoirDtos;

public class ChoirGetDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly FoundedAt { get; set; }
    public List<ChoirUserGetDto> ChoirUsers { get; set; }
}