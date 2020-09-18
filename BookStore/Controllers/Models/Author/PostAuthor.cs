using FluentValidation;

namespace BookStore.Controllers.Models.Author
{
    public class PostAuthor
    {
        public string FullName { get; set; }
    }

    public class PostAuthorValidator : AbstractValidator<PostAuthor>
    {
        public PostAuthorValidator()
        {
            RuleFor(a => a.FullName).NotEmpty();
            
        }
    }
}
