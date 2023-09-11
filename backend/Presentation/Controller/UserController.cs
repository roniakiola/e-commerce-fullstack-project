using Application.Service.Abstraction;
using Application.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controller
{
  [Authorize(Policy = "OwnerOrAdmin")]
  public class UserController : CrudController<User, UserCreateDto, UserReadDto, UserUpdateDto>
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService) : base(userService)
    {
      _userService = userService;
    }

    [HttpPost("{id}/details")]
    public async Task<ActionResult<UserWithDetailsReadDto>> AddUserDetailsAsync(Guid id, [FromBody] UserContactDetailsDto contactDetails)
    {
      return await _userService.AddUserDetailsAsync(id, contactDetails);
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<UserWithDetailsReadDto>> GetUserDetailsAsync(Guid id)
    {
      return await _userService.GetUserDetailsAsync(id);
    }

    [HttpPatch("{id}/details")]
    public async Task<ActionResult<UserWithDetailsReadDto>> UpdateUserDetailsAsync(Guid id, UserContactDetailsUpdateDto contactDetails)
    {
      return await _userService.UpdateUserDetailsAsync(id, contactDetails);
    }

    [HttpDelete("{id}/details")]
    public async Task<ActionResult<bool>> RemoveUserDetailsAsync(Guid id)
    {
      return await _userService.RemoveUserDetailsAsync(id);
    }

    [HttpPost("admin")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserReadDto>> CreateAdminAsync(UserCreateDto userCreateDto)
    {
      return await _userService.CreateAdminAsync(userCreateDto);
    }

    [HttpPost]
    [AllowAnonymous]
    public async override Task<ActionResult<UserReadDto>> CreateAsync(UserCreateDto userCreateDto)
    {
      return await _userService.CreateAsync(userCreateDto);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async override Task<ActionResult<List<UserReadDto>>> GetAllAsync()
    {
      return await _userService.GetAllAsync();
    }
  }
}