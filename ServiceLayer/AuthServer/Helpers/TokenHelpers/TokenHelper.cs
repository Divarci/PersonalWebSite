using EntityLayer.AuthServer.ViewModels;
using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.AuthServer.Helpers.SignHelpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ServiceLayer.AuthServer.Helpers.TokenHelpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenInfo _tokenInfo;
        private readonly UserManager<AppUser> _userManager;

        public TokenHelper(IOptions<TokenInfo> tokenInfo, UserManager<AppUser> userManager)
        {
            _tokenInfo = tokenInfo.Value;
            _userManager = userManager;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        private async Task<IEnumerable<Claim>> GetClaims(AppUser user, List<string> audiences)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var userList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

            };

            userList.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return userList;
        }

        public async Task<TokenVM> CreateToken(AppUser user)
        {
            var accessTokenExpireDate = DateTime.Now.AddMinutes(_tokenInfo.AccessTokenExpireDate);
            var refreshTokenExpireDate = DateTime.Now.AddMinutes(_tokenInfo.RefreshTokenExpiredate);
            var securityKey = SignHelper.GetSymmetricSecurityKey(_tokenInfo.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenInfo.Issuer,
                expires: accessTokenExpireDate,
                notBefore: DateTime.Now,
                claims:await GetClaims(user, _tokenInfo.Audience),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            var tokenDto = new TokenVM
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpireDate = accessTokenExpireDate,
                RefreshTokenExpireDate = refreshTokenExpireDate

            };
            return tokenDto;
        }
    }
}
