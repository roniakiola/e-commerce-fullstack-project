using Domain.Entity;
using Domain.Shared;

namespace Domain.Abstraction.Repository
{
  public interface IProductRepository : IBaseRepository<Product>
  {
    Task<List<Product>> GetByQueryAsync(QueryOptions queryOptions);
  }
}