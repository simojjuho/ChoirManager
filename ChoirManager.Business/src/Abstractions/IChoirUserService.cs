using ChoirManager.Business.DTOs.ChoirUserDtos;

namespace ChoirManager.Business.Abstractions;

public interface IChoirUserService : IBaseService<ChoirUserGetDto, ChoirUserCreateDto, ChoirUserUpdateDto>
{
    
}