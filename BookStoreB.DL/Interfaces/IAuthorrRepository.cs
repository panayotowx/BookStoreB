using BookStoreB.Models.DTO;

namespace BookStoreB.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author?> GetById(string id);

        Task<List<Author>> GetAuthors(List<string> authorIds);
    }
}
