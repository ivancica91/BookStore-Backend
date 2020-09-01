using BookStore.Controllers.Models.Author;
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
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorsController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorResponse>>> GetAuthors()
        {
            return await _context.Authors
                .Select(author => new AuthorResponse() { Id = author.Id, FirstName = author.FirstName, LastName = author.LastName })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponse>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return new AuthorResponse() { Id = author.Id, FirstName = author.FirstName, LastName = author.LastName };
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<AuthorResponse>>> FindAuthor([FromQuery] FindAuthorQuery query)
        {
            List<AuthorResponse> authors = await this._context.Authors
            .Where(author => author.FirstName.StartsWith(query.FirstName))
            .Skip((query.Page - 1) * query.Limit)
            .Take(query.Limit)
            .Select(author => new AuthorResponse() { Id = author.Id, FirstName = author.FirstName, LastName = author.LastName })
            .ToListAsync();

            return this.Ok(authors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, PutAuthor author)
        {
            Author existingAuthor = await this._context.Authors.FindAsync(id);

            if (existingAuthor == null)
            {
                return this.NotFound("Author not found.");
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;

            this._context.Update(existingAuthor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AuthorResponse>> PostAuthor([FromBody] PostAuthor author)
        {
            string[] values = author.FullName.Split(' ');
            string firstName = values[0];
            string lastName = values[1];

            Author newAuthor = new Author() { FirstName = firstName, LastName = lastName };

            _context.Authors.Add(newAuthor);

            await _context.SaveChangesAsync();

            return this.Ok(new AuthorResponse() { Id = newAuthor.Id, FirstName = newAuthor.FirstName, LastName = newAuthor.LastName });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return this.Ok();
        }
    }
}
