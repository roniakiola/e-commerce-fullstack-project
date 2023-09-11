using Domain.Abstraction.Repository;
using Domain.Entity;
using Infrastructure.Database;

namespace Infrastructure.Repository
{
  public class ProductRepository : BaseRepository<Product>, IProductRepository
  {
    public ProductRepository(DatabaseContext dbContext) : base(dbContext) { }

  }
}