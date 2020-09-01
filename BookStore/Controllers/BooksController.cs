using BookStore.Controllers.Models;
using BookStore.Controllers.Models.Book;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooks()
        {
            return await _context.Books
               .Select(book => new BookResponse()
               {
                   Id = book.Id,
                   Title = book.Title,
                   Author = new BookAuthor { Id = book.AuthorId, FullName = $"{book.Author.FirstName} {book.Author.LastName}" },
                   ImageSrc = book.ImageSrc,
                   Price = book.Price,
                   Condition = book.Condition
               })
               .ToListAsync();
        }

        // GET: api/Books/FindBooksWithAuthor?authorName=Tom
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> FindBooksWithAuthor(string authorName)
        {
            List<BookResponse> books =
                await this._context.Books
                    .Where(book => book.Author.FirstName.StartsWith(authorName))
                    .Select(book => new BookResponse()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = new BookAuthor() { Id = book.AuthorId, FullName = $"{book.Author.FirstName} {book.Author.LastName}" }
                    })
                    .Skip(0)
                    .Take(10)
                    .ToListAsync();

            return books;
        }


        // GET: api/Books/FindBooksWithTitle?bookTitle=
        [HttpGet("[action]")]
        public async Task<IActionResult> FindBooksWithTitle(string bookTitle)
        {
            var books =
                  await this._context.Books
                      .Where(book => book.Title.Contains(bookTitle))
                      .Select(book => new BookResponse()
                      {
                          Id = book.Id,
                          Title = book.Title,
                          ImageSrc = book.ImageSrc,
                          Price = book.Price,
                          Description = book.Description,
                          Author = new BookAuthor()
                          {
                              Id = book.AuthorId,
                              FullName = $"{book.Author.FirstName} {book.Author.LastName}"
                          },
                      })
                      .ToListAsync();

            return Ok(books);
        }


        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetBookById(int id)
        {
            var book = await this._context.Books
                .Where(book => book.Id == id)
                .Include(a => a.Author)
                .SingleOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            var bookResponse = new BookResponse()
            {
                Id = book.Id,
                Title = book.Title,
                ImageSrc = book.ImageSrc,
                Price = book.Price,
                Description = book.Description,
                Author = new BookAuthor()
                {
                    Id = book.AuthorId,
                    FullName = $"{book.Author.FirstName} {book.Author.LastName}"
                }
            };

            return this.Ok(bookResponse);
        }


        //------------------- Working Put ,, but trying to do a more "complex" one ---------
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBook(int id, PutBook book)
        //{
        //    Book existingBook = await _context.Books.FindAsync(id);

        //    if (existingBook == null)
        //    {
        //        return NotFound("Book is not found.");
        //    }

        //    existingBook.Title = book.Title;
        //    existingBook.AuthorId = book.AuthorId;
        //    existingBook.Condition = book.Condition;
        //    existingBook.Description = book.Description;
        //    existingBook.ImageSrc = book.ImageSrc;
        //    existingBook.Price = book.Price;
        //    //existingBook.Author = ????? jesmo to rekli ne mijenjat nego cemo po authorIdu? authorId obavezno mora bit u postmanu

        //    this._context.Update(existingBook);
        //    await this._context.SaveChangesAsync();
        //    return NoContent();
        //    //radi
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBook(int id, PutBook book)
        {
            var existingBook = await this._context.Books.FindAsync(id);

            Author author = await this._context.Authors.FindAsync(book.Author.FullName);
            if (author == null) // promijenio s putBook na existingBook, probaj se igrat s tim
                // mozda ne trebam ovo jer kad ce autor bit null?
            {
                author = new Author() { FirstName = book.Author.FullName.Split(' ')[0], LastName = book.Author.FullName.Split(' ')[1] };
                this._context.Authors.Add(author);
            }


            if (book.Author.FullName != $"{existingBook.Author.FirstName} {existingBook.Author.LastName}")
            {
                existingBook.Author.FirstName = book.Author.FullName.Split(' ')[0];
                existingBook.Author.LastName = book.Author.FullName.Split(' ')[1];
                existingBook.AuthorId = book.AuthorId;
                //nekkao da stavi id od vec postojeceg autora?!?!?!?!
            }

            existingBook.Title = book.Title;
            existingBook.Condition = book.Condition;
            existingBook.Description = book.Description;
            existingBook.ImageSrc = book.ImageSrc;
            existingBook.Price = book.Price;

            this._context.Update(existingBook);
            await this._context.SaveChangesAsync();
            return Ok(book.Author);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] PostBook postBook)
        {
            Author author = await this._context.Authors.FindAsync(postBook.AuthorId);

            if (author == null)
            {
                author = new Author() { FirstName = postBook.AuthorFullName.Split(' ')[0], LastName = postBook.AuthorFullName.Split(' ')[1] };
                this._context.Authors.Add(author);
            }

            Book book = new Book()
            {
                Title = postBook.Title,
                ImageSrc = postBook.ImageSrc,
                Condition = postBook.Condition,
                Description = postBook.Description,
                Price = postBook.Price,
                Author = author
            };

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return this.Ok(book.Id);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return this.Ok();
        }
    }
}
