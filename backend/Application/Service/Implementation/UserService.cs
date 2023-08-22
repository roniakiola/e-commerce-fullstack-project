using Domain.Entity;
using Application.Service.Abstraction;
using Domain.Abstraction.Repository;
using AutoMapper;
using Application.Dto;

namespace Application.Service.Implementation
{
  public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
      _userRepository = userRepository;
    }

    public async Task<UserWithDetailsReadDto> AddUserDetailsAsync(Guid id, UserContactDetailsDto contactDetailsDto)
    {
      var contactDetails = _mapper.Map<UserContactDetails>(contactDetailsDto);
      var user = await _userRepository.GetUserDetailsAsync(id);
      if (user == null)
      {
        throw new Exception("User not found");
      }
      user.UserContactDetails = contactDetails;
      await _userRepository.UpdateAsync(user);

      return _mapper.Map<UserWithDetailsReadDto>(user);
    }

    public async Task<UserWithDetailsReadDto> GetUserDetailsAsync(Guid id)
    {
      return _mapper.Map<UserWithDetailsReadDto>(await _userRepository.GetUserDetailsAsync(id));
    }

    public async Task<UserWithDetailsReadDto> UpdateUserDetailsAsync(Guid id, UserContactDetailsUpdateDto contactDetailsUpdateDto)
    {
      var user = await _userRepository.GetUserDetailsAsync(id);
      if (user == null)
      {
        throw new Exception("User not found");
      }
      _mapper.Map(contactDetailsUpdateDto, user.UserContactDetails);
      var updatedUser = await _userRepository.UpdateAsync(user);

      return _mapper.Map<UserWithDetailsReadDto>(updatedUser);
    }

    public async Task<bool> RemoveUserDetailsAsync(Guid id)
    {
      var user = await _userRepository.GetUserDetailsAsync(id);
      if (user == null)
      {
        throw new Exception("User not found");
      }
      user.UserContactDetails = null;
      await _userRepository.UpdateAsync(user);
      return true;
    }
  }
}