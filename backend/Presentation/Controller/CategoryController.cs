using Application.Dto;
using Application.Service.Abstraction;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
  [Authorize(Roles = "Admin")]
  [Route("api/categories")]
  public class CategoryController : CrudController<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>
  {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService) : base(categoryService)
    {
      _categoryService = categoryService;
    }
  }
}