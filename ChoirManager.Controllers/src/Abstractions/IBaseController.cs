using Microsoft.AspNetCore.Mvc;

namespace ChoirManager.Controllers.Abstractions;

public interface IBaseController<TGetDto, TCreateDto, TUpdateDtp>
{
    Task<ActionResult<TGetDto>> GetOneAsync(string altKey);
    Task<ActionResult<TGetDto>> CreateOneAsync(TCreateDto choirCreateDto);
    Task<ActionResult<TGetDto>> UpdateOneAsync(string altKey, TUpdateDtp choirUpdateDto);
    Task<ActionResult<bool>> RemoveOneAsync([FromRoute] string altKey);
}