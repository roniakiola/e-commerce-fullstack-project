using Domain.Entity;
using Application.Service.Abstraction;
using Domain.Abstraction.Repository;
using AutoMapper;
using Application.Dto;
using Application.Service.Implementation.Shared;

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

    public async override Task<UserReadDto> CreateAsync(UserCreateDto userCreateDto)
    {
      var entity = _mapper.Map<User>(userCreateDto);
      PasswordService.HashPassword(userCreateDto.Password, out var hashedPassword, out var salt);
      entity.Password = hashedPassword;
      entity.Salt = salt;
      var createdUser = await _userRepository.CreateAsync(entity);
      return _mapper.Map<UserReadDto>(createdUser);
    }

    public async override Task<UserReadDto> UpdateAsync(Guid id, UserUpdateDto userUpdateDto)
    {
      var foundUser = await _userRepository.GetByIdAsync(id);
      if (userUpdateDto.Password != null)
      {
        PasswordService.HashPassword(userUpdateDto.Password, out var hashedPassword, out var salt);
        userUpdateDto.Password = hashedPassword;
        userUpdateDto.Salt = salt;
      }
      _mapper.Map(userUpdateDto, foundUser);
      return _mapper.Map<UserReadDto>(await _userRepository.UpdateAsync(foundUser));
    }

    public async Task<UserReadDto> CreateAdminAsync(UserCreateDto userCreateDto)
    {
      var entity = _mapper.Map<User>(userCreateDto);
      PasswordService.HashPassword(userCreateDto.Password, out var hashedPassword, out var salt);
      entity.Password = hashedPassword;
      entity.Salt = salt;
      entity.Role = User.UserRole.Admin;
      var createdUser = await _userRepository.CreateAsync(entity);
      return _mapper.Map<UserReadDto>(createdUser);
    }
  }
}