using Domain.Abstraction.Repository;
using Domain.Entity;
using Infrastructure.Database;

namespace Infrastructure.Repository
{
  public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
  {
    public CategoryRepository(DatabaseContext dbContext) : base(dbContext) { }
  }
}