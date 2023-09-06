using EntityLayer.AuthServer.Entities;
using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.AuthServer.Services.Abstract;
using System.Net.Http.Headers;

namespace ServiceLayer.BlogApiClient.Filters
{
    public class RequestToApi : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenAuthenticationService _tokenService;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private const string TokenKey = "Token";

        public RequestToApi(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, ITokenAuthenticationService tokenService, HttpClient httpClient, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _tokenService = tokenService;
            _httpClient = httpClient;
            _cache = cache;                        
           
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = await _userManager.FindByNameAsync(context.HttpContext.User.Identity!.Name);
            if (!_cache.TryGetValue(TokenKey, out _))
            {
                _cache.Set(TokenKey, await _unitOfWork.GetGenericRepository<AccessToken>().Where(x => x.UserId == user.Id).SingleAsync());
            }
            
            var token = _cache.Get<AccessToken>(TokenKey);

            if (token.ExpireDate < DateTime.Now)
            {
                var newToken = await _tokenService.CreateTokenAsync(user);
                _cache.Set(TokenKey, await _unitOfWork.GetGenericRepository<AccessToken>().Where(x => x.UserId == user.Id).SingleAsync());

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.AccessToken);
                context.HttpContext.Items["Token"] = _httpClient;


                await next.Invoke();
                return;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Code);
            context.HttpContext.Items["Token"] = _httpClient;

            await next.Invoke();
            return;
        }
    }
}
