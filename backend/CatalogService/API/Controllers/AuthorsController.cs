using CatalogService.API.Contracts;
using CatalogService.Core.Abstractions;
using CatalogService.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/Authors/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorsResponse>>> GetAuthors()
        {
            var books = await _authorsService.GetAllAuthors();

            var response = books.Select(b => new AuthorsResponse(b.AuthorId, b.Name, b.Surename, new List<Guid>(b.BooksId)));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewAuthor([FromBody] AuthorsRequest authorsRequest)
        {
            var author = Author.Create(
                Guid.NewGuid(),
                authorsRequest.Name,
                authorsRequest.Surename,
                new List<Guid>(authorsRequest.BooksId));

            var authorId = await _authorsService.CreateAuthor(author);

            return Ok(authorId);
        }

        [HttpPut("{authorId:guid}")]
        public async Task<ActionResult<Guid>> UpdateAuthor(Guid authorId, [FromBody] AuthorsRequest authorsRequest)
        {
            var author = await _authorsService.UpdateAuthor(
                authorId,
                authorsRequest.Name,
                authorsRequest.Surename,
                new List<Guid>(authorsRequest.BooksId));

            return Ok(author);
        }

        [HttpDelete("{authorId:guid}")]
        public async Task<ActionResult<Guid>> DeleteAuthor(Guid authorId)
        {
            return Ok(await _authorsService.DeleteAuthor(authorId));
        }
    }
}