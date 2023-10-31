using ChoirManager.Business.DTOs.UserDtos;

namespace ChoirManager.Business.Abstractions;

public interface IUserService : IBaseService<UserGetDto, UserCreateDto, UserUpdateDto>
{
    
}