using System.Security.Claims;
using Application.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.AuthRequirement
{
  public class UserOnlyRequirement : IAuthorizationRequirement { }

  public class UserOnlyAuthorizationHandler : AuthorizationHandler<UserOnlyRequirement, UserReadDto>
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserOnlyRequirement requirement, UserReadDto resource)
    {
      var authenticatedUserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      if (resource.Id.ToString() == authenticatedUserId)
      {
        context.Succeed(requirement);
      }

      return Task.CompletedTask;
    }
  }
}