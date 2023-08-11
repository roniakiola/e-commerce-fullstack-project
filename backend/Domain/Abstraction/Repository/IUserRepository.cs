using Domain.Entity;

namespace Domain.Abstraction.Repository
{
  public interface IUserRepository : IBaseRepository<User>
  {
    User GetById(Guid id);
  }
}