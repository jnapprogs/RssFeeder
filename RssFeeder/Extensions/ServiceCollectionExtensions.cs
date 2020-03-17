using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RssFeeder.Data;
using RssFeeder.Models;
using RssFeeder.Profiles;
using RssFeeder.Repositories;
using RssFeeder.Services;
using RssFeeder.Utils;

namespace RssFeeder.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterDatabaseDependency(services, configuration);
            RegisterDomainDependencies(services);
            RegisterAutoMapper(services);
            RegisterFrameworkDependencies(services);
        }

        private static void RegisterDatabaseDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }

        private static void RegisterFrameworkDependencies(IServiceCollection services)
        {
            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddRazorPages();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelToResourceProfile), typeof(ResourceToModelProfile));
        }

        private static void RegisterDomainDependencies(IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IRssLinkRepository, RssLinkRepository>();
            services.AddScoped<IRssLinkService, RssLinkService>();
            services.AddScoped<IRssParser, RssFeedParser>();
        }
    }
}
