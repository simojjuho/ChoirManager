using AutoMapper;
using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Choir, ChoirGetDto>();
    }
}