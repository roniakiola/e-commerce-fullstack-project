using Application.Dto;
using Application.Service.Abstraction;
using Domain.Entity;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
  [Authorize(Roles = "Admin")]
  public class ProductController : CrudController<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService) : base(productService)
    {
      _productService = productService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async override Task<ActionResult<List<ProductReadDto>>> GetAllAsync()
    {
      return await _productService.GetAllAsync();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async override Task<ActionResult<ProductReadDto>> GetByIdAsync([FromRoute] Guid id)
    {
      var product = await _productService.GetByIdAsync(id);

      if (product == null)
      {
        return NotFound();
      }
      return Ok(product);
    }

    [HttpGet("query")]
    [AllowAnonymous]
    public async Task<ActionResult<List<ProductReadDto>>> GetByQueryAsync([FromQuery] QueryOptions queryOptions)
    {
      return await _productService.GetByQueryAsync(queryOptions);
    }
  }
}