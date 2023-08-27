using Domain.Entity;

namespace Domain.Abstraction.Repository
{
  public interface IUserRepository : IBaseRepository<User>
  {
    Task<User> GetUserDetailsAsync(Guid id);
    Task<User> GetByUsernameAsync(string username);
  }
}