using Domain.Abstraction.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly DatabaseContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DatabaseContext dbContext)
    {
      _context = dbContext;
      _dbSet = dbContext.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
      _dbSet.Update(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
      _dbSet.Remove(entity);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}