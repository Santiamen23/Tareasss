using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TareaTecWeb.Models.Dtos;
using TareaTecWeb.Services;

namespace TareaTecWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _books;
        public BookController(IBookService books)
        {
            _books = books;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _books.getBooks());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _books.getBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            var book = await _books.createBook(dto);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookDto dto)
        {
            var book = await _books.updateBook(id, dto);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
