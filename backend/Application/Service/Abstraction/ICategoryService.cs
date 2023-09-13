using Application.Dto;
using Domain.Entity;

namespace Application.Service.Abstraction
{
  public interface ICategoryService : IBaseService<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto> { }
}