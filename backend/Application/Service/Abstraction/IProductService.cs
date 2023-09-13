using Application.Dto;
using Domain.Entity;
using Domain.Shared;

namespace Application.Service.Abstraction
{
  public interface IProductService : IBaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>
  {
    Task<List<ProductReadDto>> GetByQueryAsync(QueryOptions queryOptions);
  }
}