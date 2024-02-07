using AutoMapper;
using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Business.DTOs.UserDtos;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Choir, ChoirGetDto>();
        CreateMap<ChoirCreateDto, Choir>();
        CreateMap<ChoirUpdateDto, Choir>();
        CreateMap<User, UserGetDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();
    }
}