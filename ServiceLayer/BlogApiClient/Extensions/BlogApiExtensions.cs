using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.BlogApiClient.Services;

namespace ServiceLayer.BlogApiClient.Extensions
{
    public static class BlogApiExtensions
    {
        public static IServiceCollection LoadBlogApiExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ArticleServiceApi>();
            services.AddScoped<CategoryServiceApi>();


            var baseUrl = config["BaseUrl"];

            services.AddHttpClient<ArticleServiceApi>(opt =>
            {
                opt.BaseAddress = new Uri(baseUrl);
            });
            services.AddHttpClient<CategoryServiceApi>(opt =>
            {
                opt.BaseAddress = new Uri(baseUrl);
            });


            return services;
        }
    }
}
