using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace EMSA.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, string connectionString,
            bool sensitiveDataLogging, bool detailError)
        {
            return services
                .AddTenantContext(connectionString, sensitiveDataLogging, detailError)
                .AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();
        }

        private static IServiceCollection AddTenantContext(this IServiceCollection services, string connectionString,
            bool sensitiveDataLogging, bool detailError)
        {
            return services.AddDbContextFactory<TenantDbContext>(builder =>
            {
#if DEBUG
                sensitiveDataLogging = true;
                detailError = true;
#endif
                builder.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging(sensitiveDataLogging)
                    .EnableDetailedErrors(detailError)
#if DEBUG
                    .LogTo(s => Debug.WriteLine(s));
#endif
            });
        }
    }
}