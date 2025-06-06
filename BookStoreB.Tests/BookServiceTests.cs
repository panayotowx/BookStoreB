
using BookStoreB.BL.Interfaces;
using BookStoreB.BL.Services;
using BookStoreB.DL.Interfaces;
using BookStoreB.Models.DTO;

namespace BookStoreB.Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<IAuthorRepository> _AuthorRepositoryMock;

        private List<Book> _book = new List<Book>()
        {
            new Book()
            {
                Id = "c3bd1985-792e-4208-af81-4d154bff15c8",
                Title = "Book 1",
                Year = 2021,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Book()
            {
                Id = "4c304bec-f213-47b5-8ae0-9df4a4eb3b99",
                Title = " Book 2",
                Year = 2022,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        private List<Author> _authors = new List<Author>
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

        public BookServiceTests()
        {
            _authorRepositoryMock = new Mock<IAuthorRepository>();
            _bookRepositoryMock = new Mock<IBookRepository>();
        }

        [Fact]
        async Task GetBooksById_ReturnsData()
        {
            // Arrange
            var bookId = _books[0].Id;

            _bookRepositoryMock.Setup(x => x.GetBooksById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _books.FirstOrDefault(x => x.Id == id));

            var bookService = new BookService(_bookRepositoryMock.Object, _AuthorRepositoryMock.Object);

            // Act
            var result = await bookService.GetBooksById(bookId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookId, result.Id);
        }

        [Fact]
        void GetBooksById_BookNotExist()
        {
            // Arrange
            var bookId = "c3bd1985-792e-4208-af81-4d154bff15c9";

            _bookRepositoryMock.Setup(x => x.GetBooksById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _books.FirstOrDefault(x => x.Id == id));

            var bookService = new BookService(_bookRepositoryMock.Object, _AuthorRepositoryMock.Object);

            // Act
            var result = bookService.GetBooksById(bookId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        void GetBooksById_BookWithInvalidGuid()
        {
            // Arrange
            var bookId = "c3bd1985-792e-4208-af81-4d154bff15c9-12";

            _bookRepositoryMock.Setup(x => x.GetBooksById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _books.First(x => x.Id == id));

            var bookService = new BookService(_bookRepositoryMock.Object, _AuthorRepositoryMock.Object);

            // Act
            var result = bookService.GetBooksById(bookId);

            // Assert
            Assert.Null(result);
        }
    }
}
