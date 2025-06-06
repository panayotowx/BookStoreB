using BookStoreB.DL.DB;
using BookStoreB.DL.Interfaces;
using BookStoreB.Models.DTO;

namespace BookStoreB.DL.Repositories
{
    //internal class BookStaticRepository : IBookRepository
    //{
    //    public List<MBook> GetBook()
    //    {
    //        return StaticData.Book;
    //    }

    //    public void AddBook(Book book)
    //    {
    //        StaticData.Book.Add(book);
    //    }
    //    public void DeleteBooke(int id)
    //    {
    //        if (id <= 0) return;

    //        var book = GetBooksById(id);

    //        if (book != null)
    //        {
    //            StaticData.Book.Remove(book);
    //        }
    //    }
    //    public Book? GetBooksById(int id)
    //    {
    //        if (id <= 0) return null;

    //        return StaticData.Books
    //            .FirstOrDefault(x => x.Id == id);
    //    }
    //}
}
