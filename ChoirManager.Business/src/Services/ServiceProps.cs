using AutoMapper;
using ChoirManager.Core.Abstractions.Repositories;

namespace ChoirManager.Business.Services;

public class ServiceProps<T>
{
    protected readonly IBaseRepository<T> _repository;
    protected readonly IMapper _mapper;

    public ServiceProps(IBaseRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}