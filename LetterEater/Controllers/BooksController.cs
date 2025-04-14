using LetterEater.Application.Services;
using LetterEater.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LetterEater.Controllers
{
    [ApiController]
    [Route("api/books/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService bookService)
        {
            _booksService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetAllBooks();

            var response = books.Select(b => new BooksResponse(b.BookId, b.Title, b.Genre, b.Description, b.Price, b.CountPages, b.Series, b.ISBN, b.Quantity, b.AuthorId, b.PublishingHouseId));

            return Ok(response);
        }
    }
}
