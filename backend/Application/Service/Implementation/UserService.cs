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
      var userWithDetails = await _userRepository.AddUserDetailsAsync(id, contactDetails);

      return _mapper.Map<UserWithDetailsReadDto>(userWithDetails);
    }

    public async Task<UserWithDetailsReadDto> GetUserDetailsAsync(Guid id)
    {
      return _mapper.Map<UserWithDetailsReadDto>(await _userRepository.GetUserDetailsAsync(id));
    }

    public async Task<UserWithDetailsReadDto> UpdateUserDetailsAsync(Guid id, UserContactDetailsUpdateDto contactDetailsUpdateDto)
    {
      var contactDetails = _mapper.Map<UserContactDetails>(contactDetailsUpdateDto);

      return _mapper.Map<UserWithDetailsReadDto>(await _userRepository.UpdateUserDetailsAsync(id, contactDetails));
    }
  }
}