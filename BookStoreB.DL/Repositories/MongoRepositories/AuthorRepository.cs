using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStoreB.DL.Interfaces;
using BookStoreB.Models.Configurations;
using BookStoreB.Models.DTO;

namespace BookStoreB.DL.Repositories.MongoRepositories
{
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Authorr> _authorCollection;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(ILogger<AuthorRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb configuration is missing");

                throw new ArgumentNullException("MongoDb configuration is missing");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _AuthorCollection = database.GetCollection<Author>($"{nameof(Author)}s");
        }

        public async Task AddAuthor(Author book)
        {
            try
            {
                book.Id = Guid.NewGuid().ToString();

                await _authorCollection.InsertOneAsync(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeleteAuthor(string id)
        {
            await _authorCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Author>> GetAuthors()
        {
            var result =  await _authorCollection.FindAsync(m => true);

            return result.ToList();
        }

        public async Task<Author?> GetById(string id)
        {
           var result =  await _authorCollection.FindAsync(m => m.Id == id);

           return result.FirstOrDefault();
        }

        public async Task<List<Author>> GetAuthors(List<string> authorIds)
        {
            var result = await
                _authorCollection.FindAsync(m => authorIds.Contains(m.Id.ToString()));

            return await result.ToListAsync();
        }
    }
}
