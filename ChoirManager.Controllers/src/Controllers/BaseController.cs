using ChoirManager.Business.Abstractions;
namespace ChoirManager.Controllers.Controllers;

public class BaseController<TGetDto, TCreateDto, TUpdateDto>
{
    protected readonly IBaseService<TGetDto, TCreateDto, TUpdateDto> _service;

    protected BaseController(IBaseService<TGetDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }
}