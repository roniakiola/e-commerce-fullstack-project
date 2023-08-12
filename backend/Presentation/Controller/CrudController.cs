using Application.Abstraction.Service;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<TReadDto>> GetByIdAsync(Guid id)
    {
      var entity = await _baseService.GetByIdAsync(id);

      if (entity == null)
      {
        return NotFound();
      }
      return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<TReadDto>> CreateAsync(TCreateDto entityDto)
    {
      var entity = await _baseService.CreateAsync(entityDto);
      return Ok(entity);
    }

  }
}