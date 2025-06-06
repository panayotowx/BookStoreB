using Moq;
using BookStoreB.BL.Interfaces;
using BookStoreB.BL.Services;
using BookStoreB.DL.Interfaces;
using BookStoreB.Models.DTO;

namespace BookStoreB.Tests
{
    public class BlBookServiceUnitTest
    {
        private readonly Mock<IBookService> _bookServiceMock;
        private readonly Mock<IAuthorRepository> _authorRepositoryMock;

        private List<Book> _book = new List<Book>()
        {
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book 1",
                Year = 2021,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book 2",
                Year = 2022,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        private List<Authors> _authorss = new List<Author>
        {
            new Author()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Author 1"
            },
            new Author()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Author 2"
            },
            new Author()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Author 3"
            },
        };

        public BlBookeServiceUnitTest()
        {
            _bookServiceMock = new Mock<IBookService>();
            _authorrRepositoryMock = new Mock<IAuthorRepository>();
        }

        [Fact]
        public async Task GetAllBookDetails_ReturnsData()
        {
            //setup
            var expectedCount = 2;

            _bookServiceMock
                .Setup(x => x.GetBook())
                .ReturnsAsync(_book);

            _authorRepositoryMock
                .Setup(repo =>
                    repo.GetById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _authors.FirstOrDefault(x => x.Id == id));

            //inject
            var blBookService = new BlBookService(
                _bookServiceMock.Object,
                _authorRepositoryMock.Object);

            //act
            var result =
                await blBookService.GetAllBookDetails();

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }
    }
}