using Domain.Abstraction.Repository;
using Domain.Abstraction.Service;

namespace Application.Service
{
  public class BaseService<T> : IBaseService<T> where T : class
  {
    protected readonly IBaseRepository<T> _repository;

    public BaseService(IBaseRepository<T> repository)
    {
      _repository = repository;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
      return await _repository.GetByIdAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
      await _repository.CreateAsync(entity);
      return entity;
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
      await _repository.UpdateAsync(entity);
      return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
      var entity = await _repository.GetByIdAsync(id);
      if (entity != null)
      {
        await _repository.DeleteAsync(entity);
      }
    }
  }
}