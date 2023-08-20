using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Context;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.Repository.Generic.Concrete;
using RepositoryLayer.UnitOfWorks.Abstract;
using RepositoryLayer.UnitOfWorks.Concrete;

namespace RepositoryLayer.Extensions
{
    public static class RepositoryLayerExtensions
    {
        public static IServiceCollection LoadRepositoryLayerExtensions(this IServiceCollection services, IConfiguration config)
        {
            //connection added
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("SqlConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //DI for GenericRepository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            
            return services;
        }

    }
}
