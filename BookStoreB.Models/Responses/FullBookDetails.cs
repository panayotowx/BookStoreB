using BookStoreB.Models.DTO;

namespace BookStoreB.Models.Responses
{
    public class FullBookDetails
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<Author> Authors { get; set; }
    }
}
