using Application.Dto;
using Domain.Entity;

namespace Application.Service.Abstraction
{
  public interface IProductService : IBaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto> { }
}