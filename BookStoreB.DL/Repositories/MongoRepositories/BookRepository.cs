using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStoreB.DL.Interfaces;
using BookStoreB.Models.Configurations;
using BookStoreB.Models.DTO;

namespace BookStoreB.DL.Repositories.MongoRepositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Movie> _booksCollection;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(ILogger<BookRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb configuration is missing");

                throw new ArgumentNullException("MongoDb configuration is missing");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _booksCollection = database.GetCollection<Book>($"{nameof(Book)}s");
        }

        public async Task AddBook(Book book)
        {
            try
            {
                book.Id = Guid.NewGuid().ToString();

                await _bookCollection.InsertOneAsync(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeleteBook(string id)
        {
            await _booksCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Book>> GetBook()
        {
            var result =  await _booksCollection.FindAsync(m => true);

            return result.ToList();
        }

        public async Task<Book?> GetBookById(string id)
        {
           var result =  await _booksCollection.FindAsync(m => m.Id == id);

           return result.FirstOrDefault();
        }
    }
}
