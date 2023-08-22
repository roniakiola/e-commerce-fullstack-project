using Application.Service.Abstraction;
using Application.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
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
      Console.WriteLine($"Controller: {id}");
      return await _userService.UpdateUserDetailsAsync(id, contactDetails);
    }
  }
}