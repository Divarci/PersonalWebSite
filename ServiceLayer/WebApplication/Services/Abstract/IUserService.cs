using EntityLayer.WebApplication.ViewModels.UserVM;
using System.Security.Principal;

namespace ServiceLayer.WebApplication.Services.Abstract
{
    public interface IUserService
    {
        Task<List<ClaimListVM>> ClaimList(IPrincipal user);
    }
}
