using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using BookStoreB.BL.Interfaces;
using BookStoreB.Models.DTO;
using BookStoreB.Models.Requests;

namespace BookStoreB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ILogger<BooksController> _logger;

        public BooksController(
            IMovieService bookService,
            IMapper mapper,
            ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetMovies();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest();

            var result =
                _bookService.GetbookById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(
            [FromBody]AddbookRequest BookRequest)
        {
            if (BookRequest == null) return BadRequest();

            var book = _mapper.Map<Book>(BookRequest);

            await _bookService.AddMovie(book);

            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest($"Wrong id:{id}");

            _bookService.DeleteMovie(id);

            return Ok();
        }
    }
}
