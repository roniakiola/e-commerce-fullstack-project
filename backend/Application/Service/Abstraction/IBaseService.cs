namespace Application.Service.Abstraction
{
  public interface IBaseService<T, TCreateDto, TReadDto, TUpdateDto> where T : class
  {
    Task<List<TReadDto>> GetAllAsync();
    Task<TReadDto> GetByIdAsync(Guid id);
    Task<TReadDto> CreateAsync(TCreateDto entityDto);
    Task<TReadDto> UpdateAsync(Guid id, TUpdateDto entityDto);
    Task<bool> DeleteAsync(Guid id);
  }
}