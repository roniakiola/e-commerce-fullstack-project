using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.AuthRequirement
{
  public class OwnerOrAdminReq : IAuthorizationRequirement { }

  public class OwnerOrAdminAuthHandler : AuthorizationHandler<OwnerOrAdminReq>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OwnerOrAdminAuthHandler(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerOrAdminReq requirement)
    {
      var authenticatedUserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var routeId = _httpContextAccessor.HttpContext.Request.RouteValues["id"]?.ToString();
      var role = context.User.FindFirst(ClaimTypes.Role)?.Value;

      if (routeId == authenticatedUserId || role == "Admin")
      {
        context.Succeed(requirement);
      }

      return Task.CompletedTask;
    }
  }
}