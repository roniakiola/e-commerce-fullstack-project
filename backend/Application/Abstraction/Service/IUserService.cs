using Domain.Entity;
using Application.Dto;

namespace Application.Abstraction.Service
{
  public interface IUserService : IBaseService<User, UserCreateDto, UserReadDto, UserUpdateDto>
  {
    Task<User> GetUserDetailsAsync(Guid id);
    Task<User> AddUserDetailsAsync(Guid id, UserContactDetails contactDetails);
    Task<User> UpdateUserDetailsAsync(Guid id, UserContactDetails contactDetails);
  }
}