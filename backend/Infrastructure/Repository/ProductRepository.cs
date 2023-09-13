using Domain.Abstraction.Repository;
using Domain.Entity;
using Domain.Shared;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
  public class ProductRepository : BaseRepository<Product>, IProductRepository
  {
    public ProductRepository(DatabaseContext dbContext) : base(dbContext) { }

    public async Task<List<Product>> GetByQueryAsync(QueryOptions queryOptions)
    {
      var query = _dbSet.AsQueryable();

      if (!string.IsNullOrWhiteSpace(queryOptions.Search))
      {
        query = query.Where(p => p.Name.ToLower().Contains(queryOptions.Search.ToLower()));
      }
      switch (queryOptions.OrderBy)
      {
        case "Price":
          query = queryOptions.OrderByDescending
            ? query.OrderByDescending(p => p.Price)
            : query.OrderBy(p => p.Price);
          break;

        default:
          query = queryOptions.OrderByDescending
                ? query.OrderByDescending(p => p.CreatedAt)
                : query.OrderBy(p => p.CreatedAt);
          break;
      }
      query = query.Skip((queryOptions.PageNumber - 1) * queryOptions.PerPage).Take(queryOptions.PerPage);

      return await query.ToListAsync();
    }
  }
}