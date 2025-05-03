using CatalogService.API.Contracts;
using CatalogService.Core.Abstractions;
using CatalogService.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/Books/[controller]")]
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

            var response = books.Select(
                b => new BooksResponse(
                b.BookId,
                b.Title,
                b.AuthorName,
                b.PublicationYear,
                b.Genre,
                b.Description,
                b.Price,
                b.CountPages,
                b.PublishingHouseName,
                b.Series,
                b.ISBN,
                b.Quantity,
                b.AuthorId,
                b.PublishingHouseId));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewBook([FromBody] BooksRequest booksRequest)
        {
            var book = Book.Create(
                Guid.NewGuid(),
                booksRequest.Title,
                booksRequest.AuthorName,
                booksRequest.PublicationYear,
                booksRequest.Genre,
                booksRequest.Description,
                booksRequest.Price,
                booksRequest.CountPages,
                booksRequest.Series,
                booksRequest.PublishingHouseName,
                booksRequest.ISBN,
                booksRequest.Quantity,
                booksRequest.AuthorId,
                booksRequest.PublishingHouseId);

            var bookId = await _booksService.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut("{bookId:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid bookId, [FromBody] BooksRequest booksRequest)
        {
            var book = await _booksService.UpdateBook(
                bookId,
                booksRequest.Title,
                booksRequest.AuthorName,
                booksRequest.PublicationYear,
                booksRequest.Genre,
                booksRequest.Description,
                booksRequest.Price,
                booksRequest.CountPages,
                booksRequest.Series,
                booksRequest.PublishingHouseName,
                booksRequest.ISBN,
                booksRequest.Quantity,
                booksRequest.AuthorId,
                booksRequest.PublishingHouseId);

            return Ok(book);
        }

        [HttpDelete("{bookId:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid bookId)
        {
            return Ok(await _booksService.DeleteBook(bookId));
        }
    }
}