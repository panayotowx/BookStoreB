
using BookStoreB.Models.DTO;

namespace BookStoreB.DL.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();

        Task AddBook(Book book);

        Task DeleteBook(string id);

        Task<Book?> GetBooksById(string id);
    }
}
