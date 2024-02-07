using ChoirManager.Business.DTOs.UserDtos;

namespace ChoirManager.Controllers.Abstractions;

public interface IUserController : IWithRegularGetMany<UserGetDto, UserCreateDto, UserUpdateDto>
{
    
}