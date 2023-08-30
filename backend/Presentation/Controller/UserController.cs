using Application.Service.Abstraction;
using Application.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controller
{
  [Authorize]
  public class UserController : CrudController<User, UserCreateDto, UserReadDto, UserUpdateDto>
  {
    private readonly IUserService _userService;
    private readonly IAuthorizationService _authorizationService;

    public UserController(IUserService userService, IAuthorizationService authorizationSerivce) : base(userService)
    {
      _userService = userService;
      _authorizationService = authorizationSerivce;
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

    [HttpPost("/admin")]
    public async Task<ActionResult<UserReadDto>> CreateAdminAsync(UserCreateDto userCreateDto)
    {
      return await _userService.CreateAdminAsync(userCreateDto);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async override Task<ActionResult<List<UserReadDto>>> GetAllAsync()
    {
      return await _userService.GetAllAsync();
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "UserOnly")]
    public async override Task<ActionResult<UserReadDto>> GetByIdAsync([FromRoute] Guid id)
    {
      var entity = await _userService.GetByIdAsync(id);

      if (entity == null)
      {
        return NotFound();
      }
      return Ok(entity);
    }
  }
}