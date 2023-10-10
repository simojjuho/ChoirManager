using ChoirManager.Core.CoreEntities;
using ChoirManger.Business.DTOs.ChoirDtos;

namespace ChoirManger.Business.Abstractions;

public interface IChoirService : IBaseService<ChoirGetDto, ChoirCreateDto, ChoirUpdateDto>
{
    
}