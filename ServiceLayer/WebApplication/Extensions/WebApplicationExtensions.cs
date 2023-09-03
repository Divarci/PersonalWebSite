using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.WebApplication.Filters;

namespace ServiceLayer.WebApplication.Extensions
{
    public static class WebApplicationExtensions
    {
        public static IServiceCollection LoadWebApplicationExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(AboutMeDataCheckFilter));
            services.AddScoped(typeof(HomePageDataCheckFilter));

            return services;
        }
    }
}
