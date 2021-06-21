using System;
using CleanArchitecture.Store.Application.Contracts.Infrastructure;
using CleanArchitecture.Store.Application.Models.ExternalServices;
using CleanArchitecture.Store.Infrastructure.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Store.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache(setupAction =>
            {
                setupAction.ExpirationScanFrequency = TimeSpan.FromMinutes(3);
            });
            services.AddScoped<ICacheService, InMemoryCacheService>();
            services.AddHttpClient<ExternalProductService>();

            return services;
        }
    }
}
