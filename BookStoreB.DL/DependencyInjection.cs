using Microsoft.Extensions.DependencyInjection;
using BookStoreB.DL.Interfaces;
using BookStoreB.DL.Repositories;
using BookStoreB.DL.Repositories.MongoRepositories;

namespace BookStoreB.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection 
            AddDataDependencies(
                this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IAuthorRepository, AuthorRepository>();

            return services;
        }
    }
}
