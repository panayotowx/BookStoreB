using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using BookStoreB.BL.Interfaces;
using BookStoreB.Models.DTO;
using BookStoreB.Models.Requests;

namespace BookStoreB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksBlController : ControllerBase
    {
        private readonly IBlBookService _bookService;
        private readonly ILogger<MoviesController> _logger;

        public BooksBlController(
            IBlBookService bookService,
            ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =  await _bookService.GetAllMovieDetails();

            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

    public class TestRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
