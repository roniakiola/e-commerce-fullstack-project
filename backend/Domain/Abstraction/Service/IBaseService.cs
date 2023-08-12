namespace Domain.Abstraction.Service
{
  public interface IBaseService<T> where T : class
  {
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
  }
}