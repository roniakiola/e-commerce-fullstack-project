using Domain.Entity;
using Application.Abstraction.Service;
using Domain.Abstraction.Repository;
using AutoMapper;
using Application.Dto;

namespace Application.Service
{
  public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
      _userRepository = userRepository;
    }

    public async Task<User> AddUserDetailsAsync(Guid id, UserContactDetails contactDetails)
    {
      var user = await _userRepository.AddUserDetailsAsync(id, contactDetails);
      return user;
    }

    public async Task<User> GetUserDetailsAsync(Guid id)
    {
      return await _userRepository.GetUserDetailsAsync(id);
    }

    public async Task<User> UpdateUserDetailsAsync(Guid id, UserContactDetails contactDetails)
    {
      throw new NotImplementedException();
    }
  }
}