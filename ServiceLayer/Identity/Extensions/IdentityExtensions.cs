using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Context;
using ServiceLayer.Identity.Customization.ErrorDescriber;
using ServiceLayer.Identity.Customization.Validators;
using ServiceLayer.Identity.Helpers.EmailHelper;
using ServiceLayer.Identity.Requirements;

namespace ServiceLayer.Identity.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection LoadIdentityExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            //DI for Helpers
            services.AddScoped<IEmailHelper, EmailHelper>();

            //Identity DI and options
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                //options for appuser properties
                opt.Password.RequiredLength = 8;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddPasswordValidator<CustomPasswordValidator>() // accessed to password validations
                .AddUserValidator<CustomUserValidator>()// accessed to user validations
                .AddErrorDescriber<CustomIdentityErrorDescriber>()// accessed to error describer
                .AddDefaultTokenProviders();


            //cookies
            services.ConfigureApplicationCookie(opt =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "HasanDivarci";
                opt.LoginPath = new PathString("/Authentication/SignIn");
                opt.LogoutPath = new PathString("/Authentication/LogOut");
                opt.AccessDeniedPath = new PathString("/Authentication/AccessDenied");
                opt.Cookie = cookieBuilder;
                opt.ExpireTimeSpan = TimeSpan.FromDays(30);
                opt.SlidingExpiration = false; // everytime user logged in expireTimeSpan starts fresh

            });


            //Token Life (we used it for password reset)
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromHours(1);
            });


            //Email Settings Mapping
            services.Configure<EmailOptionsVM>(configuration.GetSection("EmailSettings"));


            //Securty Stamp Setings
            services.Configure<SecurityStampValidatorOptions>(opt =>
            {
                opt.ValidationInterval = TimeSpan.FromMinutes(30);
            });

            //DI for Requirements
            services.AddScoped<IAuthorizationHandler, TrialExpireRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, AdminObserveRequirementHandler>();

            //Policy options
            services.AddAuthorization(options =>
            {
                options.AddPolicy("TrialPolicy", policy =>
                {
                    policy.AddRequirements(new TrialExpireRequirement());

                });
                options.AddPolicy("AdminObserverPolicy", policy =>
                {
                    policy.AddRequirements(new AdminObserveRequirement());

                });
            });

            return services;
        }
    }
}
