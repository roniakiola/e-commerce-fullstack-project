using Application.Dto;
using Application.Service.Abstraction;
using AutoMapper;
using Domain.Abstraction.Repository;
using Domain.Entity;

namespace Application.Service.Implementation
{
  public class CategoryService : BaseService<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>, ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper)
    {
      _categoryRepository = categoryRepository;
    }
  }
}