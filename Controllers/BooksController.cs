using libreriaa_JAMB.Data.Models.Services;
using libreriaa_JAMB.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreriaa_JAMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _BooksService;

        public BooksController(BooksService booksService)
        {
            _BooksService = booksService;
        }
        [HttpGet("get-all-books")] 
        public IActionResult GetAllBooks()
        {
            var allbooks = _BooksService.GetAllBks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-id/{id}")] 
        
        public IActionResult GetBookById(int id)
        {
            var book = _BooksService.GetBooksById(id);
            return Ok(book);
        }

        [HttpPost("add-book-with_authors")] 

        public IActionResult AddBook([FromBody] BookVM book)
        {
            _BooksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")] 
        
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updateBook = _BooksService.UpdateBookByID(id, book);
            return Ok(updateBook);
        }

        [HttpDelete ("delete-book_by_id/{id}")] 

        public IActionResult DeleteBookId(int id)
        {
            _BooksService.DeleteBookById(id);
            return Ok();
        }
    }
}
