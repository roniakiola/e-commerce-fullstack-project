using Application.Abstraction.Service;
using Application.Dto;
using Domain.Entity;

namespace Presentation.Controller
{
  public class UserController : CrudController<User, UserCreateDto, UserReadDto, UserUpdateDto>
  {
    private readonly IUserService _userService;
    public UserController(IUserService userService) : base(userService)
    {
      _userService = userService;
    }
  }
}