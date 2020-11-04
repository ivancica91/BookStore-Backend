using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers.Models.Author
{
    public interface IAuthorService
    {
        Task<List<AuthorResponse>> GetListAsync();
        Task<AuthorResponse> GetAuthorById(int id);
        Task<ActionResult<List<AuthorResponse>>> FindAuthor([FromQuery] FindAuthorQuery query);
        Task<IActionResult> PutAuthor(int id, PutAuthor author);

    }
}
