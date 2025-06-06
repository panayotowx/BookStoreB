using BookStoreB.Models.DTO;

namespace BookStoreB.BL.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();

        Task AddBook(Book book);

        Task DeleteBook(string id);

        Task<Book?> GetBookById(string id);

        Task AddAuthor(string bookId, Author author);
    }
}
