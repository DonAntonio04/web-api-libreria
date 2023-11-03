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

        [HttpPost("add-book")] 

        public IActionResult AddBook([FromBody] BookVM book)
        {
            _BooksService.AddBook(book);
            return Ok();
        }
    }
}
