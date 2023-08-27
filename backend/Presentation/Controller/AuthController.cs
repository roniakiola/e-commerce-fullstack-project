using Application.Dto;
using Application.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> VerifyCredentialsAsync([FromBody] UserCredentials userCredentials)
    {
      return Ok(await _authService.VerifyCredentialsAsync(userCredentials));
    }
  }
}