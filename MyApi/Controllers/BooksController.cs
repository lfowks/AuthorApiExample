using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;
using MyApi.RequestObjects;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyApiContext _context;

        public BooksController(MyApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookVm bookRequest)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'MyApiContext.Book'  is null.");
            }

            Book newBook = new Book();
            newBook.Name = bookRequest.Name;
            newBook.AuthorId = bookRequest.AuthorId;

            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostBook", new { id = newBook.Id });
        }
    }
}
