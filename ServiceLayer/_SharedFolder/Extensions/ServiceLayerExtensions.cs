﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using Serilog;
using ServiceLayer._SharedFolder.Helpers.ImageHelper;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.BlogApiClient.Extensions;
using ServiceLayer.Identity.Extensions;
using ServiceLayer.Identity.Helpers.EmailHelper;
using ServiceLayer.WebApplication.Filters;
using ServiceLayer.WebApplication.FluentValidations.AboutMeValidation;
using System.Reflection;

namespace ServiceLayer._SharedFolder.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            //Identity Extension Called
            services.LoadIdentityExtensions(configuration);
            services.LoadBlogApiExtensions(configuration);

            //DI for Services
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"));
            foreach (var type in types)
            {
                var serviceType = type.GetInterfaces().FirstOrDefault(i => i.Name == $"I{type.Name}");
                if (serviceType != null)
                {
                    services.AddScoped(serviceType, type);
                }
            }

            //DI for Filters
            services.AddScoped(typeof(GenericNotFoundFilter<>));
            services.AddScoped(typeof(AboutMeDataCheckFilter));
            services.AddScoped(typeof(HomePageDataCheckFilter));

            //DI for Helpers
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IGenericMessages, GenericMessages>();
            services.AddScoped<IMessageMessages, MessageMessages>();
            services.AddScoped<IResumeMessages, ResumeMessages>();
            services.AddScoped<IIdentityMessages, IdentityMessages>();
            services.AddScoped<IEmailHelper, EmailHelper>();

            //Add fluent validations ad options
            services.AddFluentValidationAutoValidation(opt =>
            {
                opt.DisableDataAnnotationsValidation = true;
            });
            services.AddValidatorsFromAssemblyContaining<AboutMeAddValidation>();


            //add automapper and seeks asemblies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //DI for Toasty Notifications
            services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.BottomCenter
            }); ;

            //Logger settings
            Log.Logger = new LoggerConfiguration().WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error).CreateLogger();

            services.AddLogging(builder => builder.AddSerilog(dispose: true));

            return services;
        }
    }
}