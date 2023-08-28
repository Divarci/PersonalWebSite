using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Identity.Services.Abstract
{
    public interface IAdminAuthenticationService
    {
        //signatures for methods
        Task<IEnumerable<UserVM>> GetUserListWithRoles();
        Task TrialActivateAsync(string name);
        Task ObserveActivateAsync(string name);
    }
}
