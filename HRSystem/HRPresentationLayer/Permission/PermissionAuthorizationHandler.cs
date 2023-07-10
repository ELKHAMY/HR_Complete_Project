using Domain;
using Microsoft.AspNetCore.Authorization;

namespace HRPresentationLayer.Permission
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {
            
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, 
                                                       PermissionRequirement requirement)
        {
            if (context.User == null)
                return;
            var Permission = context.User.Claims
                .Where(c => c.Type == Helper.Permission && c.Value == requirement.Permission && c.Issuer == "LOCAL AUTHORITY");

            if (Permission.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
