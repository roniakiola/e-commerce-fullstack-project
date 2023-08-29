using Application.Service.Abstraction;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
  [ApiController]
  [Route("api/[controller]s")]
  public class CrudController<T, TCreateDto, TReadDto, TUpdateDto> : ControllerBase where T : class
  {
    private readonly IBaseService<T, TCreateDto, TReadDto, TUpdateDto> _baseService;

    public CrudController(IBaseService<T, TCreateDto, TReadDto, TUpdateDto> baseService)
    {
      _baseService = baseService;
    }

    [HttpGet]
    public async virtual Task<ActionResult<List<TReadDto>>> GetAllAsync()
    {
      var list = await _baseService.GetAllAsync();

      if (list == null)
      {
        return NotFound();
      }
      return Ok(list);
    }

    [HttpGet("{id}")]
    public async virtual Task<ActionResult<TReadDto>> GetByIdAsync([FromRoute] Guid id)
    {
      var entity = await _baseService.GetByIdAsync(id);

      if (entity == null)
      {
        return NotFound();
      }
      return Ok(entity);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<TReadDto>> CreateAsync([FromBody] TCreateDto entityDto)
    {
      var entity = await _baseService.CreateAsync(entityDto);
      return Ok(entity);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<TReadDto>> UpdateAsync([FromRoute] Guid id, [FromBody] TUpdateDto entityDto)
    {
      var entity = await _baseService.UpdateAsync(id, entityDto);
      return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
      var entity = await _baseService.DeleteAsync(id);
      return Ok(entity);
    }

  }
}