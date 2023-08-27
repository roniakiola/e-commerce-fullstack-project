using Application.Dto;

namespace Application.Service.Abstraction
{
  public interface IAuthService
  {
    Task<string> VerifyCredentialsAsync(UserCredentials userCredentials);
  }
}