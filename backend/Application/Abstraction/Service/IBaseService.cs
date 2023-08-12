namespace Application.Abstraction.Service
{
  public interface IBaseService<T, TCreateDto, TReadDto, TUpdateDto> where T : class
  {
    Task<List<TReadDto>> GetAllAsync();
    Task<TReadDto> GetByIdAsync(Guid id);
    Task<TReadDto> CreateAsync(TCreateDto entityDto);
    Task<TReadDto> UpdateAsync(Guid id, TUpdateDto entityDto);
    Task DeleteAsync(Guid id);
  }
}