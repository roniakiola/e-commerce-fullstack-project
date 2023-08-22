using Domain.Shared;

namespace Domain.Abstraction.Repository
{
  public interface IBaseRepository<T> where T : class
  {
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
  }
}