using Microsoft.Extensions.DependencyInjection;
using BookStoreB.BL.Interfaces;
using BookStoreB.BL.Services;

namespace BookStoreB.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection 
            AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IBlBookService, BlBookService>();
            return services;
        }
    }
}
