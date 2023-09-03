using EntityLayer.AuthServer.ViewModels;
using EntityLayer.Identity.Entities;

namespace ServiceLayer.AuthServer.Services.Abstract
{
    public interface ITokenAuthenticationService
    {
        Task<TokenVM> CreateTokenAsync(AppUser user);
        Task<TokenVM> RefreshTokenAsync(string refreshToken); 
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
