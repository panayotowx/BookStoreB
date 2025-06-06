using BookStoreB.Models.Responses;

namespace BookStoreB.BL.Interfaces
{
    public interface IBlBookService
    {
        Task<List<FullBookDetails>> GetAllBookDetails();
    }
}
