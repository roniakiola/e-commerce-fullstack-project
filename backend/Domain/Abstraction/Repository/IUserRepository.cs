using Domain.Entity;

namespace Domain.Abstraction.Repository
{
  public interface IUserRepository : IBaseRepository<User>
  {
    Task<User> GetUserDetailsAsync(Guid id);
    Task<User> AddUserDetailsAsync(Guid id, UserContactDetails contactDetails);
    Task<User> UpdateUserDetailsAsync(Guid id, UserContactDetails contactDetails);
  }
}