using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ServiceLayer.Identity.Requirements
{
    //same rules applied with other requirement
    public class TrialExpireRequirement : IAuthorizationRequirement
    {

    }

    public class TrialExpireRequirementHandler : AuthorizationHandler<TrialExpireRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TrialExpireRequirement requirement)
        {
            var hasTrialClaim = context.User.HasClaim(x => x.Type == "TrialExpireDate");
            var hasRole = context.User.IsInRole("SuperAdmin");
            if (!hasTrialClaim && !hasRole)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            switch (hasRole)
            {
                case true:
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                case false:
                    {
                        Claim trialExpireDate = context.User.FindFirst("TrialExpireDate")!;
                        if (DateTime.Now > Convert.ToDateTime(trialExpireDate.Value))
                        {
                            context.Fail();
                            return Task.CompletedTask;
                        }

                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
            }



        }
    }
}
