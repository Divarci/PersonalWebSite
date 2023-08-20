using EntityLayer.WebApplication.ViewModels.UserVM;
using System.Security.Principal;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IUserService
    {
        Task<List<ClaimListVM>> ClaimList(IPrincipal user);
    }
}
