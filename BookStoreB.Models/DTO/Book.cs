namespace BookStoreB.Models.DTO
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }
    }
}
