using AutoMapper;
using Domain.Abstraction.Repository;
using Application.Service.Abstraction;

namespace Application.Service.Implementation
{
  public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TCreateDto, TReadDto, TUpdateDto> where T : class
  {
    protected readonly IBaseRepository<T> _repository;
    protected readonly IMapper _mapper;

    public BaseService(IBaseRepository<T> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<TReadDto> GetByIdAsync(Guid id)
    {
      return _mapper.Map<TReadDto>(await _repository.GetByIdAsync(id));
    }

    public async Task<List<TReadDto>> GetAllAsync()
    {
      return _mapper.Map<List<TReadDto>>(await _repository.GetAllAsync());
    }

    public async Task<TReadDto> CreateAsync(TCreateDto entityDto)
    {
      var entity = _mapper.Map<T>(entityDto);
      return _mapper.Map<TReadDto>(await _repository.CreateAsync(entity));
    }

    public async Task<TReadDto> UpdateAsync(Guid id, TUpdateDto entityDto)
    {
      var entity = await _repository.GetByIdAsync(id);
      if (entity == null)
      {
        throw new Exception("Entity not found");
      }

      var entityType = entity.GetType();
      var dtoType = entityDto.GetType();

      foreach (var dtoProperty in dtoType.GetProperties())
      {
        var entityProperty = entityType.GetProperty(dtoProperty.Name);
        if (entityProperty != null)
        {
          var dtoValue = dtoProperty.GetValue(entityDto);
          if (dtoValue != null)
          {
            entityProperty.SetValue(entity, dtoValue);
          }
        }
      }
      return _mapper.Map<TReadDto>(await _repository.UpdateAsync(entity));
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
      var entity = await _repository.GetByIdAsync(id);
      if (entity == null)
      {
        return false;
      }
      return await _repository.DeleteAsync(entity);
    }
  }
}