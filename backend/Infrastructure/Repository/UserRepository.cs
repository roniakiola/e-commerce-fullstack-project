using Domain.Abstraction.Repository;
using Domain.Entity;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(DatabaseContext dbContext) : base(dbContext) { }

    public async Task<User?> GetByUsernameAsync(string username)
    {
      return await _dbSet.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User> GetUserDetailsAsync(Guid id)
    {
      return await _dbSet.Include(u => u.UserContactDetails)
        .FirstOrDefaultAsync(u => u.Id == id);
    }

  }
}