using EntityLayer.AuthServer.ViewModels;
using EntityLayer.Identity.Entities;

namespace ServiceLayer.AuthServer.Helpers.TokenHelpers
{
    public interface ITokenHelper
    {
        Task<TokenVM> CreateToken(AppUser user);
    }
}
