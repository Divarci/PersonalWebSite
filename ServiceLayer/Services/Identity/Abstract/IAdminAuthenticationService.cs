using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Services.Identity.Abstract
{
    public interface IAdminAuthenticationService
    {
        //signatures for methods
        Task<IEnumerable<UserVM>> GetUserListWithRoles();
        Task TrialActivateAsync(string name);
        Task ObserveActivateAsync(string name);
    }
}
