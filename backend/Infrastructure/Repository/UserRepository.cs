using Domain.Abstraction.Repository;
using Domain.Entity;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(DatabaseContext dbContext) : base(dbContext) { }

    public async Task<User> GetUserDetailsAsync(Guid id)
    {
      return await _dbSet.Include(u => u.UserContactDetails)
        .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> AddUserDetailsAsync(Guid id, UserContactDetails contactDetails)
    {
      var user = await GetByIdAsync(id);
      if (user != null)
      {
        user.UserContactDetails = contactDetails;
        await _context.SaveChangesAsync();
      }
      return user;
    }

    public async Task<User> UpdateUserDetailsAsync(Guid id, UserContactDetails contactDetails)
    {
      throw new NotImplementedException();
    }

  }
}