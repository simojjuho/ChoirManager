using AutoMapper;
using ChoirManager.Core.CoreEntities;
using ChoirManger.Business.DTOs.ChoirDtos;

namespace ChoirManger.Business.DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Choir, ChoirGetDto>();
    }
}