using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers.Models.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreContext _context;

        public AuthorService(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<AuthorResponse>> GetListAsync()
        {
            var authors = await this._context.Authors
                .Select(author => new AuthorResponse() { Id = author.Id, FirstName = author.FirstName, LastName = author.LastName })
                .ToListAsync();

            return authors;

        }

        public async Task<AuthorResponse> GetAuthorById(int id)
        {
            var author = await this._context.Authors.FindAsync(id);
            return new AuthorResponse { Id = author.Id, FirstName = author.FirstName, LastName = author.LastName };

        }

        public async Task<ActionResult<List<AuthorResponse>>> FindAuthor([FromQuery] FindAuthorQuery query)
        {
            List<AuthorResponse> authors = await this._context.Authors
           .Where(author => author.FirstName.StartsWith(query.FirstName) || author.LastName.StartsWith(query.LastName)) 
           .Select(author => new AuthorResponse() { Id = author.Id, FirstName = author.FirstName, LastName = author.LastName })
           .ToListAsync();

            return authors;
        }

        
    }
}
