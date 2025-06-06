using BookStoreB.BL.Interfaces;
using BookStoreB.DL.Interfaces;
using BookStoreB.Models.DTO;
using BookStoreB.Models.Responses;

namespace BookStoreB.BL.Services
{
    internal class BlBookService : IBlBookService
    {
        private readonly IBookService _bookService;
        private readonly IAAuthorRepository _authorRepository;

        public BlBookService(IBookService bookService, IAuthorRepository authorRepository)
        {
            _bookService = bookService;
            _authorrRepository = authorRepository;
        }

        public async Task<List<FullBookDetails>> GetAllBookDetails()
        {
            var result = new List<FullBookDetails>();

            var book = await _bookService.GetBook();

            foreach (var book in book)
            {
                var bookDetails = new FullBookDetails();
                bookDetails.Title = book.Title;
                bookDetails.Year = book.Year;
                bookDetails.Id = book.Id;
                
                var authors = await
                    _authorRepository.GetAuthorss(book.Authors);

                bookDetails.Authors = authors;
                result.Add(bookDetails);
            }
            return result;
        }
    }
}
