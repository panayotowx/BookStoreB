using BookStoreBStoreB.BackgroundServices;
using BookStoreB.Models.Configurations;

namespace BookeStoreB.ServiceExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfigurations(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbConfiguration>(config.GetSection(nameof(MongoDbConfiguration)));

            return services;
        }

        public static IServiceCollection AddBackgroundServices(
            this IServiceCollection services)
        {
            services.AddHostedService<TestBackgroundService>();
            //services.AddHostedService<TestHostedService>();

            return services;
        }
    }
}
