using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.Abstractions;

public interface IChoirService : IBaseService<ChoirGetDto, ChoirCreateDto, ChoirUpdateDto>
{
    
}