using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.BusinessLogic.Policy.Users
{
    public class ViewOwnUserInfoRequirement : IAuthorizationRequirement
    {
    }

    public class ViewOwnUserInfoHandler : AuthorizationHandler<ViewOwnUserInfoRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ViewOwnUserInfoHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ViewOwnUserInfoRequirement requirement)
        {
            var pathSegments = httpContextAccessor.HttpContext.Request.Path.Value.Split('/');
            var requestedId = pathSegments[pathSegments.Length - 1];
                
            var loggedUserId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            if (requestedId == loggedUserId)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
