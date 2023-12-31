using Domain.Entity;
using Application.Dto;

namespace Application.Service.Abstraction
{
  public interface IUserService : IBaseService<User, UserCreateDto, UserReadDto, UserUpdateDto>
  {
    Task<UserWithDetailsReadDto> GetUserDetailsAsync(Guid id);
    Task<UserWithDetailsReadDto> AddUserDetailsAsync(Guid id, UserContactDetailsDto contactDetails);
    Task<UserWithDetailsReadDto> UpdateUserDetailsAsync(Guid id, UserContactDetailsUpdateDto contactDetails);
    Task<bool> RemoveUserDetailsAsync(Guid id);
    Task<UserReadDto> CreateAdminAsync(UserCreateDto userCreateDto);
  }
}