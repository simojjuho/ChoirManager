using ChoirManager.Business.Abstractions;
namespace ChoirManager.Controllers.Controllers;

public class ControllerProperties<TGetDto, TCreateDto, TUpdateDto>
{
    protected readonly IBaseService<TGetDto, TCreateDto, TUpdateDto> _service;

    protected ControllerProperties(IBaseService<TGetDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }
}