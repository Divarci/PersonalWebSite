using EntityLayer.AuthServer.Entities;
using EntityLayer.AuthServer.ViewModels;
using EntityLayer.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.AuthServer.Helpers.TokenHelpers;
using ServiceLayer.AuthServer.Services.Abstract;

namespace ServiceLayer.AuthServer.Services.Concrete
{
    public class TokenAuthenticationService : ITokenAuthenticationService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitofWork;


        public TokenAuthenticationService(ITokenHelper tokenHelper, IUnitOfWork unitofWork)
        {
            _tokenHelper = tokenHelper;
            _unitofWork = unitofWork;
        }

        public async Task<TokenVM> CreateTokenAsync(AppUser user)
        {
            var token =await _tokenHelper.CreateToken(user);

            var userAccessToken = await _unitofWork.GetGenericRepository<AccessToken>().Where(x => x.UserId == user.Id).SingleOrDefaultAsync();
            if (userAccessToken == null)
            {


                await _unitofWork.GetGenericRepository<AccessToken>().AddAsync(new AccessToken { UserId = user.Id, Code = token.AccessToken, ExpireDate = token.AccessTokenExpireDate });
            }
            else
            {
                userAccessToken.Code = token.AccessToken;
                userAccessToken.ExpireDate = token.AccessTokenExpireDate;
            }

            var userRefreshToken = await _unitofWork.GetGenericRepository<RefreshToken>().Where(x=>x.UserId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {


                await _unitofWork.GetGenericRepository<RefreshToken>().AddAsync(new RefreshToken { UserId = user.Id, Code = token.RefreshToken, ExpireDate = token.RefreshTokenExpireDate });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.ExpireDate = token.RefreshTokenExpireDate;
            }

            await _unitofWork.CommitAsync();
            return token;
        }

        public Task<TokenVM> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task RevokeRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
