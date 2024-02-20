using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Controllers.Abstractions;

public interface IChoirUserController : IWithRegularGetMany<ChoirUserGetDto, ChoirUserCreateDto, ChoirUserUpdateDto>
{
    
}