using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase {
        private static List<Book> books = new();

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() => Ok(books);

        [HttpPost]
        public ActionResult<Book> Post(Book book) {
            book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, Book book) {
            var existing = books.FirstOrDefault(b => b.Id == id);
            if (existing == null) return NotFound();

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.ISBN = book.ISBN;
            existing.PublicationDate = book.PublicationDate;
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            books.Remove(book);
            return NoContent();
        }
    }
}
