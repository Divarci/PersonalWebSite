using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ServiceLayer.IdentityCustomization.Requirements
{
    //inheritence from ---  X : IAuthorizationRequirement----
    public class AdminObserveRequirement : IAuthorizationRequirement
    {
    }


    //then create another class with same name added a suffix ....handler, after inheritence a class ----XHandler : AuthorizationHandler<X> ---- which has a variable my first class
    public class AdminObserveRequirementHandler : AuthorizationHandler<AdminObserveRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminObserveRequirement requirement)
        {
            // we check first has user have the claim.
            // we also check has user have an SuperAdmin role.
            var hasAdminObserverClaim = context.User.HasClaim(x => x.Type == "AdminObserveExpireDate");
            var hasRole = context.User.IsInRole("SuperAdmin");

            //if User doesnot have both of them then not allowed to use page
            if (!hasAdminObserverClaim && !hasRole)
            {
                context.Fail();
                return Task.CompletedTask;
            }


            switch (hasRole)
            {
                //if has superadmin role. Full access
                case true:
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                //if has AdminObserveExpireDate claim. we will check expire date
                case false:
                    {
                        Claim AdminObderverExpireDate = context.User.FindFirst("AdminObserveExpireDate")!;
                        if (DateTime.Now > Convert.ToDateTime(AdminObderverExpireDate.Value))
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
