using BookStoreB.BL.Interfaces;
using BookStoreB.DL.Interfaces;
using BookStoreB.Models.DTO;

namespace BookStoreB.BL.Services
{
    internal class BookeService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IbookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }

        public async Task AddBook(Book book)
        {
            if (book == null || book.Authors == null) return;

            foreach (var author in book.Authors)
            {
                if (!Guid.TryParse(author, out _)) return;
            }

            await _bookRepository.AddBook(book);
        }

        public async Task DeleteBook(string id)
        {
            if (!string.IsNullOrEmpty(id)) return;

            await _bookRepository.DeleteBook(id);
        }

        public async Task<Book?> GetBooksById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var bookId))
            {
                return null;
            }

            return await _bookRepository.GetBooksById(bookId.ToString());
        }

        public async Task AddAuthor(string bookId, Author author)
        {
            if (string.IsNullOrEmpty(bookId) || author == null) return;

            if (!Guid.TryParse(bookId, out _)) return;

            var book = await _bookRepository.GetBooksById(bookId);

            if (book == null) return;

            if (book.Authors == null)
            {
                book.Authors = new List<string>();
            }

            if (author.Id == null || string.IsNullOrEmpty(author.Id) || Guid.TryParse(author.Id, out _) == false) return;

            var existingAuthor = await _authorRepository.GetById(author.Id);

            if (existingAuthor != null) return;

           book.Author.Add(author.Id);
        }
    }
}
