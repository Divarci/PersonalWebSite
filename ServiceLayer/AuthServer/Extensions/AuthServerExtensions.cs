using EntityLayer.AuthServer.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.AuthServer.Helpers.TokenHelpers;

namespace ServiceLayer.AuthServer.Extensions
{
    public static class AuthServerExtensions
    {
        public static IServiceCollection LoadAuthServerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenInfo>(configuration.GetSection("TokenOptions"));

            services.AddScoped<ITokenHelper, TokenHelper>();

            return services;
        }
    }
}
